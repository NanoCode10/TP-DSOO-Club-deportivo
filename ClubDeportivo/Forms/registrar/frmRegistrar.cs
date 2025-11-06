using System.Data;
using ClubDeportivo.Datos;
using ClubDeportivo.Entidades;

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

            // Dejar SIN selección en los combos
            if (cboTipoDocumento.Items.Count > 0) cboTipoDocumento.SelectedIndex = -1;
            if (cboTipo.Items.Count > 0) cboTipo.SelectedIndex = -1;
            if (cboAptoFisico.Items.Count > 0) cboAptoFisico.SelectedIndex = -1;

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
            string tipo = cboTipo.Text.Trim();
            string aptoFisico = cboAptoFisico.Text.Trim();

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

            var persona = new E_Persona
            {
                Nombre = nombre,
                Apellido = apellido,
                TipoDocumento = tipoDocumento,
                Documento = documento,
                Email = documento,
                Tel = documento,
                AptoFisico = aptoFisico.Equals("Si", StringComparison.OrdinalIgnoreCase)
            };

            string respuesta = "";

            if (tipo.Equals("Socio", StringComparison.OrdinalIgnoreCase))
            {
                respuesta = new Datos.Personas().Nueva_persona(persona, "Socio");
                bool esNro = int.TryParse(respuesta, out int codSocio);
                if (esNro && codSocio > 0)
                {
                    MessageBox.Show("Se guardó con éxito el socio con el código Nro " + codSocio,
                        "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 👉 Crear la cuota inicial
                    var cuota = new E_Cuota
                    {
                        IdSocio = codSocio,
                        FechaVencimiento = DateTime.Now,
                        Monto = 10000, // por ejemplo, el monto base de la cuota
                        FechaPago = null
                    };

                    string rtaCuota = new Datos.Cuotas().RegistrarCuota(cuota);

                    MessageBox.Show($"Se registró el socio N° {codSocio} y su cuota inicial.\nResultado: {rtaCuota}",
            "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    limpiar();
                }
            }
            else if(tipo.Equals("No Socio", StringComparison.OrdinalIgnoreCase))
            {
                respuesta = new Datos.Personas().Nueva_persona(persona, "NoSocio");
            }
            else
            {
                MessageBox.Show("Debe seleccionar un tipo válido (Socio / NoSocio).",
                    "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool esNumero = int.TryParse(respuesta, out int codigo);
                if (esNumero)
                {
                    if (codigo == 0)
                    {
                        MessageBox.Show("La persona ya existe, corroborar los datos",
                            "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Se guardó con éxito el socio con el código Nro " + respuesta,
                            "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        limpiar();
                        //CargarSocios(); // ← refresca el grid
                    }
                }
                else
                {
                    // Si vino un mensaje de error desde la capa de datos:
                    MessageBox.Show("No se pudo registrar el socio. Detalle: " + respuesta,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //CargarSocios(); // ← llena el DataGridView al abrir

        }
    }
}
