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
        public AddNuevoArticulo(ConnectDB c)
        {
            InitializeComponent();
           
            this.conexion = c;
            
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            if (comprobar())
            {
                añadirArticulo();
                MessageBox.Show("Articulo añadido");
            }
            else
            {
                MessageBox.Show("Tienes que rellenar los campos que faltan");
            }
        }

        private void añadirArticulo()
        {
            // añade articulos a la base de datos
            int nuevoid=conexion.siguienteID("IDARTICULO","ARTICULOS");
            String sentencia = "INSERT INTO ARTICULOS(IDARTICULO,COMPOSICION,MEDIDA,PRECIO,ELIMINADO,NOMBRE,REFERENCIA)"+ 
                                        " VALUES("+nuevoid+",'"+txtComposicion.Text.ToUpper()+"','"+txtMedida.Text.ToUpper()+"',"+txtPrecio.Text+",0,'"+txtNombre.Text.ToUpper()+"',"+txtReferencia.Text+")";
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

       
    }
}
