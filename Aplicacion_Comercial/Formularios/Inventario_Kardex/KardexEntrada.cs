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

namespace Aplicacion_Comercial.Formularios.Inventario_Kardex
{
    public partial class KardexEntrada : Form
    {
        public KardexEntrada()
        {
            InitializeComponent();
        }

        private int idProducto;
        private double CantidadActual;
        private double PrecioVentaActual;
        private double CostoActual;
        private double PrecioMayoreoActual;

        private double PrecioVentaNuevo;
        private double CostoNuevo;
        private double PrecioMayoreoNuevo;

        private double CantidadAgregar;
        private double CostoAgregado;

        private void KardexEntrada_Load(object sender, EventArgs e)
        {
            lblAnuncio.Text = "";
        }

        private void buscar_productos_kardex()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.buscar_productos_kardex(ref dt, txtBuscarProducto.Text);
            datalistadoProductos.DataSource = dt;
            datalistadoProductos.Visible = true;
            datalistadoProductos.Columns[1].Visible = false;
            datalistadoProductos.Columns[3].Visible = false;
            datalistadoProductos.Columns[4].Visible = false;
            datalistadoProductos.Columns[5].Visible = false;
            datalistadoProductos.Columns[6].Visible = false;
            datalistadoProductos.Columns[7].Visible = false;
            datalistadoProductos.Columns[8].Visible = false;
            datalistadoProductos.Columns[9].Visible = false;
            datalistadoProductos.Columns[10].Visible = false;
            datalistadoProductos.Columns[11].Visible = false;
            datalistadoProductos.Columns[12].Visible = false;
            datalistadoProductos.Columns[13].Visible = false;
            datalistadoProductos.Columns[14].Visible = false;
            datalistadoProductos.Columns[15].Visible = false;
            datalistadoProductos.Columns[16].Visible = false;

            Logica.BasesPCProgram.Multilinea(ref datalistadoProductos);
        }

        private void datalistadoProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            obtener_datos();
        }

        private void obtener_datos()
        {
            idProducto =Convert.ToInt32(datalistadoProductos.SelectedCells[1].Value);
            CantidadActual =Convert.ToDouble(datalistadoProductos.SelectedCells[6].Value);
            CostoActual = Convert.ToDouble(datalistadoProductos.SelectedCells[7].Value);
            PrecioVentaActual = Convert.ToDouble(datalistadoProductos.SelectedCells[9].Value);
            PrecioMayoreoActual= CostoActual = Convert.ToDouble(datalistadoProductos.SelectedCells[14].Value);
            lblCantidadActual.Text = CantidadActual.ToString();
            txtCosto.Text = CostoActual.ToString();
            txtPrecioVenta.Text = PrecioVentaActual.ToString();
            txtPrecioMayoreo.Text = PrecioMayoreoActual.ToString();
            lblAnuncio.Text = "";
            txtAgregar.Clear();
            if (PrecioMayoreoActual == 0)
            {
                label7.Visible = false;
                txtPrecioMayoreo.Visible = false;
            }
            else
            {
                label7.Visible = true;
                txtPrecioMayoreo.Visible = true;
            }
            txtBuscarProducto.Text = datalistadoProductos.SelectedCells[2].Value.ToString();
            datalistadoProductos.Visible = false; 
        }
        private void editar_precio_productos()
        {
            Logica.LProductos productos = new Logica.LProductos();
            Datos.CADEditarDatos datos = new Datos.CADEditarDatos();
            productos.idProducto = idProducto;
            productos.PrecioVenta =Convert.ToDouble(txtPrecioVenta.Text);
            productos.PrecioCompra = CostoNuevo;
            productos.PrecioMayoreo =Convert.ToDouble(txtPrecioMayoreo.Text);
            productos.Stock = txtAgregar.Text;
            if (datos.editar_precio_productos(productos) == true)
            {
                insertar_kardex_entrada();
            }
        }

        private void insertar_kardex_entrada()
        {
            Logica.LKardex kardex = new Logica.LKardex();
            Datos.CADInsertarDatos datos = new Datos.CADInsertarDatos();
            kardex.Fecha = dtpFechaRegistro.Value;
            kardex.Motivo = txtMotivo.Text;
            kardex.Cantidad =Convert.ToDouble(txtAgregar.Text);
            kardex.idProducto = idProducto;
            if (datos.insertar_kardex_entrada(kardex) == true)
            {
                txtBuscarProducto.Clear();
                txtBuscarProducto.Focus();
                datalistadoProductos.Visible = true;
                MessageBox.Show("REGISTRO REALIZADO CORRECTAMENTE");
            }
        }

        private void validaciones()
        {
            if (!string.IsNullOrEmpty(txtAgregar.Text))
            {
                if (!string.IsNullOrEmpty(txtCosto.Text))
                {
                    if (!string.IsNullOrEmpty(txtPrecioVenta.Text))
                    {
                        if (!string.IsNullOrEmpty(txtPrecioMayoreo.Text))
                        {
                            if (string.IsNullOrEmpty(txtMotivo.Text))
                            {
                                txtMotivo.Text = "SIN MOTIVO";
                            }
                            editar_precio_productos();
                        }
                        else
                        {
                            MessageBox.Show("EL CAMPO PRECIO DE VENTA AL MAYOREO NO PUEDE ESTAR VACIO", "VOLOR VACIO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPrecioMayoreo.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("EL CAMPO PRECIO DE VENTA NO PUEDE ESTAR VACIO", "VOLOR VACIO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPrecioVenta.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("EL CAMPO COSTO NO PUEDE ESTAR VACIO", "VOLOR VACIO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCosto.Focus();
                }
            }
            else
            {
                MessageBox.Show("EL CAMPO AGREGAR NO PUEDE ESTAR VACIO", "VOLOR VACIO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAgregar.Focus();

            }
        }
        private void calcular()
        {
            if (!string.IsNullOrEmpty(txtAgregar.Text))
            {
                if (!string.IsNullOrEmpty(txtCosto.Text))
                {
                    CantidadAgregar = Convert.ToDouble(txtAgregar.Text);
                    CostoAgregado = Convert.ToDouble(txtCosto.Text);
                    CostoNuevo = ((CostoActual * CantidadActual) + (CostoAgregado*CantidadAgregar))/(CantidadActual+CantidadAgregar);
                    lblAnuncio.Text = "SE RECIBIRAN " + txtAgregar.Text + " DE STOCK, EL NUEVO COSTO ES DE: " + CostoNuevo.ToString();
                }
                
            }
        }

        private void txtBuscarProducto_TextChanged_1(object sender, EventArgs e)
        {
            buscar_productos_kardex();
        }

        private void txtAgregar_TextChanged_1(object sender, EventArgs e)
        {
            calcular();
        }

        private void txtCosto_TextChanged_1(object sender, EventArgs e)
        {
            calcular();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            validaciones();
        }
    }
}
