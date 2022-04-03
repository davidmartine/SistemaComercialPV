using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion_Comercial.Conexiones
{
    class Cambiar_el_separador_de_decimales
    {
       public static void cambiar()
        {
                //CAMBIAR EL IDIOMA SEPARADORES DE CONVERSIONES DE , A .
                //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CO");
                //System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.CurrencyDecimalSeparator = ".";
                //System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.CurrencyGroupSeparator = ",";
                //System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.NumberDecimalSeparator = ".";
                //System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.NumberGroupSeparator = ",";

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CO");
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ",";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ",";

        }


    }
}
