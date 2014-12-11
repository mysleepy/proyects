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
            XML_proveedor.cargarBBDDXML("proveedor.xml", "PROVEEDORES", c);
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
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArticulosForm articulos = ArticulosForm.Instance(idRol, conexion,idUsuario);
            articulos.MdiParent = this;
            articulos.SetDesktopLocation(-1, -1); // saldra en la esquina
            articulos.WindowState = FormWindowState.Normal;
            articulos.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarProveedorBBDD("proveedor.xml");
            Application.Exit();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            cargarProveedorBBDD("proveedor.xml");
            Application.Exit();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PedidosForm pedidos = PedidosForm.Instance(idRol, conexion,idUsuario);
            pedidos.MdiParent = this;
            pedidos.SetDesktopLocation(-1, -1); // saldra en la esquina
            pedidos.WindowState = FormWindowState.Normal;
            pedidos.Show();
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
        }
        /// <summary>
        /// Metodo que es llamado cuando se cierra la aplicacion(da igual el modo que sea)
        /// y realiza una copia del archivo xml pasado en la BBDD
        /// </summary>
        /// <param name="rutaXml">ruta en la que se encuentra el fichero XML</param>
        private void cargarProveedorBBDD(String rutaXml)
        {
            String[,] datos = XML_proveedor.leerXMLDataSet(rutaXml,true);
            int idProveedor;
            String sentencia;
            for(int i = 0; i< datos.Length;i++)
            {
                idProveedor = Convert.ToInt32(conexion.DLookUp("MAX(IDPROVEEDOR)", "PROVEEDORES", ""));
                if(Convert.ToInt32(datos[i,0])<=idProveedor)
                {
                    sentencia = "UPDATE PROVEEDORES set CIF = " +Convert.ToInt32(datos[i,1]) +",NOMBRE = '" + datos[i,2] + 
                        "', DIRECCION = '" +datos[i,3] + "', REFCPPOBLACIONES = " + datos[i,4] +",TELEFONO = " + datos[i,5] + 
                        ",ELIMINADO= " + datos[i,6] + ", NIF ='" + datos[i,7] + "' WHERE IDPROVEEDOR=" + datos[i,0];
                }
                else{
                    sentencia ="INSERT INTO PROVEEDORES (IDPROVEEDOR,CIF,NOMBRE,DIRECCION,REFCPPOBLACIONES,TELEFONO,ELIMINADO,NIF)" +
                                " VALUES(" + datos[i,0] + "," + datos[i,1] + ",'" + datos[i,2] + "','" + datos[i,3] + "'," + datos[i,4] +
                                "," + datos[i,5] + "," + datos[i,6] + ",'" + datos[i,7]+"')";
                }
                conexion.setData(sentencia);
            }
        }
    }
}
