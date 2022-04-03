using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_Comercial.Conexiones
{
   public static  class AgregarCerosAdelanteDeNumeros
    {
        public static string ceros(string Nro, int Cantidad)
        {
            string numero = null;
            string cuantos = null;
            int i = 0;
            numero = Nro.Trim(' ');
            cuantos = "0";
            for (i = 1; i <= Cantidad; i++)
            {
                cuantos = cuantos + "0";

            }
            return cuantos.Substring(0, Cantidad - numero.Length) + numero;
        }


    }
}
