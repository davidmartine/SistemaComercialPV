using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Aplicacion_Comercial.Logica;

namespace Aplicacion_Comercial.Datos
{
    public class CADInsertarDatos
    {

        private int Id_Caja;
        private int idUsuario;

        public static bool insertar_consepto(string Descripcion)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_Concepto", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.ExecuteNonQuery();
                Conexiones.CADMaestra.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool insertar_gastos_varios(DateTime Fecha, string NumeroComprobante,
            string TipoComprobante, double Importe, string Descripcion, int Id_Caja, int idConcepto)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_Gastos_Varios", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fecha", Fecha);
                cmd.Parameters.AddWithValue("@Numero_Comprobante", NumeroComprobante);
                cmd.Parameters.AddWithValue("@Tipo_Comprobante", TipoComprobante);
                cmd.Parameters.AddWithValue("@Importe", Importe);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@Id_Caja", Id_Caja);
                cmd.Parameters.AddWithValue("@idConcepto", idConcepto);
                cmd.ExecuteNonQuery();
                Conexiones.CADMaestra.cerrar();
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
                return false;
            }
        }

        public static bool insertar_ingresos_varios(DateTime Fecha, string NumeroComprobante, string TipoComprobante,
            double Importe, string Descripcion, int Id_Caja)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_Ingresos_Varios", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fecha", Fecha);
                cmd.Parameters.AddWithValue("@Numero_Comprobante", NumeroComprobante);
                cmd.Parameters.AddWithValue("@Tipo_Comprobante", TipoComprobante);
                cmd.Parameters.AddWithValue("@Importe", Importe);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@Id_Caja", Id_Caja);
                cmd.ExecuteNonQuery();
                Conexiones.CADMaestra.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public  bool insertar_credito_por_pagar(LCreditoPorPagar cp)
        {

            try
            {
                Datos.ObtenerDatos.obtener_id_caja_por_serial(ref Id_Caja);
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_Credito_Por_Pagar", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Caja", Id_Caja);
                cmd.Parameters.AddWithValue("@idProveedor", cp.idProveedor);
                cmd.Parameters.AddWithValue("@Descripcion", cp.Descripcion);
                cmd.Parameters.AddWithValue("@Fecha_Registro", cp.FechaRegistro);
                cmd.Parameters.AddWithValue("@Fecha_Vencimiento", cp.FechaVencimiento);
                cmd.Parameters.AddWithValue("@Total", cp.Total);
                cmd.Parameters.AddWithValue("@Saldo", cp.Saldo);
                cmd.Parameters.AddWithValue("@Estado", "DEBE");
                cmd.ExecuteNonQuery();
                return true;
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
                return false;
            }
            finally
            {
                Conexiones.CADMaestra.cerrar();
            }


        }

        public  bool insertar_proveedor(LProveedor proveedor_parametos)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_Proveedor", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", proveedor_parametos.Nombre);
                cmd.Parameters.AddWithValue("@Direccion", proveedor_parametos.Direccion);
                cmd.Parameters.AddWithValue("@Identificador_Fiscal", proveedor_parametos.IdentificadorFiscal);
                cmd.Parameters.AddWithValue("@Movil", proveedor_parametos.Movil);
                cmd.Parameters.AddWithValue("@Estado", "ACTIVO");
                cmd.Parameters.AddWithValue("@Saldo", 0);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                Conexiones.CADMaestra.cerrar();
            }
        }

        public bool insertar_clientes(LCliente cliente_parametros)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_Cliente",Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", cliente_parametros.Nombre);
                cmd.Parameters.AddWithValue("@Direccion", cliente_parametros.Direccion);
                cmd.Parameters.AddWithValue("@Identificador_Fiscal", cliente_parametros.IdentificadorFiscal);
                cmd.Parameters.AddWithValue("@Movil", cliente_parametros.Movil);
                cmd.Parameters.AddWithValue("@Estado","ACTIVO");
                cmd.Parameters.AddWithValue("@Saldo",0);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                Conexiones.CADMaestra.cerrar();
            }
        }

        public bool insertar_credito_por_cobrar(LCreditoPorCobrar cobrar_parametros)
        {
            try
            {
                Datos.ObtenerDatos.obtener_id_caja_por_serial(ref Id_Caja);
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_Credito_Por_Cobrar", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Caja", Id_Caja);
                cmd.Parameters.AddWithValue("@idCliente", cobrar_parametros.idCliente);
                cmd.Parameters.AddWithValue("@Descripcion", cobrar_parametros.Descripcion);
                cmd.Parameters.AddWithValue("@Fecha_Registro", cobrar_parametros.Fecha_Registro);
                cmd.Parameters.AddWithValue("@Fecha_Vencimiento", cobrar_parametros.Fecha_Vencimiento);
                cmd.Parameters.AddWithValue("@Total", cobrar_parametros.Total);
                cmd.Parameters.AddWithValue("@Saldo", cobrar_parametros.Saldo);
                cmd.Parameters.AddWithValue("@Estado", "DEBE");
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return false;
            }
            finally
            {
                Conexiones.CADMaestra.cerrar();
            }
        }

        public bool Insertar_control_cobros(LControlCobros cobros_parametros)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_Control_Cobros", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Monto", cobros_parametros.Monto);
                cmd.Parameters.AddWithValue("@Fecha", cobros_parametros.Fecha);
                cmd.Parameters.AddWithValue("@Detalle", cobros_parametros.Detalle);
                cmd.Parameters.AddWithValue("@idCliente", cobros_parametros.idCliente);
                cmd.Parameters.AddWithValue("@idUsuario", cobros_parametros.idUsuario);
                cmd.Parameters.AddWithValue("@Id_Caja", cobros_parametros.Id_Caja);
                cmd.Parameters.AddWithValue("@Comprobante", cobros_parametros.Comprobante);
                cmd.Parameters.AddWithValue("@Efectivo", cobros_parametros.Efectivo);
                cmd.Parameters.AddWithValue("@Tarjeta", cobros_parametros.Tarjeta);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return false;
            }
            finally
            {
                Conexiones.CADMaestra.cerrar();
            }
        }

        public bool insertar_kardex_entrada(LKardex kardex)
        {
            try
            {
                ObtenerDatos.mostrar_inicios_de_sesion(ref idUsuario);
                ObtenerDatos.obtener_id_caja_por_serial(ref Id_Caja);
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_Kardex_Entrada", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fecha",kardex.Fecha);
                cmd.Parameters.AddWithValue("@Motivo",kardex.Motivo);
                cmd.Parameters.AddWithValue("@Cantidad",kardex.Cantidad);
                cmd.Parameters.AddWithValue("@idProducto",kardex.idProducto);
                cmd.Parameters.AddWithValue("@idUsuario",idUsuario);
                cmd.Parameters.AddWithValue("@Tipo","ENTRADA");
                cmd.Parameters.AddWithValue("@Estado","DESPACHO CONFIRMADO");
                cmd.Parameters.AddWithValue("@id_Caja",Id_Caja);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return false;
            }
            finally
            {
                Conexiones.CADMaestra.cerrar();
            }
        }

        public bool  insertar_kardex_salida(LKardex kardex)
        {
            try
            {
                ObtenerDatos.mostrar_inicios_de_sesion(ref idUsuario);
                ObtenerDatos.obtener_id_caja_por_serial(ref Id_Caja);
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_Kardex_Salida", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fecha", kardex.Fecha);
                cmd.Parameters.AddWithValue("@Motivo", kardex.Motivo);
                cmd.Parameters.AddWithValue("@Cantidad", kardex.Cantidad);
                cmd.Parameters.AddWithValue("@idProducto", kardex.idProducto);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@Tipo", "SALIDA");
                cmd.Parameters.AddWithValue("@Estado", "DESPACHO SALIDA");
                cmd.Parameters.AddWithValue("@id_Caja", Id_Caja);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return false;
            }
            finally
            {
                Conexiones.CADMaestra.cerrar();
            }
        }
    }
}
