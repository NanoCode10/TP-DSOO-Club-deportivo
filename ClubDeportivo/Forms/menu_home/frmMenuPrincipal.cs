using ClubDeportivo.Forms.cobrar_cuota;
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
            btnCobrarActividad.Enabled = false;
            btnListado.Enabled = false;
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
    }
}
