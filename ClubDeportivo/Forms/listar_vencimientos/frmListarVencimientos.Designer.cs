namespace ClubDeportivo.Forms.listar_vencimientos
{
    partial class frmListarVencimientos
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
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            codCuota = new DataGridViewTextBoxColumn();
            Monto = new DataGridViewTextBoxColumn();
            codSocio = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Apellido = new DataGridViewTextBoxColumn();
            documento = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            tel = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(339, 37);
            label1.Name = "label1";
            label1.Size = new Size(400, 21);
            label1.TabIndex = 0;
            label1.Text = "Listado de cuotas con vencimiento al día de la fecha";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Location = new Point(339, 83);
            label2.Name = "label2";
            label2.Size = new Size(400, 21);
            label2.TabIndex = 1;
            label2.Text = "Fecha de hoy: N/A";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Location = new Point(423, 118);
            button1.Name = "button1";
            button1.Size = new Size(226, 47);
            button1.TabIndex = 2;
            button1.Text = "Generar Listado";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.Location = new Point(339, 191);
            label3.Name = "label3";
            label3.Size = new Size(400, 27);
            label3.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { codCuota, Monto, codSocio, Nombre, Apellido, documento, email, tel });
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 262);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1048, 188);
            dataGridView1.TabIndex = 4;
            // 
            // codCuota
            // 
            codCuota.HeaderText = "Código de cuota";
            codCuota.Name = "codCuota";
            // 
            // Monto
            // 
            Monto.HeaderText = "Monto";
            Monto.Name = "Monto";
            // 
            // codSocio
            // 
            codSocio.HeaderText = "Código del socio";
            codSocio.Name = "codSocio";
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            // 
            // Apellido
            // 
            Apellido.HeaderText = "Apellido";
            Apellido.Name = "Apellido";
            // 
            // documento
            // 
            documento.HeaderText = "N° Documento";
            documento.Name = "documento";
            // 
            // email
            // 
            email.HeaderText = "Correo electrónico";
            email.Name = "email";
            // 
            // tel
            // 
            tel.HeaderText = "Teléfono";
            tel.Name = "tel";
            // 
            // frmListarVencimientos
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1048, 450);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmListarVencimientos";
            Text = "Form1";
            Load += frmListarVencimientos_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button button1;
        private Label label3;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn codCuota;
        private DataGridViewTextBoxColumn Monto;
        private DataGridViewTextBoxColumn codSocio;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn documento;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn tel;
    }
}