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
        public AddPedido(ConnectDB c)
        {
            InitializeComponent();
            conexion=c;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnArticulo_Click(object sender, EventArgs e)
        {
            AddArticulo newArticulo = new AddArticulo(conexion);
        }

        public void cargarCliente()
        {
            DataSet data;
            DataTable tabla;
            //Cargo el combo box de comunidades autonomas
            data = conexion.getData("SELECT NOMBRE,DIRECCION,APELLIDO1,APELLIDO2 FROM CLIENTES ORDER BY IDCLIENTE", "CLIENTES");
            tabla = data.Tables["CLIENTES"];
            foreach (DataRow row in tabla.Rows)
            {
                cbNombre.Items.Add(Convert.ToString(row["NOMBRE"]));
                txtApellido1.Text = Convert.ToString(row["APELLIDO1"]);
                txtApellido2.Text = Convert.ToString(row["APELLIDO2"]);
                txtDireccion.Text = Convert.ToString(row["DIRECCION"]);
            }
        }

        private void AddPedido_Load(object sender, EventArgs e)
        {
            cargarCliente();
        }
    }
}
