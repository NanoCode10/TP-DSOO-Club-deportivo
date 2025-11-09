using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClubDeportivo.Datos;

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

        }

        private void frmActividades_Load(object sender, EventArgs e)
        {
            CargarPersonas("NoSocio");
            CargarActividades();
        }

        private void btnPagoActividad_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Actividad pagada con éxito",
                    "Aviso del sistema", MessageBoxButtons.OK);
        }
    }
}
