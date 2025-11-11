using System;
using System.Windows.Forms;
using ClubDeportivo.Datos;
using ClubDeportivo.Entidades;

namespace ClubDeportivo.Forms.editar_persona
{
    public partial class FmEditarPersona : Form
    {
        private readonly int _idPersona;
        private readonly string _tipo; // "Socio" | "NoSocio"
        private readonly Personas _repo = new();

        public FmEditarPersona(int idPersona, string tipo)
        {
            InitializeComponent();
            _idPersona = idPersona;
            _tipo = tipo;          

            // Enter = Actualizar, Esc = Cancelar
            this.AcceptButton = btnActualizar;
            this.CancelButton = btnCancelar;
        }

        private void FmEditarPersona_Load(object? sender, EventArgs e)
        {
            // Título según tipo
            this.Text = _tipo == "Socio" ? "Editar socio" : "Editar no socio";

            // ==== Combo "Tipo": ====
            if (cboTipo.Items.Count == 0)
                cboTipo.Items.AddRange(new object[] { "Socio", "No Socio" });
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.SelectedIndex = (_tipo == "Socio") ? 0 : 1;
            cboTipo.Enabled = false; // bloqueado

            // Traer datos
            var p = _repo.ObtenerPersona(_idPersona);
            if (p is null)
            {
                MessageBox.Show("No se encontró la persona.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            // Precarga
            txtNombre.Text = p.Nombre;
            txtApellido.Text = p.Apellido;
            txtDocumento.Text = p.Documento;
            txtEmail.Text = p.Email;
            txtTel.Text = p.Tel;

            // Tipo documento 
            SetComboSelectedValueIgnoreCase(cboTipoDocumento, p.TipoDocumento);

            // Apto físico
            if (cboAptoFisico.Items.Count == 0)
                cboAptoFisico.Items.AddRange(new object[] { "Si", "No" });
            cboAptoFisico.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAptoFisico.SelectedIndex = p.AptoFisico ? 0 : 1;
        }

        private static void SetComboSelectedValueIgnoreCase(ComboBox cbo, string value)
        {
            if (string.IsNullOrWhiteSpace(value)) { cbo.SelectedIndex = -1; return; }

            int found = -1;
            for (int i = 0; i < cbo.Items.Count; i++)
            {
                var t = cbo.GetItemText(cbo.Items[i]);
                if (string.Equals(t, value, StringComparison.OrdinalIgnoreCase)) { found = i; break; }
            }

            if (found >= 0)
            {
                cbo.SelectedIndex = found;
            }
            else
            {
                if (cbo.DropDownStyle == ComboBoxStyle.DropDownList)
                    cbo.Items.Add(value);
                cbo.Text = value;
            }
        }


        
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            
         
                // Validación mínima
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtDocumento.Text) ||
                    string.IsNullOrWhiteSpace(cboTipoDocumento.Text))
                {
                    MessageBox.Show("Completá los campos obligatorios (*).",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var ok = MessageBox.Show("¿Querés guardar los cambios?",
                                         "Confirmar actualización",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question,
                                         MessageBoxDefaultButton.Button2);
                if (ok != DialogResult.Yes) return;

                var p = new E_Persona
                {
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Documento = txtDocumento.Text.Trim(),
                    TipoDocumento = cboTipoDocumento.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Tel = txtTel.Text.Trim(),
                    AptoFisico = string.Equals(cboAptoFisico.Text, "Si", StringComparison.OrdinalIgnoreCase)
                };

                int r = _repo.Actualizar_persona(_idPersona, p, _tipo);
                if (r <= 0)
                {
                    MessageBox.Show("No se guardaron cambios.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
           
            
        }

        private void btnDesactivar_Click(object? sender, EventArgs e)
        {
            var ok = MessageBox.Show("¿Desactivar esta persona? No aparecerá en los listados.",
                                     "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ok != DialogResult.Yes) return;

            int r = _repo.Desactivar_persona(_idPersona);
            if (r <= 0)
            {
                MessageBox.Show("No se pudo desactivar.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
