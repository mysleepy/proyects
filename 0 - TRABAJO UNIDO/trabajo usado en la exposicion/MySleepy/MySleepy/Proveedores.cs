using Microsoft.VisualBasic;
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
        private InsertHistorial insert;

        public static Proveedor Instance(int idRol, int señal, ConnectDB c, AddPedido a, int idUsuario)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new Proveedor(idRol, señal, c, a, idUsuario);
            }
            return instance;
        }
        public static Proveedor Instance(int idRol, ConnectDB conexion, int idUsuario, DataSet ds)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new Proveedor(idRol, conexion, idUsuario, ds);
            }
            return instance;
        }
        private Proveedor(int idRol, int señal, ConnectDB c, AddPedido a, int idUsuario)
        {
            ds = XML_proveedor.leerXMLDataSet(RUTAXML);
            toolTip1 = new ToolTip();
            InitializeComponent();
            conexion = c;
            rolUsuario = idRol;
            ckEliminado = 0;
            numero = señal;
            addPedido = a;
            this.idUsuario = idUsuario;
            this.cbEA.SelectedIndex = 0;
            this.empresaAutonomo = 1;
            btnRestaurar.Enabled = false;
            cargarTablaInicio();
            insert = new InsertHistorial(c);
        }

        private Proveedor(int idRol, ConnectDB conexion, int idUsuario, DataSet ds)
        {
            this.ds = ds;
            toolTip1 = new ToolTip();
            InitializeComponent();
            this.rolUsuario = idRol;
            this.conexion = conexion;
            this.idUsuario = idUsuario;
            ckEliminado = 0;
            this.cbEA.SelectedIndex = 0;
            this.empresaAutonomo = 1;
            btnRestaurar.Enabled = false;
            cargarTablaInicio();
            insert = new InsertHistorial(conexion);
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
            DataTable dt = ds.Tables[0];
            limpiarTabla();
            ds.Tables.Clear();
            ds.Tables.Add(dt);
            int idProveedor, telefono, eliminado;
            String cif, nombre, direccion, nif;
            foreach (DataRow row in dt.Rows)
            {
                idProveedor = Convert.ToInt32(row["IDPROVEEDOR"]);
                cif = Convert.ToString(row["CIF"]);
                nombre = Convert.ToString(row["NOMBRE"]);
                telefono = Convert.ToInt32(row["TELEFONO"]);
                direccion = Convert.ToString(row["DIRECCION"]);
                eliminado = Convert.ToInt32(row["ELIMINADO"]);
                nif = Convert.ToString(row["NIF"]);
                Console.WriteLine(eliminado + " " + ckEliminado);
                if (eliminado == ckEliminado)
                {
                    if (this.empresaAutonomo == 0)
                    {
                        if (cif.Equals("-"))
                        {
                            dgvProveedores.Rows.Add(idProveedor, nif, nombre, direccion, telefono);
                        }
                    }
                    else
                    {
                        if (this.empresaAutonomo == 1)
                        {
                            if (nif.Equals("-"))
                            {
                                dgvProveedores.Rows.Add(idProveedor, cif, nombre, direccion, telefono);
                            }
                        }
                    }
                }
            }

            dgvProveedores.ClearSelection();
            dgvProveedores.Update();
        }
        public void cargarTabla(DataRow row)
        {
            limpiarTabla();
            Console.WriteLine("ME pasan la fila");
            int idProveedor, telefono, eliminado;
            String cif, nombre, direccion, nif;
            if (row != null)
            {
                idProveedor = Convert.ToInt32(row["IDPROVEEDOR"]);
                cif = Convert.ToString(row["CIF"]);
                nombre = Convert.ToString(row["NOMBRE"]);
                telefono = Convert.ToInt32(row["TELEFONO"]);
                direccion = Convert.ToString(row["DIRECCION"]);
                eliminado = Convert.ToInt32(row["ELIMINADO"]);
                nif = Convert.ToString(row["NIF"]);
                if (eliminado == ckEliminado)
                {
                    if (this.empresaAutonomo == 0)
                    {
                        if (cif.Equals("-"))
                        {
                            dgvProveedores.Rows.Add(idProveedor, nif, nombre, direccion, telefono);
                        }
                    }
                    else
                    {
                        if (this.empresaAutonomo == 1)
                        {
                            if (nif.Equals("-"))
                            {
                                dgvProveedores.Rows.Add(idProveedor, cif, nombre, direccion, telefono);
                            }
                        }
                    }
                    dgvProveedores.ClearSelection();
                    dgvProveedores.Update();
                }
            }
            else
            {
                cargarTablaInicio();
            }


        }
        //Boton salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            ds.WriteXml(RUTAXML);
            this.Dispose();
        }
        //Abro la ventana añadir proveedor
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            AddProveedor add = AddProveedor.Instance(conexion, ds,this, idUsuario);
            add.ShowDialog(this);
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
                    int id = extraerIDTabla();
                    AddProveedor add = AddProveedor.Instance(conexion, id, ds, this,idUsuario);
                    add.ShowDialog(this);
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
            toolTip1.SetToolTip(this.btnBuscar, "Buscar Proveedor");
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
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar) || e.KeyChar.Equals('\'') || txtTelefono.Text.Length >= 20)
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
                int id = this.extraerIDTabla();
                DataView dv = new DataView(ds.Tables[0]);
                dv.Sort = "IDPROVEEDOR";
                int index = dv.Find(id);
                dv[index]["ELIMINADO"] = 1;
                MessageBox.Show(this, "Proveedor eliminado", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarTablaInicio();
                //pedimos la confirmacion del borrado
                String nombreProveedor = Convert.ToString(conexion.DLookUp("NOMBRE", "PROVEEDORES", " IdProveedor = " + id));
                String mensaje = Interaction.InputBox("¿Motivo por el cual se elimina?", " Motivo", "");
                mensaje = "Proveedor borrado ->" + nombreProveedor + " Motivo ->" + mensaje;
                insert.insertHistorialCambio(idUsuario, 3, mensaje);

                cargarTablaInicio();
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

                int id = this.extraerIDTabla();
                DataView dv = new DataView(ds.Tables[0]);
                dv.Sort = "IDPROVEEDOR";
                int index = dv.Find(id);
                dv[index]["ELIMINADO"] = 0;
                MessageBox.Show(this, "Proveedor restaurado", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarTablaInicio();
                //insert en historial de cambios
                String nombreProveedor = Convert.ToString(conexion.DLookUp("NOMBRE", "PROVEEDORES", " IdProveedor = " + id));
                insert.insertHistorialCambio(idUsuario, 4, "Proveedor restaurado ->" + nombreProveedor);
            }
        }

        private void rbNoEliminados_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNoEliminados.Checked) { ckEliminado = 0; }
            rbEliminados.Checked = false;
        }

        private void rbEliminados_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEliminados.Checked) { ckEliminado = 1; }
            rbNoEliminados.Checked = false;
        }

        private void rbNoEliminados_Click(object sender, EventArgs e)
        {
            rbNoEliminados.Checked = true;
        }
        private void rbEliminados_Click(object sender, EventArgs e)
        {
            rbEliminados.Checked = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEA.SelectedIndex != -1)
            {
                txtCIFNIF.Enabled = true;
                if (cbEA.SelectedIndex == 0)
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
            else
            {
                txtCIFNIF.Enabled = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ckEliminado == 0)
            {
                btnBorrar.Enabled = true;
                btnRestaurar.Enabled = false;
            }
            else
            {
                btnBorrar.Enabled = false;
                btnRestaurar.Enabled = true;
            }
            DataTable dt = ds.Tables[0];
            int idProveedor, telefono;
            String direccion, nombre, cif, nif;
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
                    }
                }
                if (txtCIFNIF.Text.Length > 0)
                {
                    if (this.empresaAutonomo == 1)
                    {
                        if (txtCIFNIF.Text.Equals(cif))
                        {
                            fila = row;
                        }
                    }
                    else
                    {
                        if (this.empresaAutonomo == 0)
                        {
                            if (txtCIFNIF.Text.Equals(nif))
                            {
                                fila = row;
                            }
                        }

                    }
                }//fin txtCIFNIF
                if (txtTelefono.Text.Length > 0)
                {
                    int numero = Convert.ToInt32(txtTelefono.Text.Trim());
                    if (numero == telefono)
                    {
                        fila = row;
                    }
                }
                if (fila != null)
                {
                    break;
                }
            }
            cargarTabla(fila);
        }
        /// <summary>
        /// Metodo que cambia el atributo DataSet ds
        /// </summary>
        /// <param name="ds">DataSet que sustituira al  valor del atributo</param>
        public void setDS(DataSet ds)
        {
            this.ds = ds;
            cargarTablaInicio();
        }

        private void Proveedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            ds.WriteXml(RUTAXML);
        }
    }
}
