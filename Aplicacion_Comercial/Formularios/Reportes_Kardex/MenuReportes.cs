using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion_Comercial.Formularios.Reportes_Kardex
{
    public partial class MenuReportes : Form
    {
        public MenuReportes()
        {
            InitializeComponent();
        }

        private int idUsuario;
        private void MenuReportes_Load(object sender, EventArgs e)
        {
            PanelBienvenida.Visible = true;
            PanelBienvenida.Dock = DockStyle.Fill;

        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            PanelReporteVentas.Visible = true;
            PanelReporteVentas.Dock = DockStyle.Fill;
            PanelBienvenida.Visible = false;
            panelProductos.Visible = false;
            panelCuentas.Visible = false;

            panel4.Enabled = false;
            panelEmpleado.Visible = false;

            btnVentas.BackColor = Color.FromArgb(33,85,168);
            btnVentas.ForeColor = Color.White;
            btnCobrar.BackColor = Color.FromArgb(33, 85, 168);
            btnCobrar.ForeColor = Color.White;
            btnPagar.BackColor = Color.FromArgb(33, 85, 168);
            btnPagar.ForeColor = Color.White;
            btnProductos.BackColor = Color.FromArgb(33, 85, 168);
            btnProductos.ForeColor = Color.White;

            checkFiltros.Checked = false;
            panelFiltros.Visible = false;

        }

        private void btnResumenVentas_Click(object sender, EventArgs e)
        {
            panel4.Enabled = true;
            btnResumenVentas.ForeColor = Color.OrangeRed;
            btnVentasEmpleado.ForeColor = Color.DimGray;
            panelResumenVentas.Visible = true;
            panelVentasEmp.Visible = false;
            btnVentasEmpleado.ForeColor = Color.DimGray;
            btnHastahoy.ForeColor = Color.OrangeRed;
            panelVentasEmp.Visible = false;
            checkFiltros.Checked = false;
            panelFiltros.Visible = false;
            checkFiltros.ForeColor = Color.DimGray;
            panelEmpleado.Visible = false;
            reporte_resumen_ventas();

        }

        private void reporte_resumen_ventas()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.reporte_resumen_ventas(ref dt);
            Reportes_Kardex.Reportes_Ventas.ResumenVentas rpt = new Reportes_Ventas.ResumenVentas();
            rpt.table1.DataSource = dt;
            rpt.DataSource = dt;
            reportViewer1.Report = rpt;
            reportViewer1.RefreshReport();

        }

        private void btnHastahoy_Click(object sender, EventArgs e)
        {
            

        }

        private void checkFiltros_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFiltros.Checked == true)
            {
                if (panelResumenVentas.Visible == true)
                {
                    reporte_resumen_ventas_fechas();
                }
                if (panelVentasEmp.Visible == true)
                {
                    reporte_resumen_ventas_empleado_fechas();
                }
                btnHastahoy.ForeColor = Color.DimGray;
                panelFiltros.Visible = true;
                checkFiltros.ForeColor = Color.OrangeRed;
            }
            else
            {
                if (panelResumenVentas.Visible == true)
                {
                    reporte_resumen_ventas();
                }
                if (panelVentasEmp.Visible == true)
                {
                    reporte_resumen_ventas_empleado();
                }
                btnHastahoy.ForeColor = Color.OrangeRed;
                panelFiltros.Visible = false;
                checkFiltros.ForeColor = Color.DimGray;
            }
        }
        
        private void reporte_resumen_ventas_fechas()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.reporte_resumen_ventas_fechas(ref dt, dtpFechaInicial.Value, dtpFechaFinal.Value);
            Formularios.Reportes_Kardex.Reportes_Ventas.ResumenVentas rpt = new Reportes_Ventas.ResumenVentas();
            rpt.table1.DataSource = dt;
            rpt.DataSource = dt;
            reportViewer1.Report = rpt;
            reportViewer1.RefreshReport();
        }

        

        private void btnVentasEmpleado_Click(object sender, EventArgs e)
        {
            panel4.Enabled = true;
            btnResumenVentas.ForeColor = Color.DimGray;
            btnVentasEmpleado.ForeColor = Color.FromArgb(33, 85, 168);
            panelResumenVentas.Visible = false;
            panelVentasEmp.Visible = true;
            //btnVentasEmpleado.ForeColor = Color.DimGray;
            btnHastahoy.ForeColor = Color.FromArgb(33, 85, 168);
            panelVentasEmp.Visible = false;
            checkFiltros.Checked = false;
            panelFiltros.Visible = false;
            checkFiltros.ForeColor = Color.DimGray;
            panelEmpleado.Visible = true;
            panelVentasEmp.Visible = true;
            mostrar_usuarios();

        }
        private void mostrar_usuarios()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.mostrar_usuarios(ref dt);
            cmbEmpleado.DisplayMember = "Nombres_y_Apellidos";
            cmbEmpleado.ValueMember = "idUsuario";
            cmbEmpleado.DataSource = dt;

        }

        private void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            idUsuario =Convert.ToInt32(cmbEmpleado.SelectedValue);
            if (checkFiltros.Checked == true)
            {
                reporte_resumen_ventas_empleado_fechas();
            }
            else
            {
                reporte_resumen_ventas_empleado();
            }
        }

        private void reporte_resumen_ventas_empleado()
        {
            try
            {
                DataTable dt = new DataTable();
                Datos.ObtenerDatos.reporte_resumen_ventas_empleado(ref dt, idUsuario);
                Formularios.Reportes_Kardex.Reportes_Ventas.ResumenVentas rpt = new Reportes_Ventas.ResumenVentas();
                rpt.table1.DataSource = dt;
                rpt.DataSource = dt;
                reportViewer1.Report = rpt;
                reportViewer1.RefreshReport();
            }
            catch(Exception)
            {

            }
        }

        private void reporte_resumen_ventas_empleado_fechas()
        {
            try
            {
                DataTable dt = new DataTable();
                Datos.ObtenerDatos.reporte_resumen_ventas_empleado_fechas(ref dt, idUsuario, dtpFechaInicial.Value, dtpFechaFinal.Value);
                Reportes_Ventas.ResumenVentas rpt = new Reportes_Ventas.ResumenVentas();
                rpt.table1.DataSource = dt;
                rpt.DataSource = dt;
                reportViewer1.Report = rpt;
                reportViewer1.RefreshReport();
            }
            catch(Exception)
            {

            }
        }

        private void dtpFechaInicial_ValueChanged(object sender, EventArgs e)
        {
            validar_filtros();
        }

        private void dtpFechaFinal_ValueChanged(object sender, EventArgs e)
        {
            validar_filtros();
        }

        private void validar_filtros()
        {
            if (checkFiltros.Checked == true)
            {
                if (panelResumenVentas.Visible == true)
                {
                    reporte_resumen_ventas_fechas();
                }
                if (panelVentasEmp.Visible == true)
                {
                    reporte_resumen_ventas_empleado_fechas();
                }

            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            PanelReporteVentas.Visible = false;
            //PanelReporteVentas.Dock = DockStyle.None;
            PanelBienvenida.Visible = false;
            panelProductos.Visible = false;
            panelCuentas.Visible = true;
            panelCuentas.Dock = DockStyle.Fill;


            btnVentas.BackColor = Color.FromArgb(33,85,168);
            btnVentas.ForeColor = Color.White;
            btnCobrar.BackColor = Color.White;
            btnCobrar.ForeColor = Color.White;
            btnPagar.BackColor = Color.FromArgb(33,85,168);
            btnPagar.ForeColor = Color.White;
            btnProductos.BackColor = Color.FromArgb(33,85,168);
            btnProductos.ForeColor = Color.White;
            reporte_cuentas_cobrar();

        }

        private void reporte_cuentas_cobrar()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.reporte_cuentas_cobrar(ref dt);
            Reportes_Cuentas_por_Cobrar.ReporteCuentasCobrar rpt = new Reportes_Cuentas_por_Cobrar.ReporteCuentasCobrar();
            rpt.table1.DataSource = dt;
            rpt.DataSource = dt;
            reportViewer2.Report = rpt;
            reportViewer2.RefreshReport();

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            PanelReporteVentas.Visible = false;
            //PanelReporteVentas.Dock = DockStyle.None;
            PanelBienvenida.Visible = false;
            panelProductos.Visible = false;
            panelCuentas.Visible = true;
            panelCuentas.Dock = DockStyle.Fill;


            btnVentas.BackColor = Color.FromArgb(33,85,168);
            btnVentas.ForeColor = Color.White;
            btnCobrar.BackColor = Color.FromArgb(33, 85, 168);
            btnCobrar.ForeColor = Color.White;
            btnPagar.BackColor = Color.FromArgb(33, 85, 168);
            btnPagar.ForeColor = Color.White;
            btnProductos.BackColor = Color.FromArgb(33, 85, 168);
            btnProductos.ForeColor = Color.White;
            reporte_cuentas_pagar();
        }

        private void reporte_cuentas_pagar()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.reporte_cuentas_pagar(ref dt);
            Reporte_Cuentas_por_Pagar.ReporteCuentasPagar rpt = new Reporte_Cuentas_por_Pagar.ReporteCuentasPagar();
            rpt.table1.DataSource = dt;
            rpt.DataSource = dt;
            reportViewer2.Report = rpt;
            reportViewer2.RefreshReport();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {

            PanelReporteVentas.Visible = false;
            //PanelReporteVentas.Dock = DockStyle.None;
            PanelBienvenida.Visible = false;
            panelProductos.Visible = true;
            panelProductos.Dock = DockStyle.Fill;
            panelCuentas.Visible = false;
            //panelCuentas.Dock = DockStyle.Fill;


            btnVentas.BackColor = Color.FromArgb(33, 85, 168);
            btnVentas.ForeColor = Color.White;
            btnCobrar.BackColor = Color.FromArgb(33, 85, 168);
            btnCobrar.ForeColor = Color.White;
            btnPagar.BackColor = Color.FromArgb(33, 85, 168);
            btnPagar.ForeColor = Color.White;
            btnProductos.BackColor = Color.FromArgb(33, 85, 168);
            btnProductos.ForeColor = Color.White;

            pInventario.Visible = false;
            pProductoV.Visible = false;
            pStockBajo.Visible = false;
            reportViewer3.Visible = false;

        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            pInventario.Visible = true;
            pProductoV.Visible = false;
            pStockBajo.Visible = false;
            reportViewer3.Visible = true;
            imprimir_inventarios_todos();
        }

        private void imprimir_inventarios_todos()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.mostrar_inventarios_todos(ref dt);
            Reportes_Kardex_Diseño.ReportInventariosTodos rpt = new Reportes_Kardex_Diseño.ReportInventariosTodos();
            rpt.table1.DataSource = dt;
            rpt.DataSource = dt;
            reportViewer3.Report = rpt;
            reportViewer3.RefreshReport();


        }

        private void btnProductosVencidos_Click(object sender, EventArgs e)
        {
            pInventario.Visible = false;
            pProductoV.Visible = true;
            pStockBajo.Visible = false;
            mostrar_productos_vencidos();
        }

        private void mostrar_productos_vencidos()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.mostrar_productos_vencidos(ref dt);
            Reportes_Kardex_Diseño.ReporteProducVencidos rpt = new Reportes_Kardex_Diseño.ReporteProducVencidos();
            rpt.table1.DataSource = dt;
            rpt.DataSource = dt;
            reportViewer3.Visible = true;
            reportViewer3.Report = rpt;
            reportViewer3.RefreshReport();
        }

        private void btnStockBajo_Click(object sender, EventArgs e)
        {
            pInventario.Visible = false;
            pProductoV.Visible = false;
            pStockBajo.Visible = true;
            mostrar_inventarios_bajo_minimo();
        }

        private void mostrar_inventarios_bajo_minimo()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.mostrar_inventarios_bajo_minimo(ref dt);
            Reportes_Kardex_Diseño.ReporteInventBajoMin rpt = new Reportes_Kardex_Diseño.ReporteInventBajoMin();
            rpt.table1.DataSource = dt;
            rpt.DataSource = dt;
            reportViewer3.Visible = true;
            reportViewer3.Report = rpt;
            reportViewer3.RefreshReport();
        }

        private void btnVentas_Click_1(object sender, EventArgs e)
        {
            PanelReporteVentas.Visible = true;
            PanelReporteVentas.Dock = DockStyle.Fill;
            PanelBienvenida.Visible = false;
            panelProductos.Visible = false;
            panelCuentas.Visible = false;

            panel4.Enabled = false;
            panelEmpleado.Visible = false;

            btnVentas.BackColor = Color.FromArgb(33, 85, 168);
            btnVentas.ForeColor = Color.White;
            btnCobrar.BackColor = Color.FromArgb(33, 85, 168);
            btnCobrar.ForeColor = Color.White;
            btnPagar.BackColor = Color.FromArgb(33, 85, 168);
            btnPagar.ForeColor = Color.White;
            btnProductos.BackColor = Color.FromArgb(33, 85, 168);
            btnProductos.ForeColor = Color.White;

            checkFiltros.Checked = false;
            panelFiltros.Visible = false;
        }

        private void btnCobrar_Click_1(object sender, EventArgs e)
        {
            PanelReporteVentas.Visible = false;
            //PanelReporteVentas.Dock = DockStyle.None;
            PanelBienvenida.Visible = false;
            panelProductos.Visible = false;
            panelCuentas.Visible = true;
            panelCuentas.Dock = DockStyle.Fill;


            btnVentas.BackColor = Color.FromArgb(33, 85, 168);
            btnVentas.ForeColor = Color.White;
            btnCobrar.BackColor = Color.White;
            btnCobrar.ForeColor = Color.White;
            btnPagar.BackColor = Color.FromArgb(33, 85, 168);
            btnPagar.ForeColor = Color.White;
            btnProductos.BackColor = Color.FromArgb(33, 85, 168);
            btnProductos.ForeColor = Color.White;
            reporte_cuentas_cobrar();
        }

        private void btnPagar_Click_1(object sender, EventArgs e)
        {
            PanelReporteVentas.Visible = false;
            //PanelReporteVentas.Dock = DockStyle.None;
            PanelBienvenida.Visible = false;
            panelProductos.Visible = false;
            panelCuentas.Visible = true;
            panelCuentas.Dock = DockStyle.Fill;


            btnVentas.BackColor = Color.FromArgb(33, 85, 168);
            btnVentas.ForeColor = Color.White;
            btnCobrar.BackColor = Color.FromArgb(33, 85, 168);
            btnCobrar.ForeColor = Color.White;
            btnPagar.BackColor = Color.FromArgb(33, 85, 168);
            btnPagar.ForeColor = Color.White;
            btnProductos.BackColor = Color.FromArgb(33, 85, 168);
            btnProductos.ForeColor = Color.White;
            reporte_cuentas_pagar();
        }

        private void btnProductos_Click_1(object sender, EventArgs e)
        {
            PanelReporteVentas.Visible = false;
            //PanelReporteVentas.Dock = DockStyle.None;
            PanelBienvenida.Visible = false;
            panelProductos.Visible = true;
            panelProductos.Dock = DockStyle.Fill;
            panelCuentas.Visible = false;
            //panelCuentas.Dock = DockStyle.Fill;


            btnVentas.BackColor = Color.FromArgb(33, 85, 168);
            btnVentas.ForeColor = Color.White;
            btnCobrar.BackColor = Color.FromArgb(33, 85, 168);
            btnCobrar.ForeColor = Color.White;
            btnPagar.BackColor = Color.FromArgb(33, 85, 168);
            btnPagar.ForeColor = Color.White;
            btnProductos.BackColor = Color.FromArgb(33, 85, 168);
            btnProductos.ForeColor = Color.White;

            pInventario.Visible = false;
            pProductoV.Visible = false;
            pStockBajo.Visible = false;
            reportViewer3.Visible = false;
        }

        private void btnInventario_Click_1(object sender, EventArgs e)
        {
            pInventario.Visible = true;
            pProductoV.Visible = false;
            pStockBajo.Visible = false;
            reportViewer3.Visible = true;
            imprimir_inventarios_todos();
        }

        private void btnProductosVencidos_Click_1(object sender, EventArgs e)
        {
            pInventario.Visible = false;
            pProductoV.Visible = true;
            pStockBajo.Visible = false;
            mostrar_productos_vencidos();
        }

        private void btnStockBajo_Click_1(object sender, EventArgs e)
        {
            pInventario.Visible = false;
            pProductoV.Visible = false;
            pStockBajo.Visible = true;
            mostrar_inventarios_bajo_minimo();
        }
    }
}
