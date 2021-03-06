﻿using Microsoft.VisualBasic;
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
        int rolUsuario;
        int numero;
        AddPedido pedido;
        private int idRol;
        private InsertHistorial insert;
        private int idUsuario;

        //patron singleton
        private static ArticulosForm instance;

        public static ArticulosForm Instance(int idRol, int numero, AddPedido ped, ConnectDB c, int idUsuario)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ArticulosForm(idRol, numero, ped, c, idUsuario);
            }
            return instance;
        }
        public static ArticulosForm Instance(int idRol, ConnectDB conexion, int idUsuario)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ArticulosForm(idRol, conexion, idUsuario);
            }
            return instance;
        }

        private ArticulosForm(int idRol, int numero, AddPedido ped, ConnectDB c, int idUsuario)
        {
            InitializeComponent();
            this.conexion = c;
            rolUsuario = idRol;
            this.numero = numero;
            this.pedido = ped;
            cargarDGVInicio();
            this.idUsuario = idUsuario;
            insert = new InsertHistorial(conexion);
        }

        private ArticulosForm(int idRol, ConnectDB conexion, int idUsuario)
        {
            InitializeComponent();
            this.idRol = idRol;
            this.conexion = conexion;
            cargarDGVInicio();
            this.idUsuario = idUsuario;
            insert = new InsertHistorial(conexion);
        }

        private void cargarDGVInicio()
        {
            String sentencia = "SELECT * FROM ARTICULOS WHERE ELIMINADO=0";
            actualizarDGV(sentencia);
            dgvArticulos.ClearSelection();
        }

        private void cargarCombos(ComboBox cbo)
        {
            DataSet data;
            DataTable tabla = null;
            String sentencia = "";

            sentencia = "SELECT MEDIDA FROM MEDIDAS";
            data = conexion.getData(sentencia, "MEDIDAS");
            tabla = data.Tables["MEDIDAS"];
            foreach (DataRow row in tabla.Rows)
            {
                cbo.Items.Add(Convert.ToString(row["MEDIDA"]));
            }

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            filtrar(cbMedida.SelectedIndex, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        private void limpiarCampos()
        {
            txtPrecio.Text = "";
            txtReferencia.Text = "";
            cbMedida.SelectedIndex = -1;
            txtNombre.Text = "";
            rbEliminados.Checked = false;
            rbNoEliminados.Checked = true;
        }

        public void filtrar(int medida, String nombre, String referencia, String precio)
        {
            String sentencia = "SELECT * FROM ARTICULOS WHERE ELIMINADO=0";

            if (rbEliminados.Checked == true)
            {
                sentencia = "SELECT * FROM ARTICULOS WHERE ELIMINADO=1";

            }

            if (medida != -1)
            {
                sentencia = sentencia + " AND REFMEDIDA=" + medida;

            }

            if (nombre != "")
            {
                sentencia = sentencia + " AND NOMBRE LIKE '%" + nombre + "%'";

            }

            if (referencia != "")
            {
                sentencia = sentencia + " AND REFERENCIA LIKE '%" + Convert.ToInt32(referencia) + "%'";

            }

            if (precio != "")
            {
                sentencia = sentencia + " AND PRECIO LIKE '%" + precio + "%'";

            }
            actualizarDGV(sentencia);
        }

        public void actualizarDGV(String sentencia)
        {
            limpiarTabla();
            DataSet resultado = conexion.getData(sentencia, "ARTICULOS");
            DataTable tArticulos = resultado.Tables["ARTICULOS"];
            foreach (DataRow row in tArticulos.Rows)
            {
                int referencia = Convert.ToInt32(row["REFERENCIA"]);
                int stock = Convert.ToInt32(row["STOCK"]);
                int id = Convert.ToInt32(row["IDARTICULO"]);
                String nombre = Convert.ToString(row["NOMBRE"]);
                String composicion = Convert.ToString(conexion.DLookUp("COMPOSICION", "COMPOSICIONES", "IDCOMPOSICION=" + row["REFCOMPOSICION"]));
                String medida = Convert.ToString(conexion.DLookUp("MEDIDA", "MEDIDAS", "IDMEDIDA=" + row["REFMEDIDA"]));
                String precio = Convert.ToString(row["PRECIO"]);
                dgvArticulos.Rows.Add(referencia, nombre,stock, composicion, medida, precio, id);

            } // Fin del bucle for each
            limpiarSeleccion();
        }

        public void limpiarTabla()
        {
            // Limpiamos el datagridView
            while (dgvArticulos.RowCount > 0)
            {
                dgvArticulos.Rows.Remove(dgvArticulos.CurrentRow);
            }
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            AddNuevoArticulo add = new AddNuevoArticulo(conexion, 0, this, idUsuario,0);
            add.ShowDialog();
            if (add.IsDisposed)
            {
                filtrar(cbMedida.SelectedIndex, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
            if (dgvArticulos.CurrentRow == null || dgvArticulos.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay ninguna fila seleccionada");
            }
            else
            {
                AddNuevoArticulo add = new AddNuevoArticulo(conexion, 1, this, idUsuario,0);
                add.activarReferencia(false);
                add.rellenar(dgvArticulos.CurrentRow);
                add.ShowDialog();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.RowCount == 0)
            {
                MessageBox.Show("No hay articulos para borrar");
                return;
            }
            if (dgvArticulos.CurrentRow == null || dgvArticulos.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay ninguna fila seleccionada");
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Seguro que desea eliminar el articulo?", "Eliminar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    eliminarRegistro(dgvArticulos.CurrentRow);
                    // Actualiza tabla
                    cargarDGVInicio();
                    //dgvArticulos.Rows.RemoveAt(dgvArticulos.CurrentRow.Index);
                    limpiarSeleccion();
                    filtrar(cbMedida.SelectedIndex, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
                }
            }
        }

        private void eliminarRegistro(DataGridViewRow fila)
        {
           // MessageBox.Show("aqui");
            int idarticuloseleccionado = Convert.ToInt32(fila.Cells[5].Value);
            String sentencia = "UPDATE ARTICULOS SET ELIMINADO=1 WHERE IDARTICULO=" + idarticuloseleccionado;
            
            conexion.setData(sentencia);
            //MessageBox.Show("sentencia" + sentencia);

            //insert en la tabla historial de cambios
            //pedimos confirmacion
            String nombreArticulo = Convert.ToString(conexion.DLookUp("NOMBRE", "ARTICULOS", " IDARTICULO = " + idarticuloseleccionado));
            String mensaje = Interaction.InputBox("¿Motivo por el cual se elimina?", "Motivo", "");
            mensaje = "Articulo borrado ->" + nombreArticulo + " Motivo ->" + mensaje;
            
            insert.insertHistorialCambio(idUsuario, 3, mensaje);
        }

        private void txtReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            filtrar(cbMedida.SelectedIndex, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            filtrar(cbMedida.SelectedIndex, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            filtrar(cbMedida.SelectedIndex, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        private void txtMedida_KeyPress(object sender, KeyPressEventArgs e)
        {
            filtrar(cbMedida.SelectedIndex, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        private void limpiarSeleccion()
        {
            dgvArticulos.ClearSelection();
            dgvArticulos.Update();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.RowCount == 0)
            {
                MessageBox.Show("No hay articulos para restaurar");
                return;
            }
            if (dgvArticulos.CurrentRow == null || dgvArticulos.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay ninguna fila seleccionada");
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Seguro que desea restaurar el articulo?", "Restaurar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    restaurarRegistro(dgvArticulos.CurrentRow);
                    // Actualiza tabla
                    filtrar(cbMedida.SelectedIndex, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
                }
            }

        }

        private void restaurarRegistro(DataGridViewRow fila)
        {
            int idarticuloseleccionado = Convert.ToInt32(fila.Cells[5].Value);
            String sentencia = "UPDATE ARTICULOS SET ELIMINADO=0 WHERE IDARTICULO=" + idarticuloseleccionado;
            
            conexion.setData(sentencia);
            //MessageBox.Show("sentencia" + sentencia);
            //insert en tabla historial cambios
            String nombreArticulo = Convert.ToString
                                    (conexion.DLookUp("NOMBRE", "ARTICULOS", " IDARTICULO = " + idarticuloseleccionado));
            //MessageBox.Show("sentencia" + nombreArticulo);
            insert.insertHistorialCambio(idUsuario, 4, "Articulo restaurado ->" + nombreArticulo);
            
        }

        private void rbEliminados_Click(object sender, EventArgs e)
        {
            btnBorrar.Enabled = false;
            btnRestaurar.Enabled = true;
            rbNoEliminados.Checked = false;
            rbEliminados.Checked = true;
        }

        private void rbNoEliminados_CheckedChanged(object sender, EventArgs e)
        {
            filtrar(cbMedida.SelectedIndex, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        private void ArticulosForm_Shown(object sender, EventArgs e)
        {
            dgvArticulos.ClearSelection();
            dgvArticulos.Update();

        }

        private void txtReferencia_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar(cbMedida.SelectedIndex, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar(cbMedida.SelectedIndex, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        private void txtMedida_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar(cbMedida.SelectedIndex, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        private void txtPrecio_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar(cbMedida.SelectedIndex, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        internal void actualizarTabla()
        {
            filtrar(cbMedida.SelectedIndex, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        private void dgvArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String cantidad = "";
            int stock=Convert.ToInt32(conexion.DLookUp("STOCK","ARTICULOS","IDARTICULO="+Convert.ToInt32(dgvArticulos.CurrentRow.Cells[5].Value.ToString())));
            if (numero == 1)
            {
                //controlamos que no se pueda realizar un pedido de un articulo por una cantidad superior al stock
                if (txtCantidad.Value > stock)
                {
                    MessageBox.Show("No se pueden pedir tantos articulos, el max en stock es: " + stock);
                    return;
                }
                if (txtCantidad.Value != 0)
                {
                    lblCantidad.ForeColor = Color.Green;
                    cantidad = Convert.ToString(txtCantidad.Value);
                    pedido.nuevoArticulo(Convert.ToInt32(dgvArticulos.CurrentRow.Cells[6].Value.ToString()),
                        dgvArticulos.CurrentRow.Cells[0].Value.ToString(), dgvArticulos.CurrentRow.Cells[1].Value.ToString(),
                        dgvArticulos.CurrentRow.Cells[3].Value.ToString(), dgvArticulos.CurrentRow.Cells[4].Value.ToString(),
                        dgvArticulos.CurrentRow.Cells[5].Value.ToString(), cantidad, dgvArticulos.CurrentRow.Cells[2].Value.ToString());
                    
                    return;
                }
                else
                {
                    MessageBox.Show("La cantidad no puede tener un valor de 0");
                    lblCantidad.ForeColor = Color.Red;
                    dgvArticulos.ClearSelection();
                    return;
                }
                // Referencia,Nombre,Composicion,Medida,Precio
            }
        }

        public void actualizarCantidad(decimal p1, int p2)
        {
            String select = "UPDATE ARTICULOS SET STOCK=" + p1 + " WHERE IDARTICULO=" + p2;
            conexion.setData(select);
        }

        private void ArticulosForm_Load(object sender, EventArgs e)
        {
            cargarCombos(cbMedida);
            if (numero == 1)
            {
                txtCantidad.Visible = true;
                lblCantidad.Visible = true;
                label1.Visible = true;
            }
        }

        private void cbMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar(cbMedida.SelectedIndex, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        private void rbEliminados_CheckedChanged(object sender, EventArgs e)
        {
            filtrar(cbMedida.SelectedIndex, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        private void rbNoEliminados_Click(object sender, EventArgs e)
        {
            btnBorrar.Enabled = true;
            btnRestaurar.Enabled = false;
            rbNoEliminados.Checked = true;
            rbEliminados.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNuevoArticulo add = new AddNuevoArticulo(conexion, 0, this, idUsuario,1);
            add.ShowDialog();
            if (add.IsDisposed)
            {
                filtrar(cbMedida.SelectedIndex, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
            }
        }


    }
}
