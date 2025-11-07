
using ClubDeportivo.Datos;
using ClubDeportivo.Entidades;
using ClubDeportivo.Forms.cobrar_cuota;
using ClubDeportivo.Forms.opciones_pago;
using System.Data;
using System.Drawing; // arriba del archivo para usar Color

namespace ClubDeportivo.Forms.registrar
{
    public partial class frmRegistrar : Form
    {
        // Repositorio de datos
        private readonly Personas _socios = new();

        public frmRegistrar()
        {
            InitializeComponent();

        }



        private void limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDocumento.Clear();
            txtEmail.Clear();
            txtTel.Clear();

            // Dejar SIN selección en los combos
            if (cboTipoDocumento.Items.Count > 0) cboTipoDocumento.SelectedIndex = -1;
            //if (cboTipo.Items.Count > 0) cboTipo.SelectedIndex = -1;
            //if (cboAptoFisico.Items.Count > 0) cboAptoFisico.SelectedIndex = -1;

            txtNombre.Focus();
        }



        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string documento = txtDocumento.Text.Trim();
            string tipoDocumento = cboTipoDocumento.Text.Trim();
            string email = txtEmail.Text.Trim();
            string tel = txtTel.Text.Trim();
            string tipo = cboTipo.Text.Trim();            // "Socio" | "No Socio"
            string aptoFisico = cboAptoFisico.Text.Trim();

