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
           try{
               var addr = new System.Net.Mail.MailAddress(email);
               return true;
           }
           catch{
                return false;
           }
        }
    }
}
