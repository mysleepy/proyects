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
    public partial class PrincipalForm : Form
    {
        ConnectDB conexion;
        int rol;

        public PrincipalForm(int idRol, ConnectDB c,String nombre)
        {
            InitializeComponent();
            this.conexion = c;
            this.rol = idRol;
            tipoRol(nombre);
        }

        private void tipoRol(String nombre)
        {
            String etiqueta = "Usted se ha identificado como "+nombre;
            lblTipoUsuario.Text = etiqueta;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuariosForm usuarios = new UsuariosForm(rol,conexion);
            usuarios.MdiParent = this;
            usuarios.SetDesktopLocation(-1, -1); // saldra en la esquina
            usuarios.WindowState = FormWindowState.Normal;
            usuarios.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientesForm clientes = new ClientesForm(rol, conexion);
            clientes.MdiParent = this;
            clientes.SetDesktopLocation(-1, -1); // saldra en la esquina
            clientes.WindowState = FormWindowState.Normal;
            clientes.Show();
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArticulosForm articulos = new ArticulosForm(rol, conexion);
            articulos.MdiParent = this;
            articulos.SetDesktopLocation(-1, -1); // saldra en la esquina
            articulos.WindowState = FormWindowState.Normal;
            articulos.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Exit();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PedidosForm pedidos = new PedidosForm(rol, conexion);
            pedidos.MdiParent = this;
            pedidos.SetDesktopLocation(-1, -1); // saldra en la esquina
            pedidos.WindowState = FormWindowState.Normal;
            pedidos.Show();
        }

        private void PrincipalForm_Load(object sender, EventArgs e)
        {
            if (rol == 3)
            {
                historialToolStripMenuItem.Visible = false;
            }
        }
    }
}
