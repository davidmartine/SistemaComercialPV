using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Aplicacion_Comercial.Logica;
using Aplicacion_Comercial.Datos;

namespace Aplicacion_Comercial.Formularios.Impresoras
{
    public partial class frmImpresoras : Form
    {
        public frmImpresoras()
        {
            InitializeComponent();
        }
        private ManagementObjectSearcher MisDisco = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
        private ManagementObject DiscoInfo = new ManagementObject();
        int idCaja;
        private void frmImpresoras_Load(object sender, EventArgs e)
        {
            guna2Panel1.Location = new Point((Width - guna2Panel2.Width) / 2, (Height - guna2Panel2.Height) / 2);
            cmbTicket.Items.Clear();
            cmbA4.Items.Clear();
            cargar_datos();
            for (var i=0; i< PrinterSettings.InstalledPrinters.Count; i++)
            {
                cmbTicket.Items.Add(PrinterSettings.InstalledPrinters[i]);
                cmbA4.Items.Add(PrinterSettings.InstalledPrinters[i]);
            }
            cmbTicket.Items.Add("NINGUNA");
            cmbA4.Items.Add("NINGUNA");
        }
        private void cargar_datos()
        {
            DataTable dt = new DataTable();
            Datos.ObtenerDatos.mostrar_caja(ref dt);

            try
            {
                foreach(DataRow row in dt.Rows)
                {
                    idCaja = Convert.ToInt32(row["Id_Caja"]);
                    cmbTicket.Text = row["Impresora_Ticket"].ToString();
                    cmbA4.Text = row["Impresora_A4"].ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void editar()
        {
            LImpresora impresora = new LImpresora();
            CADEditarDatos datos = new CADEditarDatos();
            impresora.idCaja = idCaja;
            impresora.ImpresoraTicket = cmbTicket.Text;
            impresora.ImpresoraA4 = cmbA4.Text;
            if (datos.editar_caja_impresoras(impresora) == true)
            {
                MessageBox.Show("DATOS GUARDADOS CORRECTAMENTE", "REGISTROS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }
    }
}
