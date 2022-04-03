using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Aplicacion_Comercial.Formularios.Reportes_Kardex.Reportes_Kardex_Diseño
{
    public partial class frmMovimientosBuscar : Form
    {
        public frmMovimientosBuscar()
        {
            InitializeComponent();
        }

        private void frmMovimientosBuscar_Load(object sender, EventArgs e)
        {
            mostrar();
        }
        //llamado al reporte
        Formularios.Reportes_Kardex.Reportes_Kardex_Diseño.ReporteMovimientoBuscar rptMovimientoBuscar = new ReporteMovimientoBuscar();
        private void mostrar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();

                da = new SqlDataAdapter("Buscar_Movimientos_Kardex", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idProducto", Formularios.Inventario_Kardex.Inventario_Menu.idProducto);
                da.Fill(dt);
                con.Close();

                rptMovimientoBuscar = new ReporteMovimientoBuscar();
                rptMovimientoBuscar.DataSource = dt;
                reportViewer1.Report = rptMovimientoBuscar;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
