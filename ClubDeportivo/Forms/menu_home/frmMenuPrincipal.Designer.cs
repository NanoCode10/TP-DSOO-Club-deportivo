namespace ClubDeportivo.Forms.menu_home
{
    partial class frmMenuPrincipal
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
            btnRegistro = new Button();
            btnCobrarCuota = new Button();
            btnCobrarActividad = new Button();
            btnListado = new Button();
            msPrincipal = new MenuStrip();
            miConexion = new ToolStripMenuItem();
            msPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // btnRegistro
            // 
            btnRegistro.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegistro.Location = new Point(129, 123);
            btnRegistro.Name = "btnRegistro";
            btnRegistro.Size = new Size(237, 79);
            btnRegistro.TabIndex = 0;
            btnRegistro.Text = "Registrar";
            btnRegistro.UseVisualStyleBackColor = true;
            btnRegistro.Click += btnRegistro_Click;
            // 
            // btnCobrarCuota
            // 
            btnCobrarCuota.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCobrarCuota.Location = new Point(129, 238);
            btnCobrarCuota.Name = "btnCobrarCuota";
            btnCobrarCuota.Size = new Size(243, 79);
            btnCobrarCuota.TabIndex = 1;
            btnCobrarCuota.Text = "Cobrar cuota";
            btnCobrarCuota.UseVisualStyleBackColor = true;
            btnCobrarCuota.Click += btnCobrarCuota_Click;
            // 
            // btnCobrarActividad
            // 
            btnCobrarActividad.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCobrarActividad.Location = new Point(412, 238);
            btnCobrarActividad.Name = "btnCobrarActividad";
            btnCobrarActividad.Size = new Size(237, 79);
            btnCobrarActividad.TabIndex = 2;
            btnCobrarActividad.Text = "Cobrar actividad";
            btnCobrarActividad.UseVisualStyleBackColor = true;
            // 
            // btnListado
            // 
            btnListado.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnListado.Location = new Point(412, 123);
            btnListado.Name = "btnListado";
            btnListado.Size = new Size(237, 79);
            btnListado.TabIndex = 3;
            btnListado.Text = "Listado de vencimientos";
            btnListado.UseVisualStyleBackColor = true;
            btnListado.Click += btnListado_Click;
            // 
            // msPrincipal
            // 
            msPrincipal.Items.AddRange(new ToolStripItem[] { miConexion });
            msPrincipal.Location = new Point(0, 0);
            msPrincipal.Name = "msPrincipal";
            msPrincipal.Size = new Size(784, 29);
            msPrincipal.TabIndex = 4;
            msPrincipal.Text = "menuStrip1";
            // 
            // miConexion
            // 
            miConexion.Alignment = ToolStripItemAlignment.Right;
            miConexion.Name = "miConexion";
            miConexion.Size = new Size(87, 25);
            miConexion.Text = "Conexión";
            miConexion.Click += miConexion_Click;
            // 
            // frmMenuPrincipal
            // 
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            ClientSize = new Size(784, 461);
            Controls.Add(btnListado);
            Controls.Add(btnCobrarActividad);
            Controls.Add(btnCobrarCuota);
            Controls.Add(btnRegistro);
            Controls.Add(msPrincipal);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = msPrincipal;
            Name = "frmMenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Club deportivo - Menú principal";
            Load += frmMenuPrincipal_Load;
            msPrincipal.ResumeLayout(false);
            msPrincipal.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Button btnRegistro;
        private Button btnCobrarCuota;
        private Button btnCobrarActividad;
        private Button btnListado;
        private MenuStrip msPrincipal;
        private ToolStripMenuItem miConexion;
    }
}