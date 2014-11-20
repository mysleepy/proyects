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
        public ClientesForm()
        {
            InitializeComponent();
            conexion = new ConnectDB();
            cargarTabla();
        }

        public void cargarTabla()
        {
            int idCliente, telefono;
            String nombre, apellido, direccion, poblacion, email;

            String sentencia = "SELECT C.IDCLIENTE,C.NOMBRE,C.APELLIDO1,C.TELEFONO,C.DIRECCION,P.POBLACION,C.EMAIL FROM CLIENTES C, POBLACIONES P WHERE C.REFCPPOBLACIONES=P.IDPOBLACION";
            DataSet data;
            data = conexion.getData(sentencia, "tClientes");

            DataTable tClientes = data.Tables["tClientes"];
            

            foreach (DataRow row in tClientes.Rows)
            {
                idCliente = Convert.ToInt32(row["IDCLIENTE"]);
                nombre = Convert.ToString(row["NOMBRE"]);
                apellido = Convert.ToString(row["APELLIDO1"]);
                telefono = Convert.ToInt32(row["TELEFONO"]);
                direccion = Convert.ToString(row["DIRECCION"]);
                poblacion = Convert.ToString(row["POBLACION"]);
                email = Convert.ToString(row["EMAIL"]);

                dgvClientes.Rows.Add(idCliente,nombre,apellido,telefono,direccion,poblacion,email);
            } // Fin del bucle for each
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
