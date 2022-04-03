using Aplicacion_Comercial.Conexiones;
using Aplicacion_Comercial.Datos;
using Aplicacion_Comercial.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Aplicacion_Comercial.Formularios.Licencias_y_Membresias
{
    public partial class Licencias_Membresias : Form
    {
        public Licencias_Membresias()
        {
            InitializeComponent();
        }

        private string SerialPC;
        private string Ruta;
        private string dbcstring;
        private string LicenciaDesencryptada;
        private AES aes = new AES();
        private string SerialPCLicencia;
        private string FechaFinLicencia;
        private string EstadoLicencia;
        private string NombreSoftwareLicencia;


        private void Licencias_Membresias_Load(object sender, EventArgs e)
        {
            Obtener_serialpc();
        }

        private void Obtener_serialpc()
        {
            Logica.BasesPCProgram.obtener_serial_pc(ref SerialPC);
            txtSerialPC.Text = SerialPC;

        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
           

        }
        private void btnActivarManualmente_Click(object sender, EventArgs e)
        {
            
        }

        private void Activar_licencia_manual()
        {
            Logica.BasesPCProgram.obtener_serial_pc(ref SerialPC);
            string FechaFin = Logica.BasesPCProgram.Encriptar(FechaFinLicencia);
            string Estado = Logica.BasesPCProgram.Encriptar("¿ACTIVADO PRO?");
            string FechaActivacion = Logica.BasesPCProgram.Encriptar(DateTime.Now.ToString());
            LMarca marca_parametros = new LMarca();
            CADEditarDatos funcion = new CADEditarDatos();
            marca_parametros.S = txtSerialPC.Text;
            marca_parametros.F = FechaFin;
            marca_parametros.E = Estado;
            marca_parametros.FA = FechaActivacion;
            MessageBox.Show(txtSerialPC.Text);
            if (funcion.Editar_marca(marca_parametros) == true)
            {
                MessageBox.Show("LICENCIA ACTIVADA,SE CERRARA EL SISTEMA PARA INICIAR NUEVAMENTEX");
                Application.Exit();
            }
                
        }

        private void Desifrar_licencia()
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(Ruta);
                XmlElement element = document.DocumentElement;
                dbcstring = element.Attributes.Item(0).Value;
                LicenciaDesencryptada = (aes.Decrypt(dbcstring, Desencryptacion.appPwdUnique,int.Parse("256")));

            }
            catch (CryptographicException ex)
            {

                
            }
        }

        private void btnCopiar_Click_1(object sender, EventArgs e)
        {
            Clipboard.SetText(txtSerialPC.Text);
        }

        private void btnComprar_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://www.google.com");
        }

        private void btnActivarManualmente_Click_1(object sender, EventArgs e)
        {
            odg.Filter = "LICENCIAS SYSGETCO|*.xml";
            odg.Title = "CARGADOR DE LICENCIAS SYSGETCO";
            if (odg.ShowDialog() == DialogResult.OK)
            {
                Ruta = Path.GetFullPath(odg.FileName);
                Desifrar_licencia();
                string Cadena = LicenciaDesencryptada;
                string[] seperadas = Cadena.Split('|');
                SerialPCLicencia = seperadas[1];
                FechaFinLicencia = seperadas[2];
                EstadoLicencia = seperadas[3];
                NombreSoftwareLicencia = seperadas[4];
                if (NombreSoftwareLicencia == "SYSGETCO")
                {
                    if (EstadoLicencia == "PENDIENTE")
                    {
                        if (SerialPCLicencia == SerialPC)
                        {
                            Activar_licencia_manual();
                        }
                    }
                }

            }
        }
    }
}
