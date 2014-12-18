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
    public partial class AddProveedor : Form
    {
        //Atributo que almacena la conexion utilizada
        private ConnectDB conexion;
        //Atributo que almacena el id de la comunidad autonoma
        private int idCAutonoma;
        //Atributo que almacena el id de la provincia
        private int idProvincia;
        //Atributo que almacena el id de la poblacion
        private int idPoblacion;
        //Atributo que almacena el id del codigo postal
        private int idCodigoPostal;
        //Atributo que almacena el mensaje de error al guardar
        private String mensaje;
        //Atributo que almacena el mensaje de confirmación
        private String confirmacion;
        //Atributo que indica si se ha de modificar o insertar en la BBDD
        private Boolean mod;
        //Atributo que almacena el id a controlar
        private int idProveedor;
        //Atributo que hace el patron singlenton
        private static AddProveedor instance;
        private DataSet ds;
        private ToolTip toolTip1;
        private int empresaAutonomo;
        private Proveedores daddy;
        private InsertHistorial insert;
        private int idUsuario;
        public static AddProveedor Instance(ConnectDB c, DataSet ds, Proveedores daddy, int idUsuario)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new AddProveedor(c, ds, daddy, idUsuario);
            }
            return instance;
        }
        public static AddProveedor Instance(ConnectDB c, int id, DataSet ds, Proveedores daddy, int idUsuario)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new AddProveedor(c, id, ds, daddy, idUsuario);
            }
            return instance;
        }
        public AddProveedor(ConnectDB conexion, DataSet ds, Proveedores daddy, int idUsuario)
        {
            this.daddy = daddy;
            toolTip1 = new ToolTip();
            InitializeComponent();
            txtCIF.Enabled = false;
            txtDNI.Enabled = false;
            txtCIF.Visible = false;
            txtDNI.Visible = false;
            cbEA.SelectedIndex = 0;
            this.mod = false;
            this.confirmacion = "¿Desea añadir al proveedor?";
            //iniciamos la conexion 
            this.conexion = conexion;
            DataSet data = new DataSet();
            DataTable tabla = new DataTable();
            this.idUsuario = idUsuario;
            //Cargo el combo box de comunidades autonomas
            data = conexion.getData("SELECT COMUNIDAD FROM COMUNIDADES ORDER BY ORDEN", "COMUNIDADES");
            tabla = data.Tables["COMUNIDADES"];
            foreach (DataRow row in tabla.Rows)
            {
                cbCAutonoma.Items.Add(Convert.ToString(row["COMUNIDAD"]));
            }
            txtCIF.LostFocus += new EventHandler(txtCIF_lostFocus);
            txtTelefono.LostFocus += new EventHandler(txtTelefono_lostFocus);
            this.ds = ds;
            insert = new InsertHistorial(conexion);
        }
        public AddProveedor(ConnectDB conexion, int id, DataSet ds, Proveedores daddy, int idUsuario)
        {
            this.daddy = daddy;
            toolTip1 = new ToolTip();
            InitializeComponent();
            txtCIF.Enabled = false;
            txtDNI.Enabled = false;
            txtCIF.Visible = false;
            txtDNI.Visible = false;
            this.mod = true;
            this.confirmacion = "¿Desea modificar al proveedor?";
            //iniciamos la conexion 
            this.conexion = conexion;
            txtCIF.LostFocus += new EventHandler(txtCIF_lostFocus);
            txtTelefono.LostFocus += new EventHandler(txtTelefono_lostFocus);
            idProveedor = id;
            this.ds = ds;
            this.idUsuario = idUsuario;
            rellenaDatos();
            insert = new InsertHistorial(conexion);

        }
        private void rellenaDatos()
        {
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "IDPROVEEDOR";
            int posicion = dv.Find(idProveedor);
            this.txtCIF.Text = dv[posicion][1].ToString();
            this.txtDNI.Text = dv[posicion][7].ToString();
            if (txtDNI.Text.Equals("-")) { cbEA.SelectedIndex = 0; }
            else { cbEA.SelectedIndex = 1; }
            this.txtNombre.Text = dv[posicion][2].ToString();
            this.txtDireccion.Text = dv[posicion][3].ToString();
            this.txtTelefono.Text = dv[posicion][5].ToString();
            String sentencia = "SELECT P.POBLACION,R.PROVINCIA,M.COMUNIDAD,L.CODIGOPOSTAL" +
                 " FROM POBLACIONES P, PROVINCIAS R, COMUNIDADES M,CODIGOSPOSTALES L,CODIGOSPOSTALESPOBLACIONES X" +
                 " WHERE X.IDCODIGOPOSTALPOB = " + dv[posicion][4].ToString() + "AND X.REFPROVINCIA = R.IDPROVINCIA AND R.REFCOMUNIDAD = M.IDCOMUNIDAD" +
                 " AND X.REFPOBLACION = P.IDPOBLACION AND X.REFCODIGOPOSTAL = L.IDCODIGOPOSTAL";
            String comunidad = "", provincia = "", poblacion = "", cp = "";
            DataSet data = new DataSet();
            DataTable tabla = new DataTable();
            data = conexion.getData(sentencia, "CODIGOSPOSTALESPOBLACIONES");
            tabla = data.Tables["CODIGOSPOSTALESPOBLACIONES"];
            foreach (DataRow row in tabla.Rows)
            {
                comunidad = Convert.ToString(row["COMUNIDAD"]);
                provincia = Convert.ToString(row["PROVINCIA"]);
                poblacion = Convert.ToString(row["POBLACION"]);
                cp = Convert.ToString(row["CODIGOPOSTAL"]);
            }
            //Cargo el combo box de comunidades autonomas
            data = conexion.getData("SELECT COMUNIDAD FROM COMUNIDADES ORDER BY ORDEN", "COMUNIDADES");
            tabla = data.Tables["COMUNIDADES"];
            foreach (DataRow row in tabla.Rows)
            {
                cbCAutonoma.Items.Add(Convert.ToString(row["COMUNIDAD"]));
            }
            cbCAutonoma.SelectedItem = comunidad;
            cbProvincia.SelectedItem = provincia;
            cbPoblacion.SelectedItem = poblacion;
            cbCP.SelectedItem = cp;

        }
        //Metodo que si alguno de los campos estan vacios
        private Boolean compruebaCampos()
        {
            Boolean vacio = false;
            this.mensaje = "Faltan por rellenar los siguientes campos: \n";
            if (this.empresaAutonomo == 1)
            {
                if (txtCIF.Text.Equals("")) { mensaje = mensaje + "-CIF \n"; vacio = true; }
            }
            else
            {
                if (this.empresaAutonomo == 0)
                {
                    if (txtDNI.Text.Equals("")) { mensaje = mensaje + "-DNI \n"; vacio = true; }
                }
                else
                {
                    mensaje = mensaje + "-CIF/DNI \n"; vacio = true;
                }
            }
            if (txtNombre.Text.Equals("")) { mensaje = mensaje + "-Nombre \n"; vacio = true; }
            if (txtTelefono.Text.Equals("")) { mensaje = mensaje + "-Teléfono \n"; vacio = true; }
            if (txtDireccion.Text.Equals("")) { mensaje = mensaje + "-Direccion \n"; vacio = true; }
            if (cbCAutonoma.SelectedIndex == -1) { mensaje = mensaje + "-Comunidad Autonoma \n"; vacio = true; }
            if (cbProvincia.SelectedIndex == -1) { mensaje = mensaje + "-Provincia \n"; vacio = true; }
            if (cbPoblacion.SelectedIndex == -1) { mensaje = mensaje + "-Poblacion \n"; vacio = true; }
            if (cbCP.SelectedIndex == -1) { mensaje = mensaje + "-CP \n"; vacio = true; }
            return vacio;
        }
        //Metodo que controla el combobox de DNI
        private void txtCIF_KeyPress(object sender, KeyPressEventArgs e)
        {
            int codigo = Convert.ToInt32(e.KeyChar);
            if ((char.IsSymbol(e.KeyChar) || e.KeyChar.Equals('\'') || txtCIF.Text.Length >= 9) && (codigo != 8))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        //Metodo para controlar que solo se escriban caracteres alfabeticos en  en campo nomb
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            int codigo = Convert.ToInt32(e.KeyChar);
            if ((Char.IsDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals('\'') || txtNombre.Text.Length >= 30) && (codigo != 8))
            {
                e.Handled = true;
                lNombre.Text = "SOLO SE PERMITEN LETRAS";
            }
            else
            {
                e.Handled = false;
                lNombre.Text ="";
            }
        }
        //Metodo para controlar que solo se escriban caracteres alfabeticos en  en campo Apellido1
        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            int codigo = Convert.ToInt32(e.KeyChar);
            if ((char.IsSymbol(e.KeyChar) || e.KeyChar.Equals('\'') || txtDNI.Text.Length >= 9) && (codigo != 8))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        //Metodo para controlar que solo se escriban caracteres numericos en  en campo telefono
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            int codigo = Convert.ToInt32(e.KeyChar);
            if ((Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals('\'') || txtTelefono.Text.Length >= 9) && (codigo != 8))
            {
                e.Handled = true;
                ltelefono.Text = "SOLO SE PERMITEN NUMEROS";
            }
            else
            {
                e.Handled = false;
                ltelefono.Text = "";
            }
        }
        //Metodo que controla el textbox direccion
        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            int codigo = Convert.ToInt32(e.KeyChar);
            if ((char.IsSymbol(e.KeyChar) || e.KeyChar.Equals('\'') || txtDireccion.Text.Length >= 30) && (codigo != 8))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        //Metodo que Controla que se ha introducido el numero correcto(longitud)
        public void txtTelefono_lostFocus(object sender, EventArgs e)
        {
            if (txtTelefono.Text != "")
            {
                if (txtTelefono.Text.Length < 9)
                {
                    txtTelefono.Text = "";
                    MessageBox.Show(this, "El número de telefono introducido es incorrecto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTelefono.Focus();
                }
            }
        }
        //Metodo que Controla que se ha introducido el numero correcto(longitud)
        public void txtCIF_lostFocus(object sender, EventArgs e)
        {
            if (txtCIF.Text != "")
            {
                if (MetodosAuxiliares.Valida_CIF(txtCIF.Text) == false)
                {
                    MessageBox.Show(this, "El CIF introducido es incorrecto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCIF.Focus();
                }
            }
        }
        //Metodo que durante la carga de la interfaz genera los tooltips
        private void AddProveedor_Load(object sender, EventArgs e)
        {
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
            toolTip1.SetToolTip(this.btnGuardar, "Guardar proveedor");
            toolTip1.SetToolTip(this.btnCancelar, "Cerrar ventana");
            toolTip1.SetToolTip(this.cbProvincia, "Ha de seleccionar primero la Comunidad Autonoma");
            toolTip1.SetToolTip(this.cbPoblacion, "Ha de seleccionar primero la Provincia");
            toolTip1.SetToolTip(this.cbCP, "Ha de seleccionar primero la Poblacion");
        }
        //Metodo que carga el combobox de provincias dependiendo de la comunidad autonoma seleccionada
        private void cbCAutonoma_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbProvincia.Items.Clear();
            if (cbCAutonoma.SelectedIndex > 0)
            {
                String cautonoma = cbCAutonoma.SelectedItem.ToString();
                this.idCAutonoma = Convert.ToInt32(conexion.DLookUp("IDCOMUNIDAD", "COMUNIDADES", "COMUNIDAD = '" + cautonoma + "'"));
                rellenarComboBox(cbProvincia, "PROVINCIAS", "PROVINCIA", "REFCOMUNIDAD =" + idCAutonoma + " ORDER BY ORDEN");
                cbProvincia.SelectedIndex = 0;
            }
        }
        //Metodo que carga el combobox de poblaciones dependiendo de la provincia seleccionada
        private void cbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbPoblacion.Items.Clear();
            if (cbProvincia.SelectedIndex >= 0)
            {
                String provincia = cbProvincia.SelectedItem.ToString();
                this.idProvincia = Convert.ToInt32(conexion.DLookUp("IDPROVINCIA", "PROVINCIAS", "PROVINCIA ='" + provincia + "'"));
                rellenarComboBox(cbPoblacion, "POBLACIONES", "POBLACION", "IDPOBLACION IN (SELECT REFPOBLACION FROM CODIGOSPOSTALESPOBLACIONES WHERE " +
                "REFPROVINCIA =" + idProvincia + ") ORDER BY POBLACION");
                cbPoblacion.SelectedIndex = 0;
            }

        }
        //Metodo que carga el combobox de codigos postales dependiendo de la poblacion seleccionada
        private void cbPoblacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCP.Items.Clear();
            if (cbPoblacion.SelectedIndex >= 0)
            {
                String poblacion = cbPoblacion.SelectedItem.ToString();
                this.idPoblacion = Convert.ToInt32(conexion.DLookUp("IDPOBLACION", "POBLACIONES", "POBLACION ='" + poblacion + "'"));
                rellenarComboBox(cbCP, "CODIGOSPOSTALES", "CODIGOPOSTAL", "IDCODIGOPOSTAL IN (SELECT REFCODIGOPOSTAL FROM CODIGOSPOSTALESPOBLACIONES WHERE " +
                "REFPOBLACION = " + idPoblacion + ") ORDER BY CODIGOPOSTAL");
                cbCP.SelectedIndex = 0;
            }

        }
        //Metodo que recoge el id del codigo postal seleccionado
        private void cbCP_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.idCodigoPostal = Convert.ToInt32(conexion.DLookUp("IDCODIGOPOSTAL", "CODIGOSPOSTALES", "CODIGOPOSTAL ='" + cbCP.SelectedItem.ToString() + "'"));
        }
        //Metodo para rellenar los combobox en base al anterior
        private void rellenarComboBox(ComboBox combo, String tabla, String columna, String condicion)
        {
            DataSet data = new DataSet();
            DataTable table = new DataTable();
            //Cargo el combo box de comunidades autonomas
            data = conexion.getData("SELECT * FROM " + tabla + " WHERE " + condicion, tabla);
            table = data.Tables[tabla];
            foreach (DataRow row in table.Rows)
            {
                combo.Items.Add(row[columna]);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            daddy.setDS(this.ds);
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (compruebaCampos() == false)
            {
                //Busco el id correspondientede la tabla conjunta CODIGOSPOSTALESPOBLACIONES
                int refCpProPo = Convert.ToInt32(conexion.DLookUp("IDCODIGOPOSTALPOB", "CODIGOSPOSTALESPOBLACIONES",
                    "REFCODIGOPOSTAL =" + this.idCodigoPostal + " AND REFPOBLACION =" + this.idPoblacion + " AND REFPROVINCIA =" + this.idProvincia));
                String cif = "-", nif = "-", direccion = txtDireccion.Text, nombre = txtNombre.Text;
                int telefono = Convert.ToInt32(txtTelefono.Text);
                if (!txtCIF.Text.Equals("")) { cif = txtCIF.Text; }
                if (!txtDNI.Text.Equals("")) { nif = txtDNI.Text; }
                if (mod == false)
                {
                    int id = Convert.ToInt32(conexion.DLookUp("IDPROVEEDOR", "PROVEEDORES", "IDPROVEEDOR = 1"));
                    if (id == -1) { id = 1;}
                    else { id = Convert.ToInt32(conexion.DLookUp("MAX(IDPROVEEDOR)", "PROVEEDORES", ""))+1; }
                    if (!txtCIF.Text.Equals("")) { cif = txtCIF.Text; }
                    if (!txtDNI.Text.Equals("")) { nif = txtDNI.Text; }
                    DataTable dt = ds.Tables[0];
                    String[] columnas = { "IDPROVEEDOR", "CIF", "NOMBRE", "DIRECCION", "REFCPPOBLACIONES", "TELEFONO", "ELIMINADO", "NIF" };
                    Object[] valores = { id, cif, nombre, direccion, refCpProPo, telefono, 0, nif };
                    XML_proveedor.rellenaFilas(dt, columnas, valores);
                    ds.Tables.Clear();
                    ds.Tables.Add(dt);
                    DialogResult opcion = MessageBox.Show("¿Desea añadir más Proveedores?", "Question",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (opcion == DialogResult.Yes)
                    {
                        limpiar();
                        //insert en historial de cambios
                        insert.insertHistorialCambio(idUsuario, 1, "Proveedor añadido ->" + nombre);
                    }
                    else
                    {
                        this.Dispose();
                    }
                    
                }
                else
                {
                    DataView dv = new DataView(ds.Tables[0]);
                    dv.Sort = "IDPROVEEDOR";
                    int index = dv.Find(idProveedor);
                    dv[index][0] = idProveedor;
                    dv[index][1] = cif;
                    dv[index][2] = nombre;
                    dv[index][3] = direccion;
                    dv[index][4] = refCpProPo;
                    dv[index][5] = telefono;
                    dv[index][6] = 0;
                    dv[index][7] = nif;
                    //MessageBox.Show(this, "Proveedor modificado", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //insert e historial de cambios
                    insert.insertHistorialCambio(idUsuario, 1, "Proveedor modificado ->" + nombre);
                    this.Dispose();
                }
            }
            else
            {
                MessageBox.Show(this, mensaje, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEA.SelectedIndex != -1)
            {
                if (cbEA.SelectedIndex == 0)
                {
                    empresaAutonomo = 1;
                    lCIF.Visible = true;
                    lDNI.Visible = false;
                    txtCIF.Enabled = true;
                    txtDNI.Enabled = false;
                    txtCIF.Visible = true;
                    txtDNI.Visible = false;
                }
                else
                {
                    //Es autonomo
                    empresaAutonomo = 0;
                    lCIF.Visible = false;
                    lDNI.Visible = true;
                    txtCIF.Enabled = false;
                    txtDNI.Enabled = true;
                    txtCIF.Visible = false;
                    txtDNI.Visible = true;
                }
            }
        }
        //Metodo que limpia los campos
        private void limpiar()
        {
            txtNombre.Text = "";
            txtDNI.Text = "";
            txtCIF.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            cbCAutonoma.SelectedIndex = 0;
            cbCP.Items.Clear();
            cbPoblacion.Items.Clear();
            lCIF.Visible = false;
            lDNI.Visible = false;
            txtCIF.Enabled = false;
            txtDNI.Enabled = false;
            txtCIF.Visible = false;
            txtDNI.Visible = false;
            cbEA.SelectedIndex = 0;
        }
    }
}
