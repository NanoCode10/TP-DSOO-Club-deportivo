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
            monto = new DataGridViewTextBoxColumn();
            codSocio = new DataGridViewTextBoxColumn();
            nombre = new DataGridViewTextBoxColumn();
            apellido = new DataGridViewTextBoxColumn();
            documento = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            tel = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(264, 26);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(311, 15);
            label1.TabIndex = 0;
            label1.Text = "Listado de cuotas vencidas al día de la fecha";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Location = new Point(264, 59);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(311, 15);
            label2.TabIndex = 1;
            label2.Text = "Fecha de hoy: N/A";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Location = new Point(329, 84);
            button1.Margin = new Padding(2, 2, 2, 2);
            button1.Name = "button1";
            button1.Size = new Size(176, 34);
            button1.TabIndex = 2;
            button1.Text = "Generar Listado";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.Location = new Point(264, 136);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(311, 19);
            label3.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { codCuota, monto, codSocio, nombre, apellido, documento, email, tel });
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 187);
            dataGridView1.Margin = new Padding(2, 2, 2, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(815, 134);
            dataGridView1.TabIndex = 4;
            // 
            // codCuota
            // 
            codCuota.HeaderText = "Código de cuota";
            codCuota.Name = "codCuota";
            // 
            // monto
            // 
            monto.HeaderText = "Monto";
            monto.Name = "monto";
            // 
            // codSocio
            // 
            codSocio.HeaderText = "Código del socio";
            codSocio.Name = "codSocio";
            // 
            // nombre
            // 
            nombre.HeaderText = "Nombre";
            nombre.Name = "nombre";
            // 
            // apellido
            // 
            apellido.HeaderText = "Apellido";
            apellido.Name = "apellido";
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
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(815, 321);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
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
        private DataGridViewTextBoxColumn monto;
        private DataGridViewTextBoxColumn codSocio;
        private DataGridViewTextBoxColumn nombre;
        private DataGridViewTextBoxColumn apellido;
        private DataGridViewTextBoxColumn documento;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn tel;
    }
}