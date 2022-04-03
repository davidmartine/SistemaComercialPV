using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpreadsheetLight;
using System.Data.SqlClient;
using System.IO;

namespace Aplicacion_Comercial.Formularios.Productos
{
    public partial class Asistente_de_ImportacionExcel : Form
    {
        public Asistente_de_ImportacionExcel()
        {
            InitializeComponent();
        }

        private void Asistente_de_ImportacionExcel_Load(object sender, EventArgs e)
        {
            btn1.Enabled = true;
            btn2.Enabled = false;
            btn2.Enabled = false;
            paso1.Visible = true;
            paso2.Visible = false;
            paso3.Visible = false;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            try
            {
                string ruta;
                if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    
                    ruta = folderBrowserDialog1.SelectedPath + @"\PRODUCTOS-SYSGETCO.xlsx";
                    SLDocument NombredeExcel = new SLDocument();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Descripcion", typeof(string));
                    dt.Columns.Add("Codigo", typeof(string));
                    NombredeExcel.ImportDataTable(1, 1, dt, true);
                    NombredeExcel.SaveAs(ruta);
                    MessageBox.Show("PLANTILLA OBTENEIDA EN: " + ruta, "ARCHIVO CREADO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                
            }
        }

        private void Siguiente_y_Guardar_Click(object sender, EventArgs e)
        {
            panelDescargaArchivo.Visible = false;
            panelCargarArchivo.Visible = true;
            btn1.Enabled = false;
            btn2.Enabled = true;
            btn3.Enabled = false;
            paso1.Visible = false;
            paso2.Visible = true;
            paso3.Visible = false;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog myFileDialog = new OpenFileDialog();
            myFileDialog.InitialDirectory = @"C:\\temp\";
            myFileDialog.Filter = "CSV files|*.csv;*.CSV";
            myFileDialog.FilterIndex = 2;
            myFileDialog.RestoreDirectory = true;
            myFileDialog.Title = "SELECCIONE EL ARCIHO .CSV";
            
            if(myFileDialog.ShowDialog() == DialogResult.OK)
            {
                lblNombredelArchivo.Text = myFileDialog.SafeFileName.ToString();
                lblNombredelArchivo.Text = lblNombredelArchivo.Text;
                lblRuta.Text = myFileDialog.FileName.ToString();
                archivo_correcto();
            }
        }

        private void archivo_correcto()
        {
            panelCargarArchivo.BackColor = Color.White;
            lblArchivoListo.Visible = true;
            label3.Visible = false;
            btnSiguiente.Visible = true;
            pCSV.Visible = true;
            linkLabel2.LinkColor = Color.Black;
            lblNombredelArchivo.ForeColor = Color.FromArgb(64, 64, 64);
            panelCargarArchivo.BackgroundImage = null;
        }

        private void panelCargarArchivo_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;

            }
        }

        private void panelCargarArchivo_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (String[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach(string path in files)
            {
                lblRuta.Text = path;
                string ruta = lblRuta.Text;
                if (ruta.Contains(".csv"))
                {
                    archivo_correcto();
                    lblNombredelArchivo.Text = Path.GetFileName(ruta);
                    lblArchivoListo.Text = lblNombredelArchivo.Text;

                }
                else
                {
                    MessageBox.Show("ARCHIVO INCORRECTO", "FORMATO INCORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            panelCargarArchivo.Visible = false;
            panelGuardarData.Visible = true;
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = true;
            paso1.Visible = false;
            paso2.Visible = false;
            paso3.Visible = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            guardar_datos_precargados();
        }

        private void guardar_datos_precargados()
        {
            string Texlines = "";
            string[] Splitlines;
            if (System.IO.File.Exists(lblRuta.Text) == true)
            {
                System.IO.StreamReader objreader = new StreamReader(lblRuta.Text);
                while(objreader.Peek() != -1)
                {
                    Texlines = objreader.ReadLine();
                    Splitlines = Texlines.Split(';');
                    datalistado.ColumnCount = Splitlines.Length;
                    datalistado.Rows.Add(Splitlines);

                }
                
            }
            else
            {
                MessageBox.Show("ARCHIVO INEXISTENTE", "CSV INEXISTENTE");

            }

            try
            {
                foreach(DataGridViewRow row in datalistado.Rows)
                {
                    rellenar_Vacios();
                    string Codigo = Convert.ToString(row.Cells["Codigo"].Value);
                    string Descripcion = Convert.ToString(row.Cells["Descripcion"].Value);
                    SqlCommand cmd;
                    Conexiones.CADMaestra.conectar.Open();
                    cmd = new SqlCommand("insertar_Productos_Importacion", Conexiones.CADMaestra.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                    cmd.Parameters.AddWithValue("@Imagen", ".");
                    cmd.Parameters.AddWithValue("@Usa_inventario", "SI");
                    cmd.Parameters.AddWithValue("@Stock", 0);
                    cmd.Parameters.AddWithValue("@Precio_de_compra", 0);
                    cmd.Parameters.AddWithValue("@Fecha_vencimiento", "NO APLICA");
                    cmd.Parameters.AddWithValue("@Precio_de_venta", 0);
                    cmd.Parameters.AddWithValue("@Codigo", Codigo);
                    cmd.Parameters.AddWithValue("@Se_vende_a", "UNIDAD");
                    cmd.Parameters.AddWithValue("@Impuesto", 0);
                    cmd.Parameters.AddWithValue("@Stock_minimo", 0);
                    cmd.Parameters.AddWithValue("@Precio_mayoreo", 0);
                    cmd.Parameters.AddWithValue("@A_partir_de", 0);
                    cmd.Parameters.AddWithValue("@Fecha", DateTime.Today);
                    cmd.Parameters.AddWithValue("@Motivo", "REGISTRO INICIAL DE PRODUCTO");
                    cmd.Parameters.AddWithValue("@Cantidad", 0);
                    cmd.Parameters.AddWithValue("@idUsuario", Productos.idUsuario);
                    cmd.Parameters.AddWithValue("@Tipo", "ENTRADA");
                    cmd.Parameters.AddWithValue("@Estado", "CONFIRMADO");
                    cmd.Parameters.AddWithValue("@Id_Caja", Productos.idCaja);
                    cmd.ExecuteNonQuery();
                    Conexiones.CADMaestra.conectar.Close();
                }
                    MessageBox.Show("IMPORTACION EXITOSA", "EXPORTACION DE DATOS");
                this.Dispose();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

        }

        private void rellenar_Vacios()
        {
            foreach(DataGridViewRow row in datalistado.Rows)
            {
                if(row.Cells["Descripcion"].Value.ToString() == "")
                {
                    row.Cells["Descripcion"].Value = "VACIO@";
                }
                if(row.Cells["Codigo"].Value.ToString() == "")
                {
                    row.Cells["Codigo"].Value = "VACIO@";
                }
            }
        }
    }
}
