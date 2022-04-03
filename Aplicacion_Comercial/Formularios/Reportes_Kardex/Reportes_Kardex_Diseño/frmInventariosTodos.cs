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
    public partial class frmInventariosTodos : Form
    {
        public frmInventariosTodos()
        {
            InitializeComponent();
        }

        private void frmInventariosTodos_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void mostrar()
        {
            try
            {
                DataTable dt = new DataTable();
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Imprimir_Mostrar_Inventarios_Todos", Conexiones.CADMaestra.conectar);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
                ReportInventariosTodos rpt = new ReportInventariosTodos();
                rpt.table1.DataSource = dt;
                rpt.DataSource = dt;
                reportViewer1.Report = rpt;
                reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
