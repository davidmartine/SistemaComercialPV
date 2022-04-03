using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Data.SqlClient;

using System.Globalization;
using System.Threading;

namespace Aplicacion_Comercial.Formularios.Caja
{
    public partial class Cierre_de_Caja : Form
    {
        public Cierre_de_Caja()
        {
            InitializeComponent();
        }
        private int Id_Caja;
        private DateTime FechaInicial;
        private DateTime FechaFinal;
        public static double SaldoQuedaCaja;
        public static double VentasEfectivo;
        public static double IngresoEfectivo;
        public static double GastoEfectivo;
        public static double VentasTarjeta;
        public static double VentasCredito;
        private  double EfectivoCaja;
        public static double VentasTotales;
        private double CreditosPorPagar;
        private double CreditosPorCobrar;
        public static double DineroCaja;
        public static double Ganacias;
        public static double Ingresos;
        public static double Egresos;
        public static double CobrosEfectivo;
        public static double CobrosTotales;
        public static double CobrosTarjeta;
        //DateTime FechaFinal = DateTime.Now;

        private void Cierre_de_Caja_Load(object sender, EventArgs e)
        {
           
            mostrar_Cierre_de_caja_pendiente();
            lblDesdeHasta.Text = "CORTE DE CAJA DESDE: " + FechaInicial + " HASTA " + DateTime.Now;
            obtener_fondo_de_caja();
            obtener_ventas_en_efectivo();
            obtener_gastos_por_turno();
            obtener_ingresos_por_turno();
            obtener_creditos_por_pagar();
            obtener_creditos_por_cobrar();
            mostrar_ventas_tarjeta_por_turno();
            mostrar_ventas_credito_por_turno();
            calcular();
            ventas_por_credito_por_rurno();





        }

        private void obtener_ingresos_por_turno()
        {
            Datos.ObtenerDatos.sumar_ingresos_por_turno(Id_Caja, FechaInicial, FechaFinal, ref IngresoEfectivo);
            lblIngresosVarios.Text = IngresoEfectivo.ToString();
        }

        private void obtener_gastos_por_turno()
        {
            Datos.ObtenerDatos.sumar_gastos_por_tunor(Id_Caja, FechaInicial, FechaFinal, ref GastoEfectivo);
            lblGastosVarios.Text = GastoEfectivo.ToString();
        }

        private void obtener_fondo_de_caja()
        {
            lblFondoCaja.Text = SaldoQuedaCaja.ToString();
        }

        private void obtener_ventas_en_efectivo()
        {
            Datos.ObtenerDatos.mostrar_ventas_en_efectivo_por_turno(Id_Caja, FechaInicial, FechaFinal,ref VentasEfectivo);
            lblVentasEfectivo.Text = VentasEfectivo.ToString();
            lblVentasEfectivoGeneral.Text = VentasEfectivo.ToString();
        }
        private void mostrar_Cierre_de_caja_pendiente()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.mostrar_cierre_de_caja_pendiente(ref dt);
            foreach (DataRow row in dt.Rows)
            {
                Id_Caja = Convert.ToInt32(row["Id_Caja"]);
                FechaInicial =Convert.ToDateTime(row["fechainicio"]);
                SaldoQuedaCaja =Convert.ToDouble(row["Saldo_queda_en_caja"]);

            }
        }
        private  void mostrar_ventas_tarjeta_por_turno()
        {
            Datos.ObtenerDatos.mostrar_ventas_tarjeta_por_turno(Id_Caja, FechaInicial, FechaFinal, ref CobrosTarjeta);
            lblAbonosTarjeta.Text = CobrosTarjeta.ToString();
        }
        
        private void mostrar_ventas_credito_por_turno()
        {
            Datos.ObtenerDatos.mostrar_ventas_creditos_por_turno(Id_Caja, FechaInicial, FechaFinal, ref CobrosEfectivo);
            lblCobrosEfectivo.Text = CobrosEfectivo.ToString();
        }

        private void calcular()
        {
            CobrosTotales = CobrosEfectivo + CobrosTarjeta;
            EfectivoCaja = SaldoQuedaCaja + VentasEfectivo + IngresoEfectivo - GastoEfectivo + CobrosEfectivo;
            VentasTotales = VentasEfectivo + VentasCredito + VentasTarjeta;

            lblEfectivoEnCaja.Text = EfectivoCaja.ToString();
            lblVentasTotal.Text = VentasTotales.ToString();
            lblTotalesVentas.Text = VentasTotales.ToString();
            lblEfectivoTotalCaja.Text = EfectivoCaja.ToString();
            Ingresos = SaldoQuedaCaja + VentasEfectivo + IngresoEfectivo + VentasTarjeta + CobrosTarjeta + CobrosEfectivo;
            Egresos = GastoEfectivo;

        }

        private void ventas_por_credito_por_rurno()
        {
            Datos.ObtenerDatos.ventas_por_credito_por_rurno(Id_Caja, FechaInicial, FechaFinal, ref VentasCredito);
            lblVentasCredito.Text = VentasCredito.ToString();
        }

        private void ventas_por_tarjeta_por_turno()
        {
            Datos.ObtenerDatos.ventas_por_tarjeta_por_turno(Id_Caja, FechaInicial, FechaFinal, ref VentasTarjeta);
            lblVentasTarjeta.Text = VentasTarjeta.ToString();
        }
        private void obtener_creditos_por_pagar()
        {
            Datos.ObtenerDatos.sumar_creditos_por_pagar(Id_Caja, FechaInicial, FechaFinal, ref CreditosPorPagar);
            lblPorPagar.Text = CreditosPorPagar.ToString();
        }

        private void obtener_creditos_por_cobrar()
        {
            Datos.ObtenerDatos.sumar_creditos_por_cobrar(Id_Caja, FechaInicial, FechaFinal, ref CreditosPorCobrar);
            lblPorCobrar.Text = CreditosPorCobrar.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void Cierre_de_Caja_FormClosing(object sender, FormClosingEventArgs e)
        {
            

        }

      

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
            Formularios.VENTAS_MENU_PRINCIPAL.Ventas_Menu_Principal frmprincipal = new VENTAS_MENU_PRINCIPAL.Ventas_Menu_Principal();
            frmprincipal.Show();
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            //this.Dispose();
            Formularios.Caja.CierreTurno frmturno = new CierreTurno();
            DineroCaja = Convert.ToDouble(lblEfectivoEnCaja.Text);
            frmturno.ShowDialog();
        }
    }
}
