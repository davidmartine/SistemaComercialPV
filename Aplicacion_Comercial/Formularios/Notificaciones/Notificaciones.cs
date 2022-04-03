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

namespace Aplicacion_Comercial.Formularios.Notificaciones
{
    public partial class Notificaciones : Form
    {
        public Notificaciones()
        {
            InitializeComponent();
        }

        private void Notificaciones_Load(object sender, EventArgs e)
        {
            dibujar_productos_vencidos();
        }

        private void dibujar_productos_vencidos()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Contar_Productos_Vencidos", con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Label B = new Label();
                    Panel P1 = new Panel();
                    Panel P2 = new Panel();
                    PictureBox I1 = new PictureBox();
                    PictureBox I2 = new PictureBox();
                    Label L = new Label();

                    B.Text = "TIENES PRODUCTOS VENCIDOS";
                    B.Name = rd["id"].ToString();
                    B.Size = new System.Drawing.Size(430, 35);
                    B.Font = new System.Drawing.Font("Arial", 12);
                    B.BackColor = Color.Transparent;
                    B.ForeColor = Color.Black;
                    B.Dock = DockStyle.Top;
                    B.TextAlign = ContentAlignment.MiddleLeft;

                    L.Text = "(" + rd["id"].ToString() + ") PRODUCTO(S) VENCIDO(S)";
                    L.Name = rd["id"].ToString();
                    L.Size = new System.Drawing.Size(430, 18);
                    L.Font = new System.Drawing.Font("Arial", 12);
                    L.BackColor = Color.Transparent;
                    L.ForeColor = Color.Gray;
                    L.Dock = DockStyle.Fill;
                    L.TextAlign = ContentAlignment.MiddleLeft;

                    I2.BackgroundImage = Properties.Resources.error;
                    I2.BackgroundImageLayout = ImageLayout.Zoom;
                    I2.Size = new System.Drawing.Size(18, 18);
                    I2.Dock = DockStyle.Left;

                    P1.Size = new System.Drawing.Size(430, 67);
                    P1.BorderStyle = BorderStyle.FixedSingle;
                    P1.Dock = DockStyle.Top;
                    P1.BackColor = Color.White;

                    P2.Size = new System.Drawing.Size(287, 22);
                    P2.Dock = DockStyle.Top;
                    P2.BackColor = Color.White;

                    I1.Image = Properties.Resources.calendario;
                    I1.BackgroundImageLayout = ImageLayout.Zoom;
                    I1.Size = new System.Drawing.Size(90, 69);
                    I1.BackColor = Color.Transparent;
                    I1.Dock = DockStyle.Left;

                    P1.Controls.Add(B);
                    P1.Controls.Add(I1);
                    P1.Controls.Add(P2);
                    P2.Controls.Add(I2);
                    P2.Controls.Add(L);

                    P2.BringToFront();
                    B.SendToBack();
                    I1.SendToBack();
                    L.BringToFront();

                    PanelContenedorNotificaciones.Controls.Add(P1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
