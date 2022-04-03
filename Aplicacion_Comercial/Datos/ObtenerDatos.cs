using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace Aplicacion_Comercial.Datos
{
    class ObtenerDatos
    {
        private static string SerialPC;
        private static int Id_Caja;


        //OBTENER EL ID DE LA CAJA POR MEDIO DEL SERIAL DEL PC
        public static void obtener_id_caja_por_serial(ref int IdCaja)
        {
            try
            {
                Logica.BasesPCProgram.obtener_serial_pc(ref SerialPC);

                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("mostrar_cajas_por_Serial_de_DiscoDuro", Conexiones.CADMaestra.conectar);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Serial", SerialPC);
                IdCaja = Convert.ToInt32(cmd.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }



        }

        // OBTENER LAS VENTAS QUE SE ENCUENTRAN EN ESPERA
        public static void mostrar_ventas_en_espera_con_fecha_y_monto(ref DataTable dt)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Mostrar_Ventas_En_Espera_Con_Fecha_y_Monto", Conexiones.CADMaestra.conectar);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }


        }

        //MOSTRAR LOS PORDUCTOS AGREGADOS EN ESPERA
        public static void mostrar_productos_agregados_a_ventas_en_espera(ref DataTable dt, int idVenta)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Mostrar_Productos_Agregados_A_Ventas_En_Espera", Conexiones.CADMaestra.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@idVenta", idVenta);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }

        }

        //MOSTRAR LOS CONCEPTOS INSERTADOS
        public static void buscar_conceptos(ref DataTable dt, string Buscador)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Buscar_Conceptos", Conexiones.CADMaestra.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@Letra", Buscador);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }

        }

        //MOSTRAR GASTOS POR TURNO
        public static void mostrar_gastos_por_turno(ref DataTable dt, int Id_Caja, DateTime FechaInicio, DateTime FechaFinal)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Mostrar_Gatos_Por_Turno", Conexiones.CADMaestra.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@Id_Caja", Id_Caja);
                data.SelectCommand.Parameters.AddWithValue("@Fecha_Inicial", FechaInicio);
                data.SelectCommand.Parameters.AddWithValue("@Fecha_Final", FechaFinal);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }

        }

        public static void mostrar_ingresos_por_turno(ref DataTable dt, int Id_Caja, DateTime Fecha_Inicial, DateTime Fecha_Final)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Mostras_Ingresos_Por_Turno", Conexiones.CADMaestra.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@Id_Caja", Id_Caja);
                data.SelectCommand.Parameters.AddWithValue("@Fecha_Inicial", Fecha_Inicial);
                data.SelectCommand.Parameters.AddWithValue("@Fecha_Final", Fecha_Final);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void mostrar_cierre_de_caja_pendiente(ref DataTable dt)
        {
            obtener_id_caja_por_serial(ref Id_Caja);
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Mostrar_Cierre_De_Caja_Pendiente", Conexiones.CADMaestra.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@Id_caja", Id_Caja);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void mostrar_inicios_de_sesion(ref int idUsuario)
        {
            Logica.BasesPCProgram.obtener_serial_pc(ref SerialPC);
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Mostrar_Inicinio_De_Sesion", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idSerial_PC", SerialPC);
                idUsuario = Convert.ToInt32(cmd.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void Mostrar_inicios_de_sesion_nombre(ref DataTable dt)
        {
            Logica.BasesPCProgram.obtener_serial_pc(ref SerialPC);
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Mostrar_Inicinio_De_Sesion", Conexiones.CADMaestra.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@idSerial_PC", SerialPC);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void mostrar_ventas_en_efectivo_por_turno(int Id_Caja, DateTime FechaInicial, DateTime FechaFinal, ref double Monto)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand command = new SqlCommand("Mostrar_Ventas_En_Efectivo_Por_Turno", Conexiones.CADMaestra.conectar);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id_Caja", Id_Caja);
                command.Parameters.AddWithValue("@FechaInicial", FechaInicial);
                command.Parameters.AddWithValue("@FechaFinal", FechaFinal);
                Monto = Convert.ToDouble(command.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.StackTrace);
                Monto = 0;
            }
        }

        public static void sumar_ingresos_por_turno(int Id_Caja, DateTime FechaInicial, DateTime FechaFinal, ref double Monto)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Sumar_Ingresos_Por_Turno", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Caja", Id_Caja);
                cmd.Parameters.AddWithValue("@Fecha_Inicial", FechaInicial);
                cmd.Parameters.AddWithValue("@Fecha_Final", FechaFinal);
                Monto = Convert.ToDouble(cmd.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception)
            {
                Monto = 0;
            }
        }

        public static void sumar_gastos_por_tunor(int Id_Caja, DateTime FechaInicial, DateTime FechaFinal, ref double Monto)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Sumar_Gastos_Por_Turno", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Caja", Id_Caja);
                cmd.Parameters.AddWithValue("@Fecha_Inicial", FechaInicial);
                cmd.Parameters.AddWithValue("@Fecha_Final", FechaFinal);
                Monto = Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch (Exception)
            {

                Monto = 0;
            }
        }

        public static void mostrar_ventas_tarjeta_por_turno(int Id_Caja, DateTime FechaInical, DateTime FechaFinal, ref double Monto)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Mostrar_Ventas_Tarjeta_Por_Turno", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Caja", Id_Caja);
                cmd.Parameters.AddWithValue("@Fecha_Inicial", FechaInical);
                cmd.Parameters.AddWithValue("@Fecha_Final", FechaFinal);
                Monto = Convert.ToDouble(cmd.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception)
            {
                Monto = 0;
            }
        }

        public static void mostrar_ventas_creditos_por_turno(int Id_Caja, DateTime FechaInicial, DateTime FechaFinal, ref double Monto)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Mostrar_Ventas_Credito_Por_Turno", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Caja", Id_Caja);
                cmd.Parameters.AddWithValue("@Fecha_Inicial", FechaInicial);
                cmd.Parameters.AddWithValue("@Fecha_Final", FechaFinal);
                Monto = Convert.ToDouble(cmd.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception)
            {

                Monto = 0;
            }
        }

        public static void ventas_por_credito_por_rurno(int Id_Caja, DateTime FechaInicial, DateTime FechaFinal, ref double Monto)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Ventas_por_Credito_por_Turno", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Caja", Id_Caja);
                cmd.Parameters.AddWithValue("@FechaInicial", FechaInicial);
                cmd.Parameters.AddWithValue("@FechaFinal", FechaFinal);
                Monto = Convert.ToDouble(cmd.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception)
            {

                Monto = 0;
            }
        }

        public static void ventas_por_tarjeta_por_turno(int Id_Caja, DateTime FechaInicial, DateTime FechaFinal, ref double Monto)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Ventas_por_Tarjeta_por_Turno", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Caja", Id_Caja);
                cmd.Parameters.AddWithValue("@FechaInicial", FechaInicial);
                cmd.Parameters.AddWithValue("@FechaFinal", FechaFinal);
                Monto = Convert.ToDouble(cmd.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception)
            {

                Monto = 0;
            }
        }

        public static void mostrar_proveedores(ref DataTable dt)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Mostrar_Proveedor", Conexiones.CADMaestra.conectar);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void buscar_proveedor(ref DataTable dt, string Buscador)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Buscar_Proveedor", Conexiones.CADMaestra.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@Letra", Buscador);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void sumar_creditos_por_pagar(int Id_Caja, DateTime FechaInicial, DateTime FechaFinal, ref double Monto)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Sumar_Credito_Por_Pagar", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Caja", Id_Caja);
                cmd.Parameters.AddWithValue("@Fecha_Inicial", FechaInicial);
                cmd.Parameters.AddWithValue("@Fecha_Final", FechaFinal);
                Monto = Convert.ToDouble(cmd.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception)
            {
                Monto = 0;
            }

        }

        public static void mostrar_cliente(ref DataTable dt)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Mostrar_Cliente", Conexiones.CADMaestra.conectar);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void buscar_cliente(ref DataTable dt, string Buscador)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Buscar_Cliente", Conexiones.CADMaestra.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@Letra", Buscador);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void sumar_creditos_por_cobrar(int Id_Caja, DateTime FechaInical, DateTime FechaFinal, ref double Monto)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Sumar_Credito_Por_Cobrar", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Caja", Id_Caja);
                cmd.Parameters.AddWithValue("@Fecha_Inicial", FechaInical);
                cmd.Parameters.AddWithValue("@Fecha_Final", FechaFinal);
                Monto = Convert.ToDouble(cmd.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception)
            {
                Monto = 0;
            }
        }

        public static void mostrar_empresa(ref DataTable dt)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("SELECT * FROM Empresa", Conexiones.CADMaestra.conectar);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void Mostrar_correo_base(ref DataTable dt)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("SELECT * FROM CorreoBase", Conexiones.CADMaestra.conectar);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }

        public static void Mostrar_estado_cuenta_cliente(ref DataTable dt, int idCliente)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Mostrar_Estado_Cuenta_Cliente", Conexiones.CADMaestra.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@idCliente", idCliente);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void Mostrar_control_cobros(ref DataTable dt)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Mostrar_Control_Cobros", Conexiones.CADMaestra.conectar);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void Reporte_por_cobrar(ref double Monto)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Reporte_Por_Cobrar", Conexiones.CADMaestra.conectar);
                Monto = Convert.ToDouble(cmd.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception)
            {
                Monto = 0;

            }
        }

        public static void Reporte_por_pagar(ref double Monto)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Reporte_Por_Pagar", Conexiones.CADMaestra.conectar);
                Monto = Convert.ToDouble(cmd.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception)
            {
                Monto = 0;
            }
        }

        public static void Reporte_ganacias(ref double Ganancia)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Reporte_Ganacias", Conexiones.CADMaestra.conectar);
                Ganancia = Convert.ToDouble(cmd.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception)
            {
                Ganancia = 0;
            }
        }

        public static void Reporte_productos_bajo_minimo(ref int StockMinimo)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Reporte_Productos_Bajo_Minimo", Conexiones.CADMaestra.conectar);
                StockMinimo = Convert.ToInt32(cmd.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();

            }
            catch (Exception)
            {
                StockMinimo = 0;
            }
        }

        public static void Reporte_cantidad_de_clientes(ref int Clientes)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(idCliente) FROM Clientes", Conexiones.CADMaestra.conectar);
                Clientes = Convert.ToInt32(cmd.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception)
            {
                Clientes = 0;
            }
        }

        public static void Reporte_cantidad_productos(ref int Productos)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(idProducto) FROM Productos", Conexiones.CADMaestra.conectar);
                Productos = Convert.ToInt32(cmd.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception)
            {
                Productos = 0;
            }
        }

        public static void Mostrar_moneda(ref string Moneda)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("SELECT Moneda FROM Empresa", Conexiones.CADMaestra.conectar);
                Moneda = Convert.ToString(cmd.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void Mostrar_ventas_grafica(ref DataTable dt)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Mostrar_Ventas_Grafica", Conexiones.CADMaestra.conectar);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }

        public static void Mostrar_ventas_grafica_fechas(ref DataTable dt, DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Mostrar_Ventas_Grafica_Fechas", Conexiones.CADMaestra.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@FechaInical", FechaInicial);
                data.SelectCommand.Parameters.AddWithValue("@FechaFinal", FechaFinal);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void Reporte_total_ventas(ref double Monto)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Reporte_Total_Ventas", Conexiones.CADMaestra.conectar);
                Monto = Convert.ToDouble(cmd.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception)
            {
                Monto = 0;
            }
        }

        public static void Reporte_total_ventas_fechas(ref double Monto, DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Reporte_Total_Ventas_Fechas", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaInicial", FechaInicial);
                cmd.Parameters.AddWithValue("@FechaFinal", FechaFinal);
                Monto = Convert.ToDouble(cmd.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception)
            {
                Monto = 0;
            }
        }

        public static void Reporte_ganancias_fecha(ref double Monto, DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Reporte_Ganancias_Fecha", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaInicial", FechaInicial);
                cmd.Parameters.AddWithValue("@FechaFinal", FechaFinal);
                Monto = Convert.ToDouble(cmd.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception)
            {
                Monto = 0;
            }
        }

        public static void Mostrar_productos_mas_vendidos(ref DataTable dt)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Mostrar_Productos_Mas_Vendidos", Conexiones.CADMaestra.conectar);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void Reporte_gastos_por_year(ref DataTable dt)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Reporte_Gastos_Por_Year", Conexiones.CADMaestra.conectar);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void Reporte_gastos_year(ref DataTable dt, int Year)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Reporte_Gastos_Year", Conexiones.CADMaestra.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@Anio", Year);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void Reporte_gastos_mes(ref DataTable dt, int Year)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Reporte_Gastos_Mes", Conexiones.CADMaestra.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@Anio", Year);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void Reporte_gastos_year_mes(ref DataTable dt, int Year, string Mes)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Reporte_Gastos_Year_Mes", Conexiones.CADMaestra.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@Anio", Year);
                data.SelectCommand.Parameters.AddWithValue("@Mes", Mes);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void mostrar_puertos(ref DataTable dt)
        {
            try
            {
                Datos.ObtenerDatos.obtener_id_caja_por_serial(ref Id_Caja);
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Mostrar_Puertos", Conexiones.CADMaestra.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@Id_Caja", Id_Caja);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void buscar_ventas(ref DataTable dt, string Buscqueda)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Buscar_Ventas", Conexiones.CADMaestra.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@Busqueda", Buscqueda);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void mostrar_detalle_venta(ref DataTable dt, int IdVenta)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Mostrar_Productos_a_Ventas", Conexiones.CADMaestra.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@idVenta", IdVenta);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void mostrar_tema_caja(ref String Tema)
        {
            try
            {
                ObtenerDatos.obtener_id_caja_por_serial(ref Id_Caja);
                Conexiones.CADMaestra.abrir();
                SqlCommand data = new SqlCommand("Mostrar_Tema_Caja", Conexiones.CADMaestra.conectar);
                data.CommandType = CommandType.StoredProcedure;
                data.Parameters.AddWithValue("@idCaja", Id_Caja);
                Tema = data.ExecuteScalar().ToString();
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void contar_ventas_espera(ref int Contador)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Contar_Ventas_Espera", Conexiones.CADMaestra.conectar);
                Contador = Convert.ToInt32(cmd.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception)
            {
                Contador = 0;
            }
        }

        public static void reporte_resumen_ventas(ref DataTable dt)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Reporte_Resumen_Ventas", Conexiones.CADMaestra.conectar);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void reporte_resumen_ventas_fechas(ref DataTable dt, DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Reporte_Resumen_Ventas_Fechas", Conexiones.CADMaestra.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@FechaInicial", FechaInicial);
                data.SelectCommand.Parameters.AddWithValue("@FechaFinal", FechaFinal);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void mostrar_usuarios(ref DataTable dt)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("SELECT * FROM USUARIO2", Conexiones.CADMaestra.conectar);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void reporte_resumen_ventas_empleado(ref DataTable dt, int idUsuario)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Reporte_Resumen_Ventas_Empleado", Conexiones.CADMaestra.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void reporte_resumen_ventas_empleado_fechas(ref DataTable dt, int idUsuario, DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Reporte_Resumen_Ventas_Empleado_Fechas", Conexiones.CADMaestra.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
                data.SelectCommand.Parameters.AddWithValue("@FechaInicial", FechaInicial);
                data.SelectCommand.Parameters.AddWithValue("@FechaFinal", FechaFinal);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void reporte_cuentas_cobrar(ref DataTable dt)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Reporte_Cuentas_Cobrar", Conexiones.CADMaestra.conectar);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void reporte_cuentas_pagar(ref DataTable dt)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Reporte_Cuentas_Pagar", Conexiones.CADMaestra.conectar);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void mostrar_inventarios_todos(ref DataTable dt)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Imprimir_Mostrar_Inventarios_Todos", Conexiones.CADMaestra.conectar);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }

        public static void mostrar_productos_vencidos(ref DataTable dt)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Mostrar_Productos_Vencidos", Conexiones.CADMaestra.conectar);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void mostrar_inventarios_bajo_minimo(ref DataTable dt)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Mostrar_Inventarios_Bajo_Minimo", Conexiones.CADMaestra.conectar);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void buscar_productos_kardex(ref DataTable dt, string Letra)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Buscar_Productos_Kardex", Conexiones.CADMaestra.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@letrab", Letra);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void mostrar_caja(ref DataTable dt)
        {
            try
            {
                Logica.BasesPCProgram.obtener_serial_pc(ref SerialPC);
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("mostrar_cajas_por_Serial_de_DiscoDuro", Conexiones.CADMaestra.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@Serial", SerialPC);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void mostrar_ticket_impreso(ref DataTable dt,int idVenta,string TotalLetras)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Mostrar_Ticket_Impreso", Conexiones.CADMaestra.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@idVenta", idVenta);
                data.SelectCommand.Parameters.AddWithValue("@Total_en_letras", TotalLetras);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void buscar_ventas_por_fechas(ref DataTable dt,DateTime fi,DateTime ff)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("Buscar_Ventas_Por_Fechas", Conexiones.CADMaestra.conectar);
                data.SelectCommand.CommandType = CommandType.StoredProcedure;
                data.SelectCommand.Parameters.AddWithValue("@Fi", fi);
                data.SelectCommand.Parameters.AddWithValue("@Ff", ff);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}

