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
    public partial class ArticulosForm : Form
    {
        // Atributos a nivel de clase
        ConnectDB conexion;
        String referencia,nombre,composicion,medida,precio;
        Boolean mostrado;
        public ArticulosForm()
        {
            InitializeComponent();
            this.conexion = new ConnectDB() ;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            filtrar(txtMedida.Text, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        private void limpiarCampos()
        {
            txtPrecio.Text = "";
            txtReferencia.Text = "";
            txtMedida.Text = "";
            txtNombre.Text = "";
        }

        private void filtrar(String medida, String nombre, String referencia, String precio)
        {
            String sentencia= "SELECT * FROM ARTICULOS";

            if (rbEliminados.Checked == true)
            {
                sentencia= sentencia+" WHERE ELIMINADO=1";
            }else{
                sentencia=sentencia+" WHERE ELIMINADO=0";
            }

            if (medida != "")
            {
                 sentencia = sentencia + " AND MEDIDA='" + medida + "'";
            }

            if (nombre != "")
            {
                sentencia = sentencia + " AND NOMBRE='" + nombre + "'";

            }

            if (referencia != "")
            {
                sentencia = sentencia + " AND REFERENCIA='"+ referencia +"'";
            }

            if (precio != "")
            {
                sentencia = sentencia + " AND PRECIO=" + precio;
            }
            actualizarDGV(sentencia);
        }

        private void actualizarDGV(String sentencia)
        {
            DataSet resultado = conexion.getData(sentencia, "ARTICULOS");
            dgvArticulos.DataSource = resultado;
        }

        public Boolean getMostrado()
        {
            return mostrado;
        }
        public void setMostrado(Boolean valor)
        {
            mostrado = valor;
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            AddNuevoArticulo add = new AddNuevoArticulo(conexion);
            add.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.SelectedRows != null)
            {
               
            }
            else
            {
                MessageBox.Show("Debes seleccionar un registro");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("¿Seguro que desea eliminar el articulo?", "Eliminar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    eliminarRegistro(dgvArticulos.CurrentRow);
                    // Actualiza tabla
                    dgvArticulos.Rows.RemoveAt(dgvArticulos.CurrentRow.Index);
                } 
            }
            else
            {
                MessageBox.Show("Debes seleccionar un registro");
            }
        }

        private void eliminarRegistro(DataGridViewRow fila)
        {
            int referencia = Convert.ToInt32(fila.Cells[0].Value);
            String sentencia = "UPDATE ARTICULOS SET ELIMINADO=1 WHERE REFERENCIA=" + referencia;
            conexion.setData(sentencia);
        }

        private void txtReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            filtrar(txtMedida.Text, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            filtrar(txtMedida.Text, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            filtrar(txtMedida.Text, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        private void txtMedida_KeyPress(object sender, KeyPressEventArgs e)
        {
            filtrar(txtMedida.Text, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        private void ArticulosForm_Load(object sender, EventArgs e)
        {
            dgvArticulos.ClearSelection();
            dgvArticulos.Update();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            dgvArticulos.ClearSelection();
            if (dgvArticulos.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("¿Seguro que desea restaurar el articulo?", "Restaurar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    restaurarRegistro(dgvArticulos.CurrentRow);
                    // Actualiza tabla
                    filtrar(txtMedida.Text, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar un registro");
            }
        }

        private void restaurarRegistro(DataGridViewRow fila)
        {
            int referencia = Convert.ToInt32(fila.Cells[0].Value);
            String sentencia = "UPDATE ARTICULOS SET ELIMINADO=0 WHERE REFERENCIA=" + referencia;
            conexion.setData(sentencia);
        }
    }
}
