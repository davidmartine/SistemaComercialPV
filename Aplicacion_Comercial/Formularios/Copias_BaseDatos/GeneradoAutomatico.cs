using Aplicacion_Comercial.Datos;
using Aplicacion_Comercial.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion_Comercial.Formularios.Copias_BaseDatos
{
    public partial class GeneradoAutomatico : Form
    {
        public GeneradoAutomatico()
        {
            InitializeComponent();
        }

        int Contador = 10;
        private string txtNombreSoft = "sysgetco";
        private string txtBaseDatos = "PuntoVenta";
        private Thread Hilo;
        private bool Acaba = false;
        private string cmbFrecuencia;
        private void GeneradoAutomatico_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            Mostrar_empresa();
            timerContador.Start();

        }
        private void Generar_copia()
        {
            if (!string.IsNullOrEmpty(txtRuta.Text))
            {
                Hilo = new Thread(new ThreadStart(ejecucion));
                pCargando.Visible = true;
                Hilo.Start();
                timer1.Start();

            }
            else
            {
                MessageBox.Show("DEBES SELECCIONAR UNA RUTA DONDE GUARDAR LA COPIA DE SEGURIDAD", "SELECCIONAR RUTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRuta.Focus();
            }
        }
        private void ejecucion()
        {
            string MiCarpeta = "Copias_De_Seguridad_De_" + txtNombreSoft;
            if (System.IO.Directory.Exists(txtRuta.Text + MiCarpeta))
            {

            }
            else
            {
                System.IO.Directory.CreateDirectory(txtRuta.Text + MiCarpeta);

            }
            string RutaCompleta = txtRuta.Text + MiCarpeta;
            string SubCarpeta = RutaCompleta + @"\Respaldo_al_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute;
            try
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(RutaCompleta, SubCarpeta));
            }
            catch (Exception)
            {

            }
            try
            {
                string VNombreRespaldo = txtBaseDatos + ".bak";
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("BACKUP DATABASE " + txtBaseDatos + " TO DISK = '" + SubCarpeta + @"\" + VNombreRespaldo + "'", Conexiones.CADMaestra.conectar);
                cmd.ExecuteNonQuery();
                Acaba = true;
            }
            catch (Exception ex)
            {
                Acaba = false;
                MessageBox.Show(ex.Message);
            }
        }
        private void Mostrar_empresa()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.mostrar_empresa(ref dt);
            foreach (DataRow row in dt.Rows)
            {
                txtRuta.Text = row["Carpeta_para_Copias_de_Seguridad"].ToString();
                cmbFrecuencia = row["Fecuencia_de_Copias"].ToString();


            }
        }
        private void timerContador_Tick(object sender, EventArgs e)
        {
            Contador -= 1;
            lblTiempo.Text =Convert.ToString(Contador);
            if(Contador == 0)
            {
                Contador = 0;
                timerContador.Stop();
                Generar_copia();

            }

        }
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void GeneradoAutomatico_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Acaba == true)
            {
                timer1.Stop();
                pCargando.Visible = false;
                Editar_respaldo();

            }
        }
        private void Editar_respaldo()
        {
            LEmpresa empresa = new LEmpresa();
            CADEditarDatos funcion = new CADEditarDatos();
            empresa.Ultima_Fecha_De_Copia_De_Seguridad = DateTime.Now.ToString();
            empresa.Carpeta_Para_Copias_De_Seguridad = txtRuta.Text;
            empresa.Ultima_Fecha_De_Copia_Date = DateTime.Now;
            empresa.Fecuencia_De_Copias = Convert.ToInt32(cmbFrecuencia);
            if (funcion.Editar_respaldo(empresa) == true)
            {
                Application.Exit();

            }

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            

        }
    }
}
