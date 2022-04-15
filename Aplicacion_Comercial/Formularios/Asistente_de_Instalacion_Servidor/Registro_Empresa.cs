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
using System.IO;
using System.Text.RegularExpressions;
using System.Management;

namespace Aplicacion_Comercial.Formularios.Asistente_de_Instalacion_Servidor
{
    public partial class Registro_Empresa : Form
    {
        public Registro_Empresa()
        {
            InitializeComponent();
        }

        private string lblSerialPc;
        private void Registro_Empresa_Load(object sender, EventArgs e)
        {
            Logica.BasesPCProgram.obtener_serial_pc(ref lblSerialPc);
            panel2.Location = new Point((Width - panel2.Width) / 2, (Height - panel2.Width) / 2);

            //ManagementObject MOS = new ManagementObject(@"Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'");
            //ManagementObjectSearcher MOS = new ManagementObjectSearcher(@"Select * From Win32_BaseBoard");
            //ManagementObjectSearcher MOS = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            //foreach(ManagementObject getserial in MOS.Get())
            //{
            //    lblSerialPc.Text = getserial.Properties["SerialNumber"].Value.ToString();
            //    lblSerialPc.Text = lblSerialPc.Text.Trim();
            //}
            txtConLectora.Checked = true;
            txtTeclado.Checked = false;
            Swsn.Checked = false;
            //no.Checked = true;
            panel6.Visible = false;
            //panel12.Visible = false;

        }
        public bool validar_Mail(string sMail)
        {
            return Regex.IsMatch(sMail, @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$");

        }
        private void tstSiguiente_y_Guardar_Click_1(object sender, EventArgs e)
        {
            if (validar_Mail(txtCorreo.Text) == false)
            {
                MessageBox.Show("Dirección de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com, " + " por favor seleccione un correo valido", "Validación de correo electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCorreo.Focus();
                txtCorreo.SelectAll();
            }
            else
            {
                if (txtNombreEmpresa.Text != "")
                {
                    if (txtRuta.Text != "")
                    {
                        //no.Checked == true
                        if (Swsn.Checked == false)
                        {
                            lblTrabajasconImpuestos.Text = "NO";
                            txtPorcentaje.Text = "0";
                        }
                        //si.Checked == true
                        if (Swsn.Checked == true)
                        {
                            lblTrabajasconImpuestos.Text = "SI";
                        }

                        insertar_empresa();
                        ingresar_caja();
                        insertar_comprobantes_por_defecto();
                        Correo = txtCorreo.Text;
                        Dispose();
                        //Hide();
                        Formularios.Asistente_de_Instalacion_Servidor.Usuarios_Autorizados_al_Sistema frmUsuarioAtorizado = new Usuarios_Autorizados_al_Sistema();
                        frmUsuarioAtorizado.ShowDialog();
                        //this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("SELECCIONA UNA RUTA PARA GUARDAR LAS COPIAS DE SEGURIDAD", "REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                else
                {
                    MessageBox.Show("INGRESE UN NOMBRE DE EMPRESA", "REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void ingresar_caja()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Insertar_Caja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Descripcion", txtCaja.Text);
                cmd.Parameters.AddWithValue("@Tema", "REDENTOR");
                cmd.Parameters.AddWithValue("@Serial_PC", lblSerialPc);
                cmd.Parameters.AddWithValue("@Impresora_Ticket", "NINGUNO");
                cmd.Parameters.AddWithValue("@Impresora_A4", "NINGUNA");
                cmd.Parameters.AddWithValue("@Tipo", "PRINCIPAL");
                cmd.ExecuteNonQuery();
                con.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
            }
        }
        private void insertar_comprobantes_por_defecto()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Insertar_Serializacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Serie", "T");
                cmd.Parameters.AddWithValue("@Cantidad_de_Numeros", "6");
                cmd.Parameters.AddWithValue("@NumeroFin", "0");
                cmd.Parameters.AddWithValue("@Destino", "VENTAS");
                cmd.Parameters.AddWithValue("@Tipo_Documento", "TICKET");
                cmd.Parameters.AddWithValue("@Por_Defecto", "SI");
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = new SqlCommand("Insertar_Serializacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Serie", "B");
                cmd.Parameters.AddWithValue("@Cantidad_de_Numeros", 6);
                cmd.Parameters.AddWithValue("@NumeroFin", 0);
                cmd.Parameters.AddWithValue("@Destino", "VENTAS");
                cmd.Parameters.AddWithValue("@Tipo_Documento", "BOLETA");
                cmd.Parameters.AddWithValue("@Por_Defecto", "-");
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = new SqlCommand("Insertar_Serializacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Serie", "F");
                cmd.Parameters.AddWithValue("@Cantidad_de_Numeros", 6);
                cmd.Parameters.AddWithValue("@NumeroFin", 0);
                cmd.Parameters.AddWithValue("@Destino", "VENTAS");
                cmd.Parameters.AddWithValue("@Tipo_Documento", "FACTURA");
                cmd.Parameters.AddWithValue("@Por_Defecto", "-");
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = new SqlCommand("Insertar_Serializacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Serie", "I");
                cmd.Parameters.AddWithValue("@Cantidad_de_Numeros", 6);
                cmd.Parameters.AddWithValue("@NumeroFin", 0);
                cmd.Parameters.AddWithValue("@Destino", "INGRESO");
                cmd.Parameters.AddWithValue("@Tipo_Documento", "INGRESO DE COBROS");
                cmd.Parameters.AddWithValue("@Por_Defecto", "-");
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = new SqlCommand("Insertar_Serializacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Serie", "E");
                cmd.Parameters.AddWithValue("@Cantidad_de_Numeros", 6);
                cmd.Parameters.AddWithValue("@NumeroFin", 0);
                cmd.Parameters.AddWithValue("@Destino", "EGRESO");
                cmd.Parameters.AddWithValue("@Tipo_Documento", "EGRESOS DE PAGOS");
                cmd.Parameters.AddWithValue("@Por_Defecto", "-");
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = new SqlCommand("Insertar_Tiket", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Identificador_Fiscal", "NIT IDENTIFICADOR FICAL DE LA EMPRESA");
                cmd.Parameters.AddWithValue("@Direccion", "CALLE,NUMERO,AVENIDA");
                cmd.Parameters.AddWithValue("@Provincia_Departamento", "CIUDAD-DEPARTAMENTO-PAIS");
                cmd.Parameters.AddWithValue("@Nombre_de_Moneda", "NOMBRE DE MONEDA");
                cmd.Parameters.AddWithValue("@Agradecimiento", "AGRADECIMIENTOS");
                cmd.Parameters.AddWithValue("@Pagina_Web", "PAGINA WEB O RED SOCIAL");
                cmd.Parameters.AddWithValue("@Anuncio", "ANUNCIO");
                cmd.Parameters.AddWithValue("@Datos_Ficales_de_Autorizacion", "DATOS FISCALES-NUMERO DE AUTORIZACION,RESOLUCION");
                cmd.Parameters.AddWithValue("@Por_Defecto", "TICKET NO FISCAL");
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = new SqlCommand("Insertar_Correo_Base", con);
                cmd.CommandType = CommandType.StoredProcedure;
                string Correo;
                string Password;
                string EstadoEnvio;
                Correo = Logica.BasesPCProgram.Encriptar("-");
                Password = Logica.BasesPCProgram.Encriptar("-");
                EstadoEnvio = "SIN CONFIRMAR";
                cmd.Parameters.AddWithValue("@Correo", Correo);
                cmd.Parameters.AddWithValue("@Passwonrd", Password);
                cmd.Parameters.AddWithValue("@EstadoEnvio", EstadoEnvio);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void insertar_empresa()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Insertar_Empresa", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre_Empresa", txtNombreEmpresa.Text);
                cmd.Parameters.AddWithValue("@Impuesto", txtImpuesto.Text);
                cmd.Parameters.AddWithValue("@Porcentaje_Impuesto",  txtPorcentaje.Text );
                cmd.Parameters.AddWithValue("@Moneda", txtMoneda.Text);
                cmd.Parameters.AddWithValue("@Trabaja_con_Impuestos", lblTrabajasconImpuestos.Text);
                cmd.Parameters.AddWithValue("@Carpeta_para_Copias_de_Seguridad", txtRuta.Text);
                cmd.Parameters.AddWithValue("@Correo_para_Envio_de_Reporte", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@Ultima_Fecha_de_Copia_de_Seguridad", "NINGUNA");
                cmd.Parameters.AddWithValue("@Ultima_Fecha_de_Copia_Date", txtFecha.Value);
                cmd.Parameters.AddWithValue("@Fecuencia_de_Copias", 1);
                cmd.Parameters.AddWithValue("@Estado", "PENDIENTE");
                cmd.Parameters.AddWithValue("@Tipo_Empresa", "GENERAL");

                if (txtConLectora.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@Modo_de_Busqueda", "LECTORA");
                }

                if (txtTeclado.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@Modo_de_Busqueda", "TECLADO");
                }

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                Imagenempresa.Image.Save(ms, Imagenempresa.Image.RawFormat);

                cmd.Parameters.AddWithValue("@Logo", ms.GetBuffer());
                cmd.Parameters.AddWithValue("@Pais", txtPais.Text);
                cmd.Parameters.AddWithValue("@Redondeo_de_Total", "NO");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtConLectora_CheckedChanged_1(object sender, EventArgs e)
        {
            if (txtConLectora.Checked == true)
            {
                txtTeclado.Checked = false;
            }

            if (txtConLectora.Checked == false)
            {
                txtTeclado.Checked = true;
            }
        }
        private void txtTeclado_CheckedChanged_1(object sender, EventArgs e)
        {
            if (txtTeclado.Checked == true)
            {
                txtConLectora.Checked = false;
            }

            if (txtTeclado.Checked == false)
            {
                txtConLectora.Checked = true;
            }
        }
        private void txtPais_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txtMoneda.SelectedIndex = txtPais.SelectedIndex;
        }
        private void lblEditarlogo_Click_1(object sender, EventArgs e)
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de Imagenes";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Imagenempresa.BackgroundImage = null;
                Imagenempresa.Image = new Bitmap(dlg.FileName);
                Imagenempresa.SizeMode = PictureBoxSizeMode.Zoom;
                Imagenempresa.Text = Path.GetFileName(dlg.FileName);
                //Imagenempresa.Visible = false;
                //Imagenempresa.Visible = false;
            }
        }


        private void label8_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog()== DialogResult.OK)
            {
                //txtRuta.Text = folderBrowserDialog1.SelectedPath;
                string ruta = txtRuta.Text;
                if (ruta.Contains(@"C:\"))
                {
                    MessageBox.Show("SELECCIONA UN DISCO DIFERENTE AL DISCO C:", "RUTA INVALIDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtRuta.Text = "";
                }
                else
                {
                    txtRuta.Text = folderBrowserDialog1.SelectedPath;
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = folderBrowserDialog1.SelectedPath;
                string ruta = txtRuta.Text;
                //if (ruta.Contains(@"C:\"))
                //{
                //    MessageBox.Show("Selecciona un disco diferente al disco C:", "Ruta Invalida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    txtRuta.Text = "";
                //}
                //else
                //{
                //    txtRuta.Text = folderBrowserDialog1.SelectedPath;
                //}
            }
        }

        public static string Correo;
       

        private void si_CheckedChanged(object sender, EventArgs e)
        {
            panel6.Visible = true;
        }

        private void no_CheckedChanged(object sender, EventArgs e)
        {
            panel6.Visible = false;
        }

        private void txtImpuesto1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPorcentaje.SelectedIndex = txtImpuesto.SelectedIndex;
        }

        private void Swsn_CheckedChanged(object sender, EventArgs e)
        {
            activar();
        }

        private void activar()
        {
            if(Swsn.Checked == true)
            {
                panel6.Visible = true;
            }
            else
            {
                panel6.Visible = false;
            }
        }
    }
}
