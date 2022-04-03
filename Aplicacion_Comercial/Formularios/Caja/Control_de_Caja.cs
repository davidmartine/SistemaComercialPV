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
using Telerik.Reporting.Charting;

namespace Aplicacion_Comercial.Formularios.Caja
{
    public partial class Control_de_Caja : Form
    {
        public Control_de_Caja()
        {
            InitializeComponent();
        }

        private void Control_de_Caja_Load(object sender, EventArgs e)
        {
            dibujar_caja_principal();
            dibujar_cajas_remotas();
        }

        private void dibujar_caja_principal()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Mostrar_Caja_Principal", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Panel P1 = new Panel();
                    Panel P2 = new Panel();
                    Panel P3 = new Panel();
                    PictureBox I1 = new PictureBox();
                    PictureBox I2 = new PictureBox();
                    Label L1 = new Label();
                    Label L2 = new Label();
                    //Label L3 = new Label();
                    Label lblUsuario = new Label();
                    Panel pBarraArriba = new Panel();
                    Panel pBarraCostado = new Panel();
                    MenuStrip MenuStrip = new MenuStrip();
                    ToolStripMenuItem ToolStripMenuItem = new ToolStripMenuItem();
                    ToolStripMenuItem ToolStripMenuItemEditar = new ToolStripMenuItem();

                    //LABEL NOMBRE DE LA CAJA
                    L1.Text = dr["Descripcion"].ToString();
                    L1.Name = dr["Id_Caja"].ToString();
                    L1.Size = new System.Drawing.Size(175, 25);
                    L1.Font = new System.Drawing.Font("Segoe UI", 20);
                    L1.AutoSize = false;
                    L1.BackColor = Color.Transparent;
                    L1.ForeColor = Color.White;
                    L1.Dock = DockStyle.Fill;
                    L1.TextAlign = ContentAlignment.MiddleCenter;
                    //
                    //LABEL NOMBRE DE USUARIO
                    lblUsuario.Text = "Por: " + dr["Nombres_y_Apellidos"].ToString();
                    lblUsuario.Dock = DockStyle.Bottom;
                    lblUsuario.AutoSize = false;
                    lblUsuario.TextAlign = ContentAlignment.MiddleCenter;
                    lblUsuario.BackColor = Color.Transparent;
                    lblUsuario.ForeColor = Color.White;
                    lblUsuario.Font = new System.Drawing.Font("Segoe UI", 10);
                    lblUsuario.Size = new System.Drawing.Size(430, 31);
                    //
                    //PANEL PRINCIPAL
                    P1.Size = new System.Drawing.Size(208, 143);
                    P1.BorderStyle = BorderStyle.None;
                    P1.Dock = DockStyle.Top;
                    P1.BackColor = Color.White;
                    //
                    // PANEL AUXILIAR O SECUNDARIO
                    P2.Size = new System.Drawing.Size(208, 24);
                    P2.Dock = DockStyle.Top;
                    P2.BackColor = Color.Transparent;
                    //
                    //LABEL DE ESTADO
                    L2.Text = dr["Estado"].ToString();
                    L2.Size = new System.Drawing.Size(430, 18);
                    L2.Font = new System.Drawing.Font("Segoe UI", 10);
                    L2.BackColor = Color.Transparent;
                    L2.AutoSize = false;
                    L2.ForeColor = Color.White;
                    L2.Dock = DockStyle.Fill;
                    L2.TextAlign = ContentAlignment.MiddleCenter;
                    //

                    MenuStrip.BackColor = Color.Transparent;
                    //MenuStrip.AutoSize = false;
                    MenuStrip.Size = new System.Drawing.Size(28, 24);
                    MenuStrip.Dock = DockStyle.Right;
                    MenuStrip.Name = dr["Id_Caja"].ToString();

