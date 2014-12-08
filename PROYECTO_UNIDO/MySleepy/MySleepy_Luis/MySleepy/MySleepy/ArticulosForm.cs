﻿using System;
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
        public ArticulosForm(int idRol, int numero, AddPedido ped, ConnectDB c, int idUsuario)
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

        public ArticulosForm(int idRol, ConnectDB conexion, int idUsuario)
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
            String sentencia = "SELECT A.REFERENCIA,A.PRECIO,A.NOMBRE,C.COMPOSICION,M.MEDIDA FROM ARTICULOS A, COMPOSICIONES C, MEDIDA M  WHERE A.REFCOMPOSICION=C.IDCOMPOSICION AND A.REFMEDIDA=M.IDMEDIDA  ELIMINADO=0";
            actualizarDGV(sentencia);
            dgvArticulos.ClearSelection();
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

        public void filtrar(String medida, String nombre, String referencia, String precio)
        {
            String sentencia = "SELECT * FROM ARTICULOS WHERE ELIMINADO=0";

            if (rbEliminados.Checked == true)
            {
                sentencia = "SELECT * FROM ARTICULOS WHERE ELIMINADO=1";

            }

            if (medida != "")
            {
                sentencia = sentencia + " AND MEDIDA LIKE '%'" + medida + "%'";

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
                int referencia = Convert.ToInt32(row["A.REFERENCIA"]);
                String nombre = Convert.ToString(row["A.NOMBRE"]);
                String composicion = Convert.ToString(row["C.COMPOSICION"]);
                String medida = Convert.ToString(row["M.MEDIDA"]);
                String precio = Convert.ToString(row["A.PRECIO"]);
                dgvArticulos.Rows.Add(referencia, nombre, composicion, medida, precio);

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
            AddNuevoArticulo add = new AddNuevoArticulo(conexion, 0, this,idUsuario);
            add.Show();
            if (add.IsDisposed)
            {
                filtrar(txtMedida.Text, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // limpiarSeleccion();
            if (dgvArticulos.CurrentRow != null)
            {
                AddNuevoArticulo add = new AddNuevoArticulo(conexion, 1, this,idUsuario);
                add.activarReferencia(false);
                add.rellenar(dgvArticulos.CurrentRow);
                add.Show();
            }
            else
            {
                MessageBox.Show("Debes seleccionar un registro");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            this.dgvArticulos.ClearSelection();
            if (dgvArticulos.RowCount == 0)
            {
                MessageBox.Show("No hay articulos para borrar");
                return;
            }
            if (dgvArticulos.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("¿Seguro que desea eliminar el articulo?", "Eliminar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    eliminarRegistro(dgvArticulos.CurrentRow);
                    // Actualiza tabla
                    cargarDGVInicio();
                    //dgvArticulos.Rows.RemoveAt(dgvArticulos.CurrentRow.Index);
                    limpiarSeleccion();
                    filtrar(txtMedida.Text, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
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

            //insert en la tabla historial de cambios
            String nombreArticulo = Convert.ToString
                            (conexion.DLookUp("NOMBRE", "USUARIOS", " REFERENCIA = " + referencia));
            insert.insertHistorialCambio(idUsuario, 3, "Articulo eliminado ->" + nombreArticulo);
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

        private void limpiarSeleccion()
        {
            dgvArticulos.ClearSelection();
            dgvArticulos.Update();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.dgvArticulos.ClearSelection();
            if (dgvArticulos.RowCount == 0)
            {
                MessageBox.Show("No hay articulos para borrar");
                return;
            }
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
            //insert en tabla historial cambios
            String nombreArticulo = Convert.ToString
                                    (conexion.DLookUp("NOMBRE", "ARTICULOS", " REFERENCIA ->" + referencia));
            insert.insertHistorialCambio(idUsuario, 4, "Articulo restaurado ->" + nombreArticulo);
        }

        private void rbEliminados_Click(object sender, EventArgs e)
        {
            limpiarSeleccion();
            btnBorrar.Enabled = false;
            btnRestaurar.Enabled = true;
            filtrar(txtMedida.Text, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        private void rbNoEliminados_CheckedChanged(object sender, EventArgs e)
        {
            limpiarSeleccion();
            btnBorrar.Enabled = true;
            btnRestaurar.Enabled = false;
            filtrar(txtMedida.Text, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        private void ArticulosForm_Shown(object sender, EventArgs e)
        {
            dgvArticulos.ClearSelection();
            dgvArticulos.Update();

        }

        private void txtReferencia_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar(txtMedida.Text, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar(txtMedida.Text, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        private void txtMedida_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar(txtMedida.Text, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        private void txtPrecio_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar(txtMedida.Text, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        internal void actualizarTabla()
        {
            filtrar(txtMedida.Text, txtNombre.Text, txtReferencia.Text, txtPrecio.Text);
        }

        private void dgvArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String cantidad = "";
            if (numero == 1)
            {
                if (txtCantidad.Value != 0)
                {
                    cantidad = Convert.ToString(txtCantidad.Value);
                    pedido.nuevoArticulo(dgvArticulos.CurrentRow.Cells[0].Value.ToString(), dgvArticulos.CurrentRow.Cells[1].Value.ToString(), dgvArticulos.CurrentRow.Cells[2].Value.ToString(), dgvArticulos.CurrentRow.Cells[3].Value.ToString(), dgvArticulos.CurrentRow.Cells[4].Value.ToString(), cantidad);
                    return;
                }
                else
                {
                    MessageBox.Show("La cantidad no puede tener un valor de 0");
                    dgvArticulos.ClearSelection();
                    return;
                }
                // Referencia,Nombre,Composicion,Medida,Precio

            }
        }

        private void ArticulosForm_Load(object sender, EventArgs e)
        {
            if (numero == 1)
            {
                txtCantidad.Visible = true;
                lblCantidad.Visible = true;
            }
        }
    }
}
