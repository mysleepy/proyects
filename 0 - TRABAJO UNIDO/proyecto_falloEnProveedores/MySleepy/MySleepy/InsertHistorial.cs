using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySleepy;
using System.IO;

namespace MySleepy
{
    class InsertHistorial
    {
        ConnectDB conexion;
        private HistorialForm historialForm;
        

        public InsertHistorial(ConnectDB conexion)
        {
            this.conexion = conexion;
            historialForm = new HistorialForm(conexion);
        }

        //METODOS DE HISTORIAL DE CAMBIOS -> CLASE A PARTE
        public void insertHistorialCambio(int idUsuario, int tipoCambio, String cambio)
        {

            String date = System.DateTime.Today.ToString("d");
            String insert = "INSERT INTO HISTORIALCAMBIOS VALUES (" + (ultimoIDHistorial() + 1) + ", " + idUsuario +
                            " , '" + date + "', " + tipoCambio + ", '" + cambio + "')";
            conexion.setData(insert);
            //MessageBox.Show(insert);

        }


        public int ultimoIDHistorial()
        {
            //Extraemos el id del rol seleccionado en el comboBox
            String extraerID = "Select IDHISTOCAMBIO from HISTORIALCAMBIOS";
            DataSet data = conexion.getData(extraerID, "HISTORIALCAMBIOS");

            DataTable tUsuarios = data.Tables["HISTORIALCAMBIOS"];

            int idUser = 0;
            foreach (DataRow row in tUsuarios.Rows)
            {
                idUser = Convert.ToInt16(row["IDHISTOCAMBIO"]);

            } // Fin del bucle for each

            return idUser;
        }

        public void guardarEnFichero(DataGridView tabla)
        {
            String fichero = Directory.GetCurrentDirectory();
            fichero = fichero + "\\" + "historialCambios.txt";

            try
            {
                //Uso el flujo de escritura y añado en el fichero
                using (StreamWriter writer = new StreamWriter(fichero))
                {

                    //Escribo en el fichero los valores de cada registro de la tabla dgvHistorial
                    //Recorrer datagridview por filas. Mensajes es el nombre que le pongo
                    for (int i = 0; i < tabla.RowCount; i++)
                    {
                        String usuario = (String)tabla.Rows[i].Cells[0].Value;
                        String fecha = (String)tabla.Rows[i].Cells[1].Value;
                        String tipo = (String)tabla.Rows[i].Cells[2].Value;
                        String observacion = (String)tabla.Rows[i].Cells[3].Value;
                        writer.Write(usuario + "#" + fecha + "#" + tipo + "#" + observacion + "##");
                        writer.WriteLine("\n");
                    }
                    writer.Close();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error: " + e);
            }
        }
    }
}
