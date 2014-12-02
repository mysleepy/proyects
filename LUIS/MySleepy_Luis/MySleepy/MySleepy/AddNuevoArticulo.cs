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
        public AddNuevoArticulo(ConnectDB c,int señal)
        {
            InitializeComponent();
            activarReferencia(true);
            this.idmodificar = 0;
            this.conexion = c;
            numero = señal;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            if (numero == 0)
            {
                if (comprobar())
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
                if (comprobar())
                {
                    añadirArticulo(idmodificar);
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
            if (numero == 0)
            {
                if (comprobarReferencia(Convert.ToInt32(txtReferencia.Text)))
                {
                    int nuevoid = conexion.siguienteID("IDARTICULO", "ARTICULOS");
                    sentencia = "INSERT INTO ARTICULOS(IDARTICULO,COMPOSICION,MEDIDA,PRECIO,ELIMINADO,NOMBRE,REFERENCIA)" +
                                                " VALUES(" + nuevoid + ",'" + txtComposicion.Text.ToUpper() + "','" + txtMedida.Text + "'," + txtPrecio.Text + ",0,'" + txtNombre.Text.ToUpper() + "'," + Convert.ToInt32(txtReferencia.Text) + ")";
                }
            }
            else
            {
                conseguirId(Convert.ToInt32(txtReferencia.Text));
                sentencia = "UPDATE ARTICULOS SET COMPOSICION='" + txtComposicion.Text.ToUpper() + "',MEDIDA='" + txtMedida.Text + "',PRECIO=" + txtPrecio.Text + ",NOMBRE='" + txtNombre.Text.ToUpper() + "'"+
                                  " WHERE IDARTICULO=" + idmodificar  + "";
            }
            conexion.setData(sentencia);
        }


        private bool comprobar()
        {
            TextBox[] ids={txtReferencia,txtComposicion,txtMedida,txtNombre,txtPrecio};
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i].Text == "")
                {
                    return false;
                }
            }
            return true;
        }

        public void rellenar(DataGridViewRow fila)
        {
            int referencia = Convert.ToInt32(fila.Cells[0].Value);
            String nombre = Convert.ToString(fila.Cells[1].Value);
            String composicion = Convert.ToString(fila.Cells[2].Value);
            String medida = Convert.ToString(fila.Cells[3].Value);
            String precio = Convert.ToString(fila.Cells[4].Value);
            conseguirId(referencia);
            escribir(referencia, nombre, composicion, medida, precio);
        }

        private void conseguirId(int referencia)
        {
            String select = "SELECT IDARTICULO FROM ARTICULOS WHERE REFERENCIA=" + referencia;
            DataSet data=conexion.getData(select, "ARTICULOS");

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

        private void escribir(int referencia, string nombre, string composicion, string medida, string precio)
        {
            txtReferencia.Text = "" + referencia;
            txtNombre.Text = nombre;
            txtComposicion.Text = composicion;
            txtMedida.Text = medida;
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

        private void txtComposicion_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtMedida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.GetNumericValue(e.KeyChar) == -1 || e.KeyChar=='x')
            {
                e.Handled = false;
                return;
            }
            if (!Char.IsDigit(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
