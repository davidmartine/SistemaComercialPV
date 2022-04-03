using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Aplicacion_Comercial.Conexiones
{
    class CADMaestra
    {
        //conexion a base datos
         public static string conexion = @"Data source=LAPTOP-KM6L71E5\SQLEXPRESS;Initial Catalog=PuntoVenta;Integrated Security=True";
        //public static string conexion = Convert.ToString(Conexiones.Desencryptacion.checkServer());

        public static SqlConnection conectar = new SqlConnection(conexion);

        public static void abrir()
        {
            if(conectar.State == System.Data.ConnectionState.Closed)
            {
                conectar.Open();
            }
        }

        public static  void cerrar()
        {
            if(conectar.State == System.Data.ConnectionState.Open)
            {
                conectar.Close();
            }
        }
    }
   
    
}
    

