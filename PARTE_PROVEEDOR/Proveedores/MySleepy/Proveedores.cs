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
    public partial class Proveedor : Form
    {
        ConnectDB conexion;
        private int rolUsuario;
        private int ckEliminado;
        private AddPedido addPedido;
        private const String RUTAXML = "proveedor.xml";
        private int numero; // Almacena si lo llama el formulario Add pedido
        //Atributo que almacena la sentencia BASE sin filtros
        private const String SQL = "SELECT * FROM PROVEEDORES C, POBLACIONES P, CODIGOSPOSTALESPOBLACIONES X,PROVINCIAS R WHERE C.REFCPPOBLACIONES=X.IDCODIGOPOSTALPOB AND X.REFPOBLACION = P.IDPOBLACION AND X.REFPROVINCIA = R.IDPROVINCIA AND C.ELIMINADO = 0";
        private ToolTip toolTip1;
        int idUsuario;
        private int empresaAutonomo = -1;
        private static Proveedor instance;
        //Atributo que almacena el dataTable usado(sacado del xml)
        private DataSet ds;

        public static Proveedor Instance(int idRol, int señal, ConnectDB c, AddPedido a,int idUsuario)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new Proveedor(idRol, señal, c, a,idUsuario);
            }
            return instance;
        }
        public static Proveedor Instance(int idRol, ConnectDB conexion,int idUsuario)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new Proveedor(idRol,conexion,idUsuario);
            }
            return instance;
        }
        private Proveedor(int idRol,int señal, ConnectDB c,AddPedido a,int idUsuario)
        {
            toolTip1 = new ToolTip();
            InitializeComponent();
            conexion = c;
            rolUsuario = idRol;
            ckEliminado = 0;
            //cargarTabla(SQL);
            numero = señal;
            addPedido = a;
            this.idUsuario = idUsuario;
            this.cbEA.SelectedIndex = 0;
            this.empresaAutonomo = 1;
            cargarTablaInicio();
        }

        private Proveedor(int idRol, ConnectDB conexion,int idUsuario)
        {
            toolTip1 = new ToolTip();
            InitializeComponent();
            this.rolUsuario = idRol;
            this.conexion = conexion;
            this.idUsuario = idUsuario;
            ckEliminado = 0;
            this.cbEA.SelectedIndex = 0;
            this.empresaAutonomo = 1;
            cargarTablaInicio();
        }
        //Con este modo se limpia la tabla
        public void limpiarTabla()
        {
            // Limpiamos el datagridView
            while (dgvProveedores.RowCount > 0)
            {
                dgvProveedores.Rows.Remove(dgvProveedores.CurrentRow);
            }
        }

        public void cargarTablaInicio()
        {
            //solo mostraremos los no eliminados inicialmente
            ds = XML_proveedor.leerXMLDataSet(RUTAXML);
            DataTable dt = ds.Tables[0];
            limpiarTabla();
            ds.Tables.Clear();
            ds.Tables.Add(dt);
            int idProveedor, telefono;
            String cif, nombre, direccion, nif;
            foreach (DataRow row in dt.Rows)
            {
                idProveedor = Convert.ToInt32(row["IDPROVEEDOR"]);
                cif = Convert.ToString(row["CIF"]);
                nombre = Convert.ToString(row["NOMBRE"]);
                telefono = Convert.ToInt32(row["TELEFONO"]);
                direccion = Convert.ToString(row["DIRECCION"]);
                nif = Convert.ToString(row["NIF"]);
                Console.WriteLine(idProveedor + " " + cif + " " + nombre);
                if (this.empresaAutonomo == 0)
                {
                    Console.WriteLine("ENTRO");
                    dgvProveedores.Rows.Add(idProveedor, nif, nombre, direccion, telefono);
                }
                else
                {
                    if (this.empresaAutonomo == 1)
                    {
                        dgvProveedores.Rows.Add(idProveedor, cif, nombre, direccion, telefono);
                    }
                }
            }

            dgvProveedores.ClearSelection();
            dgvProveedores.Update();
        }
        public void cargarTabla(DataRow row)
        {
            limpiarTabla();
            int idProveedor,telefono;
            String cif, nombre, direccion, nif;
            if (row != null)
            {
                idProveedor = Convert.ToInt32(row["IDPROVEEDOR"]);
                cif = Convert.ToString(row["CIF"]);
                nombre = Convert.ToString(row["NOMBRE"]);
                telefono = Convert.ToInt32(row["TELEFONO"]);
                direccion = Convert.ToString(row["DIRECCION"]);
                nif = Convert.ToString(row["NIF"]);
                if (this.empresaAutonomo == 0)
                {
                    if (cif == null)
                    {
                        dgvProveedores.Rows.Add(idProveedor, nif, nombre, direccion, telefono);
                    }
                }
                else
                {
                    if (this.empresaAutonomo == 1)
                    {
                        if (nif == null)
                        {
                            dgvProveedores.Rows.Add(idProveedor, nif, nombre, direccion, telefono);
                        }
                    }
                }
            }
            
            dgvProveedores.ClearSelection();
            dgvProveedores.Update();
        }
        //Boton salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        //Abro la ventana añadir proveedor
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            AddProveedor add = AddProveedor.Instance(conexion,ds);
            add.Show();
        }
        //Abre la ventana modificar proveedor
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.ckEliminado == 0)
            {
                if (dgvProveedores.CurrentRow == null || dgvProveedores.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No ha seleccionado ninguna fila");
                }
                else
                {
                    AddProveedor add = AddProveedor.Instance(conexion, extraerIDTabla(),ds);
                    add.Show();
                }
            }
        }
        //Metodo que es llamado cuando se carga la interfaz
        private void Proveedores_Load(object sender, EventArgs e)
        {
            dgvProveedores.ClearSelection();
            dgvProveedores.Update();
            tooltip();
        }
        //Metodo que crea los tooltip de los botones
        private void tooltip()
        {
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.btnAñadir, "Añadir proveedor");
            toolTip1.SetToolTip(this.btnLimpiar, "Borrar filtros");
            toolTip1.SetToolTip(this.btnModificar, "Modificar Proveedor");
            toolTip1.SetToolTip(this.btnSalir, "Cerrar ventana");
            toolTip1.SetToolTip(this.btnBorrar, "Borrar Proveedor");
            toolTip1.SetToolTip(this.btnRestaurar, "Restaurar Proveedor");
        }       
        //Metodo para extraer id
        public int extraerIDTabla()
        {
            DataGridViewRow fila = dgvProveedores.CurrentRow;
            int id = Convert.ToInt32(fila.Cells[0].Value);
            return id;
        }//Metodo que limpia la interfaz
        public void limpiar()
        {
            txtNombre.Text = "";
            txtCIFNIF.Text = "";
            txtTelefono.Text = "";
            rbNoEliminados.Checked = true;
            rbEliminados.Checked = false;
            btnBorrar.Enabled = true;
            btnRestaurar.Enabled = false;
            cbEA.SelectedItem = -1;
            cargarTablaInicio();
        }
        
        //Metodo que controlo el textBox de Nombre
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals('\'') || txtNombre.Text.Length >= 30)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        //Metodo que controla el textBox de Apellido
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals('\'') || txtTelefono.Text.Length >= 20)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
       
        //Boton limpiar filtros
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void dgvProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (numero == 1)
            {
                addPedido.cargarCliente(dgvProveedores.CurrentRow.Cells[0].Value.ToString(), dgvProveedores.CurrentRow.Cells[1].Value.ToString(), dgvProveedores.CurrentRow.Cells[2].Value.ToString(), dgvProveedores.CurrentRow.Cells[2].Value.ToString(), dgvProveedores.CurrentRow.Cells[4].Value.ToString(), dgvProveedores.CurrentRow.Cells[5].Value.ToString());
                MessageBox.Show("Proveedor añadido al pedido");
                this.Close();
            }
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null || dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ninguna fila");
            }
            else
            {
                //metodo borrar
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null || dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("No se ha seleccionado ninguna fila");
            }
            else
            {
                //metodo restaurar
            }
        }

        private void rbNoEliminados_CheckedChanged(object sender, EventArgs e)
        {
            rbEliminados.Checked = false;
            btnBorrar.Enabled = true;
            btnRestaurar.Enabled = false;
        }
        private void rbEliminados_Click(object sender, EventArgs e)
        {
            rbNoEliminados.Checked = false;
            btnBorrar.Enabled = false;
            btnRestaurar.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEA.SelectedIndex != -1)
            {
                txtCIFNIF.Enabled = true;
                if (cbEA.SelectedText.Equals("Empresa"))
                {
                    //Es una empresa
                    empresaAutonomo = 1;
                }
                else
                {
                    //Es autonomo
                    empresaAutonomo = 0;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt = ds.Tables[0];
            int idProveedor,telefono;
            String direccion,nombre, cif,nif;
            DataRow fila = null;
            foreach (DataRow row in dt.Rows)
            {
                idProveedor = Convert.ToInt32(row["IDPROVEEDOR"]);
                cif = Convert.ToString(row["CIF"]);
                nombre = Convert.ToString(row["NOMBRE"]);
                telefono = Convert.ToInt32(row["TELEFONO"]);
                direccion = Convert.ToString(row["DIRECCION"]);
                nif = Convert.ToString(row["NIF"]);
                if (txtNombre.Text.Length > 0)
                {
                    if (txtNombre.Text.Equals(nombre))
                    {
                        fila = row;
                        break;
                    }
                }
                if (txtCIFNIF.Text.Length > 0)
                {
                    if (this.empresaAutonomo == 1)
                    {
                        if (txtCIFNIF.Text.Equals(cif))
                        {
                            fila = row;
                            break;
                        }
                    }
                    else
                    {
                        if (this.empresaAutonomo == 0)
                        {
                            if (txtCIFNIF.Text.Equals(nif))
                            {
                                fila = row;
                                break;
                            }
                        }

                    }
                }//fin txtCIFNIF
                if (txtTelefono.Text.Length >0)
                {
                    if (Convert.ToInt32(txtTelefono.Text) == telefono)
                    {
                        fila = row;
                        break;
                    }
                }
            }
            cargarTabla(fila);
        }

    }
}
