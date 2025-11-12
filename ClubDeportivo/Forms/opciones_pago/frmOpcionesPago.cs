using ClubDeportivo.Entidades;
using ClubDeportivo.Forms.cobrar_cuota;
using ClubDeportivo.Forms.menu_home;
using ClubDeportivo.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClubDeportivo.Forms.opciones_pago
{
    public partial class frmOpcionesPago : Form
    {

        private int _codSocio;
        private string _nombreSocio;
        public frmOpcionesPago(int codSocio, string nombreSocio)
        {
            InitializeComponent();
            _codSocio = codSocio;
            _nombreSocio = nombreSocio;

            lblSocio.Text = $"Socio: {_nombreSocio} (Código: {_codSocio})";
        }

        private void frmOpcionesPago_Load(object sender, EventArgs e)
        {
            cboMedioPago.SelectedIndex = 1;
            cboCuotas.Visible = false;
        }

        private void cboMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMedioPago.SelectedIndex == 0)
            {
                cboCuotas.Visible = true;
                lblCuotas.Visible = true;
            }
            else if (cboMedioPago.SelectedIndex == 1)
            {
                cboCuotas.Visible = false;
                lblCuotas.Visible = false;
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            var cuota = new E_Cuota
            {
                IdSocio = _codSocio,
                FechaPago = DateTime.Now.Date
            };



            string rtaCuota = new Datos.Cuotas().PagarCuota(cuota);

            MessageBox.Show(
                $"Resultado: {rtaCuota}",
                "Aviso del sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            if (rtaCuota.Contains("éxito") || rtaCuota.Contains("pagada")) // Ajusta según tu respuesta
            {
                GenerarComprobante();
            }

            // cerrar otros formularios...
            foreach (Form frm in Application.OpenForms.Cast<Form>().ToList())
            {
                if (frm.Name != "frmMenuPrincipal" && frm.Name != "frmLogin")
                { frm.Close(); }
            }

            // obtener referencia al menu principal (si existe)
            var menu = Application.OpenForms.Cast<Form>().FirstOrDefault(f => f.Name == "frmMenuPrincipal");

            var nuevoFrm = new frmCobrarCuota(_codSocio);
            if (menu != null)
            {
                nuevoFrm.StartPosition = FormStartPosition.CenterScreen;
                nuevoFrm.ShowDialog(menu); // show con owner
            }
            else
            {
                nuevoFrm.StartPosition = FormStartPosition.CenterScreen;
                nuevoFrm.ShowDialog();
            }

            // intentar traerlo al frente/foco
            nuevoFrm.BringToFront();
            nuevoFrm.Activate();
            nuevoFrm.TopMost = true;
            nuevoFrm.TopMost = false;

        }
        private void GenerarComprobante()
        {
            var comprobanteData = new ComprobanteActividadData
            {
                NumeroComprobante = $"ACT-{DateTime.Now:yyyyMMddHHmmss}",
                NombreApellido = _nombreSocio,
                Actividad = "Cuota Social",
                Monto = 25000.00m, // Cambia por el monto real esta hardcodeada en el sql
                FechaPago = DateTime.Now,
                MedioPago = cboMedioPago.SelectedItem?.ToString() ?? "Efectivo"
            };

            var printer = new ComprobantePrinter();
            printer.Print(comprobanteData, preview: true);
        }

    }
}
