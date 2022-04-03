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

namespace Aplicacion_Comercial.Formularios.Cobros
{
    public partial class MediosCobros : Form
    {
        public MediosCobros()
        {
            InitializeComponent();
        }
        private int idCliente;
        private double Saldo;
        private int Id_Caja;
        private int idUsuario;

        private double Efectivo;
        private double Tarjeta;
        private double Vuelto;
        private double Restante;
        private double EfectivoCalculado;
        private double MontoAbonado;

        private void MediosCobros_Load(object sender, EventArgs e)
        {
            Saldo = Formularios.Cobros.Cobros.Saldo;
            lblTotal.Text =Saldo.ToString();
            idCliente = Formularios.Cobros.Cobros.idCliente;
            Datos.ObtenerDatos.obtener_id_caja_por_serial(ref Id_Caja);
            Datos.ObtenerDatos.mostrar_inicios_de_sesion(ref idUsuario);

        }

        private void Calcular_restante()
        {
            try
            {
                Efectivo = 0;
                Tarjeta = 0;
                if (string.IsNullOrEmpty(txtEfectivo.Text))
                {
                    Efectivo = 0;

                }
                else
                {
                    Efectivo = Convert.ToDouble(txtEfectivo.Text);
                }
                if (string.IsNullOrEmpty(txtTarjeta.Text))
                {
                    Tarjeta = 0;
                }
                else
                {
                    Tarjeta = Convert.ToDouble(txtTarjeta.Text);
                }
                //CALCULO  DE VUELTO
                if (Efectivo > Saldo)
                {
                    Vuelto = Efectivo - Saldo;
                    EfectivoCalculado = (Efectivo - Vuelto);
                    txtVuelto.Text = Vuelto.ToString();

                }
                else
                {
                    Vuelto = 0;
                    EfectivoCalculado = Efectivo;
                    txtVuelto.Text = Vuelto.ToString();
                }
                //CALCULO DEL RESTANTE
                Restante = Saldo - EfectivoCalculado - Tarjeta;
                lblRestante.Text = Restante.ToString();
                if(Restante < 0)
                {
                    lblRestante.Visible = false;
                    label5.Visible = false;
                }
                else
                {
                    lblRestante.Visible = true;
                    label5.Visible = true;
                }
                if(Tarjeta == Saldo)
                {
                    Efectivo = 0;
                    txtEfectivo.Text = Efectivo.ToString();

                }
                if (Tarjeta > Saldo)
                {
                    MessageBox.Show("EL PAGO CON TARJETA NO PUEDE SER MAYOR QUE EL SALDO");
                    Tarjeta = 0;
                    txtTarjeta.Text = Tarjeta.ToString();
                }

            }
            catch (Exception)
            {


            }

        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            Calcular_restante();
        }

        private void txtTarjeta_TextChanged(object sender, EventArgs e)
        {
            Calcular_restante();
        }

        private void Insertar_control_cobros()
        {
            try
            {
                LControlCobros cobros_parametros = new LControlCobros();
                CADInsertarDatos funcion = new CADInsertarDatos();
                cobros_parametros.Monto = EfectivoCalculado + Tarjeta;
                cobros_parametros.Fecha = DateTime.Now;
                cobros_parametros.Detalle = "COBRO A CLIENTE";
                cobros_parametros.idCliente = idCliente;
                cobros_parametros.idUsuario = idUsuario;
                cobros_parametros.Id_Caja = Id_Caja;
                cobros_parametros.Comprobante = "-";
                cobros_parametros.Efectivo = EfectivoCalculado;
                cobros_parametros.Tarjeta = Tarjeta;
                if (funcion.Insertar_control_cobros(cobros_parametros) == true)
                {
                    this.Dispose();
                }
            }
            catch (Exception)
            {

            }
        }

        private void Editar_saldo_cliente()
        {
            LCliente cliente_parametros = new LCliente();
            CADEditarDatos funcion = new CADEditarDatos();
            cliente_parametros.idCliente = idCliente;
            funcion.Editar_saldo_cliente(cliente_parametros, MontoAbonado);

        }

        private void btnAbonar_Click_1(object sender, EventArgs e)
        {
            MontoAbonado = EfectivoCalculado + Tarjeta;
            if (MontoAbonado > 0)
            {
                Insertar_control_cobros();
                Editar_saldo_cliente();
            }
            else
            {
                MessageBox.Show("ESPECIFIQUE UN MONTO A ABONAR");
            }
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Logica.BasesPCProgram.separador_de_numeros(txtEfectivo, e);
        }

        private void txtTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Logica.BasesPCProgram.separador_de_numeros(txtTarjeta, e);
        }
    }
}
