using System;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClubDeportivo.Forms.config
{
   
    public sealed class FmConfigConexion : Form
    {
        private readonly TextBox txtServidor = new() { Width = 220 };
        private readonly TextBox txtPuerto = new() { Width = 80, Text = "3306" };
        private readonly TextBox txtBase = new() { Width = 220 };
        private readonly TextBox txtUsuario = new() { Width = 220 };
        private readonly TextBox txtClave = new() { Width = 220, UseSystemPasswordChar = true };
        private readonly Button btnProbar = new() { Text = "Probar" };
        private readonly Button btnGuardar = new() { Text = "Guardar", DialogResult = DialogResult.OK };
        private readonly Button btnCancelar = new() { Text = "Cancelar", DialogResult = DialogResult.Cancel };

        public FmConfigConexion()
        {
            Text = "Configuración de conexión";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = MaximizeBox = false;

            BuildUI();
            Load += (_, __) => LoadConfig();
            btnProbar.Click += (_, __) => Probar();
            btnGuardar.Click += (_, __) => Guardar();
        }

        private void BuildUI()
        {
            var tlp = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(12),
                ColumnCount = 2
            };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            void Row(string label, Control ctrl)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tlp.Controls.Add(new Label { Text = label, AutoSize = true, Margin = new Padding(0, 6, 8, 0) }, 0, tlp.RowCount);
                tlp.Controls.Add(ctrl, 1, tlp.RowCount);
                tlp.RowCount++;
            }

            Row("Servidor:", txtServidor);
            Row("Puerto:", txtPuerto);
            Row("Base de datos:", txtBase);
            Row("Usuario:", txtUsuario);
            Row("Clave:", txtClave);

            var pnlBtns = new FlowLayoutPanel { FlowDirection = FlowDirection.RightToLeft, Dock = DockStyle.Fill };
            pnlBtns.Controls.AddRange(new Control[] { btnGuardar, btnCancelar, btnProbar });
            tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlp.Controls.Add(pnlBtns, 0, tlp.RowCount);
            tlp.SetColumnSpan(pnlBtns, 2);

            Controls.Add(tlp);
            ClientSize = new System.Drawing.Size(420, 230);
        }

        // Base de datos fija
        private const string DB_FIXED = "clubDeportivoAACMP";
        private void LoadConfig()
        {
            var cfg = ConexionSettings.Load(); 
            txtServidor.Text = cfg.Servidor;
            txtPuerto.Text = cfg.Puerto;
            txtBase.Text = DB_FIXED;                 // constante
            txtBase.ReadOnly = true;                 // no permite escribir
            txtBase.TabStop = false;                 // no entra con TAB
            txtBase.ShortcutsEnabled = false;        // evita pegar con Ctrl+V
            txtBase.BackColor = SystemColors.Control;   // gris del formulario
            txtBase.ForeColor = SystemColors.GrayText;  // texto gris
            txtBase.BorderStyle = BorderStyle.FixedSingle; // look
            txtUsuario.Text = cfg.Usuario;
            txtClave.Text = cfg.Clave;
        }

        private void Probar()
        {
            try
            {
                var cs = $"server={txtServidor.Text};port={txtPuerto.Text};" +
                         $"user={txtUsuario.Text};password={txtClave.Text};" +
                         $"Database={DB_FIXED};";                     // <- fija
                using var cn = new MySqlConnection(cs);
                cn.Open();
                MessageBox.Show("Conexión exitosa.", "Probar conexión",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar.\n\n" + ex.Message,
                                "Probar conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void Guardar()
        {
            if (string.IsNullOrWhiteSpace(txtServidor.Text) ||
                string.IsNullOrWhiteSpace(txtPuerto.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text)) // <- ya no valida texto
            {
                MessageBox.Show("Servidor, Puerto y Usuario son obligatorios.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            var cfg = new ConexionSettings
            {
                Servidor = txtServidor.Text.Trim(),
                Puerto = txtPuerto.Text.Trim(),
                BaseDatos = DB_FIXED,               // <- fija
                Usuario = txtUsuario.Text.Trim(),
                Clave = txtClave.Text
            };
            cfg.Save();
            MessageBox.Show("Conexión guardada.\n(Nuevas conexiones usarán estos datos).",
                "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
