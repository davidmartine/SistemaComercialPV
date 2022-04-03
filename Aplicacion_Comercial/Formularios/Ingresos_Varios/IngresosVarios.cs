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

namespace Aplicacion_Comercial.Formularios.Ingresos_Varios
{
    public partial class IngresosVarios : Form
    {
        public IngresosVarios()
        {
            InitializeComponent();
        }

        private int Id_Caja;
        private void IngresosVarios_Load(object sender, EventArgs e)
        {
            chbComprobante.Checked = true;
            Datos.ObtenerDatos.obtener_id_caja_por_serial(ref Id_Caja);
        }
        private void rellenar_campos_vacios()
        {
            if (string.IsNullOrEmpty(txtDetalle.Text))
            {
                txtDetalle.Text = "SIN DETALLAR";
            }
            if (string.IsNullOrEmpty(cmbTipoComprobante.Text))
            {
                cmbTipoComprobante.Text = "-";
            }
            if (string.IsNullOrEmpty(txtNumeroComprobante.Text))
            {
                txtNumeroComprobante.Text = "-";
            }
        }

        private void limpiar_incio()
        {
            

          //  this.Size = new System.Drawing.Size(914, 666);
            chbComprobante.Checked = true;
            panelComprobante.Visible = false;
            txtImporte.Clear();
            txtDetalle.Clear();
            txtNumeroComprobante.Clear();

        }
        private void chbComprobante_CheckedChanged(object sender, EventArgs e)
        {
            if(chbComprobante.Checked == true)
            {
                panelComprobante.Visible = false;
            }
            else
            {
                panelComprobante.Visible = true;
            }
        }
        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardarRegistros_Click_1(object sender, EventArgs e)
        {
            rellenar_campos_vacios();
            double Importe;
            Importe = Convert.ToDouble(txtImporte.Text);
            bool Estado = Datos.CADInsertarDatos.insertar_ingresos_varios(dtpFecha.Value, txtNumeroComprobante.Text, cmbTipoComprobante.Text,
                Importe, txtDetalle.Text, Id_Caja);
            if (Estado == true)
            {
                limpiar_incio();
                MessageBox.Show("INGRESO GUARDADO CORRECTAMENTE", "INGRESO EXITOSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
