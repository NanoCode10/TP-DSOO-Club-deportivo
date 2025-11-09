using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo.Forms.listar_vencimientos
{
    public partial class frmListarVencimientos : Form
    {
        public frmListarVencimientos()
        {
            InitializeComponent();

        }

        /* intento fallido de alinear horizontalmente
        private void CentrarHorizontalmente()
        {
            // centrar labels
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            label2.Left = (this.ClientSize.Width - label2.Width) / 2;
            label3.Left = (this.ClientSize.Width - label2.Width) / 2;
        }
        */

        private void frmListarVencimientos_Load(object sender, EventArgs e)
        {
            //ajustes esteticos y de inicialización de texto
            //CentrarHorizontalmente();
            DateTime fechaHoy = DateTime.Today;
            label2.Text = $"Fecha de hoy: {fechaHoy.ToString("dd/MM/yyyy")}";
            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void frmListarVencimientos_Resize(object sender, EventArgs e)
        {
            //CentrarHorizontalmente();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tablaVenc = new DataTable();
            Datos.Vencimientos vencimientos = new Datos.Vencimientos(); 
            //instancio la clase vencimientos
            tablaVenc = vencimientos.ListarVencimientos(); 
            //no lleva parametro, lo calcula dentro

            if (tablaVenc.Rows.Count > 0)
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Refresh(); 
                dataGridView1.DataSource = tablaVenc;
            }
            else
            {
                label3.Text = "No hay vencimientos el día de hoy.";
            }
        }

    }
}
