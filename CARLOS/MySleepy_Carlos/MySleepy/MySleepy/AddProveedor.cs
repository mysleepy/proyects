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
        private int idCliente;
        //Atributo que almacena la ventana padre
        private Proveedor padre;
        private ToolTip toolTip1;
        public AddProveedor(ConnectDB conexion,Proveedor padre)
        {
            toolTip1 = new ToolTip();
            InitializeComponent();
            this.mod = false;
            this.confirmacion = "¿Desea añadir al proveedor?";
            //iniciamos la conexion 
            this.conexion = conexion;
            DataSet data = new DataSet();
            DataTable tabla = new DataTable();
            //Cargo el combo box de comunidades autonomas
            data = conexion.getData("SELECT COMUNIDAD FROM COMUNIDADES ORDER BY ORDEN", "COMUNIDADES");
            tabla = data.Tables["COMUNIDADES"];
            foreach (DataRow row in tabla.Rows)
            {
                cbCAutonoma.Items.Add(Convert.ToString(row["COMUNIDAD"]));
            }
            this.padre = padre;
            txtCIF.LostFocus += new EventHandler(txtCIF_lostFocus);
            txtEmail.LostFocus += new EventHandler(txtEmail_lostFocus);
            txtTelefono.LostFocus += new EventHandler(txtTelefono_lostFocus);
        }
        public AddProveedor(ConnectDB conexion,Proveedor padre,int id)
        {
            toolTip1 = new ToolTip();
            InitializeComponent();
            this.mod = true;
            this.confirmacion = "¿Desea modificar al proveedor?";
            //iniciamos la conexion 
            this.conexion = conexion;
            txtCIF.LostFocus += new EventHandler(txtCIF_lostFocus);
            txtEmail.LostFocus += new EventHandler(txtEmail_lostFocus);
            txtTelefono.LostFocus += new EventHandler(txtTelefono_lostFocus);
            idCliente = id;
            this.padre = padre;
            rellenaDatos();
        }
        //Metodo que si alguno de los campos estan vacios
        private Boolean compruebaCampos()
        {
            Boolean vacio = false;
            this.mensaje = "Faltan por rellenar los siguientes campos: \n";
            if (txtCIF.Text.Equals("")) { mensaje = mensaje + "-DNI \n"; vacio = true; }
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
        //Metodo para controlar que solo se escriban caracteres alfabeticos en  en campo nombre
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            int codigo = Convert.ToInt32(e.KeyChar);
            if ((Char.IsDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals('\'') || txtNombre.Text.Length >= 30) && (codigo != 8))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        //Metodo para controlar que solo se escriban caracteres alfabeticos en  en campo Apellido1
        private void txtApellido1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int codigo = Convert.ToInt32(e.KeyChar);
            if ((Char.IsDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals('\'') || txtApellido1.Text.Length >= 20) && (codigo != 8))
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
            }
            else
            {
                e.Handled = false;
            }
        }
        //Metodo que controla el textbox del email
        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            int codigo = Convert.ToInt32(e.KeyChar);
            if ((e.KeyChar.Equals('\'') || txtEmail.Text.Length >= 30) && (codigo != 8))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        //Metodo que controla el textbox direccion
        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            int codigo = Convert.ToInt32(e.KeyChar);
            if ((Char.IsDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals('\'') || txtDireccion.Text.Length >= 30) && (codigo != 8))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        //Metodo que comprueba si el email introducido es el correcto
        public void txtEmail_lostFocus(object sender, EventArgs e)
        {
            if (txtEmail.Text != "")
            {
                if (MetodosAuxiliares.emailCorrecto(txtEmail.Text) == false)
                {
                    txtEmail.Text = "";
                    txtEmail.Focus();
                    MessageBox.Show(this, "La estructura del email introducido es incorrecta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                if (MetodosAuxiliares.VerificarNIF(txtCIF.Text) == false)
                {
                    txtCIF.Text = "";
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

    }
}
