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
            lblApellido = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            comboBox2 = new ComboBox();
            btnRegistro = new Button();
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
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblApellido.Location = new Point(161, 107);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(120, 18);
            lblApellido.TabIndex = 13;
            lblApellido.Text = "Método de pago:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Tarjeta de crédito", "Efectivo" });
            comboBox1.Location = new Point(287, 107);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(274, 23);
            comboBox1.TabIndex = 14;
            comboBox1.Text = "Seleccionar ...";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(142, 156);
            label1.Name = "label1";
            label1.Size = new Size(139, 18);
            label1.TabIndex = 15;
            label1.Text = "Cantidad de cuotas:";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "1 cuota", "3 cuotas", "6 cuotas" });
            comboBox2.Location = new Point(284, 156);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(110, 23);
            comboBox2.TabIndex = 16;
            comboBox2.Text = "Seleccionar ...";
            // 
            // btnRegistro
            // 
            btnRegistro.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegistro.Location = new Point(284, 267);
            btnRegistro.Name = "btnRegistro";
            btnRegistro.Size = new Size(237, 79);
            btnRegistro.TabIndex = 17;
            btnRegistro.Text = "Pagar cuota";
            btnRegistro.UseVisualStyleBackColor = true;
            // 
            // frmOpcionesPago
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(btnRegistro);
            Controls.Add(comboBox2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(lblApellido);
            Controls.Add(lblCobroCuota);
            Name = "frmOpcionesPago";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Club deportivo - Opciones de pago";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCobroCuota;
        private Label lblApellido;
        private ComboBox comboBox1;
        private Label label1;
        private ComboBox comboBox2;
        private Button btnRegistro;
    }
}