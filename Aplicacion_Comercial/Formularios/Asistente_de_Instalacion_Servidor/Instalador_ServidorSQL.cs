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
using System.IO;
using System.Diagnostics;

namespace Aplicacion_Comercial.Formularios.Asistente_de_Instalacion_Servidor
{
    public partial class Instalador_ServidorSQL : Form
    {
        public Instalador_ServidorSQL()
        {
            InitializeComponent();
        }

        string nombre_del_equipo;
        string ruta;
        private Conexiones.AES aes = new Conexiones.AES();
        public static int milisegundo;
        public static int segundo;
        public static int milisegundo1;
        public static int segundo1;
        public static int minutos1;

        private void Instalador_ServidorSQL_Load(object sender, EventArgs e)
        {
            centrar_panales();
            reemplazar();
            comprobar_si_ya_hay_servidor_instalado_sql_espress();
            conectar();

        }

        private void conectar()
        {
            if(btnInstalarServidor.Visible == true)
            {
                comprobar_si_hay_servidor_instalado_sql_normal();
            }
        }

        private void comprobar_si_hay_servidor_instalado_sql_normal()
        {
            lblservidor.Text = ".";
            ejecutar_script_eliminarbase_comprobacion_de_inicio();
            ejecutar_script_crearbase_comprobacion_de_inicio();
        }

        private void centrar_panales()
        {
            nombre_del_equipo = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            Panel2.Location = new Point((Width - Panel2.Width) / 2, (Height - Panel2.Height) / 2);
            Cursor = Cursors.WaitCursor;
            panel8.Visible = false;
            panel8.Dock = DockStyle.None;
        }
        private void reemplazar()
        {
            
            txtCrear_procedimientos.Text = txtCrear_procedimientos.Text.Replace("PuntoVenta", txtbasededatos.Text);
            txtEliminarBase.Text = txtEliminarBase.Text.Replace("PuntoVenta", txtbasededatos.Text);
            txtCrearUsuarioDb.Text = txtCrearUsuarioDb.Text.Replace("sysgetco", txtusuario.Text);
            txtCrearUsuarioDb.Text = txtCrearUsuarioDb.Text.Replace("PuntoVenta", txtbasededatos.Text);
            txtCrearUsuarioDb.Text = txtCrearUsuarioDb.Text.Replace("SoftwareVentas", txtcontraseña.Text);
            //Adjuntando al texbox que contiene los procedimientos almacenados
            txtCrear_procedimientos.Text = txtCrear_procedimientos.Text + Environment.NewLine + txtCrearUsuarioDb.Text;
        }

        private void comprobar_si_ya_hay_servidor_instalado_sql_espress()
        {
            lblservidor.Text = @".\" + txtnombredeservicio.Text;
            ejecutar_script_eliminarbase_comprobacion_de_inicio();
            ejecutar_script_crearbase_comprobacion_de_inicio();


        }

