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
    class CADEliminarDatos
    {

        public static void eliminar_venta(int idVenta)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Eliminar_Venta", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idVenta", idVenta);
                cmd.ExecuteNonQuery();
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }

        }

        public static void eliminar_ingreso(int idIngreso)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Eliminar_Ingreso_Varios", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idIngreso", idIngreso);
                cmd.ExecuteNonQuery();
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void eliminar_gasto(int idGasto)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Eliminar_Gasto_Varios", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idGasto", idGasto);
                cmd.ExecuteNonQuery();
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }

        public bool eliminar_proveedor(LProveedor proveedor_parametros)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Eliminar_Proveedor", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProveedor", proveedor_parametros.idProveedor);
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

        public bool eliminar_cliente(LCliente cliente_parametros)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Eliminar_Cliente", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", cliente_parametros.idCliente);
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

        public bool Eliminar_control_cobros(LControlCobros cobros_parametros)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Eliminar_Control_Cobros", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idControlCobro", cobros_parametros.idControlCobros);
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

        public bool eliminar_ventas(LVentas ventas)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Eliminar_Venta", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idVenta", ventas.idVenta);
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
    }
}
