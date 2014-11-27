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
        //Con este metodo cargo la tabla Clientes
        public void cargarTabla()
        {
            int idCliente,telefono;
            String nombre, apellido, direccion, poblacion, email;

            String sentencia = "SELECT C.IDCLIENTE,C.NOMBRE,C.APELLIDO1,C.TELEFONO,C.DIRECCION,P.POBLACION,C.EMAIL"+
                "FROM CLIENTES C, POBLACIONES P WHERE C.REFCPPOBLACIONES=(SELECT IDCODIGOPOSTALPOB FROM CODIGOSPOSTALESPOBLACIONES"+
                "   WHERE REFPOBLACION = P.IDPOBLACION) AND C.ELIMINADO ="+ckEliminado;
            DataSet data;
            data = conexion.getData(sentencia, "tClientes");

            DataTable tClientes = data.Tables["tClientes"];
            

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
            }
            else
            {
                this.ckEliminado = 0;
            }
            cargarTabla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows != null)
            {
                int idClienteSel = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value.ToString());
                AddCliente add = new AddCliente(conexion, idClienteSel);
                add.Show();
                if (add.IsDisposed)
                {
                    cargarTabla();
                }
            }
        }
    }
}
