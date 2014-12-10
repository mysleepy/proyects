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
    public partial class AddPedido : Form
    {
        ConnectDB conexion;
        InsertHistorial insert;
        int id_pedido, id_articulo_añadir, precio, id_cliente, id_rol, totalpedido, idUsuario, señal;
        String n_pedido, cliente, nombre_articulo_añadir, cantidad;
        ////////////////////////////////////////////////////////////////////////
        ///////////////// CONSTRUCTORES /////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////

        public AddPedido(ConnectDB c, int idrol, int idUsuario, int señal)
        {
            InitializeComponent();
            conexion = c;
            recuperarIdPedido();
            this.id_rol = idrol;
            this.idUsuario = idUsuario;
            insert = new InsertHistorial(conexion);
            this.señal = señal;
        }

        private void AddPedido_Load(object sender, EventArgs e)
        {
            generarNumero();
            cargarComboFormasPago();
            if (señal == 1)
            {
                // Modificar pedido

            }
        }

        ////////////////////////////////////////////////////////////////////////
        ///////////////// LISTENER BOTONES  //////////////////////////////////
        ////////////////////////////////////////////////////////////////////////

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            ArticulosForm add = ArticulosForm.Instance(id_rol, conexion, idUsuario);
            add.Show();
        }

        private void btnRealizar_Click(object sender, EventArgs e)
        {
            if (cbFormaPago.SelectedIndex == -1)
            {
                guardarPedido();
            }
            else
            {
                MessageBox.Show("Tienes que rellenar la forma de pago");
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            ClientesForm clientes = ClientesForm.Instance(id_rol, 1, conexion, this, idUsuario);
            clientes.Show();
        }

        private void btnAddArticulo_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                ArticulosForm articulos = ArticulosForm.Instance(id_rol, 1, this, conexion, idUsuario);
                articulos.Show();
            }
            else
            {
                MessageBox.Show("Debes seleccionar un cliente, porfavor");
            }
        }

        private void dpFecha_ValueChanged(object sender, EventArgs e)
        {
            generarNumero();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dgvPedidos.CurrentRow == null || dgvPedidos.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay ninguna fila seleccionada");
            }
            else
            {
                disminuirTotalPedido(Convert.ToInt32(dgvPedidos.Rows[dgvPedidos.CurrentRow.Index].Cells[3].Value));
                dgvPedidos.Rows.RemoveAt(dgvPedidos.CurrentRow.Index);
            }

        }

        public void cargarCliente(String id_cliente, String nombre, String ape1, String ape2, String direccion, String poblacion)
        {
            this.id_cliente = Convert.ToInt32(id_cliente);
            txtNombre.Text = nombre;
            txtDireccion.Text = direccion;
            txtApellido1.Text = ape1;
            txtApellido2.Text = ape2;
            txtPoblacion.Text = poblacion;
        }

        

      

        public void nuevoArticulo(int id_articulo, String refArticulo, String nombre, String composicion, String medida, String precio, String cantidad)
        {
            this.id_articulo_añadir = id_articulo;
            this.nombre_articulo_añadir = nombre;
            this.precio = calcularPrecio(cantidad, precio);
            aumentarTotalPedido(this.precio);
            this.cantidad = cantidad;
            MessageBox.Show("Articulo añadido");
            actualizarDGV();
        }

        ////////////////////////////////////////////////////////////////////////
        ///////////////// METODOS PROGRAMA /////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        public void obtenerDatosCliente()
        {
            cliente = txtNombre.Text;
            n_pedido = txtNumeroPedido.Text;
        }
        private void actualizarDGV()
        {
            obtenerDatosCliente();
            dgvPedidos.Rows.Add(txtNombre.Text, nombre_articulo_añadir, cantidad, precio.ToString(), id_articulo_añadir);
        }

        public void cargarComboFormasPago()
        {
            DataSet data = new DataSet();
            DataTable tabla = new DataTable();
            data = conexion.getData("SELECT FORMAPAGO FROM FORMASDEPAGO ORDER BY IDPAGO", "FORMASDEPAGO");
            tabla = data.Tables["FORMASDEPAGO"];
            foreach (DataRow row in tabla.Rows)
            {
                cbFormaPago.Items.Add(Convert.ToString(row["FORMAPAGO"]));
            }
        }

        public void generarNumero()
        {
            DateTime fechaD = dpFecha.Value;
            DateTime today = DateTime.Today;
            if (today >= fechaD)
            {
                MessageBox.Show("Selecciona otra fecha, no puede ser inferior al sistema");
            }
            else
            {
                String fcientifica = "";
                fcientifica = devFCientifica() + id_pedido;
                txtNumeroPedido.Text = fcientifica;
            }
        }

        public String devFCientifica()
        {
            DateTime fechaD = dpFecha.Value;
            String fcientifica = "" + fechaD.Year;
            fcientifica = fcientifica + fechaD.Month;
            fcientifica = fcientifica + fechaD.Day;
            return fcientifica;
        }

        

        public int calcularPrecio(String cantidad, String precio)
        {
            int cant = Convert.ToInt32(cantidad);
            int preciot = Convert.ToInt32(precio);
            int res = cant * preciot;
            return res;
        }

        public void aumentarTotalPedido(int p)
        {
            this.totalpedido = this.totalpedido + p;
            txtTotalPedido.Text = " " + this.totalpedido;
        }
        
        private void guardarPedido()
        {
            if (dgvPedidos.RowCount > 0 || cbFormaPago.SelectedIndex > 0)
            {
                String n_pedido, cliente, articulos, cantidad, precio, id_articulo;
                while (dgvPedidos.RowCount > 0)
                {
                    n_pedido = txtNumeroPedido.Text;
                    cliente = dgvPedidos.Rows[0].Cells[0].Value.ToString();
                    articulos = dgvPedidos.Rows[0].Cells[1].Value.ToString();
                    cantidad = dgvPedidos.Rows[0].Cells[2].Value.ToString();
                    precio = dgvPedidos.Rows[0].Cells[3].Value.ToString();
                    id_articulo = dgvPedidos.Rows[0].Cells[4].Value.ToString();
                    añadirPedido(n_pedido, cliente, articulos, cantidad, precio, id_articulo);
                    dgvPedidos.Rows.RemoveAt(0);

                }
                MessageBox.Show("Pedido realizado correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Falta por seleccionar la forma de pago");
            }
        }

        private void añadirPedido(string n_pedido, string cliente, string articulos, string cantidad, string precio, string id)
        {
            String fpago = cbFormaPago.SelectedText;
            Char pagado = 'N';
            if (cbPagado.Checked)
            {
                pagado = 'S';
            }
            String select = "INSERT INTO PEDIDOS (IDPEDIDO,REFCLIENTE,REFUSUARIO,FECHA,REFFORMAPAGO,TOTAL,PAGADO,N_PEDIDO ,ELIMINADO)" +
                                "VALUES(" + conexion.siguienteID("IDPEDIDO", "PEDIDOS") + "," + Convert.ToInt32(conexion.DLookUp("IDCLIENTE", "CLIENTES", "NOMBRE='" + cliente + "'")) + "," + idUsuario + ",'" + dpFecha.Value.ToShortDateString() + "'," + (cbFormaPago.SelectedIndex + 1) + ",'" + precio + "','" + pagado + "','" + n_pedido + "'," + 0 + ")";
            String selectArticulos = "INSERT INTO PEDIDOSARTICULOS (IDPEDIDOARTICULO,REFPEDIDO,REFARTICULO,CANTIDAD,PRECIOVENTA)" +
                                " VALUES(" + Convert.ToInt32(conexion.siguienteID("IDPEDIDOARTICULO", "PEDIDOSARTICULOS")) + "," + id_pedido + "," + Convert.ToInt32(id) + "," + Convert.ToInt32(cantidad) + "," + Convert.ToInt32(precio) + ")";
            conexion.setData(select);
            conexion.setData(selectArticulos);
            // Añade el pedido
            //insert en tabla historial cambios
            insert.insertHistorialCambio(idUsuario, 1, "Pedido añadido  num_pedido->" + n_pedido);
        }

        private void recuperarIdPedido()
        {
            id_pedido = conexion.siguienteID("IDPEDIDO", "PEDIDOS");
        }
        

        private void disminuirTotalPedido(int p)
        {
            totalpedido = totalpedido - p;
            txtTotalPedido.Text = ""+totalpedido;
        } 
    }
}
