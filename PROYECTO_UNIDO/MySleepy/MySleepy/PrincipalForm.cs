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
            this.BackColor = Color.Azure;
            this.conexion = c;
            this.idRol = idRol;
            this.idUsuario = idUsuario;
            tipoRol(nombre);
        }

        public PrincipalForm()
        {
            //InitializeComponent();
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
                UsuariosForm usuarios = UsuariosForm.Instance(idRol,conexion,idUsuario);
                usuarios.MdiParent = this;
                usuarios.SetDesktopLocation(-1, -1); // saldra en la esquina
                usuarios.WindowState = FormWindowState.Normal;
                usuarios.Show();
                usuarios.Focus();
            }
            else
            {
                MessageBox.Show("Los operativos no pueden acceder al menú Usuarios");
            }
           
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientesForm clientes = ClientesForm.Instance(idRol,conexion,idUsuario);
            clientes.MdiParent = this;
            clientes.SetDesktopLocation(-1, -1); // saldra en la esquina
            clientes.WindowState = FormWindowState.Normal;
            clientes.Show();
            clientes.Focus();
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArticulosForm articulos = ArticulosForm.Instance(idRol, conexion,idUsuario);
            articulos.MdiParent = this;
            articulos.SetDesktopLocation(-1, -1); // saldra en la esquina
            articulos.WindowState = FormWindowState.Normal;
            articulos.Show();
            articulos.Focus();
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
            PedidosForm pedidos = PedidosForm.Instance(idRol, conexion,idUsuario);
            pedidos.MdiParent = this;
            pedidos.SetDesktopLocation(-1, -1); // saldra en la esquina
            pedidos.WindowState = FormWindowState.Normal;
            pedidos.Show();
            pedidos.Focus();
        }

        private void PrincipalForm_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.fondo_atardecer_en_el_caribe;
         
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
                    AccesoForm acceso = AccesoForm.Instance();
                    acceso.Show();

                    this.Visible = false;
                }
        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            HistorialForm historial = HistorialForm.Instance(idUsuario,conexion);
            historial.MdiParent = this;
            historial.SetDesktopLocation(-1, -1); // saldra en la esquina
            historial.WindowState = FormWindowState.Normal;
            historial.Show();
            historial.Focus();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = Proveedor.Instance(idRol, conexion, idUsuario);
            proveedor.MdiParent = this;
            proveedor.SetDesktopLocation(-1, -1);
            proveedor.WindowState = FormWindowState.Normal;
            proveedor.Show();
            proveedor.Focus();

        }
    }
}
