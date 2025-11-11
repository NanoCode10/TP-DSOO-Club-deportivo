namespace ClubDeportivo.Forms.actividades
{
    partial class frmActividades
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
            lblRegistro = new Label();
            lblSeleccionarActivdad = new Label();
            cboActividad = new ComboBox();
            lblSeleccionarNoSocio = new Label();
            cboNoSocio = new ComboBox();
            btnPagoActividad = new Button();
            lblMonto = new Label();
            lblMontoValor = new Label();
            SuspendLayout();
            // 
            // lblRegistro
            // 
            lblRegistro.AutoSize = true;
            lblRegistro.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRegistro.Location = new Point(262, 37);
            lblRegistro.Name = "lblRegistro";
            lblRegistro.Size = new Size(224, 20);
            lblRegistro.TabIndex = 7;
            lblRegistro.Text = "Pago de actividad eventual";
            // 
            // lblSeleccionarActivdad
            // 
            lblSeleccionarActivdad.AutoSize = true;
            lblSeleccionarActivdad.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSeleccionarActivdad.Location = new Point(161, 129);
            lblSeleccionarActivdad.Name = "lblSeleccionarActivdad";
            lblSeleccionarActivdad.Size = new Size(151, 18);
            lblSeleccionarActivdad.TabIndex = 14;
            lblSeleccionarActivdad.Text = "Seleccionar actividad:";
            // 
            // cboActividad
            // 
            cboActividad.FormattingEnabled = true;
            cboActividad.Location = new Point(326, 129);
            cboActividad.Name = "cboActividad";
            cboActividad.Size = new Size(274, 23);
            cboActividad.TabIndex = 13;
            cboActividad.Text = " Seleccionar ...";
            cboActividad.SelectedIndexChanged += cboActividad_SelectedIndexChanged;
            // 
            // lblSeleccionarNoSocio
            // 
            lblSeleccionarNoSocio.AutoSize = true;
            lblSeleccionarNoSocio.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSeleccionarNoSocio.Location = new Point(161, 85);
            lblSeleccionarNoSocio.Name = "lblSeleccionarNoSocio";
            lblSeleccionarNoSocio.Size = new Size(157, 18);
            lblSeleccionarNoSocio.TabIndex = 15;
            lblSeleccionarNoSocio.Text = "Seleccionar No Socio:";
            // 
            // cboNoSocio
            // 
            cboNoSocio.FormattingEnabled = true;
            cboNoSocio.Location = new Point(326, 85);
            cboNoSocio.Name = "cboNoSocio";
            cboNoSocio.Size = new Size(274, 23);
            cboNoSocio.TabIndex = 16;
            cboNoSocio.Text = " Seleccionar ...";
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMonto.Location = new Point(161, 175);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(54, 18);
            lblMonto.TabIndex = 18;
            lblMonto.Text = "Monto:";
            // 
            // lblMontoValor
            // 
            lblMontoValor.AutoSize = true;
            lblMontoValor.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMontoValor.ForeColor = Color.Green;
            lblMontoValor.Location = new Point(326, 175);
            lblMontoValor.Name = "lblMontoValor";
            lblMontoValor.Size = new Size(45, 18);
            lblMontoValor.TabIndex = 19;
            lblMontoValor.Text = "$0.00";

            // ... (código existente del formulario)

            // EN Controls.Add AGREGAR:
            Controls.Add(lblMontoValor);
            Controls.Add(lblMonto);
            // 
            // btnPagoActividad
            // 
            btnPagoActividad.BackColor = Color.MediumSeaGreen;
            btnPagoActividad.BackgroundImageLayout = ImageLayout.None;
            btnPagoActividad.FlatStyle = FlatStyle.Flat;
            btnPagoActividad.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPagoActividad.ForeColor = SystemColors.Control;
            btnPagoActividad.Location = new Point(293, 210);
            btnPagoActividad.Name = "btnPagoActividad";
            btnPagoActividad.Size = new Size(193, 35);
            btnPagoActividad.TabIndex = 17;
            btnPagoActividad.Text = "Pagar";
            btnPagoActividad.UseVisualStyleBackColor = false;
            btnPagoActividad.Click += btnPagoActividad_Click;
            // 
            // frmActividades
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(btnPagoActividad);
            Controls.Add(cboNoSocio);
            Controls.Add(lblSeleccionarNoSocio);
            Controls.Add(lblSeleccionarActivdad);
            Controls.Add(cboActividad);
            Controls.Add(lblRegistro);
            Name = "frmActividades";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Club deportivo - Actividades";
            Load += frmActividades_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRegistro;
        private Label lblSeleccionarActivdad;
        private ComboBox cboActividad;
        private Label lblSeleccionarNoSocio;
        private ComboBox cboNoSocio;
        private Button btnPagoActividad;
        private Label lblMonto;
        private Label lblMontoValor;
    }
}