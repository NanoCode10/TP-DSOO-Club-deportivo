using ClubDeportivo.Forms.actividades;
using ClubDeportivo.Forms.cobrar_cuota;

using ClubDeportivo.Forms.listar_vencimientos;
using ClubDeportivo.Forms.registrar;

namespace ClubDeportivo.Forms.menu_home
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();

        }


        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }
        

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            frmRegistrar frmR = new frmRegistrar();
            frmR.ShowDialog();
        }

        private void btnCobrarCuota_Click(object sender, EventArgs e)
        {
            frmCobrarCuota frmCobrar = new frmCobrarCuota();
            frmCobrar.ShowDialog();
        }

        private void btnListado_Click(object sender, EventArgs e)
        {
            frmListarVencimientos frmListado = new frmListarVencimientos();
            frmListado.ShowDialog();
        }

        private void btnCobrarActividad_Click(object sender, EventArgs e)
        {
            frmActividades frmAct = new frmActividades();
            frmAct.ShowDialog();
        }
    }
}
