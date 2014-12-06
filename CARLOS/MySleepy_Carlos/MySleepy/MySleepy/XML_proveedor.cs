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
        public static void Leerxml(String direccionXml,String tabla)
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i;
            String[,] resultado;
            FileStream fs = new FileStream(direccionXml, FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName(tabla);
            resultado = new String[xmlnode.Count,];
            for (i = 0; i < xmlnode.Count - 1; i++)
            {
                xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                
            }
        }
    }
}
