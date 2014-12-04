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
    public partial class AddArticulo : Form
    {
        ConnectDB con;
        AddPedido pedido;
        public AddArticulo(ConnectDB c,AddPedido p)
        {
            InitializeComponent();
            dgvArticulos.ClearSelection();
            this.con = c;
            this.pedido = p;
            cargarDGV();
        }

        public void cargarDGV(){
            String sentencia = "SELECT IDARTICULO,NOMBRE,COMPOSICION,PRECIO FROM ARTICULOS WHERE ELIMINADO=0";
            ejecutarConsulta(sentencia);
        }

        private void ejecutarConsulta(String sentencia)
        {
            limpiarTabla();
            DataSet resultado = con.getData(sentencia, "ARTICULOS");
            DataTable tArticulos = resultado.Tables["ARTICULOS"];
            foreach (DataRow row in tArticulos.Rows)
            {
                int id = Convert.ToInt32(row["IDARTICULO"]);
                String nombre = Convert.ToString(row["NOMBRE"]);
                String composicion = Convert.ToString(row["COMPOSICION"]);
                String precio = Convert.ToString(row["PRECIO"]);
                dgvArticulos.Rows.Add(id.ToString(),nombre, composicion, precio);

            } // Fin del bucle for each
            dgvArticulos.ClearSelection();
        }

        private void AddArticulo_Load(object sender, EventArgs e)
        {
            dgvArticulos.ClearSelection();
            dgvArticulos.Update();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            filtrar(txtNombre.Text.ToUpper(),txtPrecio.Text);
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar(txtNombre.Text.ToUpper(),txtPrecio.Text);
        }

        private void filtrar(string nombre, string precio)
        {
            String sentencia = "SELECT NOMBRE,COMPOSICION,PRECIO FROM ARTICULOS WHERE ELIMINADO=0";

            if (nombre != "")
            {
                sentencia = sentencia + " AND NOMBRE LIKE '%"+nombre+"%'";
            }
            if (precio != "")
            {
                sentencia = sentencia + " AND PRECIO LIKE '%" + precio + "%'";
            }

            ejecutarConsulta(sentencia);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            filtrar(txtNombre.Text.ToUpper(), txtPrecio.Text);
        }

        private void txtPrecio_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar(txtNombre.Text.ToUpper(), txtPrecio.Text);
        }

        public void limpiarTabla()
        {
            // Limpiamos el datagridView
            while (dgvArticulos.RowCount > 0)
            {
                dgvArticulos.Rows.Remove(dgvArticulos.CurrentRow);
            }
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            
        }
        private void añadirArticulo(int id)
        {
            
        }
    }
}
