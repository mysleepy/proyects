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
    public partial class UsuariosForm : Form
    {
        private int idUsuario;
        private int señal; //dependiendo de si se pulsa el boton añadir -> señal = 0 // modificar ->  señal = 1
                   //determina la accion del boton Aceptar del formulario AddUsuario
        private int rolUsuario = -1;
        private string nombre ="";
        ConnectDB conexion;
        public UsuariosForm(int idRol, ConnectDB c)
        {
            InitializeComponent();
            this.conexion = c;
            this.rolUsuario = idRol;
            dgvUsuarios.ClearSelection();
            cargarTablaInicio();
            rellenarCombo();
            btnRestaurar.Enabled = false;
            btnBorrar.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void limpiarTabla()
        {
            // Limpiamos el datagridView
            while (dgvUsuarios.RowCount > 0)
            {
                dgvUsuarios.Rows.Remove(dgvUsuarios.CurrentRow);
            }
        }
        public void cargarTablaInicio()
        {
            //solo mostraremos los no eliminados inicialmente
            String select =  "SELECT * from USUARIOS where ELIMINADO = "+0 +"order by IDUSUARIO";
            cargarTabla(select);
        }
        public void cargarTabla(String sentencia)
        {
            
            limpiarTabla();
            int idUsuario;
            String nombre, passEncriptada;

            
            DataSet data;
            data = conexion.getData(sentencia, "USUARIOS");

            DataTable tUsuarios = data.Tables["USUARIOS"];


            foreach (DataRow row in tUsuarios.Rows)
            {
                idUsuario = Convert.ToInt32(row["IDUSUARIO"]);
                nombre = Convert.ToString(row["NOMBRE"]);
                passEncriptada = Convert.ToString(row["PASSWORD"]);

                dgvUsuarios.Rows.Add(idUsuario, nombre, passEncriptada);
                
            } // Fin del bucle for each
            dgvUsuarios.ClearSelection();
            dgvUsuarios.Update();
        }
        
        private void rbEliminados_CheckedChanged(object sender, EventArgs e)
        {
            rbNoEliminados.Checked = false;
            btnBorrar.Enabled = false;
            btnRestaurar.Enabled = true;
            //Mostramos los usuarios eliminados
            filtrar();
        }

        private void rbNoEliminados_CheckedChanged(object sender, EventArgs e)
        {
            rbEliminados.Checked = false;
            btnRestaurar.Enabled = false;
            filtrar();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            AddUsuario add = new AddUsuario(this);
            //comprobar que no este abierto los formularios addClientes etc
            add.Show();

            if (add.IsDisposed)
            {
                cargarTablaInicio();
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Extraemos los datos de la fila seleccionada -> id

            //Si el usuario con el que nos hemos conectado es root -> vamos al formulario AddUsuarios donde lo podremos cambiar todo

            //Para el resto de usuarios -> ModificarUsuario
            ModificarUsuario mod = new ModificarUsuario();
            mod.Show();

            
        }

        private void dvgUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow fila = extraerFilaSeleccionada();
            idUsuario = Convert.ToInt32(fila.Cells[0].Value); //columna referente al idUsuario
            //MessageBox.Show(""+idUsuario);
            

        }
        public DataGridViewRow extraerFilaSeleccionada()
        {
            return dgvUsuarios.CurrentRow;
            
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            dgvUsuarios.ClearSelection();
            //pedimos confirmacion
            DialogResult opcion = MessageBox.Show("¿Desea borrar el usuario?", "Confirmación",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (opcion == DialogResult.OK)
            {
                if (idUsuario == 1)
                {
                    //El usuario root no se puede borrar
                    MessageBox.Show("El usuario root no se puede eliminar");
                }
                else
                {
                    if ( extraerFilaSeleccionada()== null)
                    {
                        MessageBox.Show("Debe seleccionar una fila");
                    }
                    else
                    {
                        String update = " update USUARIOS  set ELIMINADO = " + 1 + " where IDUSUARIO=" + idUsuario;
                        conexion.setData(update);
                        MessageBox.Show("Usuario eliminado");

                        //Actualizar los usuarios visualizados en el data grid view
                        cargarTablaInicio();
                    }
                    
                } 
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            //pedimos confirmacion
            DialogResult opcion = MessageBox.Show("¿Desea restaurar el usuario?", "Confirmación",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (opcion == DialogResult.OK)
            {
                if (extraerFilaSeleccionada() == null)
                {
                    MessageBox.Show("Debe seleccionar una fila");
                }
                else
                {
                    String update = " update USUARIOS  set ELIMINADO = " + 0 + " where IDUSUARIO=" + idUsuario;
                    conexion.setData(update);
                    MessageBox.Show("Usuario restaurado");

                    //Actualizar los usuarios visualizados en el data grid view
                    cargarTablaInicio();
                }
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            nombre = txtNombre.Text;
            nombre = nombre.ToUpper();
            filtrar();
        }
        public void filtrar()
        {
            String select = "Select * from USUARIOS";
            if (rbEliminados.Checked == true)
            {
                select += " where ELIMINADO = "+ 1;
            }
            else
            {
                select += " where ELIMINADO = " + 0;
            }

            if (txtNombre.Text != "")
            {
                select += " and NOMBRE like '%" + txtNombre.Text.ToUpper() + "%'";
            }
            if (cbRoles.SelectedIndex != -1)
            {
                select += " and IDROL like '%" + rolUsuario+"%'";
            }
            select += " order by IDUSUARIO";

            cargarTabla(select);
        }
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

        private void cbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            //extraer idRol
            String rol = cbRoles.SelectedItem.ToString();
            String select = "Select idROL from ROLES where NOMBREROL = '" + rol + "'";
            rolUsuario = extraerIDRol(select);
            filtrar();
        }
        public int extraerIDRol(String select)
        {
            DataSet data = conexion.getData(select, "ROLES");

            DataTable tRoles = data.Tables["ROLES"];

            int id = 0;
            foreach (DataRow row in tRoles.Rows)
            {
                id = Convert.ToInt32(row["IDROL"]);

            } // Fin del bucle for each
            return id;
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            nombre = "";
            rolUsuario = -1;
            cargarTablaInicio();
            rbNoEliminados.Checked = true;
            rbEliminados.Checked = false;
        }

        private void UsuariosForm_Load(object sender, EventArgs e)
        {
            dgvUsuarios.ClearSelection();
            dgvUsuarios.Update();
        }
    }
}
