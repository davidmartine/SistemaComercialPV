using Aplicacion_Comercial.Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.Reporting.Charting;

namespace Aplicacion_Comercial.Formularios.Admin_Control
{
    public partial class Adminitrador_Principal : Form
    {
        public Adminitrador_Principal()
        {
            InitializeComponent();
        }

        private int contadorCajas;
        private int idusuariovariable;
        private int idcajavariable;
        private int contador_Movimientos_de_caja;
        private string lblApertura_De_caja;
        private string lblSerialPc;
        private string BaseDatos = "PuntoVenta";
        private string Servidor = @".\SQLEXPRESS";
        private string Ruta;
        private string ResultadoLicencia;
        private string FechaFinal;
        private double PorCobrar;
        private double PorPagar;
        private double GanaciasGenerales;
        private int ProductoMinimo;
        private int CantidadClientes;
        private int CantidadProductos;
        private string Moneda;
        private DataTable dtVentas;
        private double TotalVentas;
        private double GananciasFecha;
        private DataTable dtProductos;
        private int Year;
        private string Mes;


        private void Adminitrador_Principal_Load(object sender, EventArgs e)
        {
            Validar_licencia();
            //ManagementObject MOS = new ManagementObject(@"Win32_PhysicalMedia ='\\.\PHYSICALDRIVE0'");
            Logica.BasesPCProgram.obtener_serial_pc(ref lblSerialPc);
            Datos.ObtenerDatos.obtener_id_caja_por_serial(ref idcajavariable);
            Datos.ObtenerDatos.mostrar_inicios_de_sesion(ref idusuariovariable);
            Mostrar_moneda();
            Reporte_por_cobrar();
            Reporte_por_pagar();
            Reporte_productos_bajo_minimo();
            Reporte_cantidad_de_clientes();
            Reporte_cantidad_productos();
            Mostrar_ventas_grafica();
            checkFiltros.Checked = false;
            //Reporte_total_ventas();
            Mostrar_productos_mas_vendidos();
            Reporte_gastos_por_year();
            Obtener_fecha_hoy();

        }

        private void Mostrar_ventas_grafica()
        {
            ArrayList Fecha = new ArrayList();
            ArrayList Monto = new ArrayList();
            dtVentas = new DataTable();
            Datos.ObtenerDatos.Mostrar_ventas_grafica(ref dtVentas);
            foreach(DataRow row in dtVentas.Rows)
            {
                Fecha.Add(row["Fecha"]);
                Monto.Add(row["Total"]);

            }
            chartVentas.Series[0].Points.DataBindXY(Fecha, Monto);
            Reporte_total_ventas();
            Reporte_ganancias();

        }

        private void Mostrar_ventas_grafica_fechas()
        {
            ArrayList Fecha = new ArrayList();
            ArrayList Monto = new ArrayList();
            dtVentas = new DataTable();
            Datos.ObtenerDatos.Mostrar_ventas_grafica_fechas(ref dtVentas, dtpFechaInicial.Value, dtpFechaFinal.Value);
            foreach(DataRow row in dtVentas.Rows)
            {
                Fecha.Add(row["Fecha"]);
                Monto.Add(row["Total"]);
            }
            chartVentas.Series[0].Points.DataBindXY(Fecha, Monto);
            Reporte_total_ventas_fechas();
            Reporte_ganancias_fecha();
        }

        private void Mostrar_productos_mas_vendidos()
        {
            ArrayList Cantidad = new ArrayList();
            ArrayList Producto = new ArrayList();
            dtProductos = new DataTable();
            Datos.ObtenerDatos.Mostrar_productos_mas_vendidos(ref dtProductos);
            foreach(DataRow row in dtProductos.Rows)
            {
                Cantidad.Add(row["Cantidad"]);
                Producto.Add(row["Descripcion"]);
            }
            chartProductos.Series[0].Points.DataBindXY(Producto,Cantidad);

        }
        private void Reporte_total_ventas_fechas()
        {
            Datos.ObtenerDatos.Reporte_total_ventas_fechas(ref TotalVentas, dtpFechaInicial.Value, dtpFechaFinal.Value);
            lblTotalVentas.Text =Moneda + " " +  Convert.ToString(TotalVentas);

        }

