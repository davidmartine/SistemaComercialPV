using Aplicacion_Comercial.Conexiones;
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
using System.Xml;

namespace Aplicacion_Comercial.Formularios.Cajas_Remotas
{
    public partial class Conexion_Secundaria : Form
    {
        public Conexion_Secundaria()
        {
            InitializeComponent();
        }

        string cadena_conexion;
        int Id;
        string IndicadorConexion;
        private AES AES = new AES();
        int Id_caja = 0;
        string lblSerialPC;

        private void Conexion_Secundaria_Load(object sender, EventArgs e)
        {

        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtObtenerIp.Text))
            {
                conectar_manualmente();
            }
            else
            {
                MessageBox.Show("INGRESA LA DIRECCION IP", "CONECTAR IP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void comprobar_conexion()
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadena_conexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT idUsuario FROM USUARIO2", connection);
                Id = Convert.ToInt32(cmd.ExecuteScalar());
                IndicadorConexion = "HAY CONEXION";



            }
            catch (Exception)
            {
                IndicadorConexion = "NO HAY CONEXION";
            }
        }
        private void conectar_manualmente()
        {

            string Ip = txtObtenerIp.Text;
            cadena_conexion = "Data Source =" + Ip + ";Initial Catalog=PuntoVenta;Integrated Security=false;User Id=sysgetco;Password=puntoventa";
            comprobar_conexion();
            if (IndicadorConexion == "HAY CONEXION")
            {
                SavetoXML(AES.Encrypt(cadena_conexion, Desencryptacion.appPwdUnique, int.Parse("256")));
                obtener_idcaja();
                if (Id_caja > 0)
                {
                    MessageBox.Show("CONEXION CORRECTA.VUELVE ABRIR EL SISTEMA", "CONEXION EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                {
                    Formularios.Cajas_Remotas.Caja_Secundaria.lblConexion = cadena_conexion;
                    this.Dispose();
                    Formularios.Cajas_Remotas.Caja_Secundaria frmsecundaria = new Caja_Secundaria();
                    frmsecundaria.ShowDialog();
                }

            }


        }

        private void obtener_idcaja()
        {
            try
            {
                Logica.BasesPCProgram.obtener_serial_pc(ref lblSerialPC);
                SqlConnection connection_express = new SqlConnection(cadena_conexion);
                connection_express.Open();
                SqlCommand cmd = new SqlCommand("mostrar_cajas_por_Serial_de_DiscoDuro", connection_express);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Serial", lblSerialPC);
                Id_caja = Convert.ToInt32(cmd.ExecuteScalar());
                connection_express.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public void SavetoXML(object dbcnString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ConnectionString.xml");
            XmlElement root = doc.DocumentElement;
            root.Attributes[0].Value = Convert.ToString(dbcnString);
            XmlTextWriter writer = new XmlTextWriter("ConnectionString.xml", null);
            writer.Formatting = Formatting.Indented;
            doc.Save(writer);
            writer.Close();
        }
    }
}