                    ToolStripMenuItem.Image = Properties.Resources.menu;
                    ToolStripMenuItem.BackColor = Color.Transparent;
                    ToolStripMenuItemEditar.Text = "EDITAR";
                    ToolStripMenuItemEditar.Name = dr["Descripcion"].ToString();
                    ToolStripMenuItemEditar.Tag = dr["Id_Caja"].ToString();

                    MenuStrip.Items.Add(ToolStripMenuItem);
                    ToolStripMenuItem.DropDownItems.Add(ToolStripMenuItemEditar);

                    if(L2.Text == "RECIEN CREADA")
                    {
                        I1.BackgroundImage = Properties.Resources.PuntoBlanco;

                    }
                    else if(L2.Text =="CAJA RESTAURADA")
                    {
                        I1.BackgroundImage = Properties.Resources.PuntoBlanco;
                    }
                    else if(L2.Text =="CAJA APERTURADA")
                    {
                        I1.BackgroundImage = Properties.Resources.PuntoVerde;
                    }
                    else if(L2.Text == "CAJA CERRADA")
                    {
                        I1.BackgroundImage = Properties.Resources.PuntoRojo;
                    }
                    else if(L2.Text =="CAJA ELIMINADA")
                    {
                        I1.BackgroundImage = Properties.Resources.PuntoGris;
                        L2.ForeColor = Color.DimGray;
                    }
                    I1.BackgroundImageLayout = ImageLayout.Zoom;
                    I1.Size = new System.Drawing.Size(22, 24);
                    I1.Dock = DockStyle.Fill;
                    I1.BackColor = Color.Transparent;

                    P3.Size = new System.Drawing.Size(30, 24);
                    P3.Dock = DockStyle.Left;
                    P3.BackColor = Color.Transparent;

                    pBarraArriba.Size = new System.Drawing.Size(22, 5);
                    pBarraArriba.Dock = DockStyle.Top;
                    pBarraArriba.BackColor = Color.Transparent;

                    pBarraCostado.Size = new System.Drawing.Size(2, 22);
                    pBarraCostado.Dock = DockStyle.Left;
                    pBarraCostado.BackColor = Color.Transparent;

                    P3.Controls.Add(pBarraArriba);
                    P3.Controls.Add(pBarraCostado);
                    P3.Controls.Add(I1);
                    P2.Controls.Add(P3);
                    P2.Controls.Add(L2);
                    P2.Controls.Add(MenuStrip);
                    P1.Controls.Add(P2);
                    P1.Controls.Add(L1);
                    P1.Controls.Add(lblUsuario);
                    panel2.Controls.Add(P1);
                    lblUsuario.BringToFront();
                    I1.BringToFront();

                    ToolStripMenuItemEditar.Click += new EventHandler(mieventoToolStripMenuEditar);

                }
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int idCaja;
        private void mieventoToolStripMenuEditar(System.Object sender,EventArgs e)
        {
            idCaja =Convert.ToInt32(((ToolStripMenuItem)sender).Tag);
            txtCaja.Text = ((ToolStripMenuItem)sender).Name;
            panel12.Visible = true;
            panel12.Dock = DockStyle.Fill;
            panelEdicionCaja.Location = new Point((panel12.Width - panelEdicionCaja.Width) / 2, (panel12.Height - panelEdicionCaja.Height) / 2);
            txtCaja.SelectAll();
            txtCaja.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel12.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            editar_caja();
        }

