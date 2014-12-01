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
        AddArticulo formArticulos;
        int n_pedidosdia;
        int id_articulo_añadir;
        int precio;
        
        ///       ///////////////////////
        String n_pedido,cliente,nombre_articulo_añadir;
        int cantidad;
        public AddPedido(ConnectDB c)
        {
            InitializeComponent();
            conexion=c;
            formArticulos = new AddArticulo(conexion,this);
            n_pedidosdia = 0;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnArticulo_Click(object sender, EventArgs e)
        {
            AddArticulo newArticulo = new AddArticulo(conexion,this);
        }

        public void cargarCliente()
        {
            DataSet data;
            DataTable tabla;
            
            data = conexion.getData("SELECT NOMBRE,DIRECCION,APELLIDO1,APELLIDO2 FROM CLIENTES ORDER BY IDCLIENTE", "CLIENTES");
            tabla = data.Tables["CLIENTES"];
            foreach (DataRow row in tabla.Rows)
            {
                txtNombre.Text=(Convert.ToString(row["NOMBRE"]));
                txtApellido1.Text = Convert.ToString(row["APELLIDO1"]);
                txtApellido2.Text = Convert.ToString(row["APELLIDO2"]);
                txtDireccion.Text = Convert.ToString(row["DIRECCION"]);
            }
        }

        private void AddPedido_Load(object sender, EventArgs e)
        {
            cargarCliente();
            txtNumeroPedido.Text = generarNumero();
            cargarComboFormasPago();
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            formArticulos.Show();
        }

        public void nuevoArticulo(String idarticulo,String nombre,String precio)
        {
            this.id_articulo_añadir = Convert.ToInt32(idarticulo);
            this.nombre_articulo_añadir = nombre;
            this.precio = Convert.ToInt32(precio);
            txtNombreArticulo.Text = nombre;
            MessageBox.Show("Articulo con identificador " + id_articulo_añadir + " y nombre " + nombre+" ha sido añadido");
            actualizarDGV();
        }

        public void obtenerDatosCliente()
        {
            cliente = txtNombre.Text;
            n_pedido = txtNumeroPedido.Text;
            cantidad = cbACantidad.SelectedIndex;
            if (cantidad == 0)
            {
                cantidad = 1;
            }
        }
        private void actualizarDGV()
        {
            obtenerDatosCliente();
            dgvPedidos.Rows.Add(n_pedido, DateTime.Today.ToString(), Nombre, nombre_articulo_añadir, precio.ToString());
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

        public String generarNumero(){
            n_pedidosdia = n_pedidosdia + 1;
            DateTime today=DateTime.Today;
            String fcientifica =""+ today.Year;
            fcientifica = fcientifica + today.Month;
            fcientifica = fcientifica + today.Day;
            fcientifica = fcientifica + n_pedidosdia;
            return fcientifica;
        }

        private void btnRealizar_Click(object sender, EventArgs e)
        {
            guardarPedido();
        }

        private void guardarPedido()
        {
           
            String n_pedido,cliente,articulos,cantidad,precio;
            while (dgvPedidos.RowCount < 0)
            {
                n_pedido=dgvPedidos.Rows[0].Cells[0].Value.ToString();
                cliente = dgvPedidos.Rows[0].Cells[1].Value.ToString();
                articulos = dgvPedidos.Rows[0].Cells[2].Value.ToString();
                cantidad = dgvPedidos.Rows[0].Cells[3].Value.ToString();
                precio = dgvPedidos.Rows[0].Cells[4].Value.ToString();
                añadirPedido(n_pedido, cliente, articulos, cantidad, precio);
                dgvPedidos.Rows.RemoveAt(0);
            }
        }

        private void añadirPedido(string n_pedido, string cliente, string articulos, string cantidad, string precio)
        {
            String fpago=cbFormaPago.SelectedText;
            Char pagado='N';
            if (cbPagado.Checked){
                pagado='S';
            }
            String select="INSERT INTO PEDIDOS (IDPEDIDO,REFCLIENTE,REFUSUARIO,FECHA,REFFORMAPAGO,TOTAL,PAGADO,N_PEDIDO "+
                                "VALUES("+conexion.siguienteID("IDPEDIDO","PEDIDOS")+","+conexion.DLookUp("IDCLIENTE","CLIENTES","WHERE NOMBRE='"+cliente+"'")+",'"+dpFecha.Value.ToString()+"',"+conexion.DLookUp("IDPAGO","FORMASDEPAGO","WHERE FORMAPAGO='"+fpago+"'")+",'"+precio+"','"+pagado+"','"+n_pedido+"')";
            // Añade el pedido
        }

        private void cbACantidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow != null)
            {
                cantidad = cbACantidad.SelectedIndex + 1;
            }
        }

        private void dgvPedidos_SelectionChanged(object sender, EventArgs e)
        {
            actualizarArticuloCantidad();    
        }

        private void actualizarArticuloCantidad()
        {
            dgvPedidos.CurrentRow.Cells[4].Value = cantidad;
        }

        
    }
}
