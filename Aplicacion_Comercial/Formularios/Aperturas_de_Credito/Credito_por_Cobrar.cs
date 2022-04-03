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

namespace Aplicacion_Comercial.Formularios.Aperturas_de_Credito
{
    public partial class Credito_por_Cobrar : Form
    {
        public Credito_por_Cobrar()
        {
            InitializeComponent();
        }

        private int idCliente;
        Panel p = new Panel();
        private void Credito_por_Cobrar_Load(object sender, EventArgs e)
        {
            buscador_cliente();
        }

        private void insertar_creditos()
        {

            LCreditoPorCobrar parametros = new LCreditoPorCobrar();
            CADInsertarDatos funcion = new CADInsertarDatos();
            parametros.idCliente = idCliente;
            parametros.Descripcion = txtDetalle.Text;
            parametros.Fecha_Registro = dpFechaRegistro.Value;
            parametros.Fecha_Vencimiento = dpFechaVencimiento.Value;
            parametros.Total = Convert.ToDouble(txtSaldo.Text);
            parametros.Saldo = Convert.ToDouble(txtSaldo.Text);
            if (funcion.insertar_credito_por_cobrar(parametros) == true)
            {
                MessageBox.Show("REGISTRADO");
                limpiar_textos();
                buscador_cliente();

            }

        }

        private void limpiar_textos()
        {
            txtSaldo.Clear();
            txtDetalle.Clear();
            txtCliente.Clear();
            idCliente = 0;
        }

        private void buscador_cliente()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.buscar_cliente(ref dt,txtCliente.Text);
            datalistado.DataSource = dt;
            datalistado.Columns[1].Visible = false;
            datalistado.Columns[3].Visible = false;
            datalistado.Columns[4].Visible = false;
            datalistado.Columns[5].Visible = false;
            datalistado.Columns[6].Visible = false;
            datalistado.Columns[7].Visible = false;
            dibujar_panel_datalistado();
        }

        private void dibujar_panel_datalistado()
        {
            datalistado.Dock = DockStyle.Fill;
            datalistado.Visible = true;
            p.Controls.Add(datalistado);
            p.Location = new Point(panel4.Location.X, panel4.Location.Y + panelProveedor.Location.Y);
            p.Size = new System.Drawing.Size(743, 395);
            Controls.Add(p);
            p.BringToFront();

        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            buscador_cliente();
        }


        private void btnNuevoConcepto_Click(object sender, EventArgs e)
        {
            Formularios.Clientes_Proveedores.Clientes frmclientes = new Clientes_Proveedores.Clientes();
            frmclientes.ShowDialog();
        }

        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idCliente = Convert.ToInt32(datalistado.SelectedCells[1].Value);
            txtCliente.Text = datalistado.SelectedCells[2].Value.ToString();
            Controls.Remove(p);
        }

        private void txtCliente_Click(object sender, EventArgs e)
        {
            txtCliente.SelectAll();
        }

        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSaldo.Text))
            {
                if (!string.IsNullOrEmpty(txtDetalle.Text))
                {

                    insertar_creditos();
                }
                else
                {
                    txtDetalle.Text = "-";
                }

            }
            else
            {
                MessageBox.Show("DEBE DE INGRESAR UN SALDO", "SALDO OBLIGATORIO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void txtSaldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Logica.BasesPCProgram.separador_de_numeros(txtSaldo, e);
        }
    }
}
