namespace ClubDeportivo.Forms.registrar
{
    partial class frmRegistrar
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
            txtNombre = new TextBox();
            btnRegistrar = new Button();
            lblRegistro = new Label();
            lblDatosPersonales = new Label();
            lblNombre = new Label();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblDocumento = new Label();
            txtDocumento = new TextBox();
            lblTipoDocumento = new Label();
            cboTipoDocumento = new ComboBox();
            lblDatosAdicionales = new Label();
            lblTipo = new Label();
            cboTipo = new ComboBox();
            cboAptoFisico = new ComboBox();
            lblAptoFísico = new Label();
            btnLimpiar = new Button();
            lblTel = new Label();
            txtTel = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            tcListados = new TabControl();
            tabSocios = new TabPage();
            dgvSocios = new DataGridView();
            tabNoSocios = new TabPage();
            dgvNoSocios = new DataGridView();
            tcListados.SuspendLayout();
            tabSocios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).BeginInit();
            tabNoSocios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNoSocios).BeginInit();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(154, 89);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(182, 26);
            txtNombre.TabIndex = 0;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.FromArgb(55, 176, 53);
            btnRegistrar.Cursor = Cursors.Hand;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.ForeColor = SystemColors.HighlightText;
            btnRegistrar.Location = new Point(406, 318);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(202, 26);
            btnRegistrar.TabIndex = 8;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // lblRegistro
            // 
            lblRegistro.AutoSize = true;
            lblRegistro.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRegistro.Location = new Point(292, 9);
            lblRegistro.Name = "lblRegistro";
            lblRegistro.Size = new Size(221, 20);
            lblRegistro.TabIndex = 6;
            lblRegistro.Text = "Registro de socio/no socio";
            // 
            // lblDatosPersonales
            // 
            lblDatosPersonales.AutoSize = true;
            lblDatosPersonales.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDatosPersonales.Location = new Point(154, 48);
            lblDatosPersonales.Name = "lblDatosPersonales";
            lblDatosPersonales.Size = new Size(151, 20);
            lblDatosPersonales.TabIndex = 8;
            lblDatosPersonales.Text = "Datos Personales";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(85, 93);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(72, 18);
            lblNombre.TabIndex = 9;
            lblNombre.Text = "Nombre:*";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblApellido.Location = new Point(382, 93);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(69, 18);
            lblApellido.TabIndex = 11;
            lblApellido.Text = "Apellido:*";
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellido.Location = new Point(451, 89);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(182, 26);
            txtApellido.TabIndex = 1;
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDocumento.Location = new Point(59, 177);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(96, 18);
            lblDocumento.TabIndex = 13;
            lblDocumento.Text = "Documento:*";
            // 
            // txtDocumento
            // 
            txtDocumento.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDocumento.Location = new Point(154, 173);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(182, 26);
            txtDocumento.TabIndex = 4;
            // 
            // lblTipoDocumento
            // 
            lblTipoDocumento.AutoSize = true;
            lblTipoDocumento.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTipoDocumento.Location = new Point(377, 177);
            lblTipoDocumento.Name = "lblTipoDocumento";
            lblTipoDocumento.Size = new Size(126, 18);
            lblTipoDocumento.TabIndex = 14;
            lblTipoDocumento.Text = "Tipo documento:*";
            // 
            // cboTipoDocumento
            // 
            cboTipoDocumento.FormattingEnabled = true;
            cboTipoDocumento.Items.AddRange(new object[] { "DNI", "PASAPORTE" });
            cboTipoDocumento.Location = new Point(512, 176);
            cboTipoDocumento.Name = "cboTipoDocumento";
            cboTipoDocumento.Size = new Size(121, 23);
            cboTipoDocumento.TabIndex = 5;
            // 
            // lblDatosAdicionales
            // 
            lblDatosAdicionales.AutoSize = true;
            lblDatosAdicionales.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDatosAdicionales.Location = new Point(154, 221);
            lblDatosAdicionales.Name = "lblDatosAdicionales";
            lblDatosAdicionales.Size = new Size(152, 20);
            lblDatosAdicionales.TabIndex = 16;
            lblDatosAdicionales.Text = "Datos adicionales";
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTipo.Location = new Point(183, 259);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(47, 18);
            lblTipo.TabIndex = 17;
            lblTipo.Text = "Tipo:*";
            // 
            // cboTipo
            // 
            cboTipo.FormattingEnabled = true;
            cboTipo.Items.AddRange(new object[] { "Socio", "No Socio" });
            cboTipo.Location = new Point(238, 255);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(121, 23);
            cboTipo.TabIndex = 6;
            cboTipo.Text = "Seleccionar...";
            // 
            // cboAptoFisico
            // 
            cboAptoFisico.FormattingEnabled = true;
            cboAptoFisico.Items.AddRange(new object[] { "Si", "No" });
            cboAptoFisico.Location = new Point(490, 255);
            cboAptoFisico.Name = "cboAptoFisico";
            cboAptoFisico.Size = new Size(76, 23);
            cboAptoFisico.TabIndex = 7;
            cboAptoFisico.Text = "Seleccionar...";
            // 
            // lblAptoFísico
            // 
            lblAptoFísico.AutoSize = true;
            lblAptoFísico.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAptoFísico.Location = new Point(393, 259);
            lblAptoFísico.Name = "lblAptoFísico";
            lblAptoFísico.Size = new Size(87, 18);
            lblAptoFísico.TabIndex = 21;
            lblAptoFísico.Text = "Apto físico:*";
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = SystemColors.ControlLightLight;
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.ForeColor = SystemColors.Desktop;
            btnLimpiar.Location = new Point(170, 318);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(202, 26);
            btnLimpiar.TabIndex = 10;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lblTel
            // 
            lblTel.AutoSize = true;
            lblTel.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTel.Location = new Point(382, 135);
            lblTel.Name = "lblTel";
            lblTel.Size = new Size(70, 18);
            lblTel.TabIndex = 25;
            lblTel.Text = "Teléfono:";
            // 
            // txtTel
            // 
            txtTel.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTel.Location = new Point(451, 131);
            txtTel.Name = "txtTel";
            txtTel.Size = new Size(182, 26);
            txtTel.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(85, 135);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 18);
            lblEmail.TabIndex = 24;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(154, 131);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(182, 26);
            txtEmail.TabIndex = 2;
            // 
            // tcListados
            // 
            tcListados.Controls.Add(tabSocios);
            tcListados.Controls.Add(tabNoSocios);
            tcListados.Location = new Point(0, 350);
            tcListados.Name = "tcListados";
            tcListados.SelectedIndex = 0;
            tcListados.Size = new Size(772, 200);
            tcListados.TabIndex = 26;
            // 
            // tabSocios
            // 
            tabSocios.Controls.Add(dgvSocios);
            tabSocios.Location = new Point(4, 24);
            tabSocios.Name = "tabSocios";
            tabSocios.Padding = new Padding(3);
            tabSocios.Size = new Size(764, 172);
            tabSocios.TabIndex = 0;
            tabSocios.Text = "Socios";
            tabSocios.UseVisualStyleBackColor = true;
            // 
            // dgvSocios
            // 
            dgvSocios.AllowUserToAddRows = false;
            dgvSocios.AllowUserToDeleteRows = false;
            dgvSocios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSocios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSocios.Location = new Point(3, 6);
            dgvSocios.MultiSelect = false;
            dgvSocios.Name = "dgvSocios";
            dgvSocios.RowHeadersVisible = false;
            dgvSocios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSocios.Size = new Size(755, 150);
            dgvSocios.TabIndex = 0;
            // 
            // tabNoSocios
            // 
            tabNoSocios.Controls.Add(dgvNoSocios);
            tabNoSocios.Location = new Point(4, 24);
            tabNoSocios.Name = "tabNoSocios";
            tabNoSocios.Padding = new Padding(3);
            tabNoSocios.Size = new Size(764, 172);
            tabNoSocios.TabIndex = 1;
            tabNoSocios.Text = "No Socios";
            tabNoSocios.UseVisualStyleBackColor = true;
            // 
            // dgvNoSocios
            // 
            dgvNoSocios.AllowUserToAddRows = false;
            dgvNoSocios.AllowUserToDeleteRows = false;
            dgvNoSocios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNoSocios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNoSocios.Location = new Point(6, 6);
            dgvNoSocios.MultiSelect = false;
            dgvNoSocios.Name = "dgvNoSocios";
            dgvNoSocios.RowHeadersVisible = false;
            dgvNoSocios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNoSocios.Size = new Size(752, 150);
            dgvNoSocios.TabIndex = 0;
            // 
            // frmRegistrar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 562);
            Controls.Add(tcListados);
            Controls.Add(lblTel);
            Controls.Add(txtTel);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(btnLimpiar);
            Controls.Add(lblAptoFísico);
            Controls.Add(cboAptoFisico);
            Controls.Add(cboTipo);
            Controls.Add(lblTipo);
            Controls.Add(lblDatosAdicionales);
            Controls.Add(cboTipoDocumento);
            Controls.Add(lblTipoDocumento);
            Controls.Add(lblDocumento);
            Controls.Add(txtDocumento);
            Controls.Add(lblApellido);
            Controls.Add(txtApellido);
            Controls.Add(lblNombre);
            Controls.Add(lblDatosPersonales);
            Controls.Add(btnRegistrar);
            Controls.Add(lblRegistro);
            Controls.Add(txtNombre);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmRegistrar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Club deportivo  -Registrar  persona";
            Load += frmAgregarPersona_Load;
            tcListados.ResumeLayout(false);
            tabSocios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSocios).EndInit();
            tabNoSocios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNoSocios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private Button btnRegistrar;
        private Label lblRegistro;
        private Label lblDatosPersonales;
        private Label lblNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblDocumento;
        private TextBox txtDocumento;
        private Label lblTipoDocumento;
        private ComboBox cboTipoDocumento;
        private Label lblDatosAdicionales;
        private Label lblTipo;
        private ComboBox cboTipo;
        private ComboBox cboAptoFisico;
        private Label lblAptoFísico;
        private Button btnLimpiar;
        private Label lblTel;
        private TextBox txtTel;
        private Label lblEmail;
        private TextBox txtEmail;
        private TabControl tcListados;
        private TabPage tabSocios;
        private TabPage tabNoSocios;
        private DataGridView dgvSocios;
        private DataGridView dgvNoSocios;
    }
}