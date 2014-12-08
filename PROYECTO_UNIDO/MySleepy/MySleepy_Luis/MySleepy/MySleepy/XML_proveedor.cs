using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace MySleepy
{
    class XML_proveedor
    {
        /// <summary>
        /// Metodo que lee el archivo indicado y devuelve un
        /// array de String con los valores de los campos
        /// </summary>
        /// <param name="direccionXml">ruta del archivo a leer</param>
        /// <param name="tabla">tabla a leer de la BBDD</param>
        /// <param name="campos">cantidad de campos que contiene la tabla a leer</param>
        /// <returns>un array de String con todos los nodos</returns>
        public static String[,] Leerxml(String direccionXml,String tabla,int campos)
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i;
            String[,] resultado;
            FileStream fs = new FileStream(direccionXml, FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName(tabla);
            resultado = new String[xmlnode.Count,campos];
            for (i = 0; i < xmlnode.Count - 1; i++)
            {
                xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                for (int j = 0; j < campos; j++)
                {
                    resultado[i, j] = xmlnode[i].ChildNodes.Item(j).InnerText.Trim();
                }
            }
            return resultado;
        }
        /// <summary>
        /// Metodo que escribira en el archivo XML especificado
        /// </summary>
        /// <param name="rutaXml">ruta en la que se encuentra o se creara el archivo</param>
        /// <param name="nombreElemento">Nombre usado para los nodos</param>
        /// <param name="nombreColumnas">Nombres usados para los nodos hijos</param>
        /// <param name="valorCampos">Valores a almacenar en cada nodo hijo</param>
        public static void escribirXml(String rutaXml, String nombreElemento,String[] nombreColumnas,String[,] valorCampos)
        {
            XmlTextWriter writer = new XmlTextWriter(rutaXml, System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Table");
            for (int i = 0; i < valorCampos.GetUpperBound(0); i++)
            {
                String[] registro = new String[valorCampos.GetUpperBound(1)];
                for (int j = 0; j < registro.Length; j++)
                {
                    registro[j] = valorCampos[i, j];                  
                }
                crearNodo(writer, nombreElemento, nombreColumnas, registro);
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        public static void insertXML(String rutaXml, String nombreElemento, String[] nombreColumnas, String[,] valorCampos)
        {
            XmlTextWriter writer = new XmlTextWriter(rutaXml, System.Text.Encoding.UTF8);
            //writer.WriteStartDocument(false);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Table");
            for (int i = 0; i < valorCampos.GetUpperBound(0); i++)
            {
                String[] registro = new String[valorCampos.GetUpperBound(1)];
                for (int j = 0; j < registro.Length; j++)
                {
                    registro[j] = valorCampos[i, j];
                }
                crearNodo(writer, nombreElemento, nombreColumnas, registro);
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }
        /// <summary>
        /// Metodo que genera los nodos para almacenar los 
        /// datos en el archivo xml
        /// </summary>
        /// <param name="writer">Clase usada para escribir en el archivo XML</param>
        /// <param name="nombreElemento">Nombre usado para los nodos</param>
        /// <param name="nombreColumnas">Nombres para los nodos hijo (ChildNode)</param>
        /// <param name="valorCampos">Valores a almacenar en cada nodo hijo</param>
        private static void crearNodo(XmlTextWriter writer,String nombreElemento, String[] nombreColumnas, String[] valorCampos)
        {
            writer.WriteStartElement(nombreElemento);
            for (int i = 0; i < nombreColumnas.Length; i++)
            {
                writer.WriteStartElement(nombreColumnas[i]);
                writer.WriteString(valorCampos[i]);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
    }
}
