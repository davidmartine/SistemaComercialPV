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
    public partial class frmMovimientosFiltros : Form
    {
        public frmMovimientosFiltros()
        {
            InitializeComponent();
        }

        private void frmMovimientosFiltros_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        //llamado al reportador
        Formularios.Reportes_Kardex.Reportes_Kardex_Diseño.ReporteMovimientosFiltros rptMovimientosFiltros = new ReporteMovimientosFiltros();

        private void mostrar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();

                da = new SqlDataAdapter("Buscar_Movimientos_Kardex_Filtros", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Fecha", Formularios.Inventario_Kardex.Inventario_Menu.fecha);
                da.SelectCommand.Parameters.AddWithValue("@Tipo", Formularios.Inventario_Kardex.Inventario_Menu.tipo_de_movimiento);
                da.SelectCommand.Parameters.AddWithValue("@idUsuario", Formularios.Inventario_Kardex.Inventario_Menu.idusuario);
                da.Fill(dt);
                con.Close();

                rptMovimientosFiltros = new ReporteMovimientosFiltros();
                rptMovimientosFiltros.DataSource = dt;
                rptMovimientosFiltros.table1.DataSource = dt;
                reportViewer1.Report = rptMovimientosFiltros;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
