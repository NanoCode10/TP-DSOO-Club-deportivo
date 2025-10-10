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
            btnCobrarCuota.Enabled = false;
            btnListado.Enabled = false;
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            frmRegistrar frmR = new frmRegistrar();
            frmR.ShowDialog();
        }
    }
}
