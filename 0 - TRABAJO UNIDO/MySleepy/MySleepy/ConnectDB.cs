using System;
using System.Data;
using System.Data.OracleClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySleepy
{
    public class ConnectDB
    {
        ////////////////////////////////////////////////////////////
        //////////////////// ASIGNAR DRIVER //////////////////////
        ////////////////////////////////////////////////////////////
        const String driver = "Data Source=(DESCRIPTION ="
        + "(ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = LOCALHOST)(PORT = 1521)))"
        + "(CONNECT_DATA = (SERVICE_NAME = ORADAM2))); "
        + "User Id=C##EJEMPLO1; Password=3907;";

        ////////////////////////////////////////////////////////////

        /**
         * Metodo que devuelve un conjunto de datos de la tabla 
         * Parametros: Query----> Consulta
         * Parametros: Tabla ----> Tabla que queremos buscar
         */
        public DataSet getData(String query, String table)
        {
            OracleConnection objConexion;
            OracleDataAdapter objComando;
            DataSet requestQuery = new DataSet();

            objConexion = new OracleConnection(driver);
            objConexion.Open();
            objComando = new OracleDataAdapter(query, objConexion);
            objComando.Fill(requestQuery, table);
            objConexion.Close();

            return requestQuery;
        }

        /**
         * Metodo que devuelve un conjunto de datos de la tabla 
         * Parametros: Sentencia ----> Sentencia a realizar
         */
        public void setData(String sentencia)
        {
            OracleConnection objConexion;
            OracleCommand objComando;

            objConexion = new OracleConnection(driver);
            objConexion.Open();
            objComando = new OracleCommand(sentencia, objConexion);

            objComando.ExecuteNonQuery();
            objComando.Connection.Close();
        }

        /**
         * Metodo que realiza la consulta
         * Parametros: columna-----> Columna
         * Parametros: Tabla ------> Tabla que queremos buscar
         * Parametros: Condicion --> Condicion para extraer los registros
         */
        public Object DLookUp(String columna, String tabla, String condicion)
        {
            OracleConnection objConexion;
            OracleDataAdapter objComando;
            DataSet requestQuery = new DataSet();
            Object resultado;

            objConexion = new OracleConnection(driver);
            objConexion.Open();

            if (condicion.Equals(""))
            {
                objComando = new OracleDataAdapter("Select " + columna + " from " + tabla, objConexion);
            }
            else
            {
                objComando = new OracleDataAdapter("Select " + columna + " from " + tabla + " where " + condicion, objConexion);
            }

            objComando.Fill(requestQuery);

            try
            {
                resultado = requestQuery.Tables[0].Rows[0][requestQuery.Tables[0].Columns.IndexOf(columna)];
            }
            catch (Exception a)
            {
                resultado = -1;
            }
            objConexion.Close();
            return resultado;
        }

        public int siguienteID(String campo, String tabla)
        {
            String sentencia = "SELECT MAX(" + campo + ") from " + tabla;
            DataSet resultado = getData(sentencia, tabla);
            DataTable tTabla = resultado.Tables[tabla];

            int idg = 0;
            foreach (DataRow row in tTabla.Rows)
            {
                try{
                    idg = Convert.ToInt16(row["MAX(" + campo + ")"]);
                }catch (Exception a)
                {
                    break;
                }
            }
            return idg + 1;
        }
    }
}
