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
        int tipoCambio;
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
            btnBorrar.Enabled = true;
            btnRestaurar.Enabled = false;
            filtrar();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            tipoCambio = 1; //tipo de cambio -> añadir
            AddUsuario add = new AddUsuario(this,0,tipoCambio,idUsuario);
            //comprobar que no este abierto los formularios addClientes etc
            add.Show();
            
            if (add.IsDisposed)
            {
                cargarTablaInicio();
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            tipoCambio = 2;
             if (idUsuario == 1)
             {
                 MessageBox.Show("El usuario ROOT no se puede modificar");
             }
             else
             {
                 AddUsuario modificar = new AddUsuario(this, 1,tipoCambio,idUsuario);
                 modificar.Show();
             }            
        }

        private void dvgUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idUsuario = extraerIDTabla();
        }

        public int extraerIDTabla()
        {
            DataGridViewRow fila = dgvUsuarios.CurrentRow;
            int id = Convert.ToInt32(fila.Cells[0].Value); //columna referente al idUsuario
            return id;
            //MessageBox.Show(""+idUsuario);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            tipoCambio = 3;
            dgvUsuarios.ClearSelection();
            //pedimos confirmacion
            DialogResult opcion = MessageBox.Show("¿Desea borrar el usuario?", "Confirmación",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (opcion == DialogResult.OK)
            {
                idUsuario = extraerIDTabla();
                if (idUsuario == 1)
                {
                    //El usuario root no se puede borrar
                    MessageBox.Show("El usuario root no se puede eliminar");
                }
                else
                {
                    if (dgvUsuarios.CurrentRow == null)
                    {
                        MessageBox.Show("Debe seleccionar una fila");
                    }
                    else
                    {
                        String update = " update USUARIOS  set ELIMINADO = " + 1 + " where IDUSUARIO=" + idUsuario;
                        conexion.setData(update);
                        
                        //Actualizar los usuarios visualizados en el data grid view
                        cargarTablaInicio();
                        insertHistorialCambio(tipoCambio, idUsuario);
                        MessageBox.Show("Usuario eliminado");
                        limpiar();
                    }
                    
                } 
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            tipoCambio = 4;
            //pedimos confirmacion
            DialogResult opcion = MessageBox.Show("¿Desea restaurar el usuario?", "Confirmación",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (opcion == DialogResult.OK)
            {
                if (dgvUsuarios.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar una fila");
                }
                else
                {
                    String update = " update USUARIOS  set ELIMINADO = " + 0 + " where IDUSUARIO=" + idUsuario;
                    conexion.setData(update);
                    insertHistorialCambio(tipoCambio, idUsuario);
                    MessageBox.Show("Usuario restaurado");

                    //Actualizar los usuarios visualizados en el data grid view
                    cargarTablaInicio();
                    limpiar() ;
                }
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
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
                select += " and upper(NOMBRE) like '%" + txtNombre.Text.ToUpper() + "%'";
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
            if (cbRoles.SelectedIndex != -1)
            {
                //extraer idRol
                String rol = cbRoles.SelectedItem.ToString();
                String select = "Select idROL from ROLES where NOMBREROL = '" + rol + "'";
                rolUsuario = extraerID(select, "IDROL", "ROLES");
                filtrar();
            }
            
        }
        public int extraerID(String select, String idTabla,String tabla)
        {
            DataSet data = conexion.getData(select, tabla);

            DataTable tRoles = data.Tables[tabla];

            int id = 0;
            foreach (DataRow row in tRoles.Rows)
            {
                id = Convert.ToInt32(row[idTabla]);

            } // Fin del bucle for each
            return id;
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar() ;
        }
        public void limpiar()
        {
            txtNombre.Text = "";
            nombre = "";
            rolUsuario = -1;
            cargarTablaInicio();
            rbNoEliminados.Checked = true;
            rbEliminados.Checked = false;
            cbRoles.SelectedIndex = -1;
            btnBorrar.Enabled = true;
            btnRestaurar.Enabled = false;
        }
        private void UsuariosForm_Load(object sender, EventArgs e)
        {
            dgvUsuarios.ClearSelection();
            dgvUsuarios.Update();
        }



        //METODOS DE HISTORIAL DE CAMBIOS -> CLASE A PARTE
        public void insertHistorialCambio(int tipoCambio,int idUsuario)
        {
            String mensaje = "";
            if (tipoCambio == 1)
            {
                mensaje = "Añadido nuevo usuario";
            }
            if (tipoCambio == 2)
            {
                mensaje = "Usuario modificado";
            }
            if (tipoCambio == 3)
            {
                mensaje = "Usuario borrado";
            }
            if(tipoCambio == 4){
                mensaje = "Usuario restaurado";
            }
            String date = System.DateTime.Today.ToString("d");
            String insert = "INSERT INTO HISTORIALCAMBIOS VALUES (" + (ultimoIDHistorial() + 1) + ", " + idUsuario +
                            " , '" + date + "', " + tipoCambio + ", '"+mensaje+"')";
            conexion.setData(insert);
            //MessageBox.Show(insert);

        }


        public int ultimoIDHistorial()
        {
            //Extraemos el id del rol seleccionado en el comboBox
            String extraerID = "Select IDHISTOCAMBIO from HISTORIALCAMBIOS";
            DataSet data = conexion.getData(extraerID, "HISTORIALCAMBIOS");

            DataTable tUsuarios = data.Tables["HISTORIALCAMBIOS"];

            int idUser = 0;
            foreach (DataRow row in tUsuarios.Rows)
            {
                idUser = Convert.ToInt16(row["IDHISTOCAMBIO"]);

            } // Fin del bucle for each

            return idUser;
        }
    }
}
