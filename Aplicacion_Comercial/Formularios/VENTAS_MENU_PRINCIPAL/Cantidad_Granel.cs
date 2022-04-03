using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion_Comercial.Formularios.VENTAS_MENU_PRINCIPAL
{
    public partial class Cantidad_Granel : Form
    {
        public Cantidad_Granel()
        {
            InitializeComponent();
        }
         public  double preciounitario;
        private string BufferRespuesta;
        private delegate void DelegadoAcceso(string Accion);
        string PuertoBalanza;
        string EstadoPuerto;

        private void BtnCerrar_turno_Click(object sender, EventArgs e)
        {
            
        }

        private void CANTIDAD_A_GRANEL_Load(object sender, EventArgs e)
        {
            txtprecio_unitario.Text = Convert.ToString(preciounitario);
            mostrar_puertos();
        }

        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {
            calcularTotal();
        }
        private void calcularTotal()
        {
            try
            {
            double total;
            double cantidad;
            cantidad =Convert.ToDouble ( txtcantidad.Text);
            total = preciounitario * cantidad;
            txttotal.Text =Convert.ToString ( total);
            }
            catch (Exception)
            {

            }
            
        }

        private void acceso_formulario(string Accion)
        {
            BufferRespuesta = Accion;
            txtcantidad.Text = BufferRespuesta;

        }

        private void acceso_interrupcion(string Accion)
        {
            DelegadoAcceso vardelagadoacceso;
            vardelagadoacceso = new DelegadoAcceso(acceso_formulario);
            Object[] arg = { Accion };
            base.Invoke(vardelagadoacceso, arg);

        }

        private void Puertos_DataReceived(Object sender, SerialDataReceivedEventArgs e)
        {
            acceso_interrupcion(Puertos.ReadExisting());

        }

        private void abrir_puerto_balanza()
        {
            Puertos.Close();
            try
            {
                Puertos.BaudRate = 9600;
                Puertos.DataBits = 8;
                Puertos.Parity = Parity.None;
                Puertos.StopBits = (StopBits)1;
                Puertos.PortName = PuertoBalanza;
                Puertos.Open();
                if (Puertos.IsOpen)
                {
                    EstadoPuerto = "CONECTADO";
                }
                else
                {
                    EstadoPuerto = "FALLO DE CONEXION";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void mostrar_puertos()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.mostrar_puertos(ref dt);
            foreach (DataRow row in dt.Rows)
            {
                PuertoBalanza = row["PuertoBalanza"].ToString();
                EstadoPuerto = row["EstadoBalanza"].ToString();

            }
            if (EstadoPuerto == "CONFIRMADO")
            {
                abrir_puerto_balanza();
            }
        }

        private void BtnCerrar_turno_Click_1(object sender, EventArgs e)
        {
            Ventas_Menu_Principal.txtpantalla = Convert.ToDouble(txtcantidad.Text);
            Dispose();
        }

       
    }
}
