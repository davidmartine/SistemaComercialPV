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
using Aplicacion_Comercial.Logica;
using Aplicacion_Comercial.Datos;

namespace Aplicacion_Comercial.Formularios.Cobros
{
    public partial class Cobros : Form
    {
        public Cobros()
        {
            InitializeComponent();
        }

        public static int idCliente;
        public static double Saldo;
        private void Cobros_Load(object sender, EventArgs e)
        {
           // panelContenedor.Location = new Point((Width - panelContenedor.Width) / 2, (Height - panelContenedor.Height) / 2);

        }
        private void txtClienteSolicitante_TextChanged(object sender, EventArgs e)
        {
            Buscar_clientes();
        }

        private void Buscar_clientes()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.buscar_cliente(ref dt,txtClienteSolicitante.Text);
            datalistadoClientes.DataSource = dt;
            datalistadoClientes.Columns[1].Visible = false;
            datalistadoClientes.Columns[3].Visible = false;
            datalistadoClientes.Columns[4].Visible = false;
            datalistadoClientes.Columns[5].Visible = false;
            datalistadoClientes.Columns[6].Visible = false;
            datalistadoClientes.Columns[7].Visible = false;
            datalistadoClientes.Columns[2].Width = datalistadoClientes.Width;
            datalistadoClientes.BringToFront();
            datalistadoClientes.Visible = true;
            datalistadoClientes.Location = new Point(panel8.Location.X, panel8.Location.Y);
            datalistadoClientes.Size = new Size(341, 156);
            //panelRegistros.Visible = false;

        }

        private void datalistadoClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idCliente =Convert.ToInt32(datalistadoClientes.SelectedCells[1].Value);
            txtClienteSolicitante.Text = datalistadoClientes.SelectedCells[2].Value.ToString();
            Obtener_saldo();
            datalistadoClientes.Visible = false;
           // panelRegistros.Visible = true;
            Mostrar_estado_cuenta_cliente();
           
        }

        private void Obtener_saldo()
        {
            lblTotalSaldo.Text = datalistadoClientes.SelectedCells[7].Value.ToString();
            Saldo = Convert.ToDouble(datalistadoClientes.SelectedCells[7].Value);
            //Saldo =Convert.ToDouble(lblTotalSaldo.Text);
        }

        private void Mostrar_estado_cuenta_cliente()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.Mostrar_estado_cuenta_cliente(ref dt, idCliente);
            datalistadoHistorial.DataSource = dt;
            Logica.BasesPCProgram.MultilineaCobros(ref datalistadoHistorial);
            panelH.Visible = true;
            panelM.Visible = false;
            panelHistorial.Visible = true;
            panelHistorial.Dock = DockStyle.Fill;
            panelMovimientos.Visible = false;
            panelMovimientos.Dock = DockStyle.None;
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            Mostrar_control_cobros();
        }

        private void Mostrar_control_cobros()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.Mostrar_control_cobros(ref dt);
            datalistadoMovimientos.DataSource = dt;
            Logica.BasesPCProgram.MultilineaCobros(ref datalistadoMovimientos);
            datalistadoMovimientos.Columns[1].Visible = false;
            datalistadoMovimientos.Columns[5].Visible = false;
            datalistadoMovimientos.Columns[6].Visible = false;
            datalistadoMovimientos.Columns[7].Visible = false;
            panelH.Visible = false;
            panelM.Visible = true;
            panelHistorial.Visible = false;
            panelMovimientos.Visible = true;
            panelMovimientos.Dock = DockStyle.Fill;
            panelHistorial.Dock = DockStyle.None;

        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            Mostrar_estado_cuenta_cliente();
        }

        private void btnAbonar_Click(object sender, EventArgs e)
        {
            
            
        }

        private void Frmmedios_FormClosing(object sender, FormClosingEventArgs e)
        {
            Buscar_clientes();
            Obtener_saldo();
            Mostrar_control_cobros();
        }

        private void txtClienteSolicitante_Click(object sender, EventArgs e)
        {
            txtClienteSolicitante.SelectAll();

        }

        private void datalistadoMovimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == datalistadoMovimientos.Columns["Eli"].Index)
            {
                DialogResult result;
                result = MessageBox.Show("¿ESTA SEGURO DE ELIMINAR ESTE ABONO?", "ELIMINANDO REGISTRO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(result == DialogResult.OK)
                {
                    Aumentar_saldo_cliente();
                }
            }
        }

        private void Aumentar_saldo_cliente()
        {
            double Saldo;
            Saldo =Convert.ToDouble(datalistadoMovimientos.SelectedCells[2].Value);
            LCliente cliente_parametros = new LCliente();
            CADEditarDatos funcion = new CADEditarDatos();
            cliente_parametros.idCliente = idCliente;
            if(funcion.Aumentar_saldo_cliente(cliente_parametros,Saldo) ==true)
            {
                Eliminar_control_cobros();
            }

        }

        private void Eliminar_control_cobros()
        {
            LControlCobros cobros_parametros = new LControlCobros();
            CADEliminarDatos funcion = new CADEliminarDatos();
            cobros_parametros.idControlCobros =Convert.ToInt32(datalistadoMovimientos.SelectedCells[1].Value);
            if (funcion.Eliminar_control_cobros(cobros_parametros) == true)
            {
                Buscar_clientes();
            }

        }

        private void btnAbonar_Click_1(object sender, EventArgs e)
        {
            if (Saldo > 0)
            {
                Formularios.Cobros.MediosCobros frmmedios = new MediosCobros();
                frmmedios.FormClosing += Frmmedios_FormClosing;
                frmmedios.ShowDialog();
            }
            else
            {
                MessageBox.Show("EL SALDO DEL CLIENTE ACTUAL ES CERO");
            }
        }

       
    }
}
