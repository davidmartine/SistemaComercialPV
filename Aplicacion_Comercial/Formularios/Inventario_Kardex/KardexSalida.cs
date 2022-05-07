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

namespace Aplicacion_Comercial.Formularios.Inventario_Kardex
{
    public partial class KardexSalida : Form
    {
        private double CantidadActual;
        public KardexSalida()
        {
            InitializeComponent();
        }

        private int idProdducto;
        private void KardexSalida_Load(object sender, EventArgs e)
        {

        }
        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            buscar_productos_kardex();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            validaciones();
        }

        private void validaciones()
        {
            if (!string.IsNullOrEmpty(txtCantidad.Text))
            {
                if (string.IsNullOrEmpty(txtMotivo.Text))
                {
                    txtMotivo.Text = "SIN MOTIVO";
                }
                double CantidadDisminuir = Convert.ToDouble(txtCantidad.Text);
                if (CantidadDisminuir <= Convert.ToDouble(lblCantidadActual.Text))
                {
                    disminuir_stock();
                }
                else
                {
                    MessageBox.Show("SE HA RESTADO MAS DE LO QUE HAY EN STOCK", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("EL CAMPO AGREGAR NO PUEDE ESTAR VACIO", "VALOR VACIO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCantidad.Focus();
            }
        }
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            validaciones();
        }
        private void insertar_kardex_salida()
        {
            LKardex kardex = new LKardex();
            CADInsertarDatos datos = new CADInsertarDatos();
            kardex.Fecha = dtpFechaRegistro.Value;
            kardex.Motivo = txtMotivo.Text;
            kardex.Cantidad = Convert.ToDouble(txtCantidad.Text);
            kardex.idProducto = idProdducto;
            if (datos.insertar_kardex_salida(kardex) == true)
            {
                txtBuscarProducto.Clear();
                txtBuscarProducto.Focus();
                datalistadoProductos.Visible = true;
                MessageBox.Show("REGISTRO REALIZADO CORRECTAMENTE");
            }
        }
        private void disminuir_stock()
        {
            LProductos productos = new LProductos();
            CADEditarDatos datos = new CADEditarDatos();
            productos.idProducto = idProdducto;
            productos.Stock = txtCantidad.Text;
            if (datos.disminuir_stock_productos(productos) == true)
            {
                insertar_kardex_salida();
            }
        }
        private void txtBuscarProducto_TextChanged_1(object sender, EventArgs e)
        {
            buscar_productos_kardex();
        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
          //  Logica.BasesPCProgram.separador_de_numeros(txtCantidad, e); ;
        }
        private void datalistadoProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenetDatos();
        }
        private void ObtenetDatos()
        {
            idProdducto = Convert.ToInt32(datalistadoProductos.SelectedCells[1].Value);
            CantidadActual = Convert.ToDouble(datalistadoProductos.SelectedCells[6].Value);
            lblCantidadActual.Text = CantidadActual.ToString();
            txtMotivo.Clear();
            txtMotivo.Clear();
            txtBuscarProducto.Text = datalistadoProductos.SelectedCells[2].Value.ToString();
            datalistadoProductos.Visible = false; ;
        }

    }
}
