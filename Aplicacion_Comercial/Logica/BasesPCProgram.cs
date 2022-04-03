using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;
using System.Globalization;
using System.Threading;

namespace Aplicacion_Comercial.Logica
{
    class BasesPCProgram
    {

        //VARIABLES
        //public static string ValorIP;
        public static string appPwdUnique = Conexiones.Desencryptacion.appPwdUnique;


        //OBTNER EL SERIAL DE LA COMPUTADORA
        public static void obtener_serial_pc(ref string SerialPC)
        {
            //ManagementObject SeriaPC = new ManagementObject("Win32_PhysicalMedia='\\\\.\\PHYSICALDRIVE0'");
            //Serial = SeriaPC.Properties["SerialNumber"].Value.ToString();
            //Serial = Serial.Trim();

            ManagementObjectSearcher MOS = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            foreach (ManagementObject getserial in MOS.Get())
            {
                SerialPC = getserial.Properties["SerialNumber"].Value.ToString();
                SerialPC =Encriptar(SerialPC.Trim());
            }


        }

        //CAMBIAR EL IDIOMA REGIONAL 
        public static void cambiar_idioma_regional()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CO");
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ",";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ",";
        }

        //PONER LOS DATAGRIDVIEW EN EL TAMAÑO QUE NOSOTRO QUERAMOS
        public static void Multilinea(ref DataGridView List)
        {
            List.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //List.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
            List.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            List.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            List.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            List.EnableHeadersVisualStyles = false;
            List.BackgroundColor = Color.White;
            List.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            List.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
            List.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            List.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;
            DataGridViewCellStyle styCabeceras = new DataGridViewCellStyle();
            styCabeceras.BackColor = System.Drawing.Color.White;
            styCabeceras.ForeColor = System.Drawing.Color.Black;
            styCabeceras.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            List.ColumnHeadersDefaultCellStyle = styCabeceras;
        }

        public static void MultilineaTemaOscuro(ref DataGridView List)
        {
            List.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //List.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
            List.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            List.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            List.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            List.BackgroundColor = Color.FromArgb(51, 51, 51);
            List.RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(51, 51, 51);
            List.RowTemplate.DefaultCellStyle.ForeColor = Color.White;
            List.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 93, 90);
            List.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            List.EnableHeadersVisualStyles = false;

            DataGridViewCellStyle styCabeceras = new DataGridViewCellStyle();
            styCabeceras.BackColor = System.Drawing.Color.FromArgb(51,51,51);
            styCabeceras.ForeColor = System.Drawing.Color.White;
            styCabeceras.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            List.ColumnHeadersDefaultCellStyle = styCabeceras;
        }
        public static void MultilineaCobros(ref DataGridView List)
        {
            List.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //List.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
            List.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            List.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            List.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            List.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle styCabeceras = new DataGridViewCellStyle();
            styCabeceras.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            styCabeceras.ForeColor = System.Drawing.Color.White;
            styCabeceras.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            List.ColumnHeadersDefaultCellStyle = styCabeceras;
        }

        public static string Encriptar(string texto)
        {
            try
            {
                //string key = "sysgetco2020A4sfc45rtrdfhgbddsgfhfghytgfsdvadc"
                //string key = "SYSGETCO.COMERC.PuntoVenta.A4sfc45rtrdfhgbddsgfhfghytgfsdvadc";

                byte[] keyArray;

                byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(texto);

                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(appPwdUnique));

                hashmd5.Clear();

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();

                byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);

                tdes.Clear();

                texto = Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);

            }
            catch
            {

            }
            return texto;
        }

        public static string Desencriptar(string textoEncriptado)
        {
            try
            {
               // string key = "sysgetco2021A4sfc45rtrdfhgbddsgfhfghytgfsdvadc";
                byte[] keyArray;
                byte[] Array_a_Descifrar = Convert.FromBase64String(textoEncriptado);

                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(appPwdUnique));

                hashmd5.Clear();

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();

                byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);

                tdes.Clear();
                textoEncriptado = UTF8Encoding.UTF8.GetString(resultArray);

            }
            catch (Exception)
            {

            }
            return textoEncriptado;
        }

        public static bool  enviarCorreo(string emisor, string password, string mensaje, string asunto, string destinatario, string ruta)
        {
            try
            {
                MailMessage correos = new MailMessage();
                SmtpClient envios = new SmtpClient();
                correos.To.Clear();
                correos.Body = "";
                correos.Subject = "";
                correos.Body = mensaje;
                correos.Subject = asunto;
                correos.IsBodyHtml = true;
                correos.To.Add((destinatario));
                correos.From = new MailAddress(emisor);
                envios.Credentials = new NetworkCredential(emisor, password);

                envios.Host = "smtp.gmail.com";
                envios.Port = 587;
                envios.EnableSsl = true;
                envios.Send(correos);
                return true;
            }
            catch (Exception ex)
            {
            
                MessageBox.Show("ERROR, revisa tu correo Electronico", "Restauracion de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }


        }

        public static object separador_de_numeros(TextBox CajaTexto,KeyPressEventArgs e)
        {
            if ((e.KeyChar != '.') || (e.KeyChar != ','))
            {

                string CultureName = Thread.CurrentThread.CurrentCulture.Name;
                CultureInfo ci = new CultureInfo(CultureName);

                ci.NumberFormat.NumberDecimalSeparator = ".";
                Thread.CurrentThread.CurrentCulture = ci;

            }
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (!(e.KeyChar == CajaTexto.Text.IndexOf('.')))
            {
                e.Handled = true;
            }


            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == ',')
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;

            }
            return null;
        }

        public static string ObtenerIP(ref string ValorIP)
        {
            ValorIP = Dns.GetHostEntry(Environment.MachineName).AddressList.FirstOrDefault((i) => i.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();
            return ValorIP;
        }
    }
}