        private void ejecutar_script_crearbase_comprobacion_de_inicio()
        {
            var con = new SqlConnection("Server=" + lblservidor.Text + "; " + "database=master;integrated security=yes");
            string s = "CREATE DATABASE " + txtbasededatos.Text;
            var cmd = new SqlCommand(s, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                SavetoXML(aes.Encrypt("Data Source=" + lblservidor.Text + ";Initial Catalog=" + txtbasededatos.Text + "Integrated Security=True", Conexiones.Desencryptacion.appPwdUnique, int.Parse("256")));
                ejecutar_script_crear_procedimientos_almacenados_y_tablas();
                panel8.Visible = true;
                panel8.Dock = DockStyle.Fill;
                label17.Text = @"INSTANCIA ENCONTRADA NO CIERRE ESTA VENTANA SE CERRARA AUTOMATICAMENTE CUANDO TODO ESTE LISTO";
                panel12.Visible = false;
                timer4.Start();


            }
            catch (Exception)
            {
                this.Cursor = Cursors.Default;
                panel12.Visible = true;
                btnInstalarServidor.Visible = true;
                panel8.Visible = false;
                panel8.Dock = DockStyle.None;
                lblbuscador_de_servidores.Text = "DE CLICK EN INSTALAR SERVIDOR,LUEGO EN SI CUANDO LE PIDA,LUEGO PRECIONE ACEPTAR Y ESPERA POR FAVOR ";

            }
            finally
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void ejecutar_script_crearbase()
        {
            var con = new SqlConnection("Server=" + lblservidor.Text + "; " + "database=master; integrated security=yes");
            string s = "CREATE DATABASE " + txtbasededatos.Text;
            var cmd = new SqlCommand(s, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                SavetoXML(aes.Encrypt("Data Source=" + lblservidor.Text + ";Initial Catalog=" + txtbasededatos.Text + "Integrated Security=True", Conexiones.Desencryptacion.appPwdUnique, int.Parse("256")));
                ejecutar_script_crear_procedimientos_almacenados_y_tablas();
                timer4.Start();
            }
            catch(Exception)
            {

            }
            finally
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void ejecutar_script_eliminarbase()
        {
            string str;
            SqlConnection connection = new SqlConnection("Data Source=" + lblservidor.Text + ";Initial Catalog=master;Integrated Security=True");
            str = txtEliminarBase.Text;
            SqlCommand cmd = new SqlCommand(str, connection);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                if(connection.State== ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void ejecutar_script_crear_procedimientos_almacenados_y_tablas() 
        {
            ruta = Path.Combine(Directory.GetCurrentDirectory(), txtnombre_scrypt.Text + ".txt");
            FileInfo info = new FileInfo(ruta);
            StreamWriter writer;
            try
            {
                if(File.Exists(ruta) == false)
                {
                    
                    writer = File.CreateText(ruta);
                    writer.WriteLine(txtCrear_procedimientos.Text);
                    writer.Flush();
                    writer.Close();
                }
                else if (File.Exists(ruta) == true)
                {
                    File.Delete(ruta);
                    writer = File.CreateText(ruta);
                    writer.WriteLine(txtCrear_procedimientos.Text);
                    writer.Flush();
                    writer.Close();

                }
            }
            catch(Exception)
            {

            }
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "sqlcmd";
                process.StartInfo.Arguments = " -S " + lblservidor.Text + " -E -i" + txtnombre_scrypt.Text + ".txt";
                process.Start();
            }
            catch (Exception)
            {

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

        private void ejecutar_script_eliminarbase_comprobacion_de_inicio()
        {
            string str;
            SqlConnection connection = new SqlConnection(@"Data Source=" + lblservidor.Text + ";Initial Catalog=master;Integrated Security=True");
            str = txtEliminarBase.Text;
            SqlCommand cmd = new SqlCommand(str, connection);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                if((connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            timer3.Stop();
            milisegundo += 1;
            mil3.Text = Convert.ToString(milisegundo);
            if (milisegundo == 60) 
            {
                segundo += 1;
                seg3.Text = Convert.ToString(segundo);
                milisegundo = 0;
            }
            if(segundo == 15)
            {
                timer4.Stop();
                try
                {
                    File.Delete(ruta);
                }
                catch(Exception)
                {

                }
                this.Dispose();
                Application.Restart();
            }
            
        }

        private void btnInstalarServidor_Click(object sender, EventArgs e)
        {
            try
            {
                txtArgumentosini.Text = txtArgumentosini.Text.Replace("PRUEBAFINAL22",txtnombredeservicio.Text);
                TimerCRARINI.Start();
                executa();
                timer2.Start();
                panel8.Visible = true;
                panel8.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void executa()
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "SQLEXPR_x86_ESN.exe";
                process.StartInfo.Arguments = "/ConfigurationFile=ConfigurationFile.ini /ACTION=Install /IACCEPTSQLSERVERLICENSETERMS /SECURITYMODE=SQL /SAPWD=" + txtcontraseña.Text + " /SQLSYSADMINACCOUNTS=" + nombre_del_equipo;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.Start();
                panel8.Visible = true;
                panel8.Dock = DockStyle.Fill;

            }
            catch (Exception)
            {

            }
        }

        private void TimerCRARINI_Tick(object sender, EventArgs e)
        {
            string RutaPreparar;
            StreamWriter sw;
            RutaPreparar = Path.Combine(Directory.GetCurrentDirectory(), "ConfigurationFile.ini");
            RutaPreparar = RutaPreparar.Replace("ConfigurationFile.ini", @"SQLEXPR_x86_ESN\ConfigurationFile.ini");
            if (File.Exists(RutaPreparar) == true)
            {
                TimerCRARINI.Stop();
            }
            try
            {
                sw = File.CreateText(RutaPreparar);
                sw.WriteLine(txtArgumentosini.Text);
                sw.Flush();
                sw.Close();
                TimerCRARINI.Stop();
            }
            catch (Exception)
            {

            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            milisegundo1 += 1;
            milise.Text = Convert.ToString(milisegundo1);
            if(milisegundo1 == 60)
            {
                segundo1 += 1;
                seg.Text = Convert.ToString(segundo1);
                milisegundo1 = 0;
            }
            if(segundo1 == 60)
            {
                minutos1 += 1;
                min.Text = Convert.ToString(minutos1);
                segundo1 = 0;
            }
            if (minutos1 == 1)
            {
                ejecutar_script_eliminarbase();
                ejecutar_script_crearbase();

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            milisegundo1 += 1;
            milise.Text = Convert.ToString(milisegundo1);
            if(milisegundo1 == 60)
            {
                segundo1 += 1;
                seg.Text = Convert.ToString(segundo1);
                milisegundo1 = 0;

            }
            if(segundo1 == 60)
            {
                minutos1 += 1;
                min.Text = Convert.ToString(minutos1);
                segundo1 = 0;
                  
            }
            if(minutos1 == 6)
            {
                timer2.Enabled = false;
                ejecutar_script_eliminarbase();
                ejecutar_script_crearbase();
                timer3.Start();
            }
        }
    }
}
