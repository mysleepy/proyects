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
        ClientesForm clientes;
        UsuariosForm usuarios;
        ArticulosForm articulos;
        PedidosForm pedidos;
        Proveedor proveedores;
        HistorialForm historial;

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
            lblTipoUsuario.BackColor = Color.Transparent;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (idRol == 1 || idRol == 2)
            {
                if (historial == null || historial.IsDisposed)
                {
                    usuarios = UsuariosForm.Instance(idRol, conexion, idUsuario);
                    usuarios.MdiParent = this;
                    usuarios.SetDesktopLocation(-1, -1); // saldra en la esquina
                    usuarios.WindowState = FormWindowState.Normal;
                    usuarios.Show();
                    usuarios.Focus();
                }
                else
                {
                    MessageBox.Show("Debe cerrar la ventana historial");
                }
            }
            else
            {
                MessageBox.Show("Los operativos no pueden acceder al menú Usuarios");
            }
           
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] ventanas = { pedidos,historial};
            if (ventanasCerradas(ventanas) == true)
            {
                clientes = ClientesForm.Instance(idRol, conexion, idUsuario);
                clientes.MdiParent = this;
                clientes.SetDesktopLocation(-1, -1); // saldra en la esquina
                clientes.WindowState = FormWindowState.Normal;
                clientes.Show();
                clientes.Focus();
            }
            else
            {
                MessageBox.Show("Debe cerrar las ventanas Pedidos y/o Historial");
            }
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] ventanas = { pedidos,historial};
            if (ventanasCerradas(ventanas) == true)
            {
                articulos = ArticulosForm.Instance(idRol, conexion, idUsuario);
                articulos.MdiParent = this;
                articulos.SetDesktopLocation(-1, -1); // saldra en la esquina
                articulos.WindowState = FormWindowState.Normal;
                articulos.Show();
                articulos.Focus();
            }
            else
            {
                MessageBox.Show("Debe cerrar las ventanas Pedidos y/o Historial");
            }
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
            Form[] ventanas = { clientes, articulos, historial, proveedores };
            if (ventanasCerradas(ventanas) == true)
            {
                pedidos = PedidosForm.Instance(idRol, conexion, idUsuario);
                pedidos.MdiParent = this;
                pedidos.SetDesktopLocation(-1, -1); // saldra en la esquina
                pedidos.WindowState = FormWindowState.Normal;
                pedidos.Show();
                pedidos.Focus();
            }
            else
            {
                MessageBox.Show("Debe cerrar todas las ventanas exceptuando Usuarios");
            }    
            
                
           
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
                DialogResult opcion = MessageBox.Show("¿Desea cerrar sesión?", "Confirmación",
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
            Form[] ventanas = { pedidos,usuarios,articulos,clientes,proveedores};
            if (ventanasCerradas(ventanas) == true)
            {
                historial = HistorialForm.Instance(idUsuario, conexion);
                historial.MdiParent = this;
                historial.SetDesktopLocation(-1, -1); // saldra en la esquina
                historial.WindowState = FormWindowState.Normal;
                historial.Show();
                historial.Focus();
                
            }
            else
            {
                MessageBox.Show("Debe cerrar el resto de ventanas para acceder al historial");
            }
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] ventanas = { pedidos, historial };
            if (ventanasCerradas(ventanas))
            {
                proveedores = Proveedor.Instance(idRol, conexion, idUsuario);
                proveedores.MdiParent = this;
                proveedores.SetDesktopLocation(-1, -1);
                proveedores.WindowState = FormWindowState.Normal;
                proveedores.Show();
                proveedores.Focus();
            }
            else
            {
                MessageBox.Show("Debe cerrar las ventanas Pedidos e Historial");
            }

        }

        private Boolean ventanasCerradas(Form[] ventanas)
        {
            Boolean cerrado =false;
            for (int i = 0; i < ventanas.Length; i++)
            {
                if (ventanas[i] == null || ventanas[i].IsDisposed )
                {
                    cerrado = true;
                }
                else
                {
                    return false;
                }
            }
            return cerrado;
        }
    }
}
