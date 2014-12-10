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
        int rolUsuario, refPedido, refCliente;
        DateTime fecha;
        float cantidad;
        int idUsuario;
        //patron singleton
        private static PedidosForm instance;

        ////////////////////////////////////////////////////////////////////////
        ///////////////// CONSTRUCTORES /////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////

        public static PedidosForm Instance(int idRol, ConnectDB c, int idUsuario){
            if(instance == null || instance.IsDisposed){
                instance = new PedidosForm(idRol,c,idUsuario);
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
            String sentencia = " Select N_PEDIDO,REFCLIENTE,FECHA,TOTAL,PAGADO" +
                                " from PEDIDOS" +
                                " where ELIMINADO=0";
            actualizarDGV(sentencia);
        }
        ////////////////////////////////////////////////////////////////////////
        ///////////////// LISTENERS BOTONES /////////////////////////////////
        ///////////////////////////////////////////////////////////////////////
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            AddPedido añadir = new AddPedido(conexion, rolUsuario,idUsuario,0);
            añadir.Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void txtReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            filtrar();
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
            rbNoEliminados.Enabled = false;
        }

        private void rbNoEliminados_Click(object sender, EventArgs e)
        {
            filtrar();
            rbEliminados.Enabled = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.SelectedRows.Count > 0)
            {
                AddPedido añadir = new AddPedido(conexion, rolUsuario, idUsuario, 1);
                añadir.Show();
            }
            else
            {
                MessageBox.Show("Selecciona pedidos");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.SelectedRows.Count > 0)
            {

            }
            else
            {
                MessageBox.Show("Selecciona pedidos");
            }
        }

        ////////////////////////////////////////////////////////////////////////
        ///////////////// CARGA FORMULARIO /////////////////////////////////
        ///////////////////////////////////////////////////////////////////////
        private void Pedidos_Load(object sender, EventArgs e)
        {
            dgvPedidos.ClearSelection();
            dgvPedidos.Update();
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
                sentencia="SELECT * FROM PEDIDOS WHERE ELIMINADO=1";
            }
            if (txtReferencia.Text != "")
            {
                sentencia = sentencia + " AND N_PEDIDO LIKE '%" + Convert.ToInt32(txtReferencia.Text ) + "%'";
            }
            if (txtNombre.Text != "")
            {
                int rCliente = Convert.ToInt32(conexion.DLookUp("IDCLIENTE", "CLIENTES", "NOMBRE LIKE '%" + txtNombre.Text + "%'"));
                sentencia = sentencia + " AND REFCLIENTE=" + rCliente;
            }

               sentencia=sentencia+" AND FECHA='"+dateTimePicker1.Value.ToShortDateString()+"'";

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
                dgvPedidos.Rows.Add(n_pedido, fecha, cliente, precio,pagado);

            } // Fin del bucle for each
        }

        // Limpia la tabla
        private void limpiarTabla()
        {
            // Limpiamos el datagridView
            while (dgvPedidos.RowCount > 0)
            {
                dgvPedidos.Rows.Remove(dgvPedidos.CurrentRow);
            }
        }

        // Devuelve una fecha seleccionada en el calendario 
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            fecha = e.Start;
            int dia = fecha.Day;
            int mes = fecha.Month;
            int anio = fecha.Year;
            fecha = new DateTime(anio, mes, dia);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtReferencia_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            filtrar();
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            filtrar();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            filtrar();
        }

        private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            filtrar();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            filtrar();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void txtReferencia_KeyUp_1(object sender, KeyEventArgs e)
        {
            filtrar();
        }

        


    }
}
