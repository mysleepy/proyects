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
    public partial class HistorialForm : Form
    {
        ConnectDB conexion;
        private int idUsuario;
        public HistorialForm(int idUsuario, ConnectDB c)
        {
            InitializeComponent();
            this.conexion = c;
            this.idUsuario = idUsuario;
            cargarTablaInicio();
        }

        public void limpiarTabla()
        {
            // Limpiamos el datagridView
            while (dgvHistorial.RowCount > 0)
            {
                dgvHistorial.Rows.Remove(dgvHistorial.CurrentRow);
            }
        }
        public void cargarTablaInicio()
        {
            //solo mostraremos los no eliminados inicialmente
            String select = "SELECT * from HISTORIALCAMBIOS order by IDHISTOCAMBIO";
            cargarTabla(select);
        }
        public void cargarTabla(String sentencia)
        {

           // limpiarTabla();     

            DataSet data;
            data = conexion.getData(sentencia, "HISTORIALCAMBIOS");

            DataTable tUsuarios = data.Tables["HISTORIALCAMBIOS"];

            int idHistorial = 0,idTipo = 0;
            String fecha = "",observacion  ="",tipoCambio="",nombre ="";
            foreach (DataRow row in tUsuarios.Rows)
            {
                idHistorial = Convert.ToInt32(row["IDHISTOCAMBIO"]);
                idUsuario = Convert.ToInt32(row["IDUSUARIO"]);
                nombre = Convert.ToString(conexion.DLookUp("NOMBRE", "USUARIOS", "IDUSUARIO = " + idUsuario));
                fecha = Convert.ToString(row["FECHA"]);
                idTipo = Convert.ToInt32(row["IDTIPOCAMBIO"]);
                tipoCambio = Convert.ToString(conexion.DLookUp("DESCRIPCION","TIPOCAMBIO","IDTIPOCAMBIO ="+idTipo));
                observacion = Convert.ToString(row["OBSERVACION"]);

                dgvHistorial.Rows.Add(nombre,fecha, tipoCambio,observacion);

            } // Fin del bucle for each
            dgvHistorial.ClearSelection();
            dgvHistorial.Update();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
