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
        ArticulosForm formArticulos;
        int id_pedido;
        int id_articulo_añadir;
        int precio;
        int id_cliente;
        int id_rol;
        int totalpedido;
        InsertHistorial insert;
        int idUsuario;
        ///       ///////////////////////
        String n_pedido, cliente, nombre_articulo_añadir;
        String cantidad;
        public AddPedido(ConnectDB c, int idrol, int idUsuario)
        {
            InitializeComponent();
            conexion = c;
            recuperarIdPedido();
            this.id_rol = idrol;
            this.idUsuario = idUsuario;
            insert = new InsertHistorial(conexion);
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void AddPedido_Load(object sender, EventArgs e)
        {
            generarNumero();
            cargarComboFormasPago();
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            formArticulos.Show();
        }

        public void nuevoArticulo(String refArticulo, String nombre, String composicion, String medida, String precio, String cantidad)
        {
            this.id_articulo_añadir = Convert.ToInt32(refArticulo);
            this.nombre_articulo_añadir = nombre;
            this.precio = calcularPrecio(cantidad, precio);
            totalpedido = totalpedido + this.precio;
            aumentarTotalPedido(this.precio);
            this.cantidad = cantidad;
            MessageBox.Show("Articulo con referencia " + id_articulo_añadir + " y nombre " + nombre + " ha sido añadido");
            actualizarDGV();
        }

        public void obtenerDatosCliente()
        {
            cliente = txtNombre.Text;
            n_pedido = txtNumeroPedido.Text;
        }
        private void actualizarDGV()
        {
            obtenerDatosCliente();
            dgvPedidos.Rows.Add(n_pedido, dpFecha.Value, txtNombre.Text, nombre_articulo_añadir, cantidad, precio.ToString());
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
                recuperarIdPedido();
                String fcientifica = "" + fechaD.Year;
                fcientifica = fcientifica + fechaD.Month;
                fcientifica = fcientifica + fechaD.Day;
                fcientifica = fcientifica + id_pedido;
                txtNumeroPedido.Text = fcientifica;
            }

        }

        private void btnRealizar_Click(object sender, EventArgs e)
        {
            guardarPedido();
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
            int precioEscribir = totalpedido + p;
            txtTotalPedido.Text = " " + precioEscribir;
        }
        private void guardarPedido()
        {
            if (dgvPedidos.RowCount != 0 || cbFormaPago.SelectedIndex != 0)
            {
                String n_pedido, cliente, articulos, cantidad, precio;
                while (dgvPedidos.RowCount > 0)
                {
                    n_pedido = dgvPedidos.Rows[0].Cells[0].Value.ToString();
                    cliente = dgvPedidos.Rows[0].Cells[1].Value.ToString();
                    articulos = dgvPedidos.Rows[0].Cells[2].Value.ToString();
                    cantidad = dgvPedidos.Rows[0].Cells[3].Value.ToString();
                    precio = dgvPedidos.Rows[0].Cells[4].Value.ToString();
                    añadirPedido(n_pedido, cliente, articulos, cantidad, precio);
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

        private void añadirPedido(string n_pedido, string cliente, string articulos, string cantidad, string precio)
        {
            String fpago = cbFormaPago.SelectedText;
            Char pagado = 'N';
            if (cbPagado.Checked)
            {
                pagado = 'S';
            }
            String select = "INSERT INTO PEDIDOS (IDPEDIDO,REFCLIENTE,REFUSUARIO,FECHA,REFFORMAPAGO,TOTAL,PAGADO,N_PEDIDO " +
                                "VALUES(" + conexion.siguienteID("IDPEDIDO", "PEDIDOS") + "," + conexion.DLookUp("IDCLIENTE", "CLIENTES", "WHERE NOMBRE='" + cliente + "'") + ",'" + dpFecha.Value.ToString() + "'," + conexion.DLookUp("IDPAGO", "FORMASDEPAGO", "WHERE FORMAPAGO='" + fpago + "'") + ",'" + precio + "','" + pagado + "','" + n_pedido + "')";
            // Añade el pedido

            //insert en tabla historial cambios
            insert.insertHistorialCambio(idUsuario, 1, "Pedido añadido  num_pedido->" + n_pedido);
        }

        private void recuperarIdPedido()
        {
            id_pedido = conexion.siguienteID("IDPEDIDO", "PEDIDOS");
        }
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            ClientesForm clientes = new ClientesForm(id_rol, 1, conexion, this, idUsuario);
            clientes.Show();
        }

        private void btnAddArticulo_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                ArticulosForm articulos = new ArticulosForm(id_rol, 1, this, conexion, idUsuario);
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
            dgvPedidos.Rows.RemoveAt(dgvPedidos.CurrentRow.Index);
        } 
    }
}
