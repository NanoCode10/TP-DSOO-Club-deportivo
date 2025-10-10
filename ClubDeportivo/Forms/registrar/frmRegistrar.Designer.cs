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
            dgvSocios = new DataGridView();
            lblListaSociosNoSocios = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).BeginInit();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(151, 95);
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
            btnRegistrar.Location = new Point(387, 360);
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
            lblDatosPersonales.Location = new Point(151, 58);
            lblDatosPersonales.Name = "lblDatosPersonales";
            lblDatosPersonales.Size = new Size(151, 20);
            lblDatosPersonales.TabIndex = 8;
            lblDatosPersonales.Text = "Datos Personales";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(82, 99);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(66, 18);
            lblNombre.TabIndex = 9;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblApellido.Location = new Point(379, 99);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(63, 18);
            lblApellido.TabIndex = 11;
            lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellido.Location = new Point(448, 95);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(182, 26);
            txtApellido.TabIndex = 1;
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDocumento.Location = new Point(56, 154);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(90, 18);
            lblDocumento.TabIndex = 13;
            lblDocumento.Text = "Documento:";
            // 
            // txtDocumento
            // 
            txtDocumento.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDocumento.Location = new Point(151, 150);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(182, 26);
            txtDocumento.TabIndex = 3;
            // 
            // lblTipoDocumento
            // 
            lblTipoDocumento.AutoSize = true;
            lblTipoDocumento.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTipoDocumento.Location = new Point(374, 154);
            lblTipoDocumento.Name = "lblTipoDocumento";
            lblTipoDocumento.Size = new Size(120, 18);
            lblTipoDocumento.TabIndex = 14;
            lblTipoDocumento.Text = "Tipo documento:";
            // 
            // cboTipoDocumento
            // 
            cboTipoDocumento.FormattingEnabled = true;
            cboTipoDocumento.Items.AddRange(new object[] { "DNI", "PASAPORTE" });
            cboTipoDocumento.Location = new Point(509, 153);
            cboTipoDocumento.Name = "cboTipoDocumento";
            cboTipoDocumento.Size = new Size(121, 23);
            cboTipoDocumento.TabIndex = 4;
            // 
            // lblDatosAdicionales
            // 
            lblDatosAdicionales.AutoSize = true;
            lblDatosAdicionales.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDatosAdicionales.Location = new Point(151, 217);
            lblDatosAdicionales.Name = "lblDatosAdicionales";
            lblDatosAdicionales.Size = new Size(152, 20);
            lblDatosAdicionales.TabIndex = 16;
            lblDatosAdicionales.Text = "Datos adicionales";
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTipo.Location = new Point(177, 282);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(41, 18);
            lblTipo.TabIndex = 17;
            lblTipo.Text = "Tipo:";
            // 
            // cboTipo
            // 
            cboTipo.FormattingEnabled = true;
            cboTipo.Items.AddRange(new object[] { "Socio" });
            cboTipo.Location = new Point(232, 278);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(121, 23);
            cboTipo.TabIndex = 5;
            cboTipo.Text = "Seleccionar...";
            // 
            // cboAptoFisico
            // 
            cboAptoFisico.FormattingEnabled = true;
            cboAptoFisico.Items.AddRange(new object[] { "Si", "No" });
            cboAptoFisico.Location = new Point(484, 278);
            cboAptoFisico.Name = "cboAptoFisico";
            cboAptoFisico.Size = new Size(76, 23);
            cboAptoFisico.TabIndex = 6;
            cboAptoFisico.Text = "Seleccionar...";
            // 
            // lblAptoFísico
            // 
            lblAptoFísico.AutoSize = true;
            lblAptoFísico.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAptoFísico.Location = new Point(387, 282);
            lblAptoFísico.Name = "lblAptoFísico";
            lblAptoFísico.Size = new Size(81, 18);
            lblAptoFísico.TabIndex = 21;
            lblAptoFísico.Text = "Apto físico:";
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = SystemColors.ControlLightLight;
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.ForeColor = SystemColors.Desktop;
            btnLimpiar.Location = new Point(151, 360);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(202, 26);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dgvSocios
            // 
            dgvSocios.AllowUserToAddRows = false;
            dgvSocios.AllowUserToDeleteRows = false;
            dgvSocios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSocios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSocios.Location = new Point(29, 461);
            dgvSocios.MultiSelect = false;
            dgvSocios.Name = "dgvSocios";
            dgvSocios.ReadOnly = true;
            dgvSocios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSocios.Size = new Size(725, 88);
            dgvSocios.TabIndex = 23;
            // 
            // lblListaSociosNoSocios
            // 
            lblListaSociosNoSocios.AutoSize = true;
            lblListaSociosNoSocios.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblListaSociosNoSocios.Location = new Point(29, 423);
            lblListaSociosNoSocios.Name = "lblListaSociosNoSocios";
            lblListaSociosNoSocios.Size = new Size(152, 20);
            lblListaSociosNoSocios.TabIndex = 24;
            lblListaSociosNoSocios.Text = "Listado de Socios";
            // 
            // frmRegistrar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(lblListaSociosNoSocios);
            Controls.Add(dgvSocios);
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
            ((System.ComponentModel.ISupportInitialize)dgvSocios).EndInit();
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
        private DataGridView dgvSocios;
        private Label lblListaSociosNoSocios;
    }
}