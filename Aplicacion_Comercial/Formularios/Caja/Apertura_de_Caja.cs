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
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Management;
using System.Xml;

namespace Aplicacion_Comercial.Formularios.Caja
{
    public partial class Apertura_de_Caja : Form
    {
        public Apertura_de_Caja()
        {
            InitializeComponent();
        }

        private int txtidcaja;


        private void APERTURA_DE_CAJA_Load(object sender, EventArgs e)
        {
            Logica.BasesPCProgram.cambiar_idioma_regional();
            Datos.ObtenerDatos.obtener_id_caja_por_serial(ref txtidcaja);
            //Panel1.Location = new Point((Width - Panel1.Width) / 2, (Height - Panel1.Height) / 2);  
        }
        /*private static void OnlyNumber(KeyPressEventArgs e, bool isdecimal)
        {
            String aceptados;
            if (!isdecimal)
            {
                aceptados = "0123456789." + Convert.ToChar(8);
            }
            else
                aceptados = "0123456789," + Convert.ToChar(8);

            if (aceptados.Contains("" + e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }*/
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            double Monto;
            Monto = Convert.ToDouble(txtMonto.Text);
            if (string.IsNullOrEmpty(txtMonto.Text))
            {
                txtMonto.Text = "0";
            }
            bool Estado = Datos.CADEditarDatos.editar_dinero_caja_inicial(txtidcaja, Monto);
            if (Estado == true)
            {
                pasar_a_ventas();
            }
        }
        /*private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }*/

        /*private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    this.WindowState = FormWindowState.Maximized;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/

        /*private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }*/

        private void btnOmitir_Click(object sender, EventArgs e)
        {
            pasar_a_ventas();
        }

        private void pasar_a_ventas()
        {
            this.Dispose();
            Formularios.VENTAS_MENU_PRINCIPAL.Ventas_Menu_Principal frmventasprincipal = new VENTAS_MENU_PRINCIPAL.Ventas_Menu_Principal();
            frmventasprincipal.ShowDialog();

        }

        private void Panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {

            Logica.BasesPCProgram.separador_de_numeros(txtMonto, e);
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