        private void Reporte_gastos_por_year()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.Reporte_gastos_por_year(ref dt);
            cmbAnioGasto.DisplayMember = "Fecha";
            cmbAnioGasto.ValueMember = "Fecha";
            cmbAnioGasto.DataSource = dt;

        }

        private void Reporte_ganancias_fecha()
        {
            Datos.ObtenerDatos.Reporte_ganancias_fecha(ref GananciasFecha, dtpFechaInicial.Value, dtpFechaFinal.Value);
            lblTotalGanacias.Text = Moneda + " " + Convert.ToString(GananciasFecha);
        }

        private void Reporte_total_ventas()
        {
            Datos.ObtenerDatos.Reporte_total_ventas(ref TotalVentas);
            lblTotalVentas.Text =Moneda + " " + Convert.ToString(TotalVentas);
        }
        private void Reporte_por_cobrar()
        {
            Datos.ObtenerDatos.Reporte_por_cobrar(ref PorCobrar);
            lblPorCobrar.Text = Moneda + " " + Convert.ToString(PorCobrar);
        }

        private void Reporte_por_pagar()
        {
            Datos.ObtenerDatos.Reporte_por_pagar(ref PorPagar);
            lblPorPagar.Text = Moneda + " " + Convert.ToString(PorPagar);

        }

        private void Reporte_ganancias()
        {
            Datos.ObtenerDatos.Reporte_ganacias(ref GanaciasGenerales);
            lblGanancia.Text = Moneda + " " + Convert.ToString(GanaciasGenerales);
            lblTotalGanacias.Text = lblGanancia.Text;

        }


        private void Reporte_productos_bajo_minimo()
        {
            Datos.ObtenerDatos.Reporte_productos_bajo_minimo(ref ProductoMinimo);
            lblStockBajo.Text = Convert.ToString(ProductoMinimo);

        }

        private void Reporte_cantidad_de_clientes()
        {
            Datos.ObtenerDatos.Reporte_cantidad_de_clientes(ref CantidadClientes);
            lblNumeroClientes.Text = Convert.ToString(CantidadClientes);

        }

        private void Reporte_cantidad_productos()
        {
            Datos.ObtenerDatos.Reporte_cantidad_productos(ref CantidadProductos);
            lblCantidadProductos.Text = Convert.ToString(CantidadProductos);
        }

        private void Mostrar_moneda()
        {
            Datos.ObtenerDatos.Mostrar_moneda(ref Moneda);

        }

        private void Validar_licencia()
        {
            try
            {
                CADLicencias funcion = new CADLicencias();
                funcion.Validar_licencias(ref ResultadoLicencia, ref FechaFinal);
                if (ResultadoLicencia == "?ACTIVO?")
                {
                    lblEstadoLicencia.Text = "LICENCIA DE PRUEBA ACTIVADA HASTA EL: " + FechaFinal;
                    btnActivarLicencia.Visible = true;


                }
                if (ResultadoLicencia == "¿ACTIVADO PRO?")
                {
                    lblEstadoLicencia.Text = "LICENCIA PROFESIONAL ACTIVADA HASTA EL: " + FechaFinal;
                    btnActivarLicencia.Visible = false;
                }
                if (ResultadoLicencia == "VENCIDA")
                {
                    Datos.CADLicencias.Editar_marcas_vencidas();
                    this.Dispose();
                    Formularios.Licencias_y_Membresias.Licencias_Membresias frmlicencias = new Licencias_y_Membresias.Licencias_Membresias();
                    frmlicencias.ShowDialog();
                }
            }
            catch (Exception)
            {

            }
        }

