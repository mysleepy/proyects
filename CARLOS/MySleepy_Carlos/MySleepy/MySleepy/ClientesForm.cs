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
    public partial class ClientesForm : Form
    {
        ConnectDB conexion;
        private int rolUsuario;
        private int ckEliminado;
        private AddPedido addPedido;
        private int numero; // Almacena si lo llama el formulario Add pedido
        //Atributo que almacena la sentencia BASE sin filtros
        private const String SQL = "SELECT * FROM CLIENTES C, POBLACIONES P, CODIGOSPOSTALESPOBLACIONES X,PROVINCIAS R WHERE C.REFCPPOBLACIONES=X.IDCODIGOPOSTALPOB AND X.REFPOBLACION = P.IDPOBLACION AND X.REFPROVINCIA = R.IDPROVINCIA AND C.ELIMINADO = 0";
        private ToolTip toolTip1;
        public ClientesForm(int idRol,int señal, ConnectDB c,AddPedido a)
        {
            toolTip1 = new ToolTip();
            InitializeComponent();
            conexion = c;
            rolUsuario = idRol;
            ckEliminado = 0;
            cargarTabla(SQL);
            numero = señal;
            addPedido = a;
        }

        public ClientesForm(int idRol, ConnectDB conexion)
        {
            toolTip1 = new ToolTip();
            InitializeComponent();
            this.rolUsuario = idRol;
            this.conexion = conexion;
            cargarTabla(SQL);
            ckEliminado = 0;
        }

        //Con este modo se limpia la tabla
        public void limpiarTabla()
        {
            // Limpiamos el datagridView
            while (dgvClientes.RowCount > 0)
            {
                dgvClientes.Rows.Remove(dgvClientes.CurrentRow);
            }
        }
        //Con este metodo cargo la tabla Clientes
        public void cargarTabla(String sql)
        {
            limpiarTabla();
            int idCliente,telefono;
            String nombre, dni, apellido1,apellido2, direccion, poblacion, email;

            sql = sql + " AND ELIMINADO = "+this.ckEliminado+" order by C.IDCLIENTE";
            DataSet data;
            data = conexion.getData(sql, "CLIENTES");

            DataTable tClientes = data.Tables["CLIENTES"];
            foreach (DataRow row in tClientes.Rows)
            {
                idCliente = Convert.ToInt32(row["IDCLIENTE"]);
                dni = Convert.ToString(row["DNI"]);
                nombre = Convert.ToString(row["NOMBRE"]);
                apellido1 = Convert.ToString(row["APELLIDO1"]);
                apellido2 = Convert.ToString(row["APELLIDO2"]);
                telefono = Convert.ToInt32(row["TELEFONO"]);
                direccion = Convert.ToString(row["DIRECCION"]);
                poblacion = Convert.ToString(row["POBLACION"]);
                email = Convert.ToString(row["EMAIL"]);

                dgvClientes.Rows.Add(idCliente,dni,nombre,apellido1,apellido2,telefono,direccion,poblacion,email);
            } // Fin del bucle for each
            dgvClientes.ClearSelection();
            dgvClientes.Update();
        }
        //Boton salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Abro la ventana añadir clientes
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            AddCliente add = new AddCliente(conexion,this);
            add.Show();
        }
        //Metodo que es llamado cuando se carga la interfaz
        private void ClientesForm_Load(object sender, EventArgs e)
        {
            dgvClientes.ClearSelection();
            dgvClientes.Update();
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
            toolTip1.SetToolTip(this.btnAñadir, "Añadir cliente");
            toolTip1.SetToolTip(this.btnLimpiar, "Borrar filtros");
            toolTip1.SetToolTip(this.btnModificar, "Modificar Cliente");
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
        //Metodo que es llamado cada vez que se produce un cambio en el checkbox
        private void ckbBorrar_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbBorrar.Checked == true)
            {
                this.ckEliminado = 1;
                btnBorrar.Image = MySleepy.Properties.Resources.restaurar;
                tooltipBorrar();
            }
            else
            {
                this.ckEliminado = 0;
                btnBorrar.Image = MySleepy.Properties.Resources.papelera_de_reciclaje;
                tooltipBorrar();
            }
            filtrar();
        }
        //Metodo para extraer id
        public int extraerIDTabla()
        {
            DataGridViewRow fila = dgvClientes.CurrentRow;
            int id = Convert.ToInt32(fila.Cells[0].Value);
            return id;
        }
        //Boton modificar
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count != 0)
            {
                int idClienteSel =extraerIDTabla();
                AddCliente add = new AddCliente(conexion, this, idClienteSel);
                add.Show();
            }
            else{
                MessageBox.Show(this, "No hay ningún Cliente seleccionado", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //Boton borrar y restaurar
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count != 0)
            {
                String mensaje, mensajeConf;
                int eliminar_rest;
                if (this.ckEliminado == 0)
                {
                    mensaje = "¿Desea borrar al cliente?";
                    mensajeConf = "Cliente borrado correctamente";
                    eliminar_rest = 1;
                }
                else
                {
                    mensaje = "¿Desea restaurar al cliente?";
                    mensajeConf = "Cliente restaurado correctamente";
                    eliminar_rest = 0;
                }
                int idCliente;
                dgvClientes.ClearSelection();
                //pedimos confirmacion
                DialogResult opcion = MessageBox.Show(mensaje, "Confirmación",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (opcion == DialogResult.OK)
                {
                    idCliente = extraerIDTabla();
                    if (dgvClientes.CurrentRow == null)
                    {
                        MessageBox.Show("Debe seleccionar una fila");
                    }
                    else
                    {
                        String update = " UPDATE CLIENTES  set ELIMINADO = " + eliminar_rest + " where IDCLIENTE=" + idCliente;
                        conexion.setData(update);

                        //Actualizar los usuarios visualizados en el data grid view
                        MessageBox.Show(mensajeConf, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                    }

                }
            }
            else
            {
                MessageBox.Show(this, "No hay ningún Cliente seleccionado", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
          }
           //Metodo que limpia la interfaz
            public void limpiar()
            {
                txtNombre.Text = "";
                txtPoblacion.Text = "";
                txtApellido.Text = "";
                txtCM.Text = "";
                txtProvincia.Text = "";
                ckbBorrar.Checked = false;
                cargarTabla(SQL);
            }
            //Metodo usado para filtrar la tabla
            private void filtrar()
            {
                String sentencia = "SELECT * FROM CLIENTES C, POBLACIONES P, COMUNIDADES M, CODIGOSPOSTALESPOBLACIONES X,PROVINCIAS R"+
                    " WHERE C.REFCPPOBLACIONES=X.IDCODIGOPOSTALPOB AND X.REFPOBLACION = P.IDPOBLACION AND X.REFPROVINCIA = R.IDPROVINCIA"+
                    " AND M.IDCOMUNIDAD = R.REFCOMUNIDAD";
                if (txtNombre.Text !="")
                {
                    sentencia = sentencia + " AND UPPER(C.NOMBRE) LIKE '%" + txtNombre.Text.ToUpper() + "%'";
                }
                if (txtApellido.Text != "")
                {
                    sentencia = sentencia + " AND UPPER(C.APELLIDO1) LIKE '%" + txtApellido.Text.ToUpper() + "%'";
                }
                if (txtPoblacion.Text != "")
                {
                    sentencia = sentencia + " AND UPPER(P.POBLACION) LIKE '%" + txtPoblacion.Text.ToUpper() +"%'";
                }
                if (txtProvincia.Text != "")
                {
                    sentencia = sentencia + " AND UPPER(R.PROVINCIA) LIKE '%" + txtProvincia.Text.ToUpper() + "%'";
                }
                if (txtCM.Text != "")
                {
                    sentencia = sentencia + " AND UPPER(M.COMUNIDAD) LIKE '%" + txtCM.Text.ToUpper() + "%'";
                }
                cargarTabla(sentencia);
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

            private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                if (numero == 1)
                {
                    addPedido.cargarCliente(dgvClientes.CurrentRow.Cells[0].Value.ToString(), dgvClientes.CurrentRow.Cells[1].Value.ToString(), dgvClientes.CurrentRow.Cells[2].Value.ToString(), dgvClientes.CurrentRow.Cells[2].Value.ToString(), dgvClientes.CurrentRow.Cells[4].Value.ToString(), dgvClientes.CurrentRow.Cells[5].Value.ToString());
                    MessageBox.Show("Cliente añadido al pedido");
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
            
        }
    }

