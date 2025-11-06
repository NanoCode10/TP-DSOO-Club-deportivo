using ClubDeportivo.Datos;
using ClubDeportivo.Forms.opciones_pago;
using ClubDeportivo.Forms.registrar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using ClubDeportivo.Entidades;


namespace ClubDeportivo.Forms.cobrar_cuota
{
    
    public partial class frmCobrarCuota : Form
    {

        private SocioCardData? _card;
        public frmCobrarCuota()
        {
            InitializeComponent();

        }

        private int _codSocio;
        private string nombreApellido;

        private DataTable dt;
        private bool cargando = false;


        private void MostrarDataTableMessageBox(DataTable dt)

        {
            //Función para debbug dataTable
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
        }

        private void inicializarLabels()
        {
            lblIdSocio.Text = "Código de Socio: ";
            lblNombreApellido.Text = "Nombre y apellido: ";
            lblEmail.Text = "Email: ";
            lblTel.Text = "Teléfono: ";
            lblFechaVencimiento.Text = "Vencimiento de la cuota: ";
            lblEstado.Text = "Estado del socio: ";
        }

       

    private void cboSocio_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cargando || cboSocio.SelectedIndex == -1) return;

        // 1) Obtener el código de socio seleccionado (INICIALIZADO)
        int codSocio = Convert.ToInt32(cboSocio.SelectedValue);


        // 2) Buscar la fila en el DataTable
        DataRow[] filas = dt.Select($"codSocio = {codSocio}");
        if (filas.Length == 0)
        {
            _card = null;
            btnImprimirCarnet.Enabled = false;
            return;
        }

        DataRow fila = filas[0];

        // 3) Refrescar labels 
        inicializarLabels();
        lblIdSocio.Text += codSocio;
        lblNombreApellido.Text += $"{fila["nombre"]} {fila["apellido"]}";
        lblEmail.Text += Convert.ToString(fila["email"]) ?? "";
        lblTel.Text += Convert.ToString(fila["tel"]) ?? "";
        lblFechaVencimiento.Text += (fila["fechaVencimiento"] == DBNull.Value
                                      ? "-"
                                      : Convert.ToDateTime(fila["fechaVencimiento"]).ToString("dd/MM/yyyy"));
        lblEstado.Text += (dt.Columns.Contains("EstadoCuota")
                                      ? Convert.ToString(fila["EstadoCuota"]) ?? ""
                                      : (dt.Columns.Contains("EstadoSocio")
                                            ? (Convert.ToBoolean(fila["EstadoSocio"]) ? "Activo" : "Inactivo")
                                            : "-"));

        // 4) Armar DTO para imprimir 
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
            Estado = dt.Columns.Contains("EstadoCuota")
                                ? (Convert.ToString(fila["EstadoCuota"]) ?? "")
                                : (dt.Columns.Contains("EstadoSocio")
                                    ? (Convert.ToBoolean(fila["EstadoSocio"]) ? "Activo" : "Inactivo")
                                    : "-")
        };

        // 5) Habilitar el botón (POR AHORA)
        btnImprimirCarnet.Enabled = true;
    }


    private void btnPago_Click(object sender, EventArgs e)
        {
            frmOpcionesPago frmOP = new frmOpcionesPago();
            frmOP.ShowDialog();
        }
       
    private void btnImprimirCarnet_Click(object sender, EventArgs e)
        {
            if (_card is null)
            {
                MessageBox.Show("Seleccione un socio primero.", "Imprimir carnet",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var printer = new CredencialPrinter();
            printer.Print(_card, preview: true);
        }

    }
}
