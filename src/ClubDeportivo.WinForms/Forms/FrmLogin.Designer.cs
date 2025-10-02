namespace ClubDeportivo.WinForms.Forms
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tlpRoot = new TableLayoutPanel();
            picMascota = new PictureBox();
            pnlLogin = new Panel();
            lblTitulo = new Label();
            tlpForm = new TableLayoutPanel();
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            btnIngresar = new Button();
            tlpRoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMascota).BeginInit();
            pnlLogin.SuspendLayout();
            tlpForm.SuspendLayout();
            SuspendLayout();
            // 
            // tlpRoot
            // 
            tlpRoot.ColumnCount = 2;
            tlpRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tlpRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            tlpRoot.Controls.Add(picMascota, 0, 0);
            tlpRoot.Controls.Add(pnlLogin, 1, 0);
            tlpRoot.Dock = DockStyle.Fill;
            tlpRoot.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tlpRoot.Location = new Point(0, 0);
            tlpRoot.Name = "tlpRoot";
            tlpRoot.Padding = new Padding(20);
            tlpRoot.RowCount = 1;
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpRoot.Size = new Size(709, 296);
            tlpRoot.TabIndex = 0;
            // 
            // picMascota
            // 
            picMascota.Anchor = AnchorStyles.None;
            picMascota.Image = Properties.Resources.img_gym;
            picMascota.Location = new Point(29, 61);
            picMascota.Name = "picMascota";
            picMascota.Size = new Size(282, 173);
            picMascota.SizeMode = PictureBoxSizeMode.Zoom;
            picMascota.TabIndex = 0;
            picMascota.TabStop = false;
            // 
            // pnlLogin
            // 
            pnlLogin.Anchor = AnchorStyles.Top;
            pnlLogin.Controls.Add(tlpForm);
            pnlLogin.Controls.Add(lblTitulo);
            pnlLogin.Location = new Point(324, 23);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(362, 250);
            pnlLogin.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top;
            lblTitulo.AutoSize = true;
            lblTitulo.Cursor = Cursors.Cross;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblTitulo.Location = new Point(131, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(105, 21);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Iniciar sesión";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tlpForm
            // 
            tlpForm.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tlpForm.AutoSize = true;
            tlpForm.ColumnCount = 1;
            tlpForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpForm.Controls.Add(txtUsuario, 0, 0);
            tlpForm.Controls.Add(txtPassword, 0, 1);
            tlpForm.Controls.Add(btnIngresar, 0, 2);
            tlpForm.Location = new Point(15, 54);
            tlpForm.Name = "tlpForm";
            tlpForm.RowCount = 3;
            tlpForm.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlpForm.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlpForm.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlpForm.Size = new Size(332, 168);
            tlpForm.TabIndex = 1;
            // 
            // txtUsuario
            // 
            txtUsuario.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtUsuario.Location = new Point(3, 16);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "Usuario";
            txtUsuario.Size = new Size(326, 23);
            txtUsuario.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(3, 72);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(326, 23);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(34, 197, 94);
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Location = new Point(3, 115);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(326, 50);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 247, 247);
            ClientSize = new Size(709, 296);
            Controls.Add(tlpRoot);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Club deportivo - Pantalla principal";
            tlpRoot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picMascota).EndInit();
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            tlpForm.ResumeLayout(false);
            tlpForm.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpRoot;
        private PictureBox picMascota;
        private Panel pnlLogin;
        private Label lblTitulo;
        private TableLayoutPanel tlpForm;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Button btnIngresar;
    }
}