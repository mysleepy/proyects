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
        private int numero; // Almacena si lo llama el formulario Add pedido
        //Atributo que almacena la sentencia BASE sin filtros
        private const String SQL = "SELECT * FROM PROVEEDORES C, POBLACIONES P, CODIGOSPOSTALESPOBLACIONES X,PROVINCIAS R WHERE C.REFCPPOBLACIONES=X.IDCODIGOPOSTALPOB AND X.REFPOBLACION = P.IDPOBLACION AND X.REFPROVINCIA = R.IDPROVINCIA AND C.ELIMINADO = 0";
        private ToolTip toolTip1;

        private static Proveedor instance;

        public static Proveedor Instance(int idRol, int señal, ConnectDB c, AddPedido a)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new Proveedor(idRol, señal, c, a);
            }
            return instance;
        }
        public static Proveedor Instance(int idRol, ConnectDB conexion)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new Proveedor(idRol,conexion);
            }
            return instance;
        }
        private Proveedor(int idRol,int señal, ConnectDB c,AddPedido a)
        {
            toolTip1 = new ToolTip();
            InitializeComponent();
            conexion = c;
            rolUsuario = idRol;
            ckEliminado = 0;
            //cargarTabla(SQL);
            numero = señal;
            addPedido = a;
        }

        private Proveedor(int idRol, ConnectDB conexion)
        {
            toolTip1 = new ToolTip();
            InitializeComponent();
            this.rolUsuario = idRol;
            this.conexion = conexion;
            //cargarTabla(SQL);
            ckEliminado = 0;
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
        //Boton salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        //Abro la ventana añadir proveedor
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            //AddCliente add;
            //add.Show();
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
            tooltipBorrar();
        }
        private void tooltipBorrar()
        {
            toolTip1.SetToolTip(this.btnBorrar, null);
            String borrar = "";
            if (this.ckEliminado == 0)
            {
                borrar = "Borrar";
            }
            else
            {
                borrar = "Restaurar";
            }
            toolTip1.SetToolTip(this.btnBorrar, borrar);
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
            txtPoblacion.Text = "";
            txtApellido.Text = "";
            txtCM.Text = "";
            txtProvincia.Text = "";
            rbNoEliminados.Checked = true;
            rbEliminados.Checked = false;
            btnBorrar.Enabled = true;
            btnRestaurar.Enabled = false;
            
            //cargarTabla(SQL);
        }
        //Metodo usado para filtrar la tabla
        private void filtrar()
        {
            String sentencia = "SELECT * FROM CLIENTES C, POBLACIONES P, COMUNIDADES M, CODIGOSPOSTALESPOBLACIONES X,PROVINCIAS R" +
                " WHERE C.REFCPPOBLACIONES=X.IDCODIGOPOSTALPOB AND X.REFPOBLACION = P.IDPOBLACION AND X.REFPROVINCIA = R.IDPROVINCIA" +
                " AND M.IDCOMUNIDAD = R.REFCOMUNIDAD";
            if (txtNombre.Text != "")
            {
                sentencia = sentencia + " AND UPPER(C.NOMBRE) LIKE '%" + txtNombre.Text.ToUpper() + "%'";
            }
            if (txtApellido.Text != "")
            {
                sentencia = sentencia + " AND UPPER(C.APELLIDO1) LIKE '%" + txtApellido.Text.ToUpper() + "%'";
            }
            if (txtPoblacion.Text != "")
            {
                sentencia = sentencia + " AND UPPER(P.POBLACION) LIKE '%" + txtPoblacion.Text.ToUpper() + "%'";
            }
            if (txtProvincia.Text != "")
            {
                sentencia = sentencia + " AND UPPER(R.PROVINCIA) LIKE '%" + txtProvincia.Text.ToUpper() + "%'";
            }
            if (txtCM.Text != "")
            {
                sentencia = sentencia + " AND UPPER(M.COMUNIDAD) LIKE '%" + txtCM.Text.ToUpper() + "%'";
            }
            //cargarTabla(sentencia);
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
                filtrar();
            }
        }
        //Metodo que controla el textBox de Apellido
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals('\'') || txtApellido.Text.Length >= 20)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
                filtrar();
            }
        }
        //Metodo que controla el textBox de Poblacion
        private void txtPoblacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals('\'') || txtCM.Text.Length >= 50)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
                filtrar();
            }
        }
        //Metodo que controla el textBox de Provincia
        private void txtProvincia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals('\'') || txtProvincia.Text.Length >= 50)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
                filtrar();
            }
        }
        //Metodo que controla el textBox de Comunidad Autonoma
        private void txtCM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals('\'') || txtCM.Text.Length >= 50)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
                filtrar();
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

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar();
        }

        private void txtApellido_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar();
        }
        private void txtProvincia_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar();
        }

        private void txtPoblacion_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar();
        }

        private void txtCM_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null || dgvProveedores.SelectedRows.Count != 0)
            {
                MessageBox.Show("No ha seleccionado ninguna fila");
            }
            else
            {

                //codigo modificacion
            }
        }

        private void Proveedor_Click(object sender, EventArgs e)
        {

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null || dgvProveedores.SelectedRows.Count != 0)
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
            if (dgvProveedores.CurrentRow == null || dgvProveedores.SelectedRows.Count != 0)
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
            filtrar();
        }
        private void rbEliminados_Click(object sender, EventArgs e)
        {
            rbNoEliminados.Checked = false;
            btnBorrar.Enabled = false;
            btnRestaurar.Enabled = true;
            filtrar();
        }
    }
}
