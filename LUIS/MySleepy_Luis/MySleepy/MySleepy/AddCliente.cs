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
    public partial class AddCliente : Form
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
        public AddCliente(ConnectDB conexion)
        {
            InitializeComponent();
            this.mod = false;
            this.confirmacion = "¿Desea añadir el cliente?";
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
            
            txtEmail.LostFocus += new EventHandler(txtEmail_lostFocus);
        }
        public AddCliente(ConnectDB conexion,int id)
        {
            InitializeComponent();
            this.mod = true;
            this.confirmacion = "¿Desea modificar al cliente?";
            //iniciamos la conexion 
            this.conexion = conexion;
            txtEmail.LostFocus += new EventHandler(txtEmail_lostFocus);
            idCliente = id;
            rellenaDatos(id);
        }
        private void rellenaDatos(int id){
            String sentencia = "SELECT C.IDCLIENTE,C.NOMBRE,C.APELLIDO1,C.APELLIDO2,C.TELEFONO,C.EMAIL,C.DIRECCION,"+
                "P.POBLACION,R.PROVINCIA,M.COMUNIDAD,L.CODIGOPOSTAL"+
                " FROM CLIENTES C, POBLACIONES P, PROVINCIAS R, COMUNIDADES M,CODIGOSPOSTALES L,CODIGOSPOSTALESPOBLACIONES X"+
                " WHERE C.REFCPPOBLACIONES=X.IDCODIGOPOSTALPOB AND X.REFPROVINCIA = R.IDPROVINCIA AND R.REFCOMUNIDAD = M.IDCOMUNIDAD"+
                " AND X.REFPOBLACION = P.IDPOBLACION AND X.REFCODIGOPOSTAL = L.IDCODIGOPOSTAL AND C.IDCLIENTE ="+id;
            String nombre = "", apellido1="", apellido2="", telefono="", email="", direccion="",comunidad ="",provincia="",poblacion ="",cp ="";
            DataSet data = new DataSet();
            DataTable tabla = new DataTable();
            data = conexion.getData(sentencia, "CLIENTES");
            tabla = data.Tables["CLIENTES"];
            foreach(DataRow row in tabla.Rows){
                nombre= Convert.ToString(row["NOMBRE"]);
                apellido1= Convert.ToString(row["APELLIDO1"]);
                apellido2=Convert.ToString(row["APELLIDO2"]);
                telefono = Convert.ToString(row["TELEFONO"]);
                email = Convert.ToString(row["EMAIL"]);
                direccion = Convert.ToString(row["DIRECCION"]);
                comunidad = Convert.ToString(row["COMUNIDAD"]);
                provincia = Convert.ToString(row["PROVINCIA"]);
                poblacion = Convert.ToString(row["POBLACION"]);
                cp = Convert.ToString(row["CODIGOPOSTAL"]);
            }
            txtNombre.Text = nombre;
            txtApellido1.Text = apellido1;
            txtApellido2.Text = apellido2;
            txtTelefono.Text = telefono;
            txtEmail.Text = email;
            txtDireccion.Text = direccion;
            //Cargo el combo box de comunidades autonomas
            data = conexion.getData("SELECT COMUNIDAD FROM COMUNIDADES ORDER BY ORDEN", "COMUNIDADES");
            tabla = data.Tables["COMUNIDADES"];
            foreach (DataRow row in tabla.Rows)
            {
                cbCAutonoma.Items.Add(Convert.ToString(row["COMUNIDAD"]));
            }
            cbCAutonoma.SelectedText = comunidad;
            data = conexion.getData("SELECT PROVINCIA FROM PROVINCIAS WHERE REFCOMUNIDAD = ORDER BY ORDEN", "PROVINCIAS");
            tabla = data.Tables["PROVINCIAS"];
            foreach (DataRow row in tabla.Rows)
            {
                cbCAutonoma.Items.Add(Convert.ToString(row["COMUNIDAD"]));
            }

            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {             
            if (compruebaCampos() == false)
            {
                confirmacion = confirmacion + "\n-" + txtNombre.Text + "  " + txtApellido1.Text + " " + txtApellido2.Text;
                //Se pide la confirmacion al usuario para realizar dicho cambio en la BBDD
                DialogResult option = MessageBox.Show(this, this.confirmacion, "Confirmación", MessageBoxButtons.YesNo);
                if (option == DialogResult.Yes)
                {
                    //Busco el id correspondientede la tabla conjunta CODIGOSPOSTALESPOBLACIONES
                    int refCpProPo = Convert.ToInt32(conexion.DLookUp("IDCODIGOPOSTALPOB", "CODIGOSPOSTALESPOBLACIONES",
                        "REFCODIGOPOSTAL =" + this.idCodigoPostal + " REFPOBLACION =" + this.idPoblacion + " REFPROVINCIA =" + this.idProvincia));
                    //Busco el ultimo id existente en la tabla clientes y lo aumento en 1
                    idCliente = Convert.ToInt32(conexion.DLookUp("MAX(IDCLIENTE)", "CLIENTES", "")) + 1;
                    if (this.mod == false)
                    {
                        //Almaceno los datos en la base de datos
                        conexion.setData("INSERT INTO CLIENTES VALUES(" + idCliente + ",'" + txtNombre.Text + "','" + txtApellido1.Text + "','" +
                            txtApellido2.Text + "','" + txtDireccion.Text + "'," + refCpProPo + "," + Convert.ToInt32(txtTelefono.Text) + ",'" +
                            txtEmail.Text + "'," + 0);
                        MessageBox.Show(this, "Cliente añadido", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }//fin if añadir
                    else
                    {
                        //Actualizo los datos del cliente
                        String update = " UPDATE CLIENTES  set NOMBRE = " + txtNombre.Text + ", APELLIDO1 = "+txtApellido1.Text+","+ 
                            "APELLIDO2 = "+txtApellido2.Text+", TELEFONO = "+txtTelefono.Text+",EMAIL ="+txtEmail.Text+", DIRECCION = "+
                            txtDireccion.Text + ", REFCPPOBLACIONES = "+refCpProPo+", WHERE IDCLIENTE=" + idCliente;
                        conexion.setData(update);
                        MessageBox.Show(this, "Cliente modificado", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }//fin else modificar
                }//fin if permiso
            }//fin if comprobar campos
            else { MessageBox.Show(this,mensaje);}
        }
        private Boolean compruebaCampos()
        {
            Boolean vacio = false;
            this.mensaje = "Faltan por rellenar los siguientes campos: \n";
            if (txtNombre.Text.Equals("")){mensaje = mensaje + "-Nombre \n";vacio = true;}
            if(txtApellido1.Text.Equals("")){mensaje = mensaje + "-Primer Apellido \n";vacio = true;}
            if(txtApellido2.Text.Equals("")){mensaje = mensaje + "-Segundo Apellido \n";vacio = true;}
            if(txtTelefono.Text.Equals("")){mensaje = mensaje + "-Teléfono \n";vacio = true;}
            if(txtEmail.Text.Equals("")){mensaje = mensaje + "-Email \n";vacio = true;}
            if(txtDireccion.Text.Equals("")){mensaje = mensaje + "-Direccion \n";vacio = true;}
            if(cbCAutonoma.SelectedIndex == -1){mensaje = mensaje +"-Comunidad Autonoma \n";vacio = true;}
            if(cbProvincia.SelectedIndex == -1){mensaje = mensaje +"-Provincia \n";vacio = true;}
            if(cbPoblacion.SelectedIndex == -1){mensaje = mensaje +"-Poblacion \n";vacio = true;}
            if (cbCP.SelectedIndex == -1) { mensaje = mensaje + "-CP \n"; vacio = true;}
            return vacio;
        }
        //Metodo para controlar que solo se escriban caracteres alfabeticos en  en campo nombre
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals('\''))
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
            if (Char.IsDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals('\''))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        //Metodo para controlar que solo se escriban caracteres alfabeticos en  en campo Apellido2
        private void txtApellido2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals('\''))
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
            if (Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals('\''))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\''))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        public void txtEmail_lostFocus(object sender, EventArgs e)
        {
            if (MetodosAuxiliares.emailCorrecto(txtEmail.Text)==false)
            {
                txtEmail.Text = "";
                MessageBox.Show(this, "La estructura del email introducido es incorrecta");
            }
        }
        //Metodo que carga el combobox de provincias dependiendo de la comunidad autonoma seleccionada
        private void cbCAutonoma_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbProvincia.Items.Clear();
            String cautonoma = cbCAutonoma.SelectedItem.ToString();
            this.idCAutonoma = Convert.ToInt32(conexion.DLookUp("IDCOMUNIDAD", "COMUNIDADES", "COMUNIDAD = '"+ cautonoma+"'"));
            rellenarComboBox(cbProvincia, "PROVINCIAS", "PROVINCIA", "REFCOMUNIDAD =" + idCAutonoma+" ORDER BY ORDEN");
        }
        //Metodo que carga el combobox de poblaciones dependiendo de la provincia seleccionada
        private void cbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbPoblacion.Items.Clear();
            String provincia = cbProvincia.SelectedItem.ToString();
            this.idProvincia = Convert.ToInt32(conexion.DLookUp("IDPROVINCIA", "PROVINCIAS", "PROVINCIA ='" + provincia+"'"));
            rellenarComboBox(cbPoblacion, "POBLACIONES", "POBLACION", "IDPOBLACION IN (SELECT REFPOBLACION FROM CODIGOSPOSTALESPOBLACIONES WHERE " +
            "REFPROVINCIA =" + idProvincia + ") ORDER BY POBLACION");
        }
        //Metodo que carga el combobox de codigos postales dependiendo de la poblacion seleccionada
        private void cbPoblacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCP.Items.Clear();
            String poblacion = cbPoblacion.SelectedItem.ToString();
            this.idPoblacion = Convert.ToInt32(conexion.DLookUp("IDPOBLACION", "POBLACIONES", "POBLACION ='" + poblacion+"'"));
            rellenarComboBox(cbCP, "CODIGOSPOSTALES", "CODIGOPOSTAL", "IDCODIGOPOSTAL IN (SELECT REFCODIGOPOSTAL FROM CODIGOSPOSTALESPOBLACIONES WHERE " +
            "REFPOBLACION = "+idPoblacion+") ORDER BY CODIGOPOSTAL");
        }
        //Metodo que recoge el id del codigo postal seleccionado
        private void cbCP_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.idCodigoPostal = Convert.ToInt32(conexion.DLookUp("IDCODIGOPOSTAL", "CODIGOPOSTALES", "CODIGOPOSTAL =" + cbCP.SelectedItem));
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Metodo para rellenar los combobox en base al anterior
        private void rellenarComboBox(ComboBox combo,String tabla,String columna, String condicion)
        {
            DataSet data = new DataSet();
            DataTable table = new DataTable();
            //Cargo el combo box de comunidades autonomas
            data = conexion.getData("SELECT * FROM "+tabla+" WHERE "+condicion, tabla);
            table = data.Tables[tabla];
            foreach (DataRow row in table.Rows)
            {
                combo.Items.Add(row[columna]);
            }
        }
    }
}