        private void apertura_detalle_de_cierre_caja()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand("insertar_DETALLE_cierre_de_caja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fechaini", DateTime.Today);
                cmd.Parameters.AddWithValue("@fechafin", DateTime.Today);
                cmd.Parameters.AddWithValue("@fechacierre", DateTime.Today);
                cmd.Parameters.AddWithValue("@ingresos", 0.00);
                cmd.Parameters.AddWithValue("@egresos", 0.00);
                cmd.Parameters.AddWithValue("@saldo", 0.00);
                cmd.Parameters.AddWithValue("@idusuario", idUsuario.Text);
                cmd.Parameters.AddWithValue("@totalcaluclado", 0.00);
                cmd.Parameters.AddWithValue("@totalreal", 0.00);
                cmd.Parameters.AddWithValue("@estado", "CAJA APERTURADA");
                cmd.Parameters.AddWithValue("@diferencia", 0.00);
                cmd.Parameters.AddWithValue("@id_caja", lblIdCaja.Text);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void pictureBox17_Click(object sender, EventArgs e)
        {
            Dispose();
            Formularios.Configuracion.Panel_Configuraciones frmPanelConfiguracion = new Configuracion.Panel_Configuraciones();
            frmPanelConfiguracion.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Formularios.Inventario_Kardex.Inventario_Menu frmInventarioMenu = new Inventario_Kardex.Inventario_Menu();
            frmInventarioMenu.ShowDialog();
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            Formularios.Configuracion.Panel_Configuraciones frmpanel_Configuraciones = new Configuracion.Panel_Configuraciones();
            frmpanel_Configuraciones.FormClosed += new FormClosedEventHandler(frm_formClosed);
            this.Dispose();
            frmpanel_Configuraciones.ShowDialog();
        }

