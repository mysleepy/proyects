using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySleepy
{
    public partial class AccesoForm : Form
    {
        int idRol;
        ConnectDB conexion;
        public AccesoForm()
        {
            InitializeComponent();
            conexion = new ConnectDB();
            txtUsuario.LostFocus += new EventHandler(txtUsuarios_lostFocus);
            txtPassword.LostFocus += new EventHandler(txtPassword_lostFocus);
            btnAceptar.NotifyDefault(true);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validarUsuario(txtUsuario.Text))
            {
                if (validarPass())
                {
                    conseguirIdRol();
                    PrincipalForm principal = new PrincipalForm(idRol, conexion);
                    principal.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Compruebe su usuario y contraseña");
                }
            }
            else
            {
                MessageBox.Show("Compruebe su usuario y contraseña");
            }
        }

        private void conseguirIdRol()
        {
            idRol = Convert.ToInt32(conexion.DLookUp("IDROL", "USUARIOS", " WHERE  UPPER(NOMBRE)='" + txtUsuario.Text.ToUpper() + "'"));
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Boolean validarPass()
        {
            //Extraemos los campos usuario y contraseña
            String user = txtUsuario.Text;
            String pass = txtPassword.Text;

            //Encriptamos la contraseña
            String passEncriptada = BCrypt.Net.BCrypt.HashPassword(pass, BCrypt.Net.BCrypt.GenerateSalt());


            String select = "Select PASSWORD from USUARIOS where NOMBRE = '" + user + "'" + " and ELIMINADO = " +0;
            DataSet data = conexion.getData(select, "tUsuarios");

            DataTable tUsuarios = data.Tables["tUsuarios"];

            String p = "";
            foreach (DataRow row in tUsuarios.Rows)
            {
                p = Convert.ToString(row["PASSWORD"]);
                //Console.WriteLine(p);
            }
            
            if (p != "")
            {
                if (BCrypt.Net.BCrypt.Verify(pass, p))
                {
                    return true;
                }
            }
            
            return false;
            
            
        }

        public Boolean validarUsuario(String nombre)
        {
            String select = "SELECT NOMBRE FROM USUARIOS WHERE NOMBRE = '"+nombre+"'" +" and ELIMINADO = " +0;
         
            DataSet data = conexion.getData(select, "tUsuarios");

            DataTable tUsuarios = data.Tables["tUsuarios"];

            String n = "";
            foreach (DataRow row in tUsuarios.Rows)
            {
                n = Convert.ToString(row["NOMBRE"]);
                //Console.WriteLine(p);
            }

            if (n != "")
            {
                if (nombre.Equals(n))
                {
                    //Console.WriteLine("Aqui");
                    return true;
                }
            }

            return false;
        }
        public void txtUsuarios_lostFocus(object sender,EventArgs e)
        {
            if (validarUsuario(txtUsuario.Text))
            {
                pbCUsuario.Image = Properties.Resources.tick_converted;
                if (txtPassword.Text != "") {
                    txtPassword_lostFocus(sender, e);
                }
            }
            else
            {
                pbCUsuario.Image = Properties.Resources.red_green_OK_not_OK_Icons_converted;
            }
        }
        public void txtPassword_lostFocus(object sender, EventArgs e)
        {
            if (validarPass())
            {
                pbCPass.Image = Properties.Resources.tick_converted;
            }
            else
            {
                pbCPass.Image = Properties.Resources.red_green_OK_not_OK_Icons_converted;
            }
        }
    }
}
