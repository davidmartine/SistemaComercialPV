using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Aplicacion_Comercial.Conexiones
{
    public static class DataHelper
    {
        public static DataTable LoadDataTable()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Conexiones.CADMaestra.conexion;
            con.Open();

            da = new SqlDataAdapter("SELECT TOP 100 Descripcion FROM Productos", con);
            da.Fill(dt);

            return dt;
        }

        public static AutoCompleteStringCollection LoadAutoComplete()
        {
            DataTable dt = LoadDataTable();

            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach  (DataRow row in dt.Rows)
            {
                stringCol.Add(Convert.ToString(row["Descripcion"]));
            }

            return stringCol;
        }

    }
}
