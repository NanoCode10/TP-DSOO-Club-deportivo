namespace ClubDeportivo.Forms.cobrar_cuota
{
    partial class frmCobrarCuota
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
            lblCobroCuota = new Label();
            cboSocio = new ComboBox();
            lblSeleccionarSocio = new Label();
            btnPago = new Button();
            pnlDatosSocio = new Panel();
            lblTel = new Label();
            lblEmail = new Label();
            lblEstado = new Label();
            lblFechaVencimiento = new Label();
            lblIdSocio = new Label();
            lblNombreApellido = new Label();
            lblTituloSocio = new Label();
            btnImprimirCarnet = new Button();
            lblFechaActual = new Label();
            pnlDatosSocio.SuspendLayout();
            SuspendLayout();
            // 
            // lblCobroCuota
            // 
            lblCobroCuota.AutoSize = true;
            lblCobroCuota.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCobroCuota.Location = new Point(319, 42);
            lblCobroCuota.Name = "lblCobroCuota";
            lblCobroCuota.Size = new Size(132, 20);
            lblCobroCuota.TabIndex = 7;
            lblCobroCuota.Text = "Cobro de cuota";
            // 
            // cboSocio
            // 
            cboSocio.FormattingEnabled = true;
            cboSocio.Location = new Point(345, 100);
            cboSocio.Name = "cboSocio";
            cboSocio.Size = new Size(274, 23);
            cboSocio.TabIndex = 8;
            cboSocio.Text = " Seleccionar ...";
            cboSocio.SelectedIndexChanged += cboSocio_SelectedIndexChanged;
            // 
            // lblSeleccionarSocio
            // 
            lblSeleccionarSocio.AutoSize = true;
            lblSeleccionarSocio.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSeleccionarSocio.Location = new Point(180, 100);
            lblSeleccionarSocio.Name = "lblSeleccionarSocio";
            lblSeleccionarSocio.Size = new Size(131, 18);
            lblSeleccionarSocio.TabIndex = 12;
            lblSeleccionarSocio.Text = "Seleccionar socio:";
            // 
            // btnPago
            // 
            btnPago.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPago.Location = new Point(203, 386);
            btnPago.Name = "btnPago";
            btnPago.Size = new Size(193, 35);
            btnPago.TabIndex = 13;
            btnPago.Text = "Ir a Pago";
            btnPago.UseVisualStyleBackColor = true;
            btnPago.Click += btnPago_Click;
            // 
            // pnlDatosSocio
            // 
            pnlDatosSocio.Controls.Add(lblTel);
            pnlDatosSocio.Controls.Add(lblEmail);
            pnlDatosSocio.Controls.Add(lblEstado);
            pnlDatosSocio.Controls.Add(lblFechaVencimiento);
            pnlDatosSocio.Controls.Add(lblIdSocio);
            pnlDatosSocio.Controls.Add(lblNombreApellido);
            pnlDatosSocio.Controls.Add(lblTituloSocio);
            pnlDatosSocio.Location = new Point(135, 147);
            pnlDatosSocio.Name = "pnlDatosSocio";
            pnlDatosSocio.Size = new Size(518, 213);
            pnlDatosSocio.TabIndex = 14;
            // 
            // lblTel
            // 
            lblTel.AutoSize = true;
            lblTel.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTel.Location = new Point(14, 119);
            lblTel.Name = "lblTel";
            lblTel.RightToLeft = RightToLeft.No;
            lblTel.Size = new Size(74, 18);
            lblTel.TabIndex = 26;
            lblTel.Text = "Teléfono: ";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(14, 93);
            lblEmail.Name = "lblEmail";
            lblEmail.RightToLeft = RightToLeft.No;
            lblEmail.Size = new Size(53, 18);
            lblEmail.TabIndex = 25;
            lblEmail.Text = "Email: ";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstado.Location = new Point(14, 174);
            lblEstado.Name = "lblEstado";
            lblEstado.RightToLeft = RightToLeft.No;
            lblEstado.Size = new Size(63, 18);
            lblEstado.TabIndex = 19;
            lblEstado.Text = "Estado: ";
            // 
            // lblFechaVencimiento
            // 
            lblFechaVencimiento.AutoSize = true;
            lblFechaVencimiento.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFechaVencimiento.Location = new Point(14, 146);
            lblFechaVencimiento.Name = "lblFechaVencimiento";
            lblFechaVencimiento.RightToLeft = RightToLeft.No;
            lblFechaVencimiento.Size = new Size(173, 18);
            lblFechaVencimiento.TabIndex = 18;
            lblFechaVencimiento.Text = "Vencimiento de la cuota: ";
            // 
            // lblIdSocio
            // 
            lblIdSocio.AutoSize = true;
            lblIdSocio.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIdSocio.Location = new Point(14, 39);
            lblIdSocio.Name = "lblIdSocio";
            lblIdSocio.RightToLeft = RightToLeft.No;
            lblIdSocio.Size = new Size(27, 18);
            lblIdSocio.TabIndex = 17;
            lblIdSocio.Text = "Id: ";
            // 
            // lblNombreApellido
            // 
            lblNombreApellido.AutoSize = true;
            lblNombreApellido.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreApellido.Location = new Point(14, 66);
            lblNombreApellido.Name = "lblNombreApellido";
            lblNombreApellido.RightToLeft = RightToLeft.No;
            lblNombreApellido.Size = new Size(135, 18);
            lblNombreApellido.TabIndex = 16;
            lblNombreApellido.Text = "Nombre y apellido: ";
            // 
            // lblTituloSocio
            // 
            lblTituloSocio.AutoSize = true;
            lblTituloSocio.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTituloSocio.Location = new Point(147, 12);
            lblTituloSocio.Name = "lblTituloSocio";
            lblTituloSocio.Size = new Size(208, 18);
            lblTituloSocio.TabIndex = 15;
            lblTituloSocio.Text = "Datos del socio seleccionado:";
            // 
            // btnImprimirCarnet
            // 
            btnImprimirCarnet.BackColor = SystemColors.Control;
            btnImprimirCarnet.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnImprimirCarnet.Location = new Point(435, 386);
            btnImprimirCarnet.Name = "btnImprimirCarnet";
            btnImprimirCarnet.Size = new Size(193, 35);
            btnImprimirCarnet.TabIndex = 15;
            btnImprimirCarnet.Text = "Imprimir carnet";
            btnImprimirCarnet.UseVisualStyleBackColor = true;
            btnImprimirCarnet.Click += btnImprimirCarnet_Click;
            // 
            // lblFechaActual
            // 
            lblFechaActual.AutoSize = true;
            lblFechaActual.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFechaActual.Location = new Point(569, 42);
            lblFechaActual.Name = "lblFechaActual";
            lblFechaActual.RightToLeft = RightToLeft.No;
            lblFechaActual.Size = new Size(100, 18);
            lblFechaActual.TabIndex = 20;
            lblFechaActual.Text = "Fecha actual: ";
            // 
            // frmCobrarCuota
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(lblFechaActual);
            Controls.Add(btnImprimirCarnet);
            Controls.Add(pnlDatosSocio);
            Controls.Add(btnPago);
            Controls.Add(lblSeleccionarSocio);
            Controls.Add(cboSocio);
            Controls.Add(lblCobroCuota);
            Name = "frmCobrarCuota";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Club deportivo - Cobrar cuota";
            Load += frmCobrarCuota_Load;
            pnlDatosSocio.ResumeLayout(false);
            pnlDatosSocio.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCobroCuota;
        private ComboBox cboSocio;
        private Label lblSeleccionarSocio;
        private Button btnPago;
        private Panel pnlDatosSocio;
        private Label lblTituloSocio;
        private Button btnImprimirCarnet;
        private Label lblNombreApellido;
        private Label lblFechaActual;
        private Label lblEstado;
        private Label lblFechaVencimiento;
        private Label lblIdSocio;
        private Label lblEmail;
        private Label lblTel;
    }
}