using ClubDeportivo.Datos;
using ClubDeportivo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo.Forms.actividades
{
    public partial class frmActividades : Form
    {
        public frmActividades()
        {
            InitializeComponent();
        }

        private void MostrarDataTableMessageBox(DataTable dt)

        {
            var sb = new StringBuilder();
            foreach (DataColumn col in dt.Columns) sb.Append(col.ColumnName).Append(" | ");
            sb.AppendLine();
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                    sb.Append(row[col]?.ToString()).Append(" | ");
                sb.AppendLine();
            }
            MessageBox.Show(sb.ToString(), "Contenido DataTable");
        }

        private void CargarPersonas(string tipo)
        {
            var persona = new Personas();
            DataTable dt = persona.Listar_personas(tipo);

            // Si no existe la columna calculada, crearla
            if (!dt.Columns.Contains("NombreCompleto"))
                dt.Columns.Add("NombreCompleto", typeof(string), "nombre + ' ' + apellido");

            string valueMember = tipo == "Socio" ? "codSocio" : "codNoSocio";
            if (!dt.Columns.Contains(valueMember))
                throw new Exception($"La columna '{valueMember}' no existe en el DataTable.");

            DataRow filaSeleccionar = dt.NewRow();

            // IMPORTANTE: no intentar asignar a la columna calculada.
            // En su lugar, asignar las columnas que la alimentan.
            if (dt.Columns.Contains("nombre")) filaSeleccionar["nombre"] = "Seleccionar...";
            if (dt.Columns.Contains("apellido")) filaSeleccionar["apellido"] = ""; 
            filaSeleccionar[valueMember] = DBNull.Value; 

            dt.Rows.InsertAt(filaSeleccionar, 0);

            cboNoSocio.DataSource = dt;
            cboNoSocio.DisplayMember = "NombreCompleto";
            cboNoSocio.ValueMember = valueMember;
            cboNoSocio.SelectedIndex = 0;
        }

        private void CargarActividades()
        {
            var datos = new Actividades();
            DataTable dt = datos.ListarActividades();

            DataRow fila = dt.NewRow();
            fila["codActividad"] = 0;
            fila["nombre"] = "Seleccionar...";
            dt.Rows.InsertAt(fila, 0);

            cboActividad.DataSource = dt;
            cboActividad.DisplayMember = "nombre";
            cboActividad.ValueMember = "codActividad";

            cboActividad.SelectedIndex = 0;
        }

        private void cboActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboActividad.SelectedValue != null &&
                cboActividad.SelectedValue != DBNull.Value)
            {
                // Obtener el valor correctamente usando TryParse
                if (int.TryParse(cboActividad.SelectedValue.ToString(), out int codActividad) && codActividad > 0)
                {
                    var datos = new Actividades();
                    decimal costo = datos.ObtenerCostoActividad(codActividad);

                    // Mostrar el monto en el Label
                    lblMontoValor.Text = $"${costo:N2}";
                }
                else
                {
                    lblMontoValor.Text = "$0.00";
                }
            }
            else
            {
                lblMontoValor.Text = "$0.00";
            }
        }

        private void frmActividades_Load(object sender, EventArgs e)
        {
            CargarPersonas("NoSocio");
            CargarActividades();
        }

        private void btnPagoActividad_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones simplificadas
                if (!int.TryParse(cboNoSocio.SelectedValue?.ToString(), out int idNoSocio) || idNoSocio == 0)
                {
                    MessageBox.Show("Debe seleccionar un No Socio", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(cboActividad.SelectedValue?.ToString(), out int codActividad) || codActividad == 0)
                {
                    MessageBox.Show("Debe seleccionar una actividad", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener el costo de la actividad
                var actividadesDatos = new Actividades();
                decimal monto = actividadesDatos.ObtenerCostoActividad(codActividad);

                // Crear el objeto E_Pago_Eventual
                var pago = new E_Pago_Eventual
                {
                    IdNoSocio = idNoSocio,
                    Monto = monto,
                    Fecha = DateTime.Today
                };

                // Registrar el pago usando la nueva clase
                var pagosEventuales = new Pagos_Eventuales();
                bool resultado = pagosEventuales.RegistrarPagoEventual(pago);

                if (resultado)
                {
                    MessageBox.Show($"Pago eventual registrado exitosamente\nMonto: ${monto:N2}",
                                   "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Limpiar selecciones
                    cboActividad.SelectedIndex = 0;
                    cboNoSocio.SelectedIndex = 0;
                    lblMontoValor.Text = "$0.00"; // ← También limpiar el monto
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el pago", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el pago: {ex.Message}",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
