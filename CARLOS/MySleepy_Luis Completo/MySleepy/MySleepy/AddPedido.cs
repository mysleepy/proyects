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
    }
}
