namespace ClubDeportivo.Forms.editar_persona
{
    partial class FmEditarPersona
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
            btnActualizar = new Button();
            btnCancelar = new Button();
            gbPersonale = new GroupBox();
            lblTel = new Label();
            txtTel = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblAptoFísico = new Label();
            cboAptoFisico = new ComboBox();
            cboTipo = new ComboBox();
            lblTipoPersona = new Label();
            lblDatosAdicionales = new Label();
            cboTipoDocumento = new ComboBox();
            lblTipoDocumento = new Label();
            lblDocumento = new Label();
            txtDocumento = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblNombre = new Label();
            lblDatosPersonales = new Label();
            lblActulizar = new Label();
            txtNombre = new TextBox();
            btnDesactivar = new Button();
            gbPersonale.SuspendLayout();
            SuspendLayout();
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(517, 403);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 0;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(707, 403);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // gbPersonale
            // 
            gbPersonale.Controls.Add(lblTel);
            gbPersonale.Controls.Add(txtTel);
            gbPersonale.Controls.Add(lblEmail);
            gbPersonale.Controls.Add(txtEmail);
            gbPersonale.Controls.Add(lblAptoFísico);
            gbPersonale.Controls.Add(cboAptoFisico);
            gbPersonale.Controls.Add(cboTipo);
            gbPersonale.Controls.Add(lblTipoPersona);
            gbPersonale.Controls.Add(lblDatosAdicionales);
            gbPersonale.Controls.Add(cboTipoDocumento);
            gbPersonale.Controls.Add(lblTipoDocumento);
            gbPersonale.Controls.Add(lblDocumento);
            gbPersonale.Controls.Add(txtDocumento);
            gbPersonale.Controls.Add(lblApellido);
            gbPersonale.Controls.Add(txtApellido);
            gbPersonale.Controls.Add(lblNombre);
            gbPersonale.Controls.Add(lblDatosPersonales);
            gbPersonale.Controls.Add(lblActulizar);
            gbPersonale.Controls.Add(txtNombre);
            gbPersonale.Location = new Point(35, 26);
            gbPersonale.Name = "gbPersonale";
            gbPersonale.Size = new Size(723, 335);
            gbPersonale.TabIndex = 2;
            gbPersonale.TabStop = false;
            gbPersonale.Text = "Datos Personales";
            // 
            // lblTel
            // 
            lblTel.AutoSize = true;
            lblTel.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTel.Location = new Point(374, 147);
            lblTel.Name = "lblTel";
            lblTel.Size = new Size(70, 18);
            lblTel.TabIndex = 44;
            lblTel.Text = "Teléfono:";
            // 
            // txtTel
            // 
            txtTel.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTel.Location = new Point(443, 143);
            txtTel.Name = "txtTel";
            txtTel.Size = new Size(182, 26);
            txtTel.TabIndex = 29;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(77, 147);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 18);
            lblEmail.TabIndex = 43;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(146, 143);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(182, 26);
            txtEmail.TabIndex = 28;
            // 
            // lblAptoFísico
            // 
            lblAptoFísico.AutoSize = true;
            lblAptoFísico.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAptoFísico.Location = new Point(385, 271);
            lblAptoFísico.Name = "lblAptoFísico";
            lblAptoFísico.Size = new Size(87, 18);
            lblAptoFísico.TabIndex = 42;
            lblAptoFísico.Text = "Apto físico:*";
            // 
            // cboAptoFisico
            // 
            cboAptoFisico.FormattingEnabled = true;
            cboAptoFisico.Items.AddRange(new object[] { "Si", "No" });
            cboAptoFisico.Location = new Point(482, 267);
            cboAptoFisico.Name = "cboAptoFisico";
            cboAptoFisico.Size = new Size(76, 23);
            cboAptoFisico.TabIndex = 34;
            cboAptoFisico.Text = "Seleccionar...";
            // 
            // cboTipo
            // 
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.FormattingEnabled = true;
            cboTipo.Items.AddRange(new object[] { "Socio", "No Socio" });
            cboTipo.Location = new Point(230, 267);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(121, 23);
            cboTipo.TabIndex = 32;
            // 
            // lblTipoPersona
            // 
            lblTipoPersona.AutoSize = true;
            lblTipoPersona.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTipoPersona.Location = new Point(175, 271);
            lblTipoPersona.Name = "lblTipoPersona";
            lblTipoPersona.Size = new Size(47, 18);
            lblTipoPersona.TabIndex = 41;
            lblTipoPersona.Text = "Tipo:*";
            // 
            // lblDatosAdicionales
            // 
            lblDatosAdicionales.AutoSize = true;
            lblDatosAdicionales.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDatosAdicionales.Location = new Point(146, 233);
            lblDatosAdicionales.Name = "lblDatosAdicionales";
            lblDatosAdicionales.Size = new Size(152, 20);
            lblDatosAdicionales.TabIndex = 40;
            lblDatosAdicionales.Text = "Datos adicionales";
            // 
            // cboTipoDocumento
            // 
            cboTipoDocumento.FormattingEnabled = true;
            cboTipoDocumento.Items.AddRange(new object[] { "DNI", "PASAPORTE" });
            cboTipoDocumento.Location = new Point(504, 188);
            cboTipoDocumento.Name = "cboTipoDocumento";
            cboTipoDocumento.Size = new Size(121, 23);
            cboTipoDocumento.TabIndex = 31;
            // 
            // lblTipoDocumento
            // 
            lblTipoDocumento.AutoSize = true;
            lblTipoDocumento.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTipoDocumento.Location = new Point(369, 189);
            lblTipoDocumento.Name = "lblTipoDocumento";
            lblTipoDocumento.Size = new Size(126, 18);
            lblTipoDocumento.TabIndex = 39;
            lblTipoDocumento.Text = "Tipo documento:*";
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDocumento.Location = new Point(51, 189);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(96, 18);
            lblDocumento.TabIndex = 38;
            lblDocumento.Text = "Documento:*";
            // 
            // txtDocumento
            // 
            txtDocumento.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDocumento.Location = new Point(146, 185);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(182, 26);
            txtDocumento.TabIndex = 30;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblApellido.Location = new Point(374, 105);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(69, 18);
            lblApellido.TabIndex = 37;
            lblApellido.Text = "Apellido:*";
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellido.Location = new Point(443, 101);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(182, 26);
            txtApellido.TabIndex = 27;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(77, 105);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(72, 18);
            lblNombre.TabIndex = 36;
            lblNombre.Text = "Nombre:*";
            // 
            // lblDatosPersonales
            // 
            lblDatosPersonales.AutoSize = true;
            lblDatosPersonales.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDatosPersonales.Location = new Point(146, 60);
            lblDatosPersonales.Name = "lblDatosPersonales";
            lblDatosPersonales.Size = new Size(151, 20);
            lblDatosPersonales.TabIndex = 35;
            lblDatosPersonales.Text = "Datos Personales";
            // 
            // lblActulizar
            // 
            lblActulizar.AutoSize = true;
            lblActulizar.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblActulizar.Location = new Point(284, 21);
            lblActulizar.Name = "lblActulizar";
            lblActulizar.Size = new Size(223, 20);
            lblActulizar.TabIndex = 33;
            lblActulizar.Text = "Actulizar de socio/no socio";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(146, 101);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(182, 26);
            txtNombre.TabIndex = 26;
            // 
            // btnDesactivar
            // 
            btnDesactivar.Location = new Point(613, 403);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(75, 23);
            btnDesactivar.TabIndex = 3;
            btnDesactivar.Text = "Desactivar";
            btnDesactivar.UseVisualStyleBackColor = true;
            btnDesactivar.Click += btnDesactivar_Click;
            // 
            // FmEditarPersona
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDesactivar);
            Controls.Add(gbPersonale);
            Controls.Add(btnCancelar);
            Controls.Add(btnActualizar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FmEditarPersona";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Editar Socios/No Socio";
            Load += FmEditarPersona_Load;
            gbPersonale.ResumeLayout(false);
            gbPersonale.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnActualizar;
        private Button btnCancelar;
        private GroupBox gbPersonale;
        private Label lblTel;
        private TextBox txtTel;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblAptoFísico;
        private ComboBox cboAptoFisico;
        private ComboBox cboTipo;
        private Label lblTipoPersona;
        private Label lblDatosAdicionales;
        private ComboBox cboTipoDocumento;
        private Label lblTipoDocumento;
        private Label lblDocumento;
        private TextBox txtDocumento;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblNombre;
        private Label lblDatosPersonales;
        private Label lblActulizar;
        private TextBox txtNombre;
        private Button btnDesactivar;
    }
}