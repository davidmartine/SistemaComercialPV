using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Aplicacion_Comercial.Formularios.BalanzaElectronica
{
    public partial class Balanza : Form
    {
        public Balanza()
        {
            InitializeComponent();
        }
        private string BufferRespuesta;
        private delegate void DelegadoAcceso(string Accion);


        private void Balanza_Load(object sender, EventArgs e)
        {
            listar_puertos();
        }

        private void acceso_formulario(string Accion)
        {
            BufferRespuesta = Accion;
            txtPeso.Text = BufferRespuesta;

        }

        private void acceso_interrupcion(string Accion)
        {
            DelegadoAcceso  vardelagadoacceso;
            vardelagadoacceso = new DelegadoAcceso(acceso_formulario);
            Object[] arg = { Accion };
            base.Invoke(vardelagadoacceso,arg);

        }

        private void Puertos_DataReceived(Object sender,SerialDataReceivedEventArgs e)
        {
            acceso_interrupcion(Puertos.ReadExisting());

        }

        private void listar_puertos()
        {
            try
            {
                cmbListarPuertos.Items.Clear();
                string[] PuertosDisponibles = SerialPort.GetPortNames();
                foreach(string puerto in PuertosDisponibles)
                {
                    cmbListarPuertos.Items.Add(Puertos);
                }
                if(cmbListarPuertos.Items.Count > 0)
                {
                    cmbListarPuertos.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("NO SE ENCONTRARON PUERTOS");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("NO SE ENCONTRARON PUERTOS");
            }
        }



        private void editar_bascula()
        {
            Logica.LCaja caja_parametros = new Logica.LCaja();
            Datos.CADEditarDatos funcion = new Datos.CADEditarDatos();
            caja_parametros.Estado = "CONFIRMADO";
            caja_parametros.PuertoBalanza = cmbListarPuertos.Text;
            if (funcion.editar_bascula(caja_parametros) == true)
            {
                MessageBox.Show("BASCULA CONFIGURADA Y GUARDADA CORRECTAMENTE");
            }

        }

        private void btnProbar_Click_1(object sender, EventArgs e)
        {
            Puertos.Close();
            try
            {
                Puertos.BaudRate = 9600;
                Puertos.DataBits = 8;
                Puertos.Parity = Parity.None;
                Puertos.StopBits = (StopBits)1;
                Puertos.PortName = cmbListarPuertos.Text;
                Puertos.Open();
                if (Puertos.IsOpen)
                {
                    lblEstado.Text = "CONECTADO";
                }
                else
                {
                    MessageBox.Show("FALLO DE CONEXION");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPeso.Text))
            {
                editar_bascula();
            }
            else
            {
                MessageBox.Show("EL CAMPO PESO NO PUEDE ESTAR VACIO PARA CONFIRMAR LA BALANZA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEnviar_Click_1(object sender, EventArgs e)
        {
            if (Puertos.IsOpen)
            {
                Puertos.WriteLine(txtPeso.Text);

            }
            else
            {
                MessageBox.Show("FALLO DE CONEXION");
            }
        }
    }
}
