using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySleepy
{
    class MetodosAuxiliares
    {
        //Metodo que comprueba si el string pasado se corresponde con la estructura de un email
        public static Boolean emailCorrecto(String email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Metodo que comprueba si el dni pasado es correcto
        /// <summary>
        /// Valida un NIF
        /// </summary>
        /// <param name="valor">NIF a validar</param>
        /// <returns>Resultado de la validacion</returns>
        public static Boolean VerificarNIF(String valor)
        {
            String aux = null;
            valor = valor.ToUpper();
            // ponemos la letra en mayúscula
            aux = valor.Substring(0, valor.Length - 1);
            // quitamos la letra del NIF
            if (aux.Length >= 7 && CadenaEsNumero(aux))
            {
                aux = CalculaNIF(aux); // calculamos la letra del NIF para comparar con la que tenemos
            }
            else
            {
                return false;
            }
            // comparamos las letras
            return (valor.Equals(aux));
        }

        /// <summary>
        /// Dado un DNI obtiene la letra que le corresponde al NIF
        /// </summary>
        /// <param name="strA">DNI</param>
        /// <returns>Letra del NIF</returns>
        private static String CalculaNIF(String strA)
        {
            const String cCADENA = "TRWAGMYFPDXBNJZSQVHLCKE";
            const String cNUMEROS = "0123456789";

            int a = 0;
            int b = 0;
            int c = 0;
            int NIF = 0;
            StringBuilder sb = new StringBuilder();

            strA = strA.Trim();
            if (strA.Length == 0) return "";

            // Dejar sólo los números
            for (int i = 0; i <= strA.Length - 1; i++)
                if (cNUMEROS.IndexOf(strA[i]) > -1) sb.Append(strA[i]);

            strA = sb.ToString();
            a = 0;
            NIF = Convert.ToInt32(strA);
            do
            {
                b = Convert.ToInt32((NIF / 24));
                c = NIF - (24 * b);
                a = a + c;
                NIF = b;
            } while (b != 0);

            b = Convert.ToInt32((a / 23));
            c = a - (23 * b);
            return strA.ToString() + cCADENA.Substring(c, 1);
        }
        /// <summary>
        /// Comprueba si una cadena introducida esta compuesta unicamente por numeros
        /// </summary>
        /// <param name="cadena">cadena a comprobar</param>
        /// <returns>True- si se compone solo de numeros. False-si no solo hay numeros o ninguno</returns>
        private static Boolean CadenaEsNumero(String cadena)
        {
            foreach (char c in cadena)
            {
                if (!Char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
