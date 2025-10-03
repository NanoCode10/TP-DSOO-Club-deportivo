using System;
using System.Data;
using System.Windows.Forms;
using ClubDeportivo.Datos;
using ClubDeportivo.Entidades;
using ClubDeportivo.Forms.menu_home;

namespace ClubDeportivo.Forms.registrar
{
    public partial class frmRegistrar : Form
    {
        public frmRegistrar()
        {
            InitializeComponent();
            rbSocio.Checked = true;
            cboTipoDoc.DropDownStyle = ComboBoxStyle.DropDownList;
            if (cboTipoDoc.Items.Count == 0)
            {
                cboTipoDoc.Items.AddRange(new object[] { "DNI", "LC", "LE", "Pasaporte" });
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Volver al menú principal
            var menu = new frmMenuPrincipal();
            menu.Show();
            this.Hide();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDocumento.Text = "";
            cboTipoDoc.SelectedIndex = -1;
            dtpNacimiento.Value = DateTime.Today;
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            rbSocio.Checked = true;
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación mínima como en el PDF (campos con (*))
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDocumento.Text) ||
                string.IsNullOrWhiteSpace(cboTipoDoc.Text))
            {
                MessageBox.Show("Debe completar datos requeridos (*)",
                    "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string respuesta;

                if (rbSocio.Checked)
                {
                    // Creamos entidad de socio
                    var s = new E_Socio
                    {
                        Nombre = txtNombre.Text.Trim(),
                        Apellido = txtApellido.Text.Trim(),
                        Dni = txtDocumento.Text.Trim(),
                        FechaNacimiento = DateOnly.FromDateTime(dtpNacimiento.Value.Date),
                        Direccion = txtDireccion.Text.Trim(),
                        Telefono = txtTelefono.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        FechaAlta = DateOnly.FromDateTime(DateTime.Today),
                        UltimoPago = default, // lo establece DB o luego de cobrar
                        FechaVencimiento = default
                    };

                    // Llamamos a Datos.Socios
                    var repo = new ClubDeportivo.Datos.Socio();
                    respuesta = repo.Nuevo_Socio(s);
                }
                else
                {
                    // Creamos entidad de no socio
                    var n = new E_NoSocio
                    {
                        Nombre = txtNombre.Text.Trim(),
                        Apellido = txtApellido.Text.Trim(),
                        Dni = txtDocumento.Text.Trim(),
                        FechaNacimiento = DateOnly.FromDateTime(dtpNacimiento.Value.Date),
                        Direccion = txtDireccion.Text.Trim(),
                        Telefono = txtTelefono.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        FechaDeRegistro = DateOnly.FromDateTime(DateTime.Today)
                    };

                    // Llamamos a Datos.NoSocios
                    var repo = new NoSocios();
                    respuesta = repo.Nuevo_NoSocio(n);
                }

                // Igual que el PDF: la capa Datos devuelve "1" si ya existe, o el código/ID si se creó
                if (int.TryParse(respuesta, out var codigo))
                {
                    if (codigo == 1)
                    {
                        MessageBox.Show("La persona ya existe", "AVISO DEL SISTEMA",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Se almacenó con éxito. Código/ID: {respuesta}",
                            "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLimpiar.PerformClick();
                    }
                }
                else
                {
                    // Por si la SP devuelve texto (error controlado)
                    MessageBox.Show(respuesta, "AVISO DEL SISTEMA",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}",
                    "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
