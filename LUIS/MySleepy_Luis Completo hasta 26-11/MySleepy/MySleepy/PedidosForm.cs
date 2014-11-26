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
    public partial class Pedidos : Form
    {
        ConnectDB conexion;
        public Pedidos()
        {
            InitializeComponent();
            conexion = new ConnectDB();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            AddPedido añadir = new AddPedido(conexion);
            añadir.Show();
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {
            dgvPedidos.ClearSelection();
            dgvPedidos.Update();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtReferencia.Text = "";
        }
    }
}
