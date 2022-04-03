using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;

namespace Aplicacion_Comercial.Formularios.Administracion_de_Panel_Software
{
    public partial class Panel_Software : Form
    {

        private Conexiones.AES aes = new Conexiones.AES();

        public Panel_Software()
        {
            InitializeComponent();
        }

        private void Panel_Software_Load(object sender, EventArgs e)
        {

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
        string dbcnString;
        public void ReadfromXML()
        {

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("ConnectionString.xml");
                XmlElement root = doc.DocumentElement;
                dbcnString = root.Attributes[0].Value;
                txtCnString.Text = (aes.Decrypt(dbcnString, Conexiones.Desencryptacion.appPwdUnique, int.Parse("256")));

            }
            catch (System.Security.Cryptography.CryptographicException ex)
            {


            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SavetoXML(aes.Encrypt(txtCnString.Text, Conexiones.Desencryptacion.appPwdUnique, int.Parse("256")));
            mostrar();
        }
        private void mostrar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                da = new SqlDataAdapter("mostrar_usuario", con);
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();
                MessageBox.Show("Coneccion realizada correctamente", "Conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception)
            {
                MessageBox.Show("Sin conexion a la Base de datos", "Conexion fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

            Logica.BasesPCProgram.Multilinea(ref datalistado);

        }

        private void CONEXION_MANUAL_Load(object sender, EventArgs e)
        {
            ReadfromXML();
        }

       
    }
}
