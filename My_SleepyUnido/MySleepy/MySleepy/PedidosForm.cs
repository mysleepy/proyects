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
    public partial class PedidosForm : Form
    {
        // Atributos de la clase
        ConnectDB conexion;
        int rolUsuario, refPedido, refCliente, idUsuario;

        //patron singleton
        private static PedidosForm instance;

        ////////////////////////////////////////////////////////////////////////
        ///////////////// CONSTRUCTORES /////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////

        public static PedidosForm Instance(int idRol, ConnectDB c, int idUsuario)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PedidosForm(idRol, c, idUsuario);
            }
            return instance;
        }
        private PedidosForm(int idRol, ConnectDB c, int idUsuario)
        {
            InitializeComponent();
            conexion = c;
            rolUsuario = idRol;
            refPedido = -1;
            refCliente = -1;
            this.idUsuario = idUsuario;
            cargarInicio();
        }

        public void cargarInicio()
        {
            String sentencia = " Select * from PEDIDOS where ELIMINADO=0";
            actualizarDGV(sentencia);
        }
        ////////////////////////////////////////////////////////////////////////
        ///////////////// LISTENERS BOTONES /////////////////////////////////
        ///////////////////////////////////////////////////////////////////////
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            AddPedido añadir = new AddPedido(conexion, rolUsuario, idUsuario, 0);
            añadir.Show();
            if (añadir.IsDisposed)
            {
                filtrar();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void txtReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\'')
            {
                filtrar();
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtReferencia_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar();
        }

        private void rbNoEliminados_CheckedChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void rbEliminados_CheckedChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void rbEliminados_Click(object sender, EventArgs e)
        {
            filtrar();
        }

        private void rbNoEliminados_Click(object sender, EventArgs e)
        {
            filtrar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != '\'')
            {
                filtrar();
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != '\'')
            {
                filtrar();
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\'')
            {
                filtrar();
            }
            else
            {
                e.Handled = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvPedidosRealizados.CurrentRow == null || dgvPedidosRealizados.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay ninguna fila seleccionada");
            }
            else
            {
                AddPedido modificar = new AddPedido(conexion, rolUsuario, idUsuario, 1);
                modificar.rellenar(dgvPedidosRealizados.CurrentRow);
                modificar.Show();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvPedidosRealizados.CurrentRow == null || dgvPedidosRealizados.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay ninguna fila seleccionada");
            }
            else
            {
                dgvPedidosRealizados.Rows.RemoveAt(dgvPedidosRealizados.CurrentRow.Index);
            }
        }

        ////////////////////////////////////////////////////////////////////////
        ///////////////// CARGA FORMULARIO /////////////////////////////////
        ///////////////////////////////////////////////////////////////////////
        private void Pedidos_Load(object sender, EventArgs e)
        {
            dgvPedidosRealizados.ClearSelection();
            dgvPedidosRealizados.Update();
            cargarInicio();
        }

        ////////////////////////////////////////////////////////////////////////
        ///////////////// METODOS QUE USA EL FORMULARIO ///////////////////
        ///////////////////////////////////////////////////////////////////////

        // Limpia los campos de los filtros
        private void limpiarCampos()
        {
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtReferencia.Text = "";
        }


        ///////////////////////////////////////////////////////
        // Metodo que filtra//////////////////////////////////////
        ///////////////////////////////////////////////////////
        public void filtrar()
        {
            String sentencia = "SELECT * FROM PEDIDOS WHERE ELIMINADO=0";
            if (rbEliminados.Checked == true)
            {
                sentencia = "SELECT * FROM PEDIDOS WHERE ELIMINADO=1";
            }
            if (txtReferencia.Text != "")
            {
                sentencia = sentencia + " AND N_PEDIDO LIKE '%" + Convert.ToInt32(txtReferencia.Text) + "%'";
            }
            if (txtNombre.Text != "")
            {
                int rCliente = Convert.ToInt32(conexion.DLookUp("IDCLIENTE", "CLIENTES", "NOMBRE LIKE '%" + txtNombre.Text + "%'"));
                sentencia = sentencia + " AND REFCLIENTE=" + rCliente;
            }

            sentencia = sentencia + " AND FECHA='" + dateTimePicker1.Value.ToShortDateString() + "'";

            actualizarDGV(sentencia);
        }

        // Metodo que actualiza el DATAGRIDVIEW
        private void actualizarDGV(string sentencia)
        {
            limpiarTabla();
            DataSet resultado = conexion.getData(sentencia, "PEDIDOS");
            DataTable tPedidos = resultado.Tables["PEDIDOS"];
            foreach (DataRow row in tPedidos.Rows)
            {
                int n_pedido = Convert.ToInt32(row["N_PEDIDO"]);
                String fecha = Convert.ToString(row["FECHA"]);
                String cliente = Convert.ToString(conexion.DLookUp("NOMBRE", "CLIENTES", "IDCLIENTE =" + row["REFCLIENTE"]));
                int precio = Convert.ToInt32(row["TOTAL"]);
                String pagado = Convert.ToString(row["PAGADO"]);
                dgvPedidosRealizados.Rows.Add(n_pedido, fecha, cliente, precio, pagado);

            } // Fin del bucle for each
        }

        // Limpia la tabla
        private void limpiarTabla()
        {
            // Limpiamos el datagridView
            while (dgvPedidosRealizados.RowCount > 0)
            {
                dgvPedidosRealizados.Rows.Remove(dgvPedidosRealizados.CurrentRow);
            }
        }

    }
}