        private void frm_formClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            Formularios.Admin_Control.Adminitrador_Principal frmAdminitrador_Principal = new Formularios.Admin_Control.Adminitrador_Principal();
            frmAdminitrador_Principal.ShowDialog();
        }

        private void validar_apertura_de_caja()
        {
            try
            {
                listar_cierres_de_caja();
                contar_cierres_de_caja();
                if (contadorCajas == 0)
                {
                    aperturar_detalle_de_cierre_caja();
                    lblApertura_De_caja = "Nuevo*****";
                    ingresar_a_ventas();

                }
                else
                {
                    mostrar_movimientos_de_caja_por_serial_y_usuario();
                    contrar_movimientos_de_caja_por_usuario();

                    if (contador_Movimientos_de_caja == 0)
                    {
                        obtener_usuario_que_aperturo_caja();
                        MessageBox.Show("CONTINUARAS CON EL TURNO DE *" + lblnombredeCajero.Text + "* TODOS LOS REGISTROS SERAN CON ESE USUARIO ", "CAJA APERTURADA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    lblApertura_De_caja = "Aperturado";
                    ingresar_a_ventas();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void listar_cierres_de_caja()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                da = new SqlDataAdapter("MOSTRAR_MOVIMIENTOS_DE_CAJA_POR_SERIAL", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@serial", lblSerialPc);
                da.Fill(dt);
                datalistado_detalle_cierre_de_caja.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }


        private void contar_cierres_de_caja()
        {
            int x;

            x = datalistado_detalle_cierre_de_caja.Rows.Count;
            contadorCajas = (x);

        }

        private void aperturar_detalle_de_cierre_caja()
        {
            try
            {


                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_DETALLE_cierre_de_caja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fechaini", DateTime.Now);
                cmd.Parameters.AddWithValue("@fechafin", DateTime.Now);
                cmd.Parameters.AddWithValue("@fechacierre", DateTime.Now);
                cmd.Parameters.AddWithValue("@ingresos", "0.00");
                cmd.Parameters.AddWithValue("@egresos", "0.00");
                cmd.Parameters.AddWithValue("@saldo", "0.00");
                cmd.Parameters.AddWithValue("@idusuario", idusuariovariable);
                cmd.Parameters.AddWithValue("@totalcaluclado", "0.00");
                cmd.Parameters.AddWithValue("@totalreal", "0.00");
                cmd.Parameters.AddWithValue("@estado", "CAJA APERTURADA");
                cmd.Parameters.AddWithValue("@diferencia", "0.00");
                cmd.Parameters.AddWithValue("@id_caja", idcajavariable);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void mostrar_movimientos_de_caja_por_serial_y_usuario()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                da = new SqlDataAdapter("MOSTRAR_MOVIMIENTOS_DE_CAJA_POR_SERIAL_y_usuario", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@serial", lblSerialPc);
                da.SelectCommand.Parameters.AddWithValue("@idusuario", idusuariovariable);
                da.Fill(dt);
                datalistado_movimientos_validar.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }


        }

        private void contrar_movimientos_de_caja_por_usuario()
        {
            int x;

            x = datalistado_movimientos_validar.Rows.Count;
            contador_Movimientos_de_caja = (x);

        }

        private void obtener_usuario_que_aperturo_caja()
        {
            try
            {
                lblusuario_queinicioCaja.Text = datalistado_detalle_cierre_de_caja.SelectedCells[1].Value.ToString();
                lblnombredeCajero.Text = datalistado_detalle_cierre_de_caja.SelectedCells[2].Value.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void ingresar_a_ventas()
        {
            if (lblApertura_De_caja == "Nuevo*****")
            {

                this.Dispose();
                Formularios.Caja.Apertura_de_Caja frmAperturaCaja = new Caja.Apertura_de_Caja();
                frmAperturaCaja.ShowDialog();


            }
            else if (lblApertura_De_caja == "Aperturado")
            {

                this.Dispose();
                Formularios.VENTAS_MENU_PRINCIPAL.Ventas_Menu_Principal frmVentasPrincipal = new VENTAS_MENU_PRINCIPAL.Ventas_Menu_Principal();
                frmVentasPrincipal.ShowDialog();

            }


        }
        private void btnVender_Click(object sender, EventArgs e)
        {
            validar_apertura_de_caja();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Formularios.Copias_BaseDatos.Crear_CopiasDB copiasDB = new Copias_BaseDatos.Crear_CopiasDB();
            copiasDB.ShowDialog();

        }

        private void btnRestaurarBD_Click(object sender, EventArgs e)
        {
            Restaurar_db_express();
        }

        private void Restaurar_db_express()
        {
            fdg.InitialDirectory = "";
            fdg.Filter = "Backup " + BaseDatos + "|*.bak";
            fdg.FilterIndex = 2;
            fdg.Title = "CARGADOR DE BACKUP";
            if (fdg.ShowDialog() == DialogResult.OK)
            {
                Ruta = Path.GetFullPath(fdg.FileName);
                DialogResult result = MessageBox.Show("USTED ESTA A PUNTO DE RESTAURAR LA BASE DATOS," + "\r\n" + "ASEGURESE DE QUE EL ARCHIVO .bak SEA RECIENTE,DE" + "LO CONTRARIO PODRIA PERDER INFORMACION Y NO PODRA" + "RECUPERARLA,¿DESEA CONTINUAR?", "RESTAURACION BASE DATOS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    SqlConnection con = new SqlConnection("Server=" + Servidor + ";database=master; integrated security=yes");
                    try
                    {

                        con.Open();
                        string Proceso = "EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'" + BaseDatos + "' USE [master] ALTER DATABASE [" + BaseDatos + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE DROP DATABASE [" + BaseDatos + "] RESTORE DATABASE " + BaseDatos + "FROM DISK = N'" + Ruta + "' WITH FILE = 1, NOUNLOAD, REPLACE, STATS=10";
                        SqlCommand cmd = new SqlCommand(Proceso, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("LA BASE DATOS HA SIDO RESTAURADA SATISFACTORIAMENTE! VUELVE A INICIAR EL APLICATIVO", "RESTAURACION DE BASE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();

                    }
                    catch (Exception)
                    {

                        Restaurar_db_no_express();
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }


                }
            }
        }

        private void Restaurar_db_no_express()
        {
            Servidor = ".";
            SqlConnection con = new SqlConnection("Server=" + Servidor + ";database=master; integrated security=yes");
            try
            {

                con.Open();
                string Proceso = "EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'" + BaseDatos + "' USE [master] ALTER DATABASE [" + BaseDatos + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE DROP DATABASE [" + BaseDatos + "] RESTORE DATABASE " + BaseDatos + "FROM DISK = N'" + Ruta + "' WITH FILE = 1, NOUNLOAD, REPLACE, STATS=10";
                SqlCommand cmd = new SqlCommand(Proceso, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("LA BASE DATOS HA SIDO RESTAURADA SATISFACTORIAMENTE! VUELVE A INICIAR EL APLICATIVO", "RESTAURACION DE BASE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();

            }
            catch (Exception)
            {


            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void btnActivarLicencia_Click(object sender, EventArgs e)
        {
            Formularios.Licencias_y_Membresias.Licencias_Membresias frmlicencias = new Licencias_y_Membresias.Licencias_Membresias();
            frmlicencias.ShowDialog();

        }

        private void checkFiltros_CheckedChanged(object sender, EventArgs e)
        {
            if(checkFiltros.Checked == true)
            {
                panelHoy.Visible = false;
                panelFiltros.Visible = true;
                Mostrar_ventas_grafica_fechas();
            }
            else
            {
                panelHoy.Visible = true;
                panelFiltros.Visible = false;
                Mostrar_ventas_grafica();
            }
        }

        private void dtpFechaInicial_ValueChanged(object sender, EventArgs e)
        {
            
            Mostrar_ventas_grafica_fechas();
        }

        private void dtpFechaFinal_ValueChanged(object sender, EventArgs e)
        {
          
            Mostrar_ventas_grafica_fechas();
        }

        private void lblHastaHoy_Click(object sender, EventArgs e)
        {
            Mostrar_ventas_grafica();
            

        }

        private void cmbAnioGasto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reporte_gastos_year();
            Reporte_gastos_mes();
        }

       
        private void Reporte_gastos_year()
        {
            DataTable dt = new DataTable();
            Year =Convert.ToInt32(cmbAnioGasto.Text);
            Datos.ObtenerDatos.Reporte_gastos_year(ref dt, Year);
            ArrayList Monto = new ArrayList();
            ArrayList Descripcion = new ArrayList();
            foreach(DataRow row in dt.Rows)
            {
                Monto.Add(row["Monto"]);
                Descripcion.Add(row["Descripcion"]);
            }
            chartGastosAño.Series[0].Points.DataBindXY(Descripcion, Monto);


        }
        private void Reporte_gastos_mes()
        {
            DataTable dt = new DataTable();
            Mes = cmbMesGasto.Text;
            Datos.ObtenerDatos.Reporte_gastos_mes(ref dt, Year);
            cmbMesGasto.DisplayMember = "Mes";
            cmbMesGasto.ValueMember = "Mes";
            cmbMesGasto.DataSource = dt;
        }

        private void Reporte_gastos_year_mes()
        {
            DataTable dt = new DataTable();
            Year =Convert.ToInt32(cmbAnioGasto.Text);
            Datos.ObtenerDatos.Reporte_gastos_year_mes(ref dt, Year, cmbMesGasto.Text);
            ArrayList Monto = new ArrayList();
            ArrayList Descripcion = new ArrayList();
            foreach(DataRow row in dt.Rows)
            {
                Monto.Add(row["Monto"]);
                Descripcion.Add(row["Descripcion"]);
            }
            chartGastosMes.Series[0].Points.DataBindXY(Descripcion, Monto);
        }



        private void cmbMesGasto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reporte_gastos_year_mes();
        }

        private void Obtener_fecha_hoy()
        {
            int Year = DateTime.Today.Year;
            DateTime FechaActual = DateTime.Now;
            string Mes = FechaActual.ToString("MMMM") + " " + Year.ToString();
            lblFechaHoy.Text = Mes;

        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            Formularios.Reportes_Kardex.MenuReportes frmMenuReportes = new Reportes_Kardex.MenuReportes();
            frmMenuReportes.ShowDialog();

        }
    }
}