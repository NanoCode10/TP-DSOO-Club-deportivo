using ClubDeportivo.Forms.menu_home;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClubDeportivo.Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;

            /*if (usuario == "admin" && password == "123")
            {
                //MessageBox.Show("Credenciales correctas");
                frmMenuPrincipal frmMH = new frmMenuPrincipal();
                frmMH.Show();
            }
            else
            {
                MessageBox.Show("Usuario inexistente o password incorrecto");
            }*/

            DataTable tablaLogin = new DataTable(); // es la que recibe los datos desde el formulario
            Datos.Usuarios dato = new Datos.Usuarios(); // variable que contiene todas las caracteristicas de la clase
            tablaLogin = dato.Log_Usu(usuario, password);
            if (tablaLogin.Rows.Count > 0)
            {
                // quiere decir que el resultado tiene 1 fila por lo que el usuario EXISTE
                //MessageBox.Show("Ingreso exitoso");
                frmMenuPrincipal frmMH = new frmMenuPrincipal();
                frmMH.Show();
            }
            else
            {
                MessageBox.Show("Usuario y/o password incorrecto");
            }

        }


        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.UseSystemPasswordChar = false;
            }

        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";

            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.ActiveControl = btnIngresar;
  
        }
    }
}

