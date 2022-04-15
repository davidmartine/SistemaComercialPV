using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.IO;

namespace Aplicacion_Comercial.Formularios.Configuracion_Empresa
{
    public partial class Empresa_Confi : Form
    {
        private string ValidarImpuestos;
        private string ModoBusqueda;
        public Empresa_Confi()
        {
            InitializeComponent();
        }

        private void Empresa_Confi_Load(object sender, EventArgs e)
        {
            panel2.Location = new Point((Width - panel2.Width) / 2, (Height - panel2.Height) / 2);
            mostrar();
            obtener_datos();
        }
        private void obtener_datos()
        {
            try
            {
                txtNombreEmpresa.Text = datalistado.SelectedCells[2].Value.ToString();
                Imagenempresa.BackgroundImage = null;
                byte[] b = (Byte[])datalistado.SelectedCells[1].Value;
                MemoryStream ms = new MemoryStream(b);
                Imagenempresa.Image = Image.FromStream(ms);
                txtPais.Text = datalistado.SelectedCells[13].Value.ToString();
                txtMoneda.Text = datalistado.SelectedCells[4].Value.ToString();
                ValidarImpuestos = datalistado.SelectedCells[9].Value.ToString();
                if (ValidarImpuestos == "SI")
                {
                    //si.Checked = true;
                    panelImpuesto.Visible = true;
                }
                if (ValidarImpuestos == "NO")
                {
                    //no.Checked = true;
                    panelImpuesto.Visible = false;
                }
                txtPorcentaje.Text = datalistado.SelectedCells[6].Value.ToString();
                txtImpuesto.Text = datalistado.SelectedCells[7].Value.ToString();
                ModoBusqueda = datalistado.SelectedCells[8].Value.ToString();
                if (ModoBusqueda == "LECTORA")
                {
                    txtConLectora.Checked = true;
                    txtTeclado.Checked = false;
                }
                if (ModoBusqueda == "TECLADO")
                {
                    txtTeclado.Checked = true;
                    txtConLectora.Checked = false;
                }
                txtRuta.Text = datalistado.SelectedCells[11].Value.ToString();
                txtCorreo.Text = datalistado.SelectedCells[10].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                da = new SqlDataAdapter("Mostrar_Empresa", con);
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool validar_email(string email)
        {
            //return Regex.IsMatch(email, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            //    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
            //    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            return Regex.IsMatch(email,@"[a-zA-Z0-9]\d{2}[a-zA-Z0-9](-\d{3}){2}[A-Za-z0-9]$");
        }
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (validar_email(txtCorreo.Text))
            {
                MessageBox.Show("DIRECCION DE CORREO NO VALIDA,EL CORREO DEBE DE TENER EL FORMATO: nombre@DOMINIO.COM," + "POR FAVOR SELECCIONE UN CORREO VALIDO", "VALIDAR CORREO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCorreo.Focus();
                txtCorreo.SelectAll();
            }
            else
            {
                if (!string.IsNullOrEmpty(txtNombreEmpresa.Text))
                {
                    try
                    {
                        if (Swsn.Checked == false)
                        {
                            ValidarImpuestos = "NO";
                        }
                        else
                        {
                            ValidarImpuestos = "SI";
                        }
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = Conexiones.CADMaestra.conexion;
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand("Editar_Empresa", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre_Empresa", txtNombreEmpresa.Text);
                        cmd.Parameters.AddWithValue("@Impuesto", txtImpuesto.Text);
                        cmd.Parameters.AddWithValue("@Porcentaje_Impuesto", txtPorcentaje.Text);
                        cmd.Parameters.AddWithValue("@Moneda", txtMoneda.Text);
                        cmd.Parameters.AddWithValue("@Trabajas_con_Impuestos", ValidarImpuestos);

                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        Imagenempresa.Image.Save(ms, Imagenempresa.Image.RawFormat);
                        cmd.Parameters.AddWithValue("@Logo", ms.GetBuffer());

                        if (txtConLectora.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@Modo_de_Busqueda", "LECTORA");
                        }
                        if (txtTeclado.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@Modo_de_Busqueda", "TECLADO");
                        }
                        cmd.Parameters.AddWithValue("@Carpeta_para_Copias_de_Seguridad", txtRuta.Text);
                        cmd.Parameters.AddWithValue("@Correo_para_Envio_de_Reportes", txtCorreo.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Cambios actualizados correctamente", "ACTUALIZADO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Dispose();
                        Formularios.Configuracion.Panel_Configuraciones frmPanelConfiguracion = new Configuracion.Panel_Configuraciones();
                        frmPanelConfiguracion.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void Swsn_CheckedChanged(object sender, EventArgs e)
        {
            if (Swsn.Checked == false)
            {
                panelImpuesto.Visible = false;

            }
            else
            {
                panelImpuesto.Visible = true;
            }
        }
        private void txtConLectora_CheckedChanged(object sender, EventArgs e)
        {
            if (txtConLectora.Checked == true)
            {
                txtTeclado.Checked = false;
            }
            else
            {
                txtTeclado.Checked = true;
            }
        }
        private void txtTeclado_CheckedChanged(object sender, EventArgs e)
        {
            if (txtTeclado.Checked == true)
            {
                txtConLectora.Checked = false;
            }
            else
            {
                txtConLectora.Checked = true;
            }
        }
        private void txtPais_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txtMoneda.SelectedIndex = txtPais.SelectedIndex;
        }

        private void txtMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPais.SelectedIndex = txtMoneda.SelectedIndex;
        }
        private void lblEditarLogo_Click_1(object sender, EventArgs e)
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "CARGADOR DE IMAGENES";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Imagenempresa.BackgroundImage = null;
                Imagenempresa.Image = new Bitmap(dlg.FileName);
                Imagenempresa.SizeMode = PictureBoxSizeMode.Zoom;

            }
        }
        private void label8_Click(object sender, EventArgs e)
        {
            obterner_ruta();
        }

        private void obterner_ruta()
        {
            string ruta = folderBrowserDialog1.SelectedPath;
            txtRuta.Text = folderBrowserDialog1.SelectedPath;
            //if (folderBrowserDialog1.ShowDialog()== DialogResult.OK)
            //{
            //    //txtRuta.Text = folderBrowserDialog1.SelectedPath;
            //    string ruta = folderBrowserDialog1.SelectedPath;
            //    if (ruta.Contains(@"C:\"))
            //    {
            //        MessageBox.Show("Seleccione un disco diferente al C", "RUTA INVALIDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //    }
            //    else
            //    {
            //        txtRuta.Text = folderBrowserDialog1.SelectedPath;
            //    }
            //}
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            obterner_ruta();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
