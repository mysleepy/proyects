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
        int idRol;
        int idUsuario;
        public PrincipalForm(int idUsuario,int idRol, ConnectDB c,String nombre)
        {
            InitializeComponent();
            this.conexion = c;
            this.idRol = idRol;
            this.idUsuario = idUsuario;
            tipoRol(nombre);
        }

        private void tipoRol(String nombre)
        {
            String etiqueta = "Usted se ha identificado como "+nombre;
            lblTipoUsuario.Text = etiqueta;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (idRol == 1 || idRol == 2)
            {
                UsuariosForm usuarios = new UsuariosForm(idRol, conexion);
                usuarios.MdiParent = this;
                usuarios.SetDesktopLocation(-1, -1); // saldra en la esquina
                usuarios.WindowState = FormWindowState.Normal;
                usuarios.Show();
            }
            else
            {
                MessageBox.Show("Los operativos no pueden acceder al menú Usuarios");
            }
           
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientesForm clientes = new ClientesForm(idRol,conexion);
            clientes.MdiParent = this;
            clientes.SetDesktopLocation(-1, -1); // saldra en la esquina
            clientes.WindowState = FormWindowState.Normal;
            clientes.Show();
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArticulosForm articulos = new ArticulosForm(idRol, conexion);
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
            PedidosForm pedidos = new PedidosForm(idRol, conexion);
            pedidos.MdiParent = this;
            pedidos.SetDesktopLocation(-1, -1); // saldra en la esquina
            pedidos.WindowState = FormWindowState.Normal;
            pedidos.Show();
        }

        private void PrincipalForm_Load(object sender, EventArgs e)
        {
            if (idRol == 3)
            {
                historialToolStripMenuItem.Visible = false;
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Pedimos confirmacion
            //Pedimos confirmacion
                DialogResult opcion = MessageBox.Show("¿Desea cerrar sesión?", "Cocnfirmación",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (opcion == DialogResult.OK)
                {
                    //Cerramos la ventana principal y mostramos la ventana de AccesoForm
                    AccesoForm acceso = new AccesoForm();
                    acceso.Show();

                    this.Visible = false;
                }
        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            HistorialForm historial = new HistorialForm(idUsuario,conexion);//cambiar el idUsuario, lo recibe de AccesoForm;
            historial.MdiParent = this;
            historial.SetDesktopLocation(-1, -1); // saldra en la esquina
            historial.WindowState = FormWindowState.Normal;
            historial.Show();
        }
    }
}