        private void editar_caja()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Editar_Caja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Caja", idCaja);
                cmd.Parameters.AddWithValue("@Descripcion", txtCaja.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                panel12.Visible = false;
                panel12.Dock = DockStyle.None;
                dibujar_caja_principal();
                dibujar_cajas_remotas();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dibujar_cajas_remotas()
        {
            flowLayoutPanel1.Controls.Clear(); 
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Mostrar_Cajas_Remotas", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Panel P1 = new Panel();
                    Panel P2 = new Panel();
                    Panel P3 = new Panel();
                    PictureBox I1 = new PictureBox();
                    PictureBox I2 = new PictureBox();
                    Label L1 = new Label();
                    Label L2 = new Label();
                    //Label L3 = new Label();
                    Label lblUsuario = new Label();
                    Panel pBarraArriba = new Panel();
                    Panel pBarraCostado = new Panel();
                    MenuStrip MenuStrip = new MenuStrip();
                    ToolStripMenuItem ToolStripMenuItem = new ToolStripMenuItem();
                    ToolStripMenuItem ToolStripMenuItemEditar = new ToolStripMenuItem();
                    ToolStripMenuItem ToolStripMenuItemEliminar = new ToolStripMenuItem();
                    ToolStripMenuItem ToolStripMenuItemRestaurar = new ToolStripMenuItem();

                    //LABEL NOMBRE DE LA CAJA
                    L1.Text = dr["Descripcion"].ToString();
                    L1.Name = dr["Id_Caja"].ToString();
                    L1.Size = new System.Drawing.Size(175, 25);
                    L1.Font = new System.Drawing.Font("Segoe UI", 20);
                    L1.AutoSize = false;
                    L1.BackColor = Color.Transparent;
                    L1.ForeColor = Color.White;
                    L1.Dock = DockStyle.Fill;
                    L1.TextAlign = ContentAlignment.MiddleCenter;
                    //
                    //LABEL NOMBRE DE USUARIO
                    lblUsuario.Text = "Por: " + dr["Nombres_y_Apellidos"].ToString();
                    lblUsuario.Dock = DockStyle.Bottom;
                    lblUsuario.AutoSize = false;
                    lblUsuario.TextAlign = ContentAlignment.MiddleCenter;
                    lblUsuario.BackColor = Color.Transparent;
                    lblUsuario.ForeColor = Color.White;
                    lblUsuario.Font = new System.Drawing.Font("Segoe UI", 10);
                    lblUsuario.Size = new System.Drawing.Size(430, 31);
                    //
                    //PANEL PRINCIPAL
                    P1.Size = new System.Drawing.Size(208, 143);
                    P1.BorderStyle = BorderStyle.None;
                    P1.Dock = DockStyle.Top;
                    P1.BackColor = Color.Black;
                    //
                    // PANEL AUXILIAR O SECUNDARIO
                    P2.Size = new System.Drawing.Size(208, 24);
                    P2.Dock = DockStyle.Top;
                    P2.BackColor = Color.Transparent;
                    //
                    //LABEL DE ESTADO
                    L2.Text = dr["Estado"].ToString();
                    L2.Size = new System.Drawing.Size(430, 18);
                    L2.Font = new System.Drawing.Font("Segoe UI", 10);
                    L2.BackColor = Color.Transparent;
                    L2.AutoSize = false;
                    L2.ForeColor = Color.White;
                    L2.Dock = DockStyle.Fill;
                    L2.TextAlign = ContentAlignment.MiddleCenter;
                    //

                    MenuStrip.BackColor = Color.Transparent;
                    //MenuStrip.AutoSize = false;
                    MenuStrip.Size = new System.Drawing.Size(28, 24);
                    MenuStrip.Dock = DockStyle.Right;
                    MenuStrip.Name = dr["Id_Caja"].ToString();

                    ToolStripMenuItem.Image = Properties.Resources.menu;
                    ToolStripMenuItem.BackColor = Color.Transparent;
                    ToolStripMenuItemEditar.Text = "EDITAR";
                    ToolStripMenuItemEditar.Name = dr["Descripcion"].ToString();
                    ToolStripMenuItemEditar.Tag = dr["Id_Caja"].ToString();
                    ToolStripMenuItemEliminar.Text = "ELIMINAR";
                    ToolStripMenuItemEliminar.Tag = dr["Id_Caja"].ToString();
                    ToolStripMenuItemRestaurar.Text = "RESTAURAR";
                    ToolStripMenuItemRestaurar.Tag= dr["Id_Caja"].ToString();


                    MenuStrip.Items.Add(ToolStripMenuItem);
                    


                    if (L2.Text == "RECIEN CREADA")
                    {
                        I1.BackgroundImage = Properties.Resources.PuntoBlanco;

                    }
                    else if (L2.Text == "CAJA RESTAURADA")
                    {
                        I1.BackgroundImage = Properties.Resources.PuntoBlanco;
                    }
                    else if (L2.Text == "CAJA APERTURADA")
                    {
                        I1.BackgroundImage = Properties.Resources.PuntoVerde;
                    }
                    else if (L2.Text == "CAJA CERRADA")
                    {
                        I1.BackgroundImage = Properties.Resources.PuntoRojo;
                    }
                    else if (L2.Text == "CAJA ELIMINADA")
                    {
                        I1.BackgroundImage = Properties.Resources.PuntoGris;
                        L2.ForeColor = Color.DimGray;
                    }
                    if(L2.Text !="CAJA ELIMINADA")
                    {
                        ToolStripMenuItem.DropDownItems.Add(ToolStripMenuItemEditar);
                        ToolStripMenuItem.DropDownItems.Add(ToolStripMenuItemEliminar);
                       
                    }
                    else
                    {
                        ToolStripMenuItem.DropDownItems.Add(ToolStripMenuItemRestaurar);
                    }

                    I1.BackgroundImageLayout = ImageLayout.Zoom;
                    I1.Size = new System.Drawing.Size(22, 24);
                    I1.Dock = DockStyle.Fill;
                    I1.BackColor = Color.Transparent;

                    P3.Size = new System.Drawing.Size(30, 24);
                    P3.Dock = DockStyle.Left;
                    P3.BackColor = Color.Transparent;

                    pBarraArriba.Size = new System.Drawing.Size(22, 5);
                    pBarraArriba.Dock = DockStyle.Top;
                    pBarraArriba.BackColor = Color.Transparent;

                    pBarraCostado.Size = new System.Drawing.Size(2, 22);
                    pBarraCostado.Dock = DockStyle.Left;
                    pBarraCostado.BackColor = Color.Transparent;

                    P3.Controls.Add(pBarraArriba);
                    P3.Controls.Add(pBarraCostado);
                    P3.Controls.Add(I1);
                    P2.Controls.Add(P3);
                    P2.Controls.Add(L2);
                    P2.Controls.Add(MenuStrip);
                    P1.Controls.Add(P2);
                    P1.Controls.Add(L1);
                    P1.Controls.Add(lblUsuario);
                    flowLayoutPanel1.Controls.Add(P1);
                    lblUsuario.BringToFront();
                    I1.BringToFront();

                    ToolStripMenuItemEditar.Click += new EventHandler(mieventoToolStripMenuEditar);
                    ToolStripMenuItemEliminar.Click += new EventHandler(mieventoToolStripMenuEliminar);
                    ToolStripMenuItemRestaurar.Click += new EventHandler(mieventoToolStripMenuRestaurar);

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mieventoToolStripMenuEliminar(System.Object sender,EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("¿Desea eliminar esta caja?", "ELIMINADO REGISTRO DE CAJA", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result == DialogResult.OK)
            {
                idCaja = Convert.ToInt32(((ToolStripMenuItem)sender).Tag);
                eliminar_caja();
                dibujar_cajas_remotas();
            }
        }

        private void eliminar_caja()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Eliminar_Caja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Caja", idCaja);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mieventoToolStripMenuRestaurar(System.Object sender,EventArgs e)
        {

            idCaja = Convert.ToInt32(((ToolStripMenuItem)sender).Tag);
            restaurar_cajas();
        }

        private void restaurar_cajas()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Restaurar_Caja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Caja", idCaja);
                cmd.ExecuteNonQuery();
                con.Close();
                dibujar_cajas_remotas();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
