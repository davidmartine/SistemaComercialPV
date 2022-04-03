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

namespace Aplicacion_Comercial.Formularios.Serializacion_de_Comprobantes
{
    public partial class Serializacion : Form
    {
        public Serializacion()
        {
            InitializeComponent();
        }

        string ValorporDefecto;
        int idSerializacion;

        private void Serializacion_Load(object sender, EventArgs e)
        {
            listar();
            panel3.Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            btnGuardar.Visible = true;
            btnGuardarCambios.Visible = false;
            txtCantidadeCeros.Clear();
            txtNumeroFin.Clear();
            txtSerie.Clear();
            txtCompro.Focus();
            ckbElejirporDefecto.Checked = false;
            ckbElejirporDefecto.Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar_serializacion();
        }

        private void guardar_serializacion() 
        {
            

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Insertar_Serializacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Serie", txtSerie.Text);
                cmd.Parameters.AddWithValue("@Cantidad_de_Numeros", txtCantidadeCeros.Text);
                cmd.Parameters.AddWithValue("@NumeroFin", txtNumeroFin.Text);
                cmd.Parameters.AddWithValue("@Destino", "OTROS");
                cmd.Parameters.AddWithValue("@Tipo_Documento", txtCompro.Text);
                cmd.Parameters.AddWithValue("@Por_Defecto", "-");
                cmd.ExecuteNonQuery();
                con.Close();
                listar();
                panel3.Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void listar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                da = new SqlDataAdapter("Mostrar_Tipo_de_Documentos_para_Insertar_estos_Mismos", con);
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();
                datalistado.Columns[1].Visible = false;
                datalistado.Columns[2].Visible = false;
                datalistado.Columns[3].Visible = false;
                datalistado.Columns[4].Visible = false;
                datalistado.Columns[5].Width = 220;
                datalistado.Columns[6].Width = 520;
                Logica.BasesPCProgram.Multilinea(ref datalistado);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            actualizar_serializacion();
        }

        private void actualizar_serializacion()
        {
            elejir_por_defecto();

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Editar_Serializacion",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Serie", txtSerie.Text);
                cmd.Parameters.AddWithValue("@Cantidad_de_Numeros", txtCantidadeCeros.Text);
                cmd.Parameters.AddWithValue("@NumeroFin", txtNumeroFin.Text);
                cmd.Parameters.AddWithValue("@Tipo_Documento", txtCompro.Text);
                cmd.Parameters.AddWithValue("@idSerializacion", idSerializacion);
                cmd.ExecuteNonQuery();
                con.Close();
                listar();
                panel3.Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void elejir_por_defecto()
        {
            if(ckbElejirporDefecto.Checked == true)
            { 
                try
                {
                    idSerializacion = Convert.ToInt32(datalistado.SelectedCells[4].Value.ToString());
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = Conexiones.CADMaestra.conexion;
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand("Editar_Serializacion_por_Defecto", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idSerializacion", idSerializacion);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.StackTrace);
                }
            }
        }

        private void datalistado_DoubleClick(object sender, EventArgs e)
        {
            panel3.Visible = true;
            try
            {
                txtCompro.Text = datalistado.SelectedCells[6].Value.ToString();
                txtCantidadeCeros.Text = datalistado.SelectedCells[2].Value.ToString();
                txtNumeroFin.Text = datalistado.SelectedCells[3].Value.ToString();
                txtSerie.Text = datalistado.SelectedCells[1].Value.ToString();
                btnGuardar.Visible = false;
                btnGuardarCambios.Visible = true;
                ValorporDefecto = datalistado.SelectedCells[7].Value.ToString();
                if (ValorporDefecto == "SI")
                {
                    ckbElejirporDefecto.Visible = false;
                    ckbElejirporDefecto.Checked = true;
                }
                else
                {
                    ckbElejirporDefecto.Visible = true;
                    ckbElejirporDefecto.Checked = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("¿ESTA SEGURO DE ELIMINAR LOS REGISTROS SELECCIONADOS?", "ELIMINAR REGISTROS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result == DialogResult.OK)
            {
                foreach(DataGridViewRow row in datalistado.SelectedRows)
                {
                    int onkey = Convert.ToInt32(row.Cells["idSerializacion"].Value);
                    try
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = Conexiones.CADMaestra.conexion;
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand("Eliminar_Serializacion", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idSerializacion", onkey);
                        cmd.ExecuteNonQuery();
                        con.Close();

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.StackTrace);
                    }
                }
            }
            listar();

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }
    }
}
