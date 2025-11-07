using ClubDeportivo.Datos;
using ClubDeportivo.Forms.opciones_pago;
using ClubDeportivo.Utilidades;
using ClubDeportivo.Entidades;
using System.Data;
using System.Text;


namespace ClubDeportivo.Forms.cobrar_cuota
{
    public partial class frmCobrarCuota : Form
    {
        public frmCobrarCuota(int p_codSocio=0)
        {
            InitializeComponent();
            _codSocio = p_codSocio;//Para cargar el socio por defecto luego del registro
        }
        private SocioCardData? _card; //para imprimir el carnet
        private int _codSocio; //necesito que codSocio sea accesible dentro de los distintos métodos de la clase
        private string nombreApellido = ""; //para mostrar juntos en un label

        private DataTable dt = new DataTable();
        private bool cargando = false;

        //Función para debbug dataTable:
        private void MostrarDataTableMessageBox(DataTable dt)

        {
            var sb = new StringBuilder();
            foreach (DataColumn col in dt.Columns) sb.Append(col.ColumnName).Append(" | ");
            sb.AppendLine();
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                    sb.Append(row[col]?.ToString()).Append(" | ");
                sb.AppendLine();
            }
            MessageBox.Show(sb.ToString(), "Contenido DataTable");
        }


        private void CargarPersonas(string tipo)
        {
            cargando = true;
            var persona = new Personas();
            dt = persona.Listar_personas(tipo);

            dt.Columns.Add("NombreCompleto", typeof(string), "nombre + ' ' + apellido");

            cboSocio.DataSource = dt;
            cboSocio.DisplayMember = "NombreCompleto";
            cboSocio.ValueMember = "codSocio";
            cboSocio.SelectedIndex = -1;

            cargando = false;

        }

        private void frmCobrarCuota_Load(object sender, EventArgs e)
        {
            inicializarLabels();
            CargarPersonas("Socio");
            btnImprimirCarnet.Enabled = false;
            if (_codSocio != 0)
            {
                cboSocio.SelectedValue = _codSocio;
            }
        }

        private void inicializarLabels()
        {
            lblIdSocio.Text = "Código de Socio: ";
            lblNombreApellido.Text = "Nombre y apellido: ";
            lblEmail.Text = "Email: ";
            lblTel.Text = "Teléfono: ";
            lblFechaVencimiento.Text = "Vencimiento de la cuota: ";
            lblEstado.Text = "Estado del socio: ";
            lblFechaActual.Text = "Fecha actual: " + DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void cboSocio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando || cboSocio.SelectedIndex == -1) return;

            //DEBUG DATATABLE:
            //MostrarDataTableMessageBox(dt);

            if (cboSocio.SelectedValue is int codSocio)
            {
                DataRow[] filas = dt.Select($"codSocio = {codSocio}");
                if (filas.Length > 0)
                {
                    DataRow fila = filas[0];
                    _codSocio = codSocio;

                    nombreApellido = fila["nombre"].ToString() + " " + fila["apellido"].ToString();
                    inicializarLabels();
                    lblIdSocio.Text += codSocio;

                    lblNombreApellido.Text += $"{fila["nombre"]} {fila["apellido"]}";
                    lblEmail.Text += fila["email"].ToString();
                    lblTel.Text += fila["tel"].ToString();
                    DateTime fechaVenc = Convert.ToDateTime(fila["fechaVencimiento"]);
                    lblFechaVencimiento.Text += fechaVenc.ToString("dd/MM/yyyy");
                    bool estadoSocio = Convert.ToBoolean(fila["estadoSocio"]);
                    lblEstado.Text += estadoSocio ? "Activo" : "Inactivo";
                    if (estadoSocio)
                    {
                        btnImprimirCarnet.Enabled = true;
                    }
                    else
                    {
                        btnImprimirCarnet.Enabled = false;
                    }

                    _card = new SocioCardData
                    {
                        CodSocio = codSocio,
                        NombreApellido = $"{fila["nombre"]} {fila["apellido"]}",
                        Documento = Convert.ToString(fila["documento"]) ?? "",
                        Email = Convert.ToString(fila["email"]) ?? "",
                        Telefono = Convert.ToString(fila["tel"]) ?? "",
                        Vencimiento = fila["fechaVencimiento"] == DBNull.Value
                                ? (DateTime?)null
                                : Convert.ToDateTime(fila["fechaVencimiento"]),
                        Estado = estadoSocio ? "Activo" : "Inactivo"
                    };

                }


            }


        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            frmOpcionesPago frmOP = new frmOpcionesPago(_codSocio, nombreApellido);
            frmOP.ShowDialog();
        }

        private void btnImprimirCarnet_Click(object sender, EventArgs e)
        {
            if (_card is null)
            {
                MessageBox.Show("No hay datos para imprimir el carnet.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var printer = new CredencialPrinter();
            printer.Print(_card, preview: true);
        }
    }
}
