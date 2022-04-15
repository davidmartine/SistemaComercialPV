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

namespace Aplicacion_Comercial.Formularios.Gastos_Varios
{
    public partial class Gastos : Form
    {
        public Gastos()
        {
            InitializeComponent();
        }
        private int idConcepto;
        private int Id_Caja;

        private void Gastos_Load(object sender, EventArgs e)
        {
            
            limpiar_incio();
            Datos.ObtenerDatos.obtener_id_caja_por_serial(ref Id_Caja);
        }
        private void limpiar_incio()
        {
            panelConceptos.Visible = false;
            panelConceptos.Dock = DockStyle.None;
            panelConceptos.BringToFront();
            txtDescripcionConcepto.Clear();
            txtBuscarConcepto.Clear();
            mostrar_datalistadoconceptos();
            
            this.Size = new System.Drawing.Size(914, 666);
            chbComprobante.Checked = true;
            panelComprobante.Visible = false;
            txtImporte.Clear();
            txtDetalle.Clear();
            txtNumeroComprobante.Clear();

        }

        private void mostrar_datalistadoconceptos()
        {
            datalistadoConceptos.Visible = true;
            //datalistadoConceptos.Location = new Point((Panel29.Width)/2,(Panel29.Height)/2);
            datalistadoConceptos.Size = new System.Drawing.Size(800, 517);
            datalistadoConceptos.BringToFront();
            buscador_de_conceptos();
        }
        private void txtConcepto_TextChanged(object sender, EventArgs e)
        {
            buscador_de_conceptos();

        }
        private void buscador_de_conceptos()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.buscar_conceptos(ref dt, txtBuscarConcepto.Text);
            datalistadoConceptos.DataSource = dt;
            datalistadoConceptos.Columns[1].Visible = false;
            Logica.BasesPCProgram.Multilinea(ref datalistadoConceptos);

        }
        private void datalistadoConceptos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idConcepto = Convert.ToInt32(datalistadoConceptos.SelectedCells[1].Value);
                txtBuscarConcepto.Text = datalistadoConceptos.SelectedCells[2].Value.ToString();
                datalistadoConceptos.Visible = false;
                if (e.ColumnIndex == datalistadoConceptos.Columns["Editar"].Index)
                {
                    mostrar_panel_conceptos();
                    btnGuardarCambiosConceptos.Visible = true;
                    btnGuardarConceptos.Visible = false;
                    txtDescripcionConcepto.Text = txtBuscarConcepto.Text;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }
        private void chbComprobante_CheckedChanged(object sender, EventArgs e)
        {
            if (chbComprobante.Checked == true)
            {
                panelComprobante.Visible = false;
            }
            else
            {
                panelComprobante.Visible = true;
            }
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
        private void btnGuardarRegistros_Click_1(object sender, EventArgs e)
        {
            rellenar_campos_vacios();
            double Importe;
            Importe = Convert.ToDouble(txtImporte.Text);
            bool Estado = Datos.CADInsertarDatos.insertar_gastos_varios(dtpFecha.Value, txtNumeroComprobante.Text, cmbTipoComprobante.Text,
                                                          Importe, txtDetalle.Text, Id_Caja, idConcepto);
            if (Estado == true)
            {
                limpiar_incio();
                MessageBox.Show("DATO REGISTRADO CORRECTAMENTE", "GASTO REGISTRADO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void txtConcepto_Click(object sender, EventArgs e)
        {
            txtBuscarConcepto.SelectAll();
            mostrar_datalistadoconceptos();
        }
        private void ocultar_panel_conceptos()
        {
            panelConceptos.Visible = false;
            panelConceptos.Dock = DockStyle.None;
            panel7.Visible = true;
        }
        private void btnVolvera_Click(object sender, EventArgs e)
        {
            ocultar_panel_conceptos();
            //mostrar_datalistadoconceptos();
        }
        private void btnGuardarCambiosConceptos_Click_1(object sender, EventArgs e)
        {
            bool Estado = Datos.CADEditarDatos.editar_conceptos(idConcepto, txtDescripcionConcepto.Text);
            if (Estado == true)
            {
                ocultar_panel_conceptos();
                buscador_de_conceptos();
                txtBuscarConcepto.Text = txtDescripcionConcepto.Text;
            }
            else
            {
                txtDescripcionConcepto.SelectAll();

            }
        }
        private void btnGuardarConceptos_Click_1(object sender, EventArgs e)
        {
            bool Estado = Datos.CADInsertarDatos.insertar_consepto(txtDescripcionConcepto.Text);
            if (Estado == true)
            {
                buscador_de_conceptos();
                ocultar_panel_conceptos();
            }
        }
        private void btnNuevoConcepto_Click(object sender, EventArgs e)
        {

            mostrar_panel_conceptos();
            btnGuardarConceptos.Visible = true;
            btnGuardarCambiosConceptos.Visible = false;
            txtDescripcionConcepto.Clear();
        }

        private void mostrar_panel_conceptos()
        {
            panelConceptos.Visible = true;
            panelConceptos.Dock = DockStyle.Fill;
            panel7.Visible = false;
            panelConceptos.BringToFront();

        }
        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Logica.BasesPCProgram.separador_de_numeros(txtImporte, e);
        }
        private void btnGuardarConceptos_Click(object sender, EventArgs e)
        {
         
           
        }
    }
}
