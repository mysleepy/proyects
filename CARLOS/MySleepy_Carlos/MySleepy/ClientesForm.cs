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
    public partial class ClientesForm : Form
    {
        ConnectDB conexion;
        private int rolUsuario;
        private int ckEliminado;

        public ClientesForm(int idRol, ConnectDB c)
        {
            InitializeComponent();
            conexion = c;
            rolUsuario = idRol;
            ckEliminado = 0;
            cargarTabla();
            
        }
        //Con este modo se limpia la tabla
        public void limpiarTabla()
        {
            // Limpiamos el datagridView
            while (dgvClientes.RowCount > 0)
            {
                dgvClientes.Rows.Remove(dgvClientes.CurrentRow);
            }
        }
        //Con este metodo cargo la tabla Clientes
        public void cargarTabla()
        {
            limpiarTabla();
            int idCliente,telefono;
            String nombre, apellido, direccion, poblacion, email;

            String sentencia = "SELECT * FROM CLIENTES C, POBLACIONES P, CODIGOSPOSTALESPOBLACIONES X,PROVINCIAS R WHERE C.REFCPPOBLACIONES=X.IDCODIGOPOSTALPOB AND X.REFPOBLACION = P.IDPOBLACION AND X.REFPROVINCIA = R.IDPROVINCIA AND C.ELIMINADO ="+this.ckEliminado+" order by C.IDCLIENTE";
            DataSet data;
            data = conexion.getData(sentencia, "CLIENTES");

            DataTable tClientes = data.Tables["CLIENTES"];
            

            foreach (DataRow row in tClientes.Rows)
            {
                idCliente = Convert.ToInt32(row["IDCLIENTE"]);
                nombre = Convert.ToString(row["NOMBRE"]);
                apellido = Convert.ToString(row["APELLIDO1"]);
                telefono = Convert.ToInt32(row["TELEFONO"]);
                direccion = Convert.ToString(row["DIRECCION"]);
                poblacion = Convert.ToString(row["POBLACION"]);
                email = Convert.ToString(row["EMAIL"]);

                dgvClientes.Rows.Add(idCliente,nombre,apellido,telefono,direccion,poblacion,email);
            } // Fin del bucle for each
            dgvClientes.ClearSelection();
            dgvClientes.Update();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Abro la ventana añadir clientes
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            AddCliente add = new AddCliente(conexion);
            add.Show();
            if (add.IsDisposed)
            {
                cargarTabla();
            }
            
        }

        private void ClientesForm_Load(object sender, EventArgs e)
        {
            dgvClientes.ClearSelection();
            dgvClientes.Update();
        }

        private void ckbBorrar_CheckedChanged(object sender, EventArgs e)
        {
            
            if (ckbBorrar.Checked == true)
            {
                this.ckEliminado = 1;
                btnBorrar.Text = "Restaurar";
            }
            else
            {
                this.ckEliminado = 0;
                btnBorrar.Text = "Borrar";
            }
            cargarTabla();
        }
        //Metodo para extraer id
        public int extraerIDTabla()
        {
            DataGridViewRow fila = dgvClientes.CurrentRow;
            int id = Convert.ToInt32(fila.Cells[0].Value);
            return id;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows != null)
            {
                int idClienteSel =extraerIDTabla();
                AddCliente add = new AddCliente(conexion, idClienteSel);
                add.Show();
                if (add.IsDisposed)
                {
                    cargarTabla();
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            String mensaje,mensajeConf;
            int eliminar_rest;
            if(this.ckEliminado == 0){
                mensaje = "¿Desea borrar al cliente?";
                mensajeConf = "Cliente borrado correctamente";
                eliminar_rest = 1;
            }
            else{
                mensaje = "¿Desea restaurar al cliente?";
                mensajeConf = "Cliente restaurado correctamente";
                eliminar_rest = 0;
            }
            int idCliente;
            dgvClientes.ClearSelection();
            //pedimos confirmacion
            DialogResult opcion = MessageBox.Show(mensaje, "Confirmación",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (opcion == DialogResult.OK)
            {
                idCliente = extraerIDTabla();
                if (dgvClientes.CurrentRow == null)
                    {
                        MessageBox.Show("Debe seleccionar una fila");
                    }
                    else
                    {
                        String update = " UPDATE CLIENTES  set ELIMINADO = " + eliminar_rest + " where IDCLIENTE=" + idCliente;
                        conexion.setData(update);

                        //Actualizar los usuarios visualizados en el data grid view
                        MessageBox.Show(mensajeConf,"Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        limpiar();
                    }

                }
            }
            //Metodo que limpia la interfaz
            public void limpiar()
            {
                txtNombre.Text = "";
                txtReferencia.Text = "";
                txtPoblacion.Text = "";
                cargarTabla();
            }
        }
    }

