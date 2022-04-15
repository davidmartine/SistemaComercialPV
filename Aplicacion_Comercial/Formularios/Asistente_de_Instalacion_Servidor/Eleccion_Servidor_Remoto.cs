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

namespace Aplicacion_Comercial.Formularios.Asistente_de_Instalacion_Servidor
{
    public partial class Eleccion_Servidor_Remoto : Form
    {
        private string lblEstado_de_conexion;

        public Eleccion_Servidor_Remoto()
        {
            InitializeComponent();
        }
        private void Eleccion_Servidor_Remoto_Load(object sender, EventArgs e)
        {
            panel2.Location = new Point((Width - panel2.Width) / 2, (Height - panel2.Height) / 2);
            Listar();
            if (lblEstado_de_conexion == "CONECTADO")
            {
                Hide();
                Formularios.Asistente_de_Instalacion_Servidor.Registro_Empresa frmRegistroEmpresa = new Registro_Empresa();
                frmRegistroEmpresa.ShowDialog();
                Dispose();

            }

        }
        private void Listar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                da = new SqlDataAdapter("SELECT * FROM USUARIO2", con);
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();
                lblEstado_de_conexion = "CONECTADO";
            }
            catch (Exception)
            {
                lblEstado_de_conexion = "-";
                // MessageBox.Show(ex.Message);
            }
        }

        private void btnPrincipal_Click(object sender, EventArgs e)
        {
            Dispose();
            Formularios.Asistente_de_Instalacion_Servidor.Instalador_ServidorSQL frmInstaladorServidorSQL = new Instalador_ServidorSQL();
            frmInstaladorServidorSQL.ShowDialog();
        }

        private void btnSecundario_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Cajas_Remotas.Conexion_Secundaria frmsecundaria = new Cajas_Remotas.Conexion_Secundaria();
            frmsecundaria.ShowDialog();
        }
    }
}
