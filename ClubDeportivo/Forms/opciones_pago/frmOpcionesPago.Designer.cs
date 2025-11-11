namespace ClubDeportivo.Forms.opciones_pago
{
    partial class frmOpcionesPago
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
            lblMetodoPago = new Label();
            cboMedioPago = new ComboBox();
            lblCuotas = new Label();
            cboCuotas = new ComboBox();
            btnPagar = new Button();
            lblSocio = new Label();
            SuspendLayout();
            // 
            // lblCobroCuota
            // 
            lblCobroCuota.AutoSize = true;
            lblCobroCuota.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCobroCuota.Location = new Point(299, 43);
            lblCobroCuota.Name = "lblCobroCuota";
            lblCobroCuota.Size = new Size(154, 20);
            lblCobroCuota.TabIndex = 8;
            lblCobroCuota.Text = "Opciones de pago";
            // 
            // lblMetodoPago
            // 
            lblMetodoPago.AutoSize = true;
            lblMetodoPago.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMetodoPago.Location = new Point(173, 140);
            lblMetodoPago.Name = "lblMetodoPago";
            lblMetodoPago.Size = new Size(120, 18);
            lblMetodoPago.TabIndex = 13;
            lblMetodoPago.Text = "Método de pago:";
            // 
            // cboMedioPago
            // 
            cboMedioPago.FormattingEnabled = true;
            cboMedioPago.Items.AddRange(new object[] { "Tarjeta de crédito", "Efectivo" });
            cboMedioPago.Location = new Point(299, 140);
            cboMedioPago.Name = "cboMedioPago";
            cboMedioPago.Size = new Size(274, 23);
            cboMedioPago.TabIndex = 14;
            cboMedioPago.Text = "Seleccionar ...";
            cboMedioPago.SelectedIndexChanged += cboMedioPago_SelectedIndexChanged;
            // 
            // lblCuotas
            // 
            lblCuotas.AutoSize = true;
            lblCuotas.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCuotas.Location = new Point(154, 189);
            lblCuotas.Name = "lblCuotas";
            lblCuotas.Size = new Size(139, 18);
            lblCuotas.TabIndex = 15;
            lblCuotas.Text = "Cantidad de cuotas:";
            // 
            // cboCuotas
            // 
            cboCuotas.FormattingEnabled = true;
            cboCuotas.Items.AddRange(new object[] { "1 cuota", "3 cuotas", "6 cuotas" });
            cboCuotas.Location = new Point(296, 189);
            cboCuotas.Name = "cboCuotas";
            cboCuotas.Size = new Size(110, 23);
            cboCuotas.TabIndex = 16;
            cboCuotas.Text = "Seleccionar ...";
            // 
            // btnPagar
            // 
            btnPagar.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPagar.Location = new Point(284, 267);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(237, 79);
            btnPagar.TabIndex = 17;
            btnPagar.Text = "Pagar cuota";
            btnPagar.UseVisualStyleBackColor = true;
            btnPagar.Click += btnPagar_Click;
            // 
            // lblSocio
            // 
            lblSocio.AutoSize = true;
            lblSocio.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSocio.Location = new Point(238, 91);
            lblSocio.Name = "lblSocio";
            lblSocio.Size = new Size(55, 18);
            lblSocio.TabIndex = 18;
            lblSocio.Text = "Socio: ";
            // 
            // frmOpcionesPago
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(lblSocio);
            Controls.Add(btnPagar);
            Controls.Add(cboCuotas);
            Controls.Add(lblCuotas);
            Controls.Add(cboMedioPago);
            Controls.Add(lblMetodoPago);
            Controls.Add(lblCobroCuota);
            Name = "frmOpcionesPago";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Club deportivo - Opciones de pago";
            Load += frmOpcionesPago_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCobroCuota;
        private Label lblMetodoPago;
        private ComboBox cboMedioPago;
        private Label lblCuotas;
        private ComboBox cboCuotas;
        private Button btnPagar;
        private Label lblSocio;
    }
}