            // Validación
            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(documento) ||
                string.IsNullOrWhiteSpace(tipoDocumento) ||
                string.IsNullOrWhiteSpace(tipo) ||
                string.IsNullOrWhiteSpace(aptoFisico))
            {
                MessageBox.Show("Los campos con * son obligatorios",
                    "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (aptoFisico.Equals("No", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Debe presentar apto físico para el registro",
                    "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool esSocio = tipo.Equals("Socio", StringComparison.OrdinalIgnoreCase);
            bool esNoSocio = tipo.Equals("No Socio", StringComparison.OrdinalIgnoreCase);

            if (!esSocio && !esNoSocio)
            {
                MessageBox.Show("Debe seleccionar un tipo válido (Socio / No Socio).",
                    "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var persona = new E_Persona
            {
                Nombre = nombre,
                Apellido = apellido,
                TipoDocumento = tipoDocumento,
                Documento = documento,
                Email = email,
                Tel = tel,
                AptoFisico = aptoFisico.Equals("Si", StringComparison.OrdinalIgnoreCase)
            };

            // --- Alta en DB ---
            string respuesta = _socios.Nueva_persona(persona, esSocio ? "Socio" : "NoSocio");

            // Manejo unificado de la respuesta del SP
            if (!int.TryParse(respuesta, out int codigoDevuelto))
            {
                MessageBox.Show("No se pudo registrar. Detalle: " + respuesta,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (codigoDevuelto == 0)
            {
                MessageBox.Show("La persona ya existe, corroborar los datos.",
                    "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- ÉXITO ---
            if (esSocio)
            {
                // Registrar cuota inicial
                var cuota = new E_Cuota
                {
                    IdSocio = codigoDevuelto,
                    FechaVencimiento = DateTime.Now.Date,
                    Monto = 10000f,
                    FechaPago = null
                };

                string rtaCuota = new Datos.Cuotas().RegistrarCuota(cuota);

                MessageBox.Show($"Se registró el SOCIO N° {codigoDevuelto} y su cuota inicial.\nResultado cuota: {rtaCuota}",
                    "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                limpiar();

                // Abrir cobrar cuota 
                var frmCC = new frmCobrarCuota(codigoDevuelto);
                frmCC.ShowDialog();
            }
            else // No Socio
            {
                MessageBox.Show($"Se registró el NO SOCIO N° {codigoDevuelto}.",
                    "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                limpiar();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }




        private void frmAgregarPersona_Load(object sender, EventArgs e)
        {
            cboTipo.SelectedIndex = 0;
            cboAptoFisico.SelectedIndex = 0;
            if (cboTipo.Items.Count > 0) cboTipo.SelectedIndex = 0;        // “Socio”
            if (cboAptoFisico.Items.Count > 0) cboAptoFisico.SelectedIndex = 0;  // “Si”
            if (cboTipoDocumento.Items.Count > 0) cboTipoDocumento.SelectedIndex = 0; // “DNI”

            ConfigurarEventosGrid(dgvSocios);
            ConfigurarEventosGrid(dgvNoSocios);
            CargarListados();

        }


        
        //*
        //**  Código relacionado a los grids de Socios / NoSocios
        //*

        #region Grids Socios / NoSocios (edición en línea + eliminar)

        // Helper: toma el primer nombre de columna que exista en el grid
        private static string Col(DataGridView dgv, params string[] opciones)
        {
            foreach (var n in opciones)
                if (dgv.Columns.Contains(n)) return n;
            throw new InvalidOperationException("No se encontraron columnas: " + string.Join(", ", opciones));
        }       

        // Agrega columna botón "Eliminar" 
        private void AgregarColumnaEliminar(DataGridView dgv)
        {
            if (!dgv.Columns.Contains("AccionEliminar"))
            {
                var btn = new DataGridViewButtonColumn
                {
                    Name = "AccionEliminar",
                    HeaderText = "Acciones",
                    Text = "Eliminar",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells, 
                    MinimumWidth = 80,        // opcional: para que no quede muy angosta
                };

               

                dgv.Columns.Add(btn);
            }
        }


        // Enlaza eventos necesarios del grid
        private void ConfigurarEventosGrid(DataGridView dgv)
        {
            dgv.DataError += Dgv_DataError;
            dgv.DataBindingComplete += Dgv_DataBindingComplete;
            dgv.CellDoubleClick += Dgv_CellDoubleClick;
            dgv.CellContentClick += Dgv_CellContentClick;
            dgv.RowValidated += Dgv_RowValidated;
        }

        private void Dgv_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            // Evita crashear si el usuario escribe algo con formato inválido
            e.ThrowException = false;
        }


        private static void SetOrdenSeguro(DataGridView dgv, params string[] order)
        {
            int next = 0;
            foreach (var n in order)
            {
                if (!dgv.Columns.Contains(n)) continue;
                var col = dgv.Columns[n];
                
                if (next >= dgv.Columns.Count) next = dgv.Columns.Count - 1;
                col.DisplayIndex = next;
                next++;
            }
        }
        private void Dgv_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = (DataGridView)sender!;

            // 1) editable 
            foreach (DataGridViewColumn c in dgv.Columns) c.ReadOnly = false;
            foreach (var idName in new[] { "codSoc", "codSocio", "codSoci", "codPers", "codPersona", "CodPersona", "ID", "Id", "Código", "Codigo" })
                if (dgv.Columns.Contains(idName)) dgv.Columns[idName].ReadOnly = true;

            // 2) ocultar IDs
            foreach (var n in new[]
{
            // persona / genéricos
            "codPers","codPersona","CodPersona","ID","Id","Código","Codigo",
            // socios
            "codSoc","codSocio","codSoci",
            // NO socios
            "codNoSocio","CodNoSocio","idNoSocio","IdNoSocio"
})
            {
                if (dgv.Columns.Contains(n))
                    dgv.Columns[n].Visible = false;
            }

            // 3) asegurar botón Eliminar antes de ordenar
            AgregarColumnaEliminar(dgv);

            // 4) renombrar headers 
            if (dgv.Columns.Contains("nombre")) dgv.Columns["nombre"].HeaderText = "Nombre";
            if (dgv.Columns.Contains("apellido")) dgv.Columns["apellido"].HeaderText = "Apellido";
            if (dgv.Columns.Contains("documento")) dgv.Columns["documento"].HeaderText = "Doc";
            if (dgv.Columns.Contains("email")) dgv.Columns["email"].HeaderText = "E-mail";
            if (dgv.Columns.Contains("EstadoSocio")) dgv.Columns["EstadoSocio"].HeaderText = "Estado";
            if (dgv.Columns.Contains("fechaVencimiento")) dgv.Columns["fechaVencimiento"].HeaderText = "Fecha Venc.";
            if (dgv.Columns.Contains("tipoDocumento")) dgv.Columns["tipoDocumento"].HeaderText = "Tipo";
            if (dgv.Columns.Contains("tel")) dgv.Columns["tel"].HeaderText = "Teléfono";
            if (dgv.Columns.Contains("fichaMedica")) dgv.Columns["fichaMedica"].HeaderText = "Apt.físico";

            // 5) ordenar (Nombre primero, etc.)
            SetOrdenSeguro(dgv,
                "Nombre", "Nombre",
                "Apellido", "Apellido",
                "Email", "Email",
                "tel", "Tel", "Teléfono", "Telefono",
                "tipoDoc", "tipoDocumento",
                "Doc",
                "fichaMedica", "AptoFisico", "AptoFis", "Apto"
            );

            // 6) mandar “Acciones” al final (índice válido)
            if (dgv.Columns.Contains("AccionEliminar"))
                dgv.Columns["AccionEliminar"].DisplayIndex = Math.Max(0, dgv.Columns.Count - 1);
        }



        private void Dgv_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var grid = (DataGridView)sender!;
            grid.CurrentCell = grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
            grid.BeginEdit(true); 
        }

        private void Dgv_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender!;
            if (e.RowIndex < 0) return;
            if (grid.Columns[e.ColumnIndex].Name == "AccionEliminar")
                EliminarFilaDeGrid(grid);
        }

        private void Dgv_RowValidated(object? sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender!;
            PersistirFila(grid, e.RowIndex); // guarda cambios al salir de la fila
        }

        // === Guardar cambios de la fila editada (llama SP actualizar_persona) ===
        private void PersistirFila(DataGridView grid, int rowIndex)
        {
            if (rowIndex < 0) return;
            var row = grid.Rows[rowIndex];
            if (row.IsNewRow) return;

            // Columnas  según tabla PERSONA 
            string cId = Col(grid, "codPersona", "CodPersona", "ID", "Id", "Código", "Codigo");
            string cNombre = Col(grid, "nombre", "Nombre");
            string cApellido = Col(grid, "apellido", "Apellido");
            string cTipoDoc = Col(grid, "tipoDocumento", "TipoDocumento", "Tipo documento", "Tipo Doc.");
            string cDocumento = Col(grid, "documento", "Documento");
            string cApto = Col(grid, "fichaMedica", "FichaMedica", "Apto físico", "AptoFisico", "Apto");
            
            string? cEmail = grid.Columns.Contains("email") || grid.Columns.Contains("Email")
                ? Col(grid, "email", "Email") : null;
            string? cTel = grid.Columns.Contains("tel") || grid.Columns.Contains("Tel") || grid.Columns.Contains("Teléfono")
                ? Col(grid, "tel", "Tel", "Teléfono", "Telefono") : null;

            int id = Convert.ToInt32(row.Cells[cId].Value);
            var persona = new E_Persona
            {
                Nombre = Convert.ToString(row.Cells[cNombre].Value) ?? "",
                Apellido = Convert.ToString(row.Cells[cApellido].Value) ?? "",
                TipoDocumento = Convert.ToString(row.Cells[cTipoDoc].Value) ?? "DNI",
                Documento = Convert.ToString(row.Cells[cDocumento].Value) ?? "",
                Email = cEmail is null ? "" : (Convert.ToString(row.Cells[cEmail].Value) ?? ""),
                Tel = cTel is null ? "" : (Convert.ToString(row.Cells[cTel].Value) ?? ""),
                AptoFisico = row.Cells[cApto].Value is bool b
                                ? b
                                : (Convert.ToString(row.Cells[cApto].Value) ?? "").Equals("Si", StringComparison.OrdinalIgnoreCase)
                                  || (Convert.ToString(row.Cells[cApto].Value) ?? "").Equals("Sí", StringComparison.OrdinalIgnoreCase)
                                  || (Convert.ToString(row.Cells[cApto].Value) ?? "").Equals("True", StringComparison.OrdinalIgnoreCase)
            };

            string tipo = ReferenceEquals(grid, dgvSocios) ? "Socio" : "NoSocio";

            int r = _socios.Actualizar_persona(id, persona, tipo); // llama SP

            if (r < 0)
            {
                MessageBox.Show("No se pudo actualizar (error del procedimiento).",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CargarListados(); // rollback visual
            }
        }

        // === Eliminar fila seleccionada (llama SP eliminar_persona) ===
        private void EliminarFilaDeGrid(DataGridView grid)
        {
            if (grid.CurrentRow is null) return;

            string cId = Col(grid, "codPersona", "CodPersona", "ID", "Id", "Código", "Codigo");
            string cNombre = Col(grid, "nombre", "Nombre");
            string cApellido = Col(grid, "apellido", "Apellido");

            int id = Convert.ToInt32(grid.CurrentRow.Cells[cId].Value);
            string nombre = Convert.ToString(grid.CurrentRow.Cells[cNombre].Value) ?? "";
            string apellido = Convert.ToString(grid.CurrentRow.Cells[cApellido].Value) ?? "";

            var ok = MessageBox.Show($"¿Eliminar a {nombre} {apellido}?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ok != DialogResult.Yes) return;

            int r = _socios.Eliminar_persona(id); // llama SP

            if (r == 1)
            {
                CargarListados();
            }
            else if (r == -1451)
            {
                MessageBox.Show("No se puede eliminar: hay registros asociados (cuotas/pagos/etc.).",
                    "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (r == 0)
            {
                MessageBox.Show("No existe el registro o ya fue eliminado.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo eliminar (error del procedimiento).",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarListados()
        {
            try
            {
                dgvSocios.AutoGenerateColumns = true;
                dgvNoSocios.AutoGenerateColumns = true;

                dgvSocios.DataSource = _socios.ListarSocios();    // SP listar_personas_por_tipo('Socio')
                dgvNoSocios.DataSource = _socios.ListarNoSocios();  // SP listar_personas_por_tipo('NoSocio')
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando listados: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        #endregion




    }
}
