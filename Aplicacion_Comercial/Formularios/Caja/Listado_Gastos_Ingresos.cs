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

namespace Aplicacion_Comercial.Formularios.Caja
{
    public partial class Listado_Gastos_Ingresos : Form
    {
        public Listado_Gastos_Ingresos()
        {
            InitializeComponent();
        }

        private int Id_Caja;
        private DateTime FechaInicial;
        private DateTime FechaFinal;
        private void Listado_Gastos_Ingresos_Load(object sender, EventArgs e)
        {
            FechaFinal = DateTime.Now;
            mostrar_cierre_caja_pendiente();
            listar_gastos();
            listar_ingresos();
        }

        private void sumar_gastos()
        {
            double TotalGasto = 0;
            foreach(DataGridViewRow rowGasto in datalistadoGastos.Rows)
            {
                TotalGasto += Convert.ToDouble(rowGasto.Cells["Importe"].Value);
            }
            lblTotalGastos.Text =Convert.ToString(TotalGasto);
        }

        private void sumar_ingresos()
        {
            double TotalIngreso = 0;
            foreach(DataGridViewRow rowIngreso in datalistadoIngresos.Rows)
            {
                TotalIngreso += Convert.ToDouble(rowIngreso.Cells["Importe"].Value);
            }
            lblTotalIngresos.Text = TotalIngreso.ToString();
        }
        private void listar_gastos()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.mostrar_gastos_por_turno(ref dt, Id_Caja, FechaInicial, FechaFinal);
            datalistadoGastos.DataSource = dt;
            Logica.BasesPCProgram.Multilinea(ref datalistadoGastos);
            datalistadoGastos.Columns[1].Visible = false;
            sumar_gastos();
        }

        private void listar_ingresos()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.mostrar_ingresos_por_turno(ref dt, Id_Caja, FechaInicial, FechaFinal);
            datalistadoIngresos.DataSource = dt;
            Logica.BasesPCProgram.Multilinea(ref datalistadoIngresos);
            datalistadoIngresos.Columns[1].Visible = false;
            sumar_ingresos();
        }

        private void mostrar_cierre_caja_pendiente()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.mostrar_cierre_de_caja_pendiente(ref dt);
            foreach(DataRow row in dt.Rows)
            {
                Id_Caja =Convert.ToInt32(row["Id_caja"]);
                FechaInicial =Convert.ToDateTime(row["fechainicio"]);
            }
        }

        private void datalistadoGastos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == datalistadoGastos.Columns["EliminarGasto"].Index)
            {
                DialogResult result;
                result = MessageBox.Show("¿ESTA SEGURO DE ELIMINAR ESTE GASTO?", "ELIMINAR GASTO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(result == DialogResult.OK)
                {
                    int idGasto = Convert.ToInt32(datalistadoGastos.SelectedCells[1].Value);
                    Datos.CADEliminarDatos.eliminar_gasto(idGasto);
                    listar_gastos();
                }
            }
        }

        private void datalistadoIngresos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex== datalistadoIngresos.Columns["EliminarIngreso"].Index)
            {
                DialogResult result;
                result = MessageBox.Show("¿ESTA SEGURO DE ELIMINAR ESTE INGRESO", "ELIMINAR INGRESO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(result == DialogResult.OK)
                {
                    int idIngreso =Convert.ToInt32(datalistadoIngresos.SelectedCells[1].Value);
                    Datos.CADEliminarDatos.eliminar_ingreso(idIngreso);
                    listar_ingresos();
                }
            }
        }
    }
}
