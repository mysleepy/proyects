using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySleepy;

namespace MySleepy
{
    public partial class AddUsuario : Form
    {
        MySleepy.ConnectDB conexion;
        String pass;
        UsuariosForm usuario;
        String mensajeError = "Por favor rellene los campos vacíos : ";
        public AddUsuario(UsuariosForm u)
        {
            InitializeComponent();
            usuario = u;
            txtRepetirPassword.LostFocus += new EventHandler(txtRepetirPassword_lostFocus);
            txtNombre.LostFocus += new EventHandler(txtNombre_lostFocus);
            conexion = new MySleepy.ConnectDB();

            rellenarCombo();
        }


        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            //Actualizamos la tabla
            usuario.cargarTablaInicio();
            
        }
        
        public void txtRepetirPassword_lostFocus(object sender, EventArgs e)
        {
            coincidenciaPassword();

        }
        public void txtNombre_lostFocus(object sender, EventArgs e)
        {
            //Comprobamos que no haya un usuario con ese nombre en la base de datos
            if (usuarioRepetido(txtNombre.Text))
            {
                lblNombre.Text = " Usuario repetido";
            }
            else
            {
                lblNombre.Text = "";
            }

        }
        
        private void chbMostrar_CheckedChanged(object sender, EventArgs e)
        {
            //txtPassword.PasswordChar;

        }
        //comprueba que todos los campos tengan datos -> todos son necesarios excepto el checkBox Mostrar
        
        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (vacio())
            {
                MessageBox.Show(mensajeError);
            }
            else
            {
                //Pedimos confirmacion
                DialogResult opcion = MessageBox.Show("¿Desea crear el usuario?", "Confirmación",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (opcion == DialogResult.OK)
                {
                    int idRol = extraerIDRol();
                    //Creamos el usuario, por defecto a no eliminado
                    String insert = "Insert into USUARIOS values ( " + (ultimoIDUser() + 1) + ", '"
                                       + txtNombre.Text + "' , '" + encriptarPassword() + "' ," + 0 + "," + idRol + ")";
                    //Console.WriteLine(insert);
                    //realizamos el insert
                    conexion.setData(insert);
                    MessageBox.Show("Usuario creado");
                }         
            }
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letra = e.KeyChar;

            if (Char.IsDigit(letra))
            {
                lblNombre.Text = "No se permiten numeros";
            }
            else
            {
                lblNombre.Text = "";
            }
        }
        public Boolean vacio()
        {
            Boolean vacio = false;
            if (txtNombre.Text.Equals(""))
            {
                mensajeError += " nombre  ";
                vacio = true;
            }
            if (txtPassword.Text.Equals(""))
            {
                mensajeError += " password  ";
                vacio = true;
            }
            if (txtRepetirPassword.Equals(""))
            {
                mensajeError += " confirmación contraseña";
                vacio = true;
            }
            if (cbRoles.SelectedIndex == -1)
            {
                mensajeError += " rol";
                vacio = true;
            }
            return vacio;
        }
        //comprueba si en la base de datos ya exite un usuario con el mismo nombre
        public Boolean usuarioRepetido(String user)
        {
            Boolean repetido = false;
            String select = "Select * from USUARIOS";
            DataSet data = conexion.getData(select, "USUARIOS");
            DataTable tUsuarios = data.Tables["USUARIOS"];

            String nombreUser = "";
            foreach (DataRow row in tUsuarios.Rows)
            {
                //Comparamos
                nombreUser = Convert.ToString(row["NOMBRE"]);
                if (nombreUser.Equals(user))
                {
                    repetido = true;
                }

            } // Fin del bucle for each
            return repetido;
        }
        public Boolean coincidenciaPassword()
        {
            pass = txtPassword.Text;
            if (!pass.Equals(txtRepetirPassword.Text))
            {
                lblError.Text = "No coincide";
                return false;
            }
            else
            {
                return true;
            }
        }
        public String encriptarPassword()
        {
            String passEncriptada = "";
            //Extraemos el texto de la caja contraseña (si ambos textos de las cajas coinciden)
            if (coincidenciaPassword())
            {
                String pass = txtPassword.Text;
                passEncriptada = BCrypt.Net.BCrypt.HashPassword(pass, BCrypt.Net.BCrypt.GenerateSalt());
            }
            return passEncriptada;

        }

        //metodo rellenar comboBox
        public void rellenarCombo()
        {
            //Select tabla roles -> Nombre roles y cada elemento al comboBox
            String select = "Select NOMBREROL from ROLES ";

            //realizar el select 
            DataSet data = conexion.getData(select, "ROLES");

            DataTable tRoles = data.Tables["ROLES"];

            String nombre;
            foreach (DataRow row in tRoles.Rows)
            {
                nombre = Convert.ToString(row["NOMBREROL"]);

                //añadir a comboBox
                cbRoles.Items.Add(nombre);

            } // Fin del bucle for each
        }
        public int extraerIDRol()
        {
            //Extraemos el id del rol seleccionado en el comboBox
            String extraerID = "Select IDROL from ROLES where NOMBREROL = '" + cbRoles.SelectedItem+"'";
            DataSet data = conexion.getData(extraerID, "ROLES");

            DataTable tRoles = data.Tables["ROLES"];

            int idRol = 0;
            foreach (DataRow row in tRoles.Rows)
            {
                idRol = Convert.ToInt16(row["IDROL"]);

            } // Fin del bucle for each

            return idRol;

        }

        public int ultimoIDUser()
        {
            //Extraemos el id del rol seleccionado en el comboBox
            String extraerID = "Select IDUSUARIO from USUARIOS";
            DataSet data = conexion.getData(extraerID, "USUARIOS");

            DataTable tUsuarios = data.Tables["USUARIOS"];

            int idUser = 0;
            foreach (DataRow row in tUsuarios.Rows)
            {
                idUser = Convert.ToInt16(row["IDUSUARIO"]);

            } // Fin del bucle for each

            return idUser;
        }

        
        
    }
}
