using Aplicacion_Comercial.Datos;
using Aplicacion_Comercial.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion_Comercial.Formularios.Caja
{
    public partial class CierreTurno : Form
    {
        public CierreTurno()
        {
            InitializeComponent();
        }
        //
        private double DineroCalculado;
        private double Resultado;
        private string CorreoBase;
        private string Password;
        private string EstadoCorreo;
        private string CorreoReceptor;
        private int idUsuario;
        private int idCaja;
        private string NombreUsuario;
        private void CierreTurno_Load(object sender, EventArgs e)
        {
            lblDeberiaHaber.Text =Convert.ToString(Formularios.Caja.Cierre_de_Caja.DineroCaja);
            DineroCalculado =Convert.ToDouble(lblDeberiaHaber.Text);
            Mostrar_Correo();
            Mostrar_estado_envio();
            Mostrar_usuarios_sesion();
        }

        private void Mostrar_usuarios_sesion()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.Mostrar_inicios_de_sesion_nombre(ref dt);
            foreach(DataRow row in dt.Rows)
            {
                NombreUsuario = row["Nombres_y_Apellidos"].ToString();

            }
        }

        private void Mostrar_estado_envio()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.mostrar_empresa(ref dt);
            foreach (DataRow row in dt.Rows)
            {
                CorreoReceptor = row["Correo_para_Envio_de_Reportes"].ToString();
                txtCorreo.Text = CorreoReceptor;
            }
        }

        private void Mostrar_Correo()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.Mostrar_correo_base(ref dt);
            foreach(DataRow row in dt.Rows)
            {
                CorreoBase =Logica.BasesPCProgram.Desencriptar(row["Correo"].ToString());
                Password =Logica.BasesPCProgram.Desencriptar(row["Password"].ToString());
                EstadoCorreo = Logica.BasesPCProgram.Desencriptar(row["EstadoEnvio"].ToString());

            }
            if(EstadoCorreo == "SINCRONIZADO")
            {
                checkCorreo.Checked = true;

            }
            else
            {
                checkCorreo.Checked = false;
            }
        }

        private void txtHay_TextChanged(object sender, EventArgs e)
        {
            Calcular();
        }

        private void ValidacionesCalculado()
        {
            if(Resultado ==0)
            {
                lblAnuncio.Text = "TODO ESTA PERFECTO";
                lblAnuncio.ForeColor = Color.Green;
                lblDiferencia.ForeColor = Color.Green;
                lblAnuncio.Visible = true;

            }
            if(Resultado < DineroCalculado & Resultado !=0)
            {
                lblAnuncio.Text = "LA DIFERENCIA SERA REGISTRADA EN SU TURNO Y SERA ENVIADA AL ADMINISTRADOR";
                lblAnuncio.ForeColor = Color.Red;
                lblDiferencia.ForeColor = Color.Red;
                lblAnuncio.Visible = true;

            }
            if(Resultado > DineroCalculado)
            {
                lblAnuncio.Text = "LA DIFERENCIA SERA REGISTRADA EN SU TURNO Y SERA ENVIADA AL ADMINISTRADOR";
                lblAnuncio.ForeColor = Color.Red;
                lblDiferencia.ForeColor = Color.Red;
                lblAnuncio.Visible = true;
            }
        }

        private void Calcular()
        {
            try
            {
                double Hay;
                Hay = Convert.ToDouble(txtHay.Text);
                if (string.IsNullOrEmpty(txtHay.Text))
                {
                    Hay = 0;
                }
                Resultado = Hay - DineroCalculado;
                lblDiferencia.Text = Convert.ToString(Resultado);
                ValidacionesCalculado();
            }
            catch (Exception)
            {

                
            }
            
        }

        private void checkCorreo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkCorreo_Click(object sender, EventArgs e)
        {
            if(EstadoCorreo != "SINCRONIZADO")
            {
                Formularios.CorreoBase.ConfigurarCorreoBase frmCorreobase = new CorreoBase.ConfigurarCorreoBase();
                frmCorreobase.FormClosing += FrmCorreobase_FormClosing;
                frmCorreobase.ShowDialog();
            }
        }

        private void FrmCorreobase_FormClosing(object sender, FormClosingEventArgs e)
        {
            Mostrar_Correo();
        }

        private void btnCerrarTurno_Click(object sender, EventArgs e)
        {
            Cerrar_mcierra_caja();

        }

        private void Reemplazar_html()
        {
            htmlEnvio.Text = htmlEnvio.Text.Replace("@VentasTotales",Formularios.Caja.Cierre_de_Caja.VentasTotales.ToString());
            htmlEnvio.Text = htmlEnvio.Text.Replace("@Ganancias",Formularios.Caja.Cierre_de_Caja.Ganacias.ToString());
            htmlEnvio.Text = htmlEnvio.Text.Replace("@Fecha",DateTime.Now.ToString());
            htmlEnvio.Text = htmlEnvio.Text.Replace("@NombreUsuario", NombreUsuario);
            htmlEnvio.Text = htmlEnvio.Text.Replace("@FondoCaja",Formularios.Caja.Cierre_de_Caja.SaldoQuedaCaja.ToString());
            htmlEnvio.Text = htmlEnvio.Text.Replace("@VentasEfectivo",Formularios.Caja.Cierre_de_Caja.VentasEfectivo.ToString());
            htmlEnvio.Text = htmlEnvio.Text.Replace("@Pagos", "0");
            htmlEnvio.Text = htmlEnvio.Text.Replace("@Cobros", "0");
            htmlEnvio.Text = htmlEnvio.Text.Replace("@IngresosVarios",Formularios.Caja.Cierre_de_Caja.IngresoEfectivo.ToString());
            htmlEnvio.Text = htmlEnvio.Text.Replace("@GastosVarios",Formularios.Caja.Cierre_de_Caja.GastoEfectivo.ToString());
            htmlEnvio.Text = htmlEnvio.Text.Replace("@Esperado", lblDeberiaHaber.Text);
            htmlEnvio.Text = htmlEnvio.Text.Replace("@Vefectivo",Formularios.Caja.Cierre_de_Caja.VentasEfectivo.ToString());
            htmlEnvio.Text = htmlEnvio.Text.Replace("@VTarjeta",Formularios.Caja.Cierre_de_Caja.VentasTarjeta.ToString());
            htmlEnvio.Text = htmlEnvio.Text.Replace("@VCredito",Formularios.Caja.Cierre_de_Caja.VentasCredito.ToString());
            htmlEnvio.Text = htmlEnvio.Text.Replace("@TVentas", Formularios.Caja.Cierre_de_Caja.VentasTotales.ToString());



        }

        private void Cerrar_mcierra_caja()
        {
            
            Datos.ObtenerDatos.mostrar_inicios_de_sesion(ref idUsuario);
            ObtenerDatos.obtener_id_caja_por_serial(ref idCaja);

            LMCajaCierre cierrec_parametros = new LMCajaCierre();
            CADEditarDatos funcion = new CADEditarDatos();
            cierrec_parametros.FechaFin = DateTime.Now;
            cierrec_parametros.FechaCierre = DateTime.Now;
            cierrec_parametros.Ingresos = Formularios.Caja.Cierre_de_Caja.Ingresos;
            cierrec_parametros.Egresos = Formularios.Caja.Cierre_de_Caja.Egresos;
            cierrec_parametros.SaldoQuedaEnCaja = 0;
            cierrec_parametros.idUsuario = idUsuario;
            cierrec_parametros.TotalCalculado = DineroCalculado;
            cierrec_parametros.TotalReal =Convert.ToDouble(txtHay.Text);
            cierrec_parametros.Estado = "CAJA CERRADA";
            cierrec_parametros.Direferencia = Resultado;
            cierrec_parametros.idCaja = idCaja;
            if (funcion.Editar_movimiento_caja_cierre(cierrec_parametros) == true)
            {
                Enviar_correo();
            }

        }

        private void Enviar_correo()
        {
            if(checkCorreo.Checked == true)
            {
                Reemplazar_html();
                bool Estado;
                Estado = Logica.BasesPCProgram.enviarCorreo(emisor: CorreoBase, password: Password, mensaje: htmlEnvio.Text, asunto: "CIERRRE DE CAJA SYSGETCO", destinatario: txtCorreo.Text, "-");
                if (Estado == true)
                {
                    MessageBox.Show("REPORTE DE CIERRE DE CAJA ENVIADO");
                    this.Dispose();
                    Formularios.Copias_BaseDatos.GeneradoAutomatico frmautomatico = new Copias_BaseDatos.GeneradoAutomatico();
                    frmautomatico.ShowDialog();

                }
                else
                {
                    MessageBox.Show("ERRROR DE ENVIO AL CORREO");
                    this.Dispose();
                    Formularios.Copias_BaseDatos.GeneradoAutomatico frmautomatico = new Copias_BaseDatos.GeneradoAutomatico();
                    frmautomatico.ShowDialog();

                }
                

            }
            else
            {
                this.Dispose();
                Formularios.Copias_BaseDatos.GeneradoAutomatico frmautomatico = new Copias_BaseDatos.GeneradoAutomatico();
                frmautomatico.ShowDialog();
            }
            
        }
        private void btnCerrarTurno_Click_1(object sender, EventArgs e)
        {
            Cerrar_mcierra_caja();
        }

        private void txtHay_TextChanged_2(object sender, EventArgs e)
        {
            Calcular();
        }

        private void txtHay_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Logica.BasesPCProgram.separador_de_numeros(txtHay, e);
        }
    }
}
