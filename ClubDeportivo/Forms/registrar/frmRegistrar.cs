
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

                //refrescar grillas (puede cambiar Estado/Fecha por el cobro)
                CargarListados();
            }
            else // No Socio
            {
                MessageBox.Show($"Se registró el NO SOCIO N° {codigoDevuelto}.",
                    "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                limpiar();

                //refrescar grillas
                CargarListados();
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

       // Botón de acción: EDITAR
        private void AgregarColumnaAccionEditar(DataGridView dgv)
        {
            if (!dgv.Columns.Contains("AccionEditar"))
            {
                var btn = new DataGridViewButtonColumn
                {
                    Name = "AccionEditar",
                    HeaderText = "Acciones",
                    Text = "Editar…",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    MinimumWidth = 80
                };
                dgv.Columns.Add(btn);
            }
        }


        // Enlaza eventos necesarios del grid
        private void ConfigurarEventosGrid(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;

            dgv.DataError += Dgv_DataError;
            dgv.DataBindingComplete += Dgv_DataBindingComplete;
            dgv.CellContentClick += Dgv_CellContentClick; //  abre editor
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

            // 1) TODO solo lectura
            foreach (DataGridViewColumn c in dgv.Columns) c.ReadOnly = true;

            // 2) Ocultar IDs
            foreach (var n in new[] { "codPers","codPersona","CodPersona","ID","Id","Código","Codigo",
                              "codSoc","codSocio","codSoci",
                              "codNoSocio","CodNoSocio","idNoSocio","IdNoSocio" })
                if (dgv.Columns.Contains(n)) dgv.Columns[n].Visible = false;

            // 3) Asegurar botón "Editar…"
            AgregarColumnaAccionEditar(dgv);

            // 4) Renombrar headers
            if (dgv.Columns.Contains("nombre")) dgv.Columns["nombre"].HeaderText = "Nombre";
            if (dgv.Columns.Contains("apellido")) dgv.Columns["apellido"].HeaderText = "Apellido";
            if (dgv.Columns.Contains("documento")) dgv.Columns["documento"].HeaderText = "Doc";
            if (dgv.Columns.Contains("email")) dgv.Columns["email"].HeaderText = "E-mail";
            if (dgv.Columns.Contains("fechaVencimiento")) dgv.Columns["fechaVencimiento"].HeaderText = "Fecha Venc.";
            if (dgv.Columns.Contains("tipoDocumento")) dgv.Columns["tipoDocumento"].HeaderText = "Tipo";
            if (dgv.Columns.Contains("tel")) dgv.Columns["tel"].HeaderText = "Teléfono";
            if (dgv.Columns.Contains("fichaMedica")) dgv.Columns["fichaMedica"].HeaderText = "Apto físico";
            if (dgv.Columns.Contains("EstadoSocio")) dgv.Columns["EstadoSocio"].Visible = false; // lo ocultamos

            // 5) Orden Nombre
            SetOrdenSeguro(dgv, "nombre", "apellido", "documento", "email", "tel", "tipoDocumento", "fichaMedica", "fechaVencimiento");

            // 6) “Acciones” al final
            if (dgv.Columns.Contains("AccionEditar"))
                dgv.Columns["AccionEditar"].DisplayIndex = Math.Max(0, dgv.Columns.Count - 1);
        }
               

        // Click en “Editar…”
        private void Dgv_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender!;
            if (e.RowIndex < 0) return;
            if (grid.Columns[e.ColumnIndex].Name != "AccionEditar") return;

            // Tomar ID de la fila
            string idCol = grid.Columns.Contains("codPersona") ? "codPersona" :
                           grid.Columns.Contains("CodPersona") ? "CodPersona" :
                           grid.Columns.Contains("ID") ? "ID" : "Id";
            int id = Convert.ToInt32(grid.Rows[e.RowIndex].Cells[idCol].Value);

            string tipo = ReferenceEquals(grid, dgvSocios) ? "Socio" : "NoSocio";

            using var fm = new Forms.editar_persona.FmEditarPersona(id, tipo);
            if (fm.ShowDialog(this) == DialogResult.OK)
                CargarListados(); // refresca grillas
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
