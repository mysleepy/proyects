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
        String nombreCliente;
        DateTime fecha;
        float cantidad;
 
        ////////////////////////////////////////////////////////////////////////
        ///////////////// CONSTRUCTORES /////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        public PedidosForm(int idRol, ConnectDB c)
        {
            InitializeComponent();
            conexion = c;
            rolUsuario = idRol;
            refPedido = -1;
            refCliente = -1;
        }

        ////////////////////////////////////////////////////////////////////////
        ///////////////// LISTENERS BOTONES /////////////////////////////////
        ///////////////////////////////////////////////////////////////////////
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            AddPedido añadir = new AddPedido(conexion,rolUsuario);
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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            buscarFecha(fecha);
        }


        ////////////////////////////////////////////////////////////////////////
        ///////////////// CARGA FORMULARIO /////////////////////////////////
        ///////////////////////////////////////////////////////////////////////
        private void Pedidos_Load(object sender, EventArgs e)
        {
            dgvPedidos.ClearSelection();
            dgvPedidos.Update();
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

        // Comprueba los campos, y asigna los valores
        public void comprobarCampos()
        {
            refPedido = Convert.ToInt32(txtReferencia.Text);
            buscarCliente();
            buscarFecha(fecha);
            cantidad = float.Parse(txtPrecio.Text);
        }

        // Busca el cliente en la base de datos y los pedidos que tiene asociados
        private void buscarCliente()
        {
            String sentencia = "SELECT P.REFCLIENTE FROM PEDIDOS P,CLIENTE C WHERE P.REFCLIENTE=C.IDCLIENTE AND C.NOMBRE='" + txtNombre.Text.ToUpper() + "'";
            DataSet res = conexion.getData(sentencia, "PEDIDOS");
            DataTable tabla = res.Tables[("PEDIDOS")];

            foreach (DataRow row in tabla.Rows)
            {
                refCliente = Convert.ToInt32(row["REFCLIENTE"]);
            }
        }

        // Busca pedidos filtrando por fecha
        private void buscarFecha(DateTime fecha)
        {
            MessageBox.Show(fecha.ToString());
            
        }

        ///////////////////////////////////////////////////////
        // Metodo que filtra
        public void filtrar()
        {
            comprobarCampos();
            String sentencia = "SELECT NºPEDIDO,FECHA,CLIENTE,ARTICULOS,PRECIO FROM PEDIDOS WHERE ELIMINADO=0";
            if (refPedido != 0)
            {
                sentencia=sentencia+" AND REFPEDIDO LIKE '%"+refPedido+"%'";
            }
            if (refCliente != 0)
            {
                sentencia=sentencia+" AND REFPEDIDO LIKE '%"+refCliente+"%'";
            }

            if (fecha != null)
            {
                buscarFecha(fecha);
            }

            actualizarDGV(sentencia);
        }

        // Metodo que actualiza el DATAGRIDVIEW
        private void actualizarDGV(string sentencia)
        {
            limpiarTabla();
            DataSet resultado = conexion.getData(sentencia, "PEDIDOS");
            DataTable tPedidos = resultado.Tables["PEDIDOSs"];
            foreach (DataRow row in tPedidos.Rows)
            {
                int referencia = Convert.ToInt32(row["REFERENCIA"]);
                String nombre = Convert.ToString(row["NOMBRE"]);
                String composicion = Convert.ToString(row["COMPOSICION"]);
                String medida = Convert.ToString(row["MEDIDA"]);
                String precio = Convert.ToString(row["PRECIO"]);
                dgvPedidos.Rows.Add(referencia, nombre, composicion, medida, precio);

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
            fecha=e.Start;
            int dia=fecha.Day;
            int mes = fecha.Month;
            int anio = fecha.Year;
            fecha = new DateTime(anio, mes, dia);
        }

        
    }
}
