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
    public partial class AddNuevoArticulo : Form
    {
        ConnectDB conexion;
        int numero;
        int idmodificar;
        ArticulosForm articulos;
        AddPedido addPedido;
        InsertHistorial insert;
        int idUsuario;
        public AddNuevoArticulo(ConnectDB c, int señal, ArticulosForm articulos, int idUsuario)
        {
            InitializeComponent();
            activarReferencia(true);
            this.idmodificar = 0;
            this.conexion = c;
            this.articulos = articulos;
            numero = señal;
            cargarCombos(cboComposicion, 0);
            cargarCombos(cboMedida, 1);
            this.idUsuario = idUsuario;
            insert = new InsertHistorial(conexion);
        }

        public AddNuevoArticulo(ConnectDB conexion, int señal, AddPedido addPedido)
        {
            InitializeComponent();
            this.conexion = conexion;
            this.addPedido = addPedido;
            numero = señal;
            cargarCombos(cboComposicion, 0);
            cargarCombos(cboMedida, 1);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            articulos.actualizarTabla();
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            if (numero == 0)
            {
                if (comprobarCajasTexto())
                {
                    añadirArticulo(idmodificar);
                    MessageBox.Show("Articulo añadido");
                }
                else
                {
                    MessageBox.Show("Tienes que rellenar los campos que faltan");
                }
            }
            else
            {
                if (comprobarCajasTexto())
                {
                    añadirArticulo(conexion.siguienteID("IDARTICULO", "ARTICULOS"));
                    MessageBox.Show("Articulo modificado");
                }
                else
                {
                    MessageBox.Show("Tienes que rellenar los campos que faltan");
                }
            }
        }

        private void añadirArticulo(int id)
        {
            // añade articulos a la base de datos
            String sentencia = "";
            String nombreArticulo = txtNombre.Text;
            int tipoCambio = 0;
            String mensajeHistorial = "";
            if (numero == 0)
            {
                if (comprobarReferencia(Convert.ToInt32(txtReferencia.Text)))
                {
                    int nuevoid = conexion.siguienteID("IDARTICULO", "ARTICULOS");
                    sentencia = "INSERT INTO ARTICULOS(IDARTICULO,REFCOMPOSICION,REFMEDIDA,PRECIO,ELIMINADO,NOMBRE,REFERENCIA,STOCK)" +
                                                " VALUES(" + nuevoid + ",'" + cboComposicion.SelectedIndex + "','" + cboMedida.SelectedIndex + "'," + txtPrecio.Text + ",0,'" + nombreArticulo.ToUpper() + "'," + Convert.ToInt32(txtReferencia.Text) + "," + Convert.ToInt32(nStock.Value.ToString())+")";

                    tipoCambio = 1;
                    mensajeHistorial = "Articulo añadido ->" + nombreArticulo;
                }

            }
            else
            {
                conseguirId(Convert.ToInt32(txtReferencia.Text));
                sentencia = "UPDATE ARTICULOS SET REFCOMPOSICION='" + cboComposicion.SelectedIndex + "',REFMEDIDA='" + cboComposicion.SelectedIndex + "',PRECIO=" + txtPrecio.Text + ",NOMBRE='" + nombreArticulo.ToUpper() + "'" +
                                  " WHERE IDARTICULO=" + idmodificar + "";
                tipoCambio = 2;
                mensajeHistorial = "Articulo modificado ->" + nombreArticulo;
            }
            conexion.setData(sentencia);
            //insert en la tabla historial de cambios
            insert.insertHistorialCambio(idUsuario, tipoCambio, mensajeHistorial);
            limpiarCampos();
        }


        private bool comprobarCajasTexto()
        {
            Boolean devolver = true;
            Label[] idsLabel = { lblReferencia, lblNombre, lblStock, lblComposicion, lblMedida, lblPrecio };
            TextBox[] idsTextBox = { txtReferencia, txtNombre, txtPrecio };
            ComboBox[] idsCombos = { cboMedida, cboComposicion };
            if (idsCombos[0].SelectedIndex == -1)
            {
                idsLabel[4].ForeColor = Color.Red;
            }
            else
            {
                idsLabel[4].ForeColor = Color.Green;
            }
            if (idsCombos[1].SelectedIndex == -1)
            {
                idsLabel[3].ForeColor = Color.Red;
            }
            else
            {
                idsLabel[3].ForeColor = Color.Green;
            }
            if (nStock.Value == 0)
            {
                idsLabel[2].ForeColor = Color.Red;
            }
            else
            {
                idsLabel[2].ForeColor = Color.Green;
            }
            if (idsTextBox[0].Text == "")
            {
                idsLabel[0].ForeColor = Color.Red;
            }
            else
            {
                idsLabel[0].ForeColor = Color.Green;
            }
            if (idsTextBox[1].Text == "")
            {
                idsLabel[1].ForeColor = Color.Red;
            }
            else
            {
                idsLabel[1].ForeColor = Color.Green;
            }
            if (idsTextBox[2].Text == "")
            {
                idsLabel[5].ForeColor = Color.Red;
            }
            else
            {
                idsLabel[5].ForeColor = Color.Green;
            }
            for (int i = 0; i < idsLabel.Length; i++)
            {
                if (idsLabel[i].ForeColor == Color.Red)
                {
                    devolver = false;
                }
            }

            return devolver;
        }

        public void rellenar(DataGridViewRow fila)
        {
            int referencia = Convert.ToInt32(fila.Cells[0].Value);
            String nombre = Convert.ToString(fila.Cells[1].Value);
            int composicion = Convert.ToInt32(conexion.DLookUp("IDCOMPOSICION", "COMPOSICIONES", "COMPOSICION='" + fila.Cells[2].Value.ToString() + "'"));
            int medida = Convert.ToInt32(conexion.DLookUp("IDMEDIDA", "MEDIDAS", "MEDIDA='" + fila.Cells[3].Value.ToString() + "'"));
            String precio = Convert.ToString(fila.Cells[4].Value);
            conseguirId(referencia);
            escribir(referencia, nombre, composicion, medida, precio);
        }

        private void conseguirId(int referencia)
        {
            String select = "SELECT IDARTICULO FROM ARTICULOS WHERE REFERENCIA=" + referencia;
            DataSet data = conexion.getData(select, "ARTICULOS");

            DataTable tArticulos = data.Tables["ARTICULOS"];

            foreach (DataRow row in tArticulos.Rows)
            {
                idmodificar = Convert.ToInt32(row["IDARTICULO"]);
            }

        }

        public Boolean comprobarReferencia(int refAdd)
        {
            String select = "SELECT REFERENCIA FROM ARTICULOS";
            DataSet data = conexion.getData(select, "ARTICULOS");

            DataTable tArticulos = data.Tables["ARTICULOS"];
            foreach (DataRow row in tArticulos.Rows)
            {
                int refTabla = Convert.ToInt32(row["REFERENCIA"]);
                if (refAdd == refTabla)
                {
                    // Existe y la encuentra devuelve false para que vuelva a introducir el usuario una nueva referencia
                    return false;
                }
            }
            return true;
        }

        public void limpiarCampos()
        {
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtReferencia.Text = "";
            cboComposicion.SelectedIndex = -1;
            cboMedida.SelectedIndex = -1;
        }

        private void escribir(int referencia, string nombre, int composicion, int medida, string precio)
        {
            txtReferencia.Text = "" + referencia;
            txtNombre.Text = nombre;
            cboComposicion.SelectedIndex = composicion;
            cboMedida.SelectedIndex = medida;
            txtPrecio.Text = precio;
        }

        public void activarReferencia(Boolean valor)
        {
            txtReferencia.Enabled = valor;
        }

        private void txtReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.GetNumericValue(e.KeyChar) == -1)
            {
                e.Handled = false;
                return;
            }
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.GetNumericValue(e.KeyChar) == -1)
            {
                e.Handled = false;
                return;
            }
            if (!Char.IsLetter(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void AddNuevoArticulo_Load(object sender, EventArgs e)
        {
            btnAnadir.NotifyDefault(true);

        }

        private void cargarCombos(ComboBox cbo, int señal)
        {
            DataSet data;
            DataTable tabla = null;
            String sentencia = "";
            if (señal == 0)
            {
                sentencia = "SELECT COMPOSICION FROM COMPOSICIONES";
                data = conexion.getData(sentencia, "COMPOSICIONES");
                tabla = data.Tables["COMPOSICIONES"];
                foreach (DataRow row in tabla.Rows)
                {
                    cbo.Items.Add(Convert.ToString(row["COMPOSICION"]));
                }
            }
            if (señal == 1)
            {
                sentencia = "SELECT MEDIDA FROM MEDIDAS";
                data = conexion.getData(sentencia, "MEDIDAS");
                tabla = data.Tables["MEDIDAS"];
                foreach (DataRow row in tabla.Rows)
                {
                    cbo.Items.Add(Convert.ToString(row["MEDIDA"]));
                }
            }


        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.GetNumericValue(e.KeyChar) == -1 || Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
                return;
            }
            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtReferencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (Char.IsDigit(Convert.ToChar(e.KeyCode)))
            {
                e.Handled = true;
            }
        }


    }
}
