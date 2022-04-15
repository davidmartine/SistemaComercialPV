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

namespace Aplicacion_Comercial.Formularios.Diseñador_de_Comprabantes
{
    public partial class Ticket : Form
    {
        public Ticket()
        {
            InitializeComponent();
        }

        string txtTipo;
        private void Ticket_Load(object sender, EventArgs e)
        {
            mostrar_formato_ticket();
            obtener_datos();
        } 

        private void mostrar_formato_ticket()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                Conexiones.CADMaestra.conectar.Open();
                da = new SqlDataAdapter("Mostrar_Formato_Ticket", Conexiones.CADMaestra.conectar); 
                da.Fill(dt);
                datalistado_ticket.DataSource = dt;
                Conexiones.CADMaestra.conectar.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void obtener_datos()
        {
            try
            {
                txtTipo = datalistado_ticket.SelectedCells[13].Value.ToString();
                if(txtTipo == "TICKET NO FISCAL")
                {
                    btnTicket.BackColor = Color.FromArgb(255, 204, 1);
                    btnFacturaBoleta.BackColor = Color.White;
                    txtAutorizacionFiscal.Visible = false;
                }
                else
                {
                    btnFacturaBoleta.BackColor = Color.FromArgb(255, 204, 1);
                    btnTicket.BackColor = Color.White;
                    txtAutorizacionFiscal.Visible = true;
                }

                Icono.BackgroundImage = null;
                byte[] b = (Byte[])datalistado_ticket.SelectedCells[1].Value;
                MemoryStream ms = new MemoryStream(b);
                Icono.Image = Image.FromStream(ms);

                txtEmpresaTiket.Text = datalistado_ticket.SelectedCells[2].Value.ToString();
                txtEmpresaRuc.Text = datalistado_ticket.SelectedCells[5].Value.ToString();
                txtDireccion.Text = datalistado_ticket.SelectedCells[6].Value.ToString();
                txtDepartamento.Text = datalistado_ticket.SelectedCells[7].Value.ToString();
                txtMoneda.Text = datalistado_ticket.SelectedCells[8].Value.ToString();
                txtAgradecimientos.Text = datalistado_ticket.SelectedCells[9].Value.ToString();
                txtRedes.Text = datalistado_ticket.SelectedCells[10].Value.ToString();
                txtAnuncio.Text = datalistado_ticket.SelectedCells[11].Value.ToString();
                txtAutorizacionFiscal.Text = datalistado_ticket.SelectedCells[12].Value.ToString();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void btnFacturaBoleta_Click(object sender, EventArgs e)
        {
            txtTipo = "FACTURA-BOLETA";
            btnTicket.BackColor = Color.White;
            btnFacturaBoleta.BackColor = Color.FromArgb(255, 204, 1);
            txtAutorizacionFiscal.Visible = true;
        }
        private void btnTicket_Click(object sender, EventArgs e)
        {
            txtTipo = "TICKET NO FISCAL";
            btnTicket.BackColor = Color.FromArgb(255, 204, 1);
            btnFacturaBoleta.BackColor = Color.White;
            txtAutorizacionFiscal.Visible = false;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            openfiledialog.InitialDirectory = "";
            openfiledialog.Filter = "Imagenes|*.jpg;*.png";
            openfiledialog.FilterIndex = 2;
            openfiledialog.Title = "CARGADOR DE IMAGENES SYSGETCO";
            if(openfiledialog.ShowDialog() == DialogResult.OK)
            {
                Icono.BackgroundImage = null;
                Icono.Image = new Bitmap(openfiledialog.FileName);

            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar_ticket();
        }
        private void guardar_ticket()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Editar_Formato_Ticket",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Identificador_Fiscal", txtEmpresaRuc.Text);
                cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                cmd.Parameters.AddWithValue("@Provincia_Departamento", txtDepartamento.Text);
                cmd.Parameters.AddWithValue("@Nombre_de_Moneda", txtMoneda.Text);
                cmd.Parameters.AddWithValue("@Agradecimiento", txtAgradecimientos.Text);
                cmd.Parameters.AddWithValue("@Pagina_Web", txtRedes.Text);
                cmd.Parameters.AddWithValue("@Anuncio", txtAnuncio.Text);
                if(txtTipo == "TICKET NO FISCAL")
                {
                    cmd.Parameters.AddWithValue("@Datos_Fiscales_de_Autorizacion","-");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Datos_Fiscales_de_Autorizacion", txtAutorizacionFiscal.Text);
                }

                cmd.Parameters.AddWithValue("@Por_Defecto", txtTipo);
                cmd.Parameters.AddWithValue("@Nombre_Empresa", txtEmpresaTiket.Text);
                MemoryStream ms = new MemoryStream();
                Icono.Image.Save(ms,Icono.Image.RawFormat);
                cmd.Parameters.AddWithValue("@Logo", ms.GetBuffer());
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("DATOS ACTUALIZADOS CORRECTAMENTE", "ACTUALIZANDO DATOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
