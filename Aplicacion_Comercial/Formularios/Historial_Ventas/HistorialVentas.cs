using Aplicacion_Comercial.Datos;
using Aplicacion_Comercial.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion_Comercial.Formularios.Historial_Ventas
{
    public partial class HistorialVentas : Form
    {
        public HistorialVentas()
        {
            InitializeComponent();
        }
        private int idVenta;
        private double Total;
        private int idDetalleVenta;
        private double Cantidad;
        private string ControlInventario;
        private int idProducto;
        private double TotalNuevo;
        private double PrecioUnitario;
        private string ControlStock;
        private string TotalEnterosString;
        private string TotalEnLetras;

        private void HistorialVentas_Load(object sender, EventArgs e)
        {
            panelBienvenida.Dock = DockStyle.Fill;

        }

        private void txtbusca_TextChanged(object sender, EventArgs e)
        {
            buscar_ventas();
        }

        private void buscar_ventas()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.buscar_ventas(ref dt, txtbusca.Text);
            datalistadoVentas.DataSource = dt;
            datalistadoVentas.Columns[1].Visible = false;
            datalistadoVentas.Columns[4].Visible = false;
            datalistadoVentas.Columns[5].Visible = false;
            datalistadoVentas.Columns[6].Visible = false;
            datalistadoVentas.Columns[8].Visible = false;
            datalistadoVentas.Columns[9].Visible = false;
            datalistadoVentas.Columns[10].Visible = false;
            Logica.BasesPCProgram.Multilinea(ref datalistadoVentas);
        }

        private void datalistadoVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            obtener_datos();
        }

        private void obtener_datos()
        {
            if (datalistadoVentas.RowCount > 0)
            {
                idVenta = Convert.ToInt32(datalistadoVentas.SelectedCells[1].Value);
                lblComprobante.Text = datalistadoVentas.SelectedCells[3].Value.ToString();
                lblTotal.Text = datalistadoVentas.SelectedCells[4].Value.ToString();
                Total = Convert.ToDouble(datalistadoVentas.SelectedCells[4].Value);
                lblCajero.Text = datalistadoVentas.SelectedCells[5].Value.ToString();
                lblPagoCon.Text = datalistadoVentas.SelectedCells[6].Value.ToString();
                lblCliente.Text = datalistadoVentas.SelectedCells[8].Value.ToString();
                lblTipoPago.Text = datalistadoVentas.SelectedCells[9].Value.ToString();
                lblPagoCon.Text = datalistadoVentas.SelectedCells[10].Value.ToString();
                panel8.Visible = true;
                panelDetalle.Visible = true;
                pCancelado.Visible = false;
                panelBienvenida.Visible = false;
                panelCantidad.Visible = false;
                panelReporte.Visible = false;
                panelDetalle.Dock = DockStyle.Fill;
                mostrar_detalle_venta();
            }
        }

        private void mostrar_detalle_venta()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.mostrar_detalle_venta(ref dt, idVenta);
            datalistadoDetalleVenta.DataSource = dt;
            datalistadoDetalleVenta.Columns[6].Visible = false;
            datalistadoDetalleVenta.Columns[7].Visible = false;
            datalistadoDetalleVenta.Columns[8].Visible = false;
            datalistadoDetalleVenta.Columns[9].Visible = false;
            datalistadoDetalleVenta.Columns[10].Visible = false;
            datalistadoDetalleVenta.Columns[11].Visible = false;
            datalistadoDetalleVenta.Columns[12].Visible = false;
            datalistadoDetalleVenta.Columns[13].Visible = false;
            datalistadoDetalleVenta.Columns[14].Visible = false;
            datalistadoDetalleVenta.Columns[15].Visible = false;
            datalistadoDetalleVenta.Columns[16].Visible = false;
            Logica.BasesPCProgram.Multilinea(ref datalistadoDetalleVenta);

        }

        private void datalistadoDetalleVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == datalistadoDetalleVenta.Columns["Devolver"].Index)
            {
                obtener_datos_detalle();
            }
        }

        private void obtener_datos_detalle()
        {
            lblCantidadActual.Text = datalistadoDetalleVenta.SelectedCells[3].Value.ToString();
            Cantidad = Convert.ToDouble(datalistadoDetalleVenta.SelectedCells[3].Value);
            PrecioUnitario = Convert.ToDouble(datalistadoDetalleVenta.SelectedCells[4].Value);
            idProducto =Convert.ToInt32(datalistadoDetalleVenta.SelectedCells[6].Value);
            idDetalleVenta = Convert.ToInt32(datalistadoDetalleVenta.SelectedCells[7].Value);
            ControlInventario = datalistadoDetalleVenta.SelectedCells[14].Value.ToString();
            txtCantidadDevolver.Clear();
            txtCantidadDevolver.Focus();
            panelCantidad.Location = new Point(lblComprobante.Location.X, lblComprobante.Location.Y);
            panelCantidad.Size = new Size(466,474);
            panelCantidad.Visible = true;
            panelCantidad.BringToFront();

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelCantidad.Visible = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            detalleventa_devolucion();
        }

        private void detalleventa_devolucion()
        {
            if (!string.IsNullOrEmpty(txtCantidadDevolver.Text))
            {
                double CantidadDevolucion;
                CantidadDevolucion = Convert.ToDouble(txtCantidadDevolver.Text);
                if (CantidadDevolucion > 0)
                {
                    if (CantidadDevolucion <= Cantidad)
                    {
                        LDetalleVenta detalleventa = new LDetalleVenta();
                        CADEditarDatos editardatos = new CADEditarDatos();
                        detalleventa.idDetalleVenta = idDetalleVenta;
                        detalleventa.Cantidad = Convert.ToDouble(CantidadDevolucion);
                        detalleventa.Cantidad_Mostrada = Convert.ToDouble(CantidadDevolucion);
                        if (editardatos.detalleventa_devolucion(detalleventa) == true)
                        {
                            if(ControlInventario == "SI")
                            {
                                aumentar_stock();
                                aumentar_stock_detalle();
                                insertar_kardex_entrada();
                                lblTotal.Text = TotalNuevo.ToString();
                                editar_ventas();
                                panelCantidad.Visible = false;
                                validar_paneles();
                                buscar_ventas();

                            }
                            else
                            {
                                lblTotal.Text = TotalNuevo.ToString();
                                editar_ventas();
                                panelCantidad.Visible = false;
                                validar_paneles();
                                buscar_ventas();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("ESTAS EXCEDIENDO LA CANTIDAD A DEVOLVER", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("LA CANTIDAD A DEVOLVER DEBE SER MAYOR A 0", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("INGRESE UNA CANTIDAD A DEVOLVER","ERROR",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
        }

        private void aumentar_stock()
        {
            LProductos productos = new LProductos();
            CADEditarDatos datos = new CADEditarDatos();
            productos.idProducto = idProducto;
            productos.Stock = txtCantidadDevolver.Text;
            datos.aumentar_stock(productos);
        }

        private void aumentar_stock_detalle()
        {
            LProductos productos = new LProductos();
            CADEditarDatos editardatos = new CADEditarDatos();
            productos.idProducto = idProducto;
            productos.Stock =txtCantidadDevolver.Text;
            editardatos.aumentar_stock_detalle(productos);
        }

        private void insertar_kardex_entrada()
        {
            LKardex kardex = new LKardex();
            CADInsertarDatos datos = new CADInsertarDatos();
            kardex.Fecha = DateTime.Now;
            kardex.Motivo = "DEVOLUCION DE PRODUCTO VENTA #" + lblComprobante.Text;
            kardex.Cantidad = Convert.ToDouble(txtCantidadDevolver.Text);
            kardex.idProducto = idProducto;
            datos.insertar_kardex_entrada(kardex);
        }

        private void editar_ventas()
        {
            LVentas ventas = new LVentas();
            CADEditarDatos datos = new CADEditarDatos();
            ventas.idVenta = idVenta;
            ventas.MontoTotal =TotalNuevo;
            datos.editar_ventas(ventas);
        }

        private void txtCantidadDevolver_TextChanged(object sender, EventArgs e)
        {
            calcular_nuevo_total();
        }

        private void calcular_nuevo_total()
        {
            try
            {
                double CantidadTexto;
                CantidadTexto =Convert.ToDouble(txtCantidadDevolver.Text);
                TotalNuevo = Total - (CantidadTexto * PrecioUnitario);

            }
            catch(Exception)
            {
               
            }
        }

        private void validar_paneles()
        {
            if(TotalNuevo == 0)
            {
                panelBienvenida.Visible = false;
                panelDetalle.Visible = false;
                panelTicket.Visible = false;
                pCancelado.Visible = true;
                pCancelado.Dock = DockStyle.Fill;
            }
        }

        private void btnEliminarVenta_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿ESTAS SEGURO DE ELIMINAR ESTA VENTA?", "ELIMINANDO REGISTROS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result == DialogResult.OK)
            {
                foreach(DataGridViewRow row in datalistadoDetalleVenta.Rows)
                {
                    ControlStock = row.Cells["Usa_Inventario"].Value.ToString();
                    if (ControlStock == "SI")
                    {
                        idProducto = Convert.ToInt32(row.Cells["idProducto"].Value);
                        txtCantidadDevolver.Text = row.Cells["Cant"].Value.ToString();
                        aumentar_stock();
                        aumentar_stock_detalle();
                        insertar_kardex_entrada();
                    }
                }
                TotalNuevo = 0;
                eliminar_ventas();
                validar_paneles();
                buscar_ventas();

            }
        }

        private void eliminar_ventas()
        {
            LVentas ventas = new LVentas();
            CADEliminarDatos datos = new CADEliminarDatos();
            ventas.idVenta = idVenta;
            datos.eliminar_ventas(ventas);
        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            convertir_total_en_letras();
            reimprimir_ticket();
        }

        private void convertir_total_en_letras()
        {
            try
            {
                TotalNuevo = Convert.ToDouble(lblTotal.Text);
                int numero = Convert.ToInt32(Math.Floor(TotalNuevo));
                TotalEnterosString = Conexiones.Total_Letras.Num2Text(numero);
                string[] a = lblTotal.Text.Split('.');
                string TotalDecimales;
                TotalDecimales = a[1];
                TotalEnLetras = TotalEnterosString + " CON " + TotalDecimales + "/100";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                
            }
        }

        private void reimprimir_ticket()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.mostrar_ticket_impreso(ref dt, idVenta, TotalEnLetras);
            Reportes_Kardex.Reportes_de_Comprobantes.TicketReporte rpt = new Reportes_Kardex.Reportes_de_Comprobantes.TicketReporte();
            rpt = new Reportes_Kardex.Reportes_de_Comprobantes.TicketReporte();
            rpt.table1.DataSource = dt;
            rpt.DataSource = dt;
            reportViewer1.Report = rpt;
            reportViewer1.RefreshReport();
            panelReporte.Visible = true;
            panelReporte.Location = new Point(panelTicket.Location.X, panelTicket.Location.Y);
            panelReporte.Size = new Size(panelTicket.Width, panelTicket.Height);
            panelReporte.BringToFront();
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            filtrar_fechas();
            dtpFi.Value = DateTime.Now;
            dtpFf.Value = DateTime.Now;
            buscar_ventas_por_fechas();
        }

        private void filtrar_fechas()
        {
            panelDetalle.Visible = false;
            panelBienvenida.Visible = true;
            panelBienvenida.Dock = DockStyle.Fill;
            pCancelado.Visible = false;
        }

        private void buscar_ventas_por_fechas()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.buscar_ventas_por_fechas(ref dt, dtpFi.Value, dtpFf.Value);
            datalistadoVentas.DataSource = dt;
            datalistadoVentas.Columns[1].Visible = false;
            datalistadoVentas.Columns[4].Visible = false;
            datalistadoVentas.Columns[5].Visible = false;
            datalistadoVentas.Columns[6].Visible = false;
            datalistadoVentas.Columns[8].Visible = false;
            datalistadoVentas.Columns[9].Visible = false;
            datalistadoVentas.Columns[10].Visible = false;
            Logica.BasesPCProgram.Multilinea(ref datalistadoVentas);
        }

        private void dtpFi_ValueChanged(object sender, EventArgs e)
        {
            filtrar_fechas();
            buscar_ventas_por_fechas();
        }

        private void dtpFf_ValueChanged(object sender, EventArgs e)
        {
            filtrar_fechas();
            buscar_ventas_por_fechas();
        }

        private void txtCantidadDevolver_KeyPress(object sender, KeyPressEventArgs e)
        {
            Logica.BasesPCProgram.separador_de_numeros(txtCantidadDevolver, e);
        }
    }
}
