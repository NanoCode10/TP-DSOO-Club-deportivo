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
            rbSocio = new RadioButton();
            rbNoSocio = new RadioButton();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            cboTipoDoc = new ComboBox();
            txtDocumento = new TextBox();
            dtpNacimiento = new DateTimePicker();
            txtDireccion = new TextBox();
            txtTelefono = new TextBox();
            txtEmail = new TextBox();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            btnVolver = new Button();
            SuspendLayout();
            // 
            // rbSocio
            // 
            rbSocio.AutoSize = true;
            rbSocio.Checked = true;
            rbSocio.Location = new Point(41, 46);
            rbSocio.Name = "rbSocio";
            rbSocio.Size = new Size(54, 19);
            rbSocio.TabIndex = 0;
            rbSocio.TabStop = true;
            rbSocio.Text = "Socio";
            rbSocio.UseVisualStyleBackColor = true;
            // 
            // rbNoSocio
            // 
            rbNoSocio.AutoSize = true;
            rbNoSocio.Location = new Point(41, 85);
            rbNoSocio.Name = "rbNoSocio";
            rbNoSocio.Size = new Size(73, 19);
            rbNoSocio.TabIndex = 1;
            rbNoSocio.Text = "No Socio";
            rbNoSocio.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(200, 32);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre";
            txtNombre.Size = new Size(200, 23);
            txtNombre.TabIndex = 2;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(200, 74);
            txtApellido.Name = "txtApellido";
            txtApellido.PlaceholderText = "Apellido";
            txtApellido.Size = new Size(200, 23);
            txtApellido.TabIndex = 3;
            // 
            // cboTipoDoc
            // 
            cboTipoDoc.FormattingEnabled = true;
            cboTipoDoc.Items.AddRange(new object[] { "DNI, LC, LE, Pasaporte;" });
            cboTipoDoc.Location = new Point(200, 117);
            cboTipoDoc.Name = "cboTipoDoc";
            cboTipoDoc.Size = new Size(200, 23);
            cboTipoDoc.TabIndex = 4;
            cboTipoDoc.SelectedIndexChanged += cboTipoDoc_SelectedIndexChanged;
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(200, 163);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.PlaceholderText = "Nro de documento";
            txtDocumento.Size = new Size(200, 23);
            txtDocumento.TabIndex = 5;
            // 
            // dtpNacimiento
            // 
            dtpNacimiento.Format = DateTimePickerFormat.Short;
            dtpNacimiento.Location = new Point(200, 206);
            dtpNacimiento.Name = "dtpNacimiento";
            dtpNacimiento.Size = new Size(200, 23);
            dtpNacimiento.TabIndex = 6;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(200, 255);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.PlaceholderText = "Calle Siempre Viva 666";
            txtDireccion.Size = new Size(200, 23);
            txtDireccion.TabIndex = 7;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(200, 297);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "11 5488 4085";
            txtTelefono.Size = new Size(200, 23);
            txtTelefono.TabIndex = 8;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(200, 348);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "correo@correo.com";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 9;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(502, 104);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(502, 162);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(502, 225);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 12;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            // 
            // frmRegistrar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 393);
            Controls.Add(btnVolver);
            Controls.Add(btnLimpiar);
            Controls.Add(btnGuardar);
            Controls.Add(txtEmail);
            Controls.Add(txtTelefono);
            Controls.Add(txtDireccion);
            Controls.Add(dtpNacimiento);
            Controls.Add(txtDocumento);
            Controls.Add(cboTipoDoc);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(rbNoSocio);
            Controls.Add(rbSocio);
            Name = "frmRegistrar";
            Text = "Registrar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton rbSocio;
        private RadioButton rbNoSocio;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private ComboBox cboTipoDoc;
        private TextBox txtDocumento;
        private DateTimePicker dtpNacimiento;
        private TextBox txtDireccion;
        private TextBox txtTelefono;
        private TextBox txtEmail;
        private Button btnGuardar;
        private Button btnLimpiar;

        private void cboTipoDoc_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // opcional: nada
        }
        private Button btnVolver;
    }



}