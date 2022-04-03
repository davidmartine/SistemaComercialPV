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
    class CADEditarDatos
    {
        private int Id_Caja;
        public static void cambio_de_caja(int Id_Caja,int idVenta)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Cambio_De_Caja", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Caja", Id_Caja);
                cmd.Parameters.AddWithValue("@idVenta", idVenta);
                cmd.ExecuteNonQuery();
                Conexiones.CADMaestra.cerrar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);   
            }
            
        }

        public static void ingresar_nombre_a_venta_en_espera(int idVenta,string Comprobante)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Ingresar_Nombre_A_Venta_En_Espera", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idVenta", idVenta);
                cmd.Parameters.AddWithValue("@Comprobante", Comprobante);
                cmd.ExecuteNonQuery();
                Conexiones.CADMaestra.cerrar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            
        }

        public static bool editar_conceptos(int idConcepto,string Descripcion)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Editar_Conceptos", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idConcepto", idConcepto);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.ExecuteNonQuery();
                Conexiones.CADMaestra.cerrar();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool editar_dinero_caja_inicial(int Id_Caja,double Saldo)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("editar_dinero_caja_inicial", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_caja", Id_Caja);
                cmd.Parameters.AddWithValue("@saldo", Saldo);
                cmd.ExecuteNonQuery();
                Conexiones.CADMaestra.cerrar();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return false;
            }
        }

        public bool editar_proveedores(LProveedor proveedor_parametos)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Editar_Proveedor", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProveedor", proveedor_parametos.idProveedor);
                cmd.Parameters.AddWithValue("@Nombre", proveedor_parametos.Nombre);
                cmd.Parameters.AddWithValue("@Direccion", proveedor_parametos.Direccion);
                cmd.Parameters.AddWithValue("@Identificador_Fiscal", proveedor_parametos.IdentificadorFiscal);
                cmd.Parameters.AddWithValue("@Movil", proveedor_parametos.Movil);
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

        public bool restaurar_proveedor(LProveedor proveedor_parametros)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Restaurar_Proveedor", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProveedor", proveedor_parametros.idProveedor);
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

        public bool editar_cliente(LCliente cliente_parametros)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Editar_Clientes", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", cliente_parametros.idCliente);
                cmd.Parameters.AddWithValue("@Nombre", cliente_parametros.Nombre);
                cmd.Parameters.AddWithValue("@Direccion", cliente_parametros.Direccion);
                cmd.Parameters.AddWithValue("@Identificador_Fiscal", cliente_parametros.IdentificadorFiscal);
                cmd.Parameters.AddWithValue("@Movil", cliente_parametros.Movil);
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

        public bool restaurar_cliente(LCliente cliente_parametros)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Restaurar_Clientes", Conexiones.CADMaestra.conectar);
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
        public  bool Editar_respaldo(LEmpresa empresa_parametros)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Editar_Respaldos", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ultima_Fecha_de_Copia_de_Seguridad", empresa_parametros.Ultima_Fecha_De_Copia_De_Seguridad);
                cmd.Parameters.AddWithValue("@Carpeta_para_Copias_de_Seguridad", empresa_parametros.Carpeta_Para_Copias_De_Seguridad);
                cmd.Parameters.AddWithValue("@Ultima_Fecha_de_Copia_Date", empresa_parametros.Ultima_Fecha_De_Copia_Date);
                cmd.Parameters.AddWithValue("@Frecuencia_de_Copias", empresa_parametros.Fecuencia_De_Copias);
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
       
        public bool Editar_base_correo(LCorreoBase correo_parametros)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Editar_Correo_Base", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Correo", correo_parametros.Corrreo);
                cmd.Parameters.AddWithValue("@Password", correo_parametros.Password);
                cmd.Parameters.AddWithValue("@EstadoEnvio", correo_parametros.EstadoCorreo);
                cmd.ExecuteNonQuery();
                Conexiones.CADMaestra.cerrar();
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

        public bool Editar_movimiento_caja_cierre(LMCajaCierre cierrec_parametros)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Cerrar_Caja", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaFin", cierrec_parametros.FechaFin);
                cmd.Parameters.AddWithValue("@FechaCierre", cierrec_parametros.FechaCierre);
                cmd.Parameters.AddWithValue("@Ingresos", cierrec_parametros.Ingresos);
                cmd.Parameters.AddWithValue("@Egresos", cierrec_parametros.Egresos);
                cmd.Parameters.AddWithValue("@Saldo_queda_en_caja", cierrec_parametros.SaldoQuedaEnCaja);
                cmd.Parameters.AddWithValue("@Id_usuario", cierrec_parametros.idUsuario);
                cmd.Parameters.AddWithValue("@Total_calculado", cierrec_parametros.TotalCalculado);
                cmd.Parameters.AddWithValue("@Total_real", cierrec_parametros.TotalReal);
                cmd.Parameters.AddWithValue("@Estado", cierrec_parametros.Estado);
                cmd.Parameters.AddWithValue("@Diferencia", cierrec_parametros.Direferencia);
                cmd.Parameters.AddWithValue("@Id_caja", cierrec_parametros.idCaja);
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

        public bool Editar_marca(LMarca marca_parametros)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Editar_Marca_a", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@S", marca_parametros.S);
                cmd.Parameters.AddWithValue("@F", marca_parametros.F);
                cmd.Parameters.AddWithValue("@E", marca_parametros.E);
                cmd.Parameters.AddWithValue("@FA", marca_parametros.FA);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;

            }
            finally
            {
                Conexiones.CADMaestra.cerrar();
            }
        }

        public bool Editar_saldo_cliente(LCliente cliente_parametros,double Monto)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Disminuir_Saldo_Cliente", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", cliente_parametros.idCliente);
                cmd.Parameters.AddWithValue("@Monto", Monto);
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
       
        public bool Aumentar_saldo_cliente(LCliente cliente_parametros,double Saldo)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Aumentar_Saldo_A_Cliente", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", cliente_parametros.idCliente);
                cmd.Parameters.AddWithValue("@Saldo", Saldo);
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

        public bool editar_bascula(LCaja caja_parametros)
        {
            try
            {
                Datos.ObtenerDatos.obtener_id_caja_por_serial(ref Id_Caja);
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Editar_Bascula", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Caja", Id_Caja);
                cmd.Parameters.AddWithValue("@Estado", caja_parametros.Estado);
                cmd.Parameters.AddWithValue("@PuertoBalanza", caja_parametros.PuertoBalanza);
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

        public bool editar_precio_mayoreo(LDetalleVenta detalleventa_paremetros)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Precio_Mayoreo", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProducto", detalleventa_paremetros.idProducto);
                cmd.Parameters.AddWithValue("@idDetalleVenta", detalleventa_paremetros.idDetalleVenta);
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

        public bool editar_precio_venta(LDetalleVenta detalleventa)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("EditarPrecioVenta",Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDestalleVenta", detalleventa.idDetalleVenta);
                cmd.Parameters.AddWithValue("@Precio_Unitario", detalleventa.Precio_Mayoreo);
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

        public bool detalleventa_devolucion(LDetalleVenta detalleventa)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("DetalleVenta_Devolucion", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDetalleVenta", detalleventa.idDetalleVenta);
                cmd.Parameters.AddWithValue("@Cantidad", detalleventa.Cantidad);
                cmd.Parameters.AddWithValue("@Cantidad_Mostrada", detalleventa.Cantidad_Mostrada);
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

        public bool aumentar_stock(LProductos productos)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Aumentar_Stock", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProducto", productos.idProducto);
                cmd.Parameters.AddWithValue("@Cantidad", productos.Stock);
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

        public bool aumentar_stock_detalle(LProductos productos)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Aumentar_Stock_En_Detalle_De_Venta", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProducto", productos.idProducto);
                cmd.Parameters.AddWithValue("@Cantidad", productos.Stock);
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

        public bool editar_ventas(LVentas ventas)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Editar_Ventas", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idVenta", ventas.idVenta);
                cmd.Parameters.AddWithValue("@Monto", ventas.MontoTotal);
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

        public bool editar_tema_caja(LCaja caja)
        {
            try
            {
                ObtenerDatos.obtener_id_caja_por_serial(ref Id_Caja);
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Editar_Tema_Caja", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCaja",Id_Caja);
                cmd.Parameters.AddWithValue("@Tema", caja.Tema);
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

        public bool editar_precio_productos(LProductos productos)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Editar_Precio_Productos", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProducto", productos.idProducto);
                cmd.Parameters.AddWithValue("@Precio_de_Venta", productos.PrecioVenta);
                cmd.Parameters.AddWithValue("@Costo", productos.PrecioCompra);
                cmd.Parameters.AddWithValue("@Precio_mayoreo", productos.PrecioMayoreo);
                cmd.Parameters.AddWithValue("@CantidadAgrada", productos.Stock);
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

        public bool disminuir_stock_productos(LProductos productos)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Disminuir_Stock_Productos", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProducto", productos.idProducto);
                cmd.Parameters.AddWithValue("@Stock", productos.Stock);
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

        public bool editar_caja_impresoras(LImpresora impresora)
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Editar_Caja_Impresora", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCaja", impresora.idCaja);
                cmd.Parameters.AddWithValue("@ImpresoraTicket", impresora.ImpresoraTicket);
                cmd.Parameters.AddWithValue("@ImpresoraA4", impresora.ImpresoraA4);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
                
            }
            finally
            {
                Conexiones.CADMaestra.cerrar();
            }
        }
    }
}
