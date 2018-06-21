using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
   public static class GuardaString
    {
       public static bool Guardar(this String texto, string archivo)
       {
           bool resp = true;
           try
           {
               StreamWriter abrir = new StreamWriter(archivo, true);
               abrir.WriteLine(texto);
               abrir.Close();
           }
           catch (Exception e)
           {
               resp = false;
               throw e;
           }
           return resp;
       }
    }
}
