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
        public static String CalculaNIF(String strA)
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
        /// <summary>
        /// Funcion que valida un CIF
        /// </summary>
        /// <param name="Numero">El numero del CIF a validar</param>
        /// <returns>True si el CIF es correcto</returns>
        public static bool Valida_CIF(string Numero)
        {
            //Valida el cif actual
            string[] letrasCodigo = { "J", "A", "B", "C", "D", "E", "F", "G", "H", "I" };

            string LetraInicial = Numero[0].ToString();
            string DigitoControl = Numero[Numero.Length - 1].ToString();
            string n = Numero.ToString().Substring(1, Numero.Length - 2);
            int sumaPares = 0;
            int sumaImpares = 0;
            int sumaTotal = 0;
            int i = 0;
            bool retVal = false;

            // Recorrido por todos los dígitos del número
            // Recorrido por todos los dígitos del número
            for (i = 0; i < n.Length; i++)
            {
                int aux;
                Int32.TryParse(n[i].ToString(), out aux);

                if ((i + 1) % 2 == 0)
                {
                    // Si es una posición par, se suman los dígitos
                    sumaPares += aux;
                }
                else
                {
                    // Si es una posición impar, se multiplican los dígitos por 2
                    aux = aux * 2;

                    // se suman los dígitos de la suma
                    sumaImpares += SumaDigitos(aux);
                }
            }

            // Se suman los resultados de los números pares e impares
            sumaTotal += sumaPares + sumaImpares;

            // Se obtiene el dígito de las unidades
            Int32 unidades = sumaTotal % 10;

            // Si las unidades son distintas de 0, se restan de 10
            if (unidades != 0) unidades = 10 - unidades;

            switch (LetraInicial)
            {
                // Sólo números
                case "A":
                case "B":
                case "E":
                case "H":
                    retVal = DigitoControl == unidades.ToString();
                    break;

                // Sólo letras
                case "K":
                case "P":
                case "Q":
                case "S":
                    retVal = DigitoControl == letrasCodigo[unidades];
                    break;

                default:
                    retVal = (DigitoControl == unidades.ToString()) || (DigitoControl == letrasCodigo[unidades]);
                    break;
            }

            return retVal;

        }

        private static Int32 SumaDigitos(Int32 digitos)
        {
            string sNumero = digitos.ToString();
            Int32 suma = 0;

            for (Int32 i = 0; i < sNumero.Length; i++)
            {
                Int32 aux;
                Int32.TryParse(sNumero[i].ToString(), out aux);
                suma += aux;
            }
            return suma;
        }

    }
}
