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

namespace Aplicacion_Comercial.Formularios.Cajas_Remotas
{
    public partial class Caja_Secundaria : Form
    {
        public Caja_Secundaria()
        {
            InitializeComponent();
        }

        public static string lblConexion;
        private string lblSerialPC;
        private void Caja_Secundaria_Load(object sender, EventArgs e)
        {
            Logica.BasesPCProgram.obtener_serial_pc(ref lblSerialPC);
        }
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCaja.Text))
            {
                ingresar_caja();
            }
            else
            {
                MessageBox.Show("DATOS INCOMPLETOS");
            }
        }
        private void ingresar_caja()
        {
            try
            {
                SqlConnection con = new SqlConnection(lblConexion);
                //con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Insertar_Caja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Descripcion", txtCaja.Text);
                cmd.Parameters.AddWithValue("@Tema", "REDENTOR");
                cmd.Parameters.AddWithValue("@Serial_PC", lblSerialPC);
                cmd.Parameters.AddWithValue("@Impresora_Ticket", "NINGUNO");
                cmd.Parameters.AddWithValue("@Impresora_A4", "NINGUNA");
                cmd.Parameters.AddWithValue("@Tipo", "SECUNDARIA");
                cmd.ExecuteNonQuery();
                con.Close();
                insertar_inicios_sesion();
                MessageBox.Show("YA TIENES ESTA CAJA HABILITADA", "CAJA HABILITADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void insertar_inicios_sesion()
        {
            try
            {
                SqlConnection con = new SqlConnection(lblConexion);
                //con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Insertar_Inicio_de_Sesion",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idSerial_PC", lblSerialPC);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
