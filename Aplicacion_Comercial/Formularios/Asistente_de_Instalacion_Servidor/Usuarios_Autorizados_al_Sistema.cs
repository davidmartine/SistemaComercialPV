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
using System.Management;

namespace Aplicacion_Comercial.Formularios.Asistente_de_Instalacion_Servidor
{
    public partial class Usuarios_Autorizados_al_Sistema : Form
    {
        public Usuarios_Autorizados_al_Sistema()
        {
            InitializeComponent();
        }

        private string lblSerial;

        private void Usuarios_Autorizados_al_Sistema_Load(object sender, EventArgs e)
        {
            panel10.Location = new Point((Width - panel10.Width) / 2, (Height - panel10.Height) / 2);
            //panel2.Location = new Point((Width - panel2.Width) / 2, (Height - panel2.Height) / 2);
            Logica.BasesPCProgram.obtener_serial_pc(ref lblSerial);

            //ManagementObject MOS = new ManagementObject(@"Win32_PhysicalMedia = '\\.\PHYSICALDRIVE0'");
            //ManagementObjectSearcher MOS = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            //foreach(ManagementObject getserial in MOS.Get())
            //{
            //    lblSerial.Text = getserial.Properties["SerialNumber"].Value.ToString();
            //    lblSerial.Text = lblSerial.Text.Trim();
            //}



        }
    
        private void insertar_licencia_de_prueba_de_30_dias()
        {
            DateTime today = DateTime.Now;
            DateTime FechaFinal = today.AddDays(30);
            lblFechaFinal.Text = Convert.ToString(FechaFinal);
            string SerialPC;
            SerialPC = lblSerial;
            string FechaFinal2;
            FechaFinal2 = Logica.BasesPCProgram.Encriptar(this.lblFechaFinal.Text.Trim());
            string Estado;
            Estado = Logica.BasesPCProgram.Encriptar("?ACTIVO?");
            string Fecha_Activacion;
            Fecha_Activacion = Logica.BasesPCProgram.Encriptar(this.txtFechaInicio.Text.Trim());

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Insertar_Marca", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@S", SerialPC);
                cmd.Parameters.AddWithValue("@F", FechaFinal2);
                cmd.Parameters.AddWithValue("@E", Estado);
                cmd.Parameters.AddWithValue("@FA", Fecha_Activacion);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void insertar_cliente_standar()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Insertar_Cliente", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", "GENERICO");
                cmd.Parameters.AddWithValue("@Direccion","0");
                cmd.Parameters.AddWithValue("@Identificador_Fiscal","0");
                cmd.Parameters.AddWithValue("@Movil", "0");
                cmd.Parameters.AddWithValue("@Estado", "0");
                cmd.Parameters.AddWithValue("@Saldo", 0);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void insertar_grupo_productos_por_defecto()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_grupo_de_productos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Linea", "GENERAL");
                cmd.Parameters.AddWithValue("@Por_defecto","SI");
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertar_inicio_de_sesion()
        {
            try 
            {
                string SerialPC;
                SerialPC = lblSerial;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Insertar_Inicio_de_Sesion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idSerial_PC",SerialPC);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (txtNombreCajero.Text != "" && txtPassword.Text != "" && txtConfiPassword.Text != "")
            {
                if (txtPassword.Text == txtConfiPassword.Text)
                {
                    string contrasena_encryptada;
                    contrasena_encryptada = Logica.BasesPCProgram.Encriptar(this.txtPassword.Text.Trim());
                    try
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = Conexiones.CADMaestra.conexion;
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand("insertar_usuario", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombres", txtNombreCajero.Text);
                        cmd.Parameters.AddWithValue("@Login", txtUsuario.Text);
                        cmd.Parameters.AddWithValue("@Password", contrasena_encryptada);
                        cmd.Parameters.AddWithValue("@Correo", Formularios.Asistente_de_Instalacion_Servidor.Registro_Empresa.Correo);
                        cmd.Parameters.AddWithValue("@Rol", "ADMINISTRADOR (Control Total)");

                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);

                        cmd.Parameters.AddWithValue("@Icono", ms.GetBuffer());
                        cmd.Parameters.AddWithValue("@Nombre_de_icono", "SYSGETCO");
                        cmd.Parameters.AddWithValue("@Estado", "ACTIVO");
                        cmd.ExecuteNonQuery();
                        con.Close();

                        insertar_licencia_de_prueba_de_30_dias();
                        insertar_cliente_standar();
                        insertar_grupo_productos_por_defecto();
                        insertar_inicio_de_sesion();
                        MessageBox.Show("Recuerda que para iniciar sesion tu USUARIO ES: "
                       + txtUsuario.Text + " y tu PASSWORD ES: " + txtPassword.Text, " REGISTRO EXITOSO", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        Dispose();
                        //Application.Restart();
                        Formularios.Logins.LOGIN frmLogin = new Logins.LOGIN();
                        frmLogin.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden", "CONFIRMAR CONTRASEÑA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            else
            {
                MessageBox.Show("Falta ingresar datos", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
    }
}
