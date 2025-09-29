using System.Windows.Forms;

namespace ClubDeportivo.WinForms.Forms;

public partial class FrmLogin : Form
{
    public FrmLogin()
    {
        InitializeComponent();
        // Por ahora: al “login”, abrimos menú y ocultamos este
        this.Load += (_, __) =>
        {
            var menu = new FrmMenuPrincipal();
            menu.Show();
            this.Hide();
        };
    }
}
