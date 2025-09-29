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

    private void InitializeComponent()
    {
        mySqlCommand1 = new MySqlConnector.MySqlCommand();
        tlpRoot = new TableLayoutPanel();
        tlpForm = new Panel();
        lblTitulo = new Label();
        tableLayoutPanel1 = new TableLayoutPanel();
        tlpRoot.SuspendLayout();
        tlpForm.SuspendLayout();
        SuspendLayout();
        // 
        // mySqlCommand1
        // 
        mySqlCommand1.CommandTimeout = 0;
        mySqlCommand1.Connection = null;
        mySqlCommand1.Transaction = null;
        mySqlCommand1.UpdatedRowSource = System.Data.UpdateRowSource.None;
        // 
        // tlpRoot
        // 
        tlpRoot.ColumnCount = 2;
        tlpRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tlpRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tlpRoot.Controls.Add(tlpForm, 1, 0);
        tlpRoot.Dock = DockStyle.Fill;
        tlpRoot.Location = new Point(0, 0);
        tlpRoot.Name = "tlpRoot";
        tlpRoot.Padding = new Padding(20, 0, 0, 0);
        tlpRoot.RowCount = 1;
        tlpRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpRoot.Size = new Size(724, 381);
        tlpRoot.TabIndex = 0;
        tlpRoot.Paint += tlpRoot_Paint;
        // 
        // tlpForm
        // 
        tlpForm.BackColor = Color.White;
        tlpForm.Controls.Add(tableLayoutPanel1);
        tlpForm.Controls.Add(lblTitulo);
        tlpForm.Dock = DockStyle.Top;
        tlpForm.Location = new Point(375, 3);
        tlpForm.Name = "tlpForm";
        tlpForm.Padding = new Padding(24, 0, 0, 0);
        tlpForm.Size = new Size(346, 234);
        tlpForm.TabIndex = 0;
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
        lblTitulo.Location = new Point(111, 54);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(105, 21);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Iniciar sesión";
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 2;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.Location = new Point(70, 106);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 2;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.Size = new Size(200, 100);
        tableLayoutPanel1.TabIndex = 1;
        // 
        // FrmLogin
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(247, 247, 247);
        ClientSize = new Size(724, 381);
        Controls.Add(tlpRoot);
        Cursor = Cursors.Default;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        KeyPreview = true;
        MaximizeBox = false;
        Name = "FrmLogin";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Club deportivo - Pantalla principal";
        tlpRoot.ResumeLayout(false);
        tlpForm.ResumeLayout(false);
        tlpForm.PerformLayout();
        ResumeLayout(false);

    }

    private void tlpRoot_Paint(object sender, PaintEventArgs e)
    {

    }

    private MySqlConnector.MySqlCommand mySqlCommand1;
    private TableLayoutPanel tlpRoot;
    private Panel tlpForm;
    private Label lblTitulo;
    private TableLayoutPanel tableLayoutPanel1;
}
