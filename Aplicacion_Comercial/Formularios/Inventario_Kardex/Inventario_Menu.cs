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

namespace Aplicacion_Comercial.Formularios.Inventario_Kardex
{
    public partial class Inventario_Menu : Form
    {
        public Inventario_Menu()
        {
            InitializeComponent();
        }
        public static int idProducto;


        public void buscarProductosMovimientos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();

                da = new SqlDataAdapter("Buscar_Productos_Kardex", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letrab", txtbuscarMovimiento.Text);
                da.Fill(dt);
                datalistadoProductosMovimientos.DataSource = dt;
                con.Close();

                datalistadoProductosMovimientos.Columns[1].Visible = false;
                datalistadoProductosMovimientos.Columns[3].Visible = false;
                datalistadoProductosMovimientos.Columns[4].Visible = false;
                datalistadoProductosMovimientos.Columns[5].Visible = false;
                datalistadoProductosMovimientos.Columns[6].Visible = false;
                datalistadoProductosMovimientos.Columns[7].Visible = false;
                datalistadoProductosMovimientos.Columns[8].Visible = false;
                datalistadoProductosMovimientos.Columns[9].Visible = false;
                datalistadoProductosMovimientos.Columns[10].Visible = false;
                datalistadoProductosMovimientos.Columns[11].Visible = false;
                datalistadoProductosMovimientos.Columns[12].Visible = false;
                datalistadoProductosMovimientos.Columns[13].Visible = false;
                datalistadoProductosMovimientos.Columns[14].Visible = false;
                datalistadoProductosMovimientos.Columns[15].Visible = false;
                datalistadoProductosMovimientos.Columns[16].Visible = false;

                Logica.BasesPCProgram.Multilinea(ref datalistadoProductosMovimientos);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void mostrarInventariosBajoMinimo()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();

                da = new SqlDataAdapter("Mostrar_Inventarios_Bajo_Minimo", con);
                da.Fill(dt);
                datalistadoInventariosBajo.DataSource = dt;
                con.Close();

                datalistadoInventariosBajo.Columns[0].Visible = false;
                datalistadoInventariosBajo.Columns[4].Visible = false;
                datalistadoInventariosBajo.Columns[7].Visible = false;
                datalistadoInventariosBajo.Columns[8].Visible = false;
                datalistadoInventariosBajo.Columns[9].Visible = false;

                Logica.BasesPCProgram.Multilinea(ref datalistadoInventariosBajo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void txtbuscarMovimiento_TextChanged(object sender, EventArgs e)
        {
            if (txtbuscarMovimiento.Text == "BUSCAR PRODUCTO" | txtbuscarMovimiento.Text == "")
            {
                datalistadoProductosMovimientos.Visible = false;
            }
            else
            {
                datalistadoProductosMovimientos.Visible = true;
                buscarProductosMovimientos();
            }
        }
        //variable publica para realizar llamados en reporte
       

        private void datalistadoProductosMovimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //idProducto=Convert.ToInt32( datalistadoProductosMovimientos.SelectedCells[1].Value.ToString());
            txtbuscarMovimiento.Text = datalistadoProductosMovimientos.SelectedCells[2].Value.ToString();
            datalistadoProductosMovimientos.Visible = false;
            buscarMovimientosKardex();
            try
            {
                idProducto = Convert.ToInt32(datalistadoProductosMovimientos.SelectedCells[1].Value.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void buscarMovimientosKardex()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();

                da = new SqlDataAdapter("Buscar_Movimientos_Kardex", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idProducto", datalistadoProductosMovimientos.SelectedCells[1].Value.ToString());
                da.Fill(dt);
                datalistadoMovimientos.DataSource = dt;
                con.Close();

                datalistadoMovimientos.Columns[0].Visible = false;
                datalistadoMovimientos.Columns[10].Visible = false;
                datalistadoMovimientos.Columns[11].Visible = false;

                Logica.BasesPCProgram.Multilinea(ref datalistadoMovimientos);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

        }

        

        private void buscarMovimientosFiltros()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();

                da = new SqlDataAdapter("Buscar_Movimientos_Kardex_Filtros", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Fecha", txtfechaM.Value);
                da.SelectCommand.Parameters.AddWithValue("@Tipo", txtTipoMovi.Text);
                da.SelectCommand.Parameters.AddWithValue("@idUsuario", txtidUsuario.Text);

                da.Fill(dt);
                datalistadoMovimientos.DataSource = dt;
                con.Close();

                datalistadoMovimientos.Columns[0].Visible = false;
                datalistadoMovimientos.Columns[10].Visible = false;
                datalistadoMovimientos.Columns[11].Visible = false;
                datalistadoMovimientos.Columns[9].Visible = false;
                datalistadoMovimientos.Columns[13].Visible = false;
                datalistadoMovimientos.Columns[14].Visible = false;
                datalistadoMovimientos.Columns[12].Visible = false;

                Logica.BasesPCProgram.Multilinea(ref datalistadoMovimientos);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void buscarMovimientosFiltrosAcumulados()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();

                da = new SqlDataAdapter("Buscar_Movimientos_Kardex_Filtos_Acumulados", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Fecha", txtfechaM.Value);
                da.SelectCommand.Parameters.AddWithValue("@Tipo", txtTipoMovi.Text);
                da.SelectCommand.Parameters.AddWithValue("@idUsuario", txtidUsuario.Text);

                da.Fill(dt);
                datalistadoMovimientoAcumuladoProducto.DataSource = dt;
                con.Close();

                datalistadoMovimientoAcumuladoProducto.Columns[4].Visible = false;
                datalistadoMovimientoAcumuladoProducto.Columns[5].Visible = false;
                datalistadoMovimientoAcumuladoProducto.Columns[6].Visible = false;

                Logica.BasesPCProgram.Multilinea(ref datalistadoMovimientoAcumuladoProducto);
                DataGridViewCellStyle styCabecera = new DataGridViewCellStyle();
                styCabecera.BackColor = System.Drawing.Color.FromArgb(26, 115, 232);
                styCabecera.ForeColor = System.Drawing.Color.White;
                styCabecera.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                datalistadoMovimientoAcumuladoProducto.ColumnHeadersDefaultCellStyle = styCabecera;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }


        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            datalistadoProductosMovimientos.Visible = false;
            txtTipoMovi.Text = "-Todos-";
            buscarMovimientosFiltros();
            buscarMovimientosFiltrosAcumulados();
            panel13.Visible = true;
            toolStripMenuItem3.Visible = false;
            toolStripMenuItem4.Visible = false;

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Formularios.Reportes_Kardex.Reportes_Kardex_Diseño.frmMovimientosBuscar frmMoviBusqueda = new Reportes_Kardex.Reportes_Kardex_Diseño.frmMovimientosBuscar();
            frmMoviBusqueda.ShowDialog();
        }

        private void ocultarFiltroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel13.Visible = false;
            groupBox1.Visible = false;
            buscarMovimientosKardex();
            txtTipoMovi.Text = "-Todos-";
            txtbuscarMovimiento.Text = "Buscar Producto";
            toolStripMenuItem3.Visible = true;
            toolStripMenuItem4.Visible = true;
        }

        private void txtfechaM_ValueChanged(object sender, EventArgs e)
        {
            if (groupBox1.Visible == true)
            {
                buscarMovimientosFiltros();
                buscarMovimientosFiltrosAcumulados();
            }
        }

        private void txtTipoMovi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (groupBox1.Visible == true)
            {
                buscarMovimientosFiltros();
                buscarMovimientosFiltrosAcumulados();
            }
        }

        private void txtUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (groupBox1.Visible == true)
            {
                buscarIdUsuario();
                buscarMovimientosFiltros();
                buscarMovimientosFiltrosAcumulados();

            }
        }

        private void buscarIdUsuario()
        {
            string resultado;
            string queryMoneda;

            queryMoneda = "Buscar_IdUsuarios";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Conexiones.CADMaestra.conexion;

            SqlCommand cmd = new SqlCommand(queryMoneda, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre_y_Apellidos", txtUsuarios.Text);
            try
            {
                con.Open();
                resultado = Convert.ToString(cmd.ExecuteScalar()); //asignamos el valor del importe
                txtidUsuario.Text = resultado;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                resultado = "";
            }


        }
        private void buscar_usuario()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();

                da = new SqlDataAdapter("SELECT * FROM USUARIO2", con);
                da.Fill(dt);
                txtUsuarios.DisplayMember = "Nombres_y_Apellidos";
                txtUsuarios.ValueMember = "idUsuario";

                txtUsuarios.DataSource = dt;
                con.Close();
                buscarIdUsuario();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        //llmado al reporte
        Formularios.Reportes_Kardex.Reportes_Kardex_Diseño.ReporteKardexMovimientos rptKardexMovimientos = new Reportes_Kardex.Reportes_Kardex_Diseño.ReporteKardexMovimientos();
        private void mostrarKardexMovimientos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();

                da = new SqlDataAdapter("Mostrar_Movimientos_De_Kardex", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idProducto", datalistadoProductos.SelectedCells[1].Value.ToString());
                da.Fill(dt);
                con.Close();

                rptKardexMovimientos = new Reportes_Kardex.Reportes_Kardex_Diseño.ReporteKardexMovimientos();
                rptKardexMovimientos.DataSource = dt;
                rptKardexMovimientos.table1.DataSource = dt;
                reportViewer1.Report = rptKardexMovimientos;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        //metodo de mostrar inventrios  stock bajo 

        private void Inventario_Menu_Load(object sender, EventArgs e)
        {
            panelMovimientos.Dock = DockStyle.None;
            panelReportesInventarios.Dock = DockStyle.None;
            panelInventarioBajo.Dock = DockStyle.None;
            panelMovimientos.Visible = false;
            panelReportesInventarios.Visible = false;
            panelInventarioBajo.Visible = false;
            panelKardex.Visible = true;
            panelKardex.Dock = DockStyle.Fill;
            panelVP.Visible = false;
            panelVencimientoProductos.Visible = false;
            panelVencimientoProductos.Dock = DockStyle.None;

            panelK.Visible = true;
            panelM.Visible = false;
            panelIB.Visible = false;
            panelRI.Visible = false;
            panelVP.Visible = false;

            txtbuscarKardexMovimientos.Text = "Buscar Producto";
        }
        private void inventariosVajosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMovimientos.Dock = DockStyle.None;
            panelReportesInventarios.Dock = DockStyle.None;

            panelMovimientos.Visible = false;
            panelReportesInventarios.Visible = false;
            panelInventarioBajo.Visible = true;
            panelInventarioBajo.Dock = DockStyle.Fill;
            panelKardex.Visible = false;
            panelKardex.Dock = DockStyle.None;
            panelK.Visible = false;
            panelM.Visible = false;
            panelIB.Visible = true;
            panelRI.Visible = false;
            panelVP.Visible = false;
            panelVencimientoProductos.Visible = false;
            panelVencimientoProductos.Dock = DockStyle.None;
            mostrarInventariosBajoMinimo();
        }

        private void txtbuscasrInventarios_TextChanged(object sender, EventArgs e)
        {
            if(txtbuscasrInventarios.Text != "BUSCAR...")
            {
                mostrarInventariosTodos();
            }
        }

        //metodo para conocer la cantidad de los productos
        internal void sumarCostodeInventarioContarProudctos()
        {
            string resultado;
            string queryMoneda;
            queryMoneda = "SELECT Moneda FROM Empresa";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Conexiones.CADMaestra.conexion;
            SqlCommand cmd = new SqlCommand(queryMoneda, con);

            try
            {
                con.Open();
                resultado = Convert.ToString(cmd.ExecuteScalar()); //asignamos el valor del importe
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                resultado = "";
            }

            string importe;
            string query;
            query = "SELECT CONVERT(NUMERIC(18,2),SUM(Productos.Precio_de_Compra * Stock)) AS Suma FROM Productos WHERE Usa_inventario = 'SI'";

            SqlCommand com = new SqlCommand(query, con);
            try
            {
                con.Open();
                importe = Convert.ToString(com.ExecuteScalar()); //asignamos el valor del importe
                con.Close();
                lblcostoinventario.Text = resultado + " " + importe;

            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.StackTrace);
                lblcostoinventario.Text = resultado + " " + 0;
            }

            string conteoresultado;
            string querycontar;
            querycontar = "SELECT COUNT(idProducto) FROM Productos";
            SqlCommand comcontar = new SqlCommand(querycontar, con);
            try
            {
                con.Open();
                conteoresultado = Convert.ToString(comcontar.ExecuteScalar()); //asignamos el valor del importe
                con.Close();
                lblcantidaddeproductoseninventario.Text = conteoresultado;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.StackTrace);
                conteoresultado = "";
                lblcantidaddeproductoseninventario.Text = "0";
            }

        }
        private void mostrarInventariosTodos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();

                da = new SqlDataAdapter("Mostrar_Inventarios_Todos", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Letra", txtbuscasrInventarios.Text);

                da.Fill(dt);
                datalistadoinventarioreportes.DataSource = dt;
                con.Close();


                datalistadoinventarioreportes.Columns[0].Visible = false;
                datalistadoinventarioreportes.Columns[9].Visible = false;
                datalistadoinventarioreportes.Columns[10].Visible = false;

                Logica.BasesPCProgram.Multilinea(ref datalistadoinventarioreportes);
                 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }



        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelRI.Visible = true;
            panelK.Visible = false;
            panelIB.Visible = false;
            panelM.Visible = false;
            panelVP.Visible = false;
            panelMovimientos.Visible = false;
            panelReportesInventarios.Visible = true;
            panelInventarioBajo.Visible = false;
            panelMovimientos.Dock = DockStyle.None;
            panelReportesInventarios.Dock = DockStyle.Fill;
            panelInventarioBajo.Dock = DockStyle.None;
            panelKardex.Visible = false;
            panelKardex.Dock = DockStyle.None;
            panelVencimientoProductos.Visible = false;
            panelVencimientoProductos.Dock = DockStyle.None;
            panelVP.Visible = false;
            mostrarInventariosTodos();
            sumarCostodeInventarioContarProudctos();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            txtbuscasrInventarios.Clear();
            mostrarInventariosTodos();
        }

        private void txtbuscarVencimiento_TextChanged(object sender, EventArgs e)
        {
            if(txtbuscarVencimiento.Text != "Buscar Producto/Codigo")
            {
                buscarProductosVencidos();
                checkporVenceren30Dias.Checked = false;
                checkProductosVencidosTodos.Checked = false;


            }
        }

        //METODO PARA  BUSCAR LOS PRODUCTOS VENCIDOS
        private void buscarProductosVencidos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();

                da = new SqlDataAdapter("Buscar_Productos_Vencidos", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Letra", txtbuscarVencimiento.Text);
                da.Fill(dt);
                datalistadoVencimientos.DataSource = dt;
                con.Close();

                datalistadoVencimientos.Columns[0].Visible = false;
                datalistadoVencimientos.Columns[1].Visible = false;
                datalistadoVencimientos.Columns[6].Visible = false;
                datalistadoVencimientos.Columns[7].Visible = false;

                Logica.BasesPCProgram.Multilinea(ref datalistadoVencimientos);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void txtbuscarVencimiento_Click(object sender, EventArgs e)
        {
            txtbuscarVencimiento.SelectAll();
        }

        private void checkporVenceren30Dias_CheckedChanged(object sender, EventArgs e)
        {
            mostrarProductosVencidosMenosde30Dias();
            txtbuscarVencimiento.Text = "Buscar Producto/Codigo";            
        }
        //METODO PARA MOSTRAR LOS PRODUCTOS VENCIDOS EN MENOS DE 30 DIAS
        private void mostrarProductosVencidosMenosde30Dias()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();

                da = new SqlDataAdapter("Mostrar_Productos_Vencidos_En_Menos_De_30Dias", con);
                da.Fill(dt);
                datalistadoVencimientos.DataSource = dt;
                con.Close();

                datalistadoVencimientos.Columns[0].Visible = false;
                datalistadoVencimientos.Columns[1].Visible = false;

                Logica.BasesPCProgram.Multilinea(ref datalistadoVencimientos);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void checkProductosVencidosTodos_CheckedChanged(object sender, EventArgs e)
        {
            mostrarProductosVencidos();
            txtbuscarVencimiento.Text = "Buscar Producto/Codigo";
        }

        private void mostrarProductosVencidos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();

                da = new SqlDataAdapter("Mostrar_Productos_Vencidos", con);
                da.Fill(dt);
                datalistadoVencimientos.DataSource = dt;
                con.Close();

                datalistadoVencimientos.Columns[0].Visible = false;
                datalistadoVencimientos.Columns[1].Visible = false;

                Logica.BasesPCProgram.Multilinea(ref datalistadoVencimientos);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TKardex_Click(object sender, EventArgs e)
        {
            panelK.Visible = true;
            panelM.Visible = false;
            panelIB.Visible = false;
            panelRI.Visible = false;
            panelVP.Visible = false;

            panelMovimientos.Dock = DockStyle.None;
            panelReportesInventarios.Dock = DockStyle.None;
            panelInventarioBajo.Dock = DockStyle.None;
            panelMovimientos.Visible = false;
            panelReportesInventarios.Visible = false;
            panelInventarioBajo.Visible = false;
            panelKardex.Visible = true;
            panelKardex.Dock = DockStyle.Fill;
            panelVencimientoProductos.Visible = false;
            panelVencimientoProductos.Dock = DockStyle.None;
            panelVP.Visible = false;

            txtbuscarKardexMovimientos.Text = "BUSCAR PRODUCTO";
        }

        private void TMovimientos_Click(object sender, EventArgs e)
        {
            panelRI.Visible = false;
            panelK.Visible = false;
            panelIB.Visible = false;
            panelM.Visible = true;
            panelVP.Visible = false;
            panelMovimientos.Visible = true;
            panelReportesInventarios.Visible = false;

            panelMovimientos.Dock = DockStyle.Fill;
            panelReportesInventarios.Dock = DockStyle.None;
            panelInventarioBajo.Dock = DockStyle.None;
            panelInventarioBajo.Visible = false;
            panelKardex.Visible = false;
            panelKardex.Dock = DockStyle.None;
            panelVencimientoProductos.Visible = false;
            panelVencimientoProductos.Dock = DockStyle.None;
            panelVP.Visible = false;
            buscarProductosMovimientos();
            buscar_usuario();
            buscarIdUsuario();
            txtbuscarMovimiento.Text = "BUSCAR PRODUCTO";
            menuStrip5.Visible = true;
            menuStrip6.Visible = true;
        }

        private void TVencimientosProductos_Click(object sender, EventArgs e)
        {
            panelRI.Visible = false;
            panelK.Visible = false;
            panelIB.Visible = false;
            panelM.Visible = false;
            panelVP.Visible = true;
            panelMovimientos.Visible = false;
            panelReportesInventarios.Visible = false;
            panelInventarioBajo.Visible = false;
            panelMovimientos.Dock = DockStyle.None;
            panelReportesInventarios.Dock = DockStyle.None;
            panelInventarioBajo.Dock = DockStyle.None;
            panelKardex.Visible = false;
            panelKardex.Dock = DockStyle.None;
            panelVencimientoProductos.Visible = true;
            panelVencimientoProductos.Dock = DockStyle.Fill;
            panelVP.Visible = true;
            txtbuscarVencimiento.Text = "Buscar Producto/Codigo";
        }

        private void txtbuscarKardexMovimientos_TextChanged(object sender, EventArgs e)
        {
            if (txtbuscarKardexMovimientos.Text == "BUSCAR PRODUCTO" | txtbuscarKardexMovimientos.Text == "")
            {
                datalistadoProductos.Visible = false;

            }
            else
            {
                buscarProductosKardex();
            }

        }

        private void buscarProductosKardex()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();

                da = new SqlDataAdapter("Buscar_Productos_Kardex", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letrab", txtbuscarKardexMovimientos.Text);
                da.Fill(dt);
                datalistadoProductos.DataSource = dt;
                con.Close();

                datalistadoProductos.Columns[1].Visible = false;
                //datalistadoProductos.Columns[2].Visible = false;
                datalistadoProductos.Columns[3].Visible = false;
                datalistadoProductos.Columns[4].Visible = false;
                datalistadoProductos.Columns[5].Visible = false;
                datalistadoProductos.Columns[6].Visible = false;
                datalistadoProductos.Columns[7].Visible = false;
                datalistadoProductos.Columns[8].Visible = false;
                datalistadoProductos.Columns[9].Visible = false;
                datalistadoProductos.Columns[10].Visible = false;
                datalistadoProductos.Columns[11].Visible = false;
                datalistadoProductos.Columns[12].Visible = false;
                datalistadoProductos.Columns[13].Visible = false;
                datalistadoProductos.Columns[14].Visible = false;
                datalistadoProductos.Columns[15].Visible = false;
                datalistadoProductos.Columns[16].Visible = false;
                datalistadoProductos.Visible = true;
                Logica.BasesPCProgram.Multilinea(ref datalistadoProductos);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void datalistadoProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void datalistadoProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtbuscarKardexMovimientos.Text = datalistadoProductos.SelectedCells[2].Value.ToString();
            datalistadoProductos.Visible = false;
            mostrarKardexMovimientos();
        }
        

        private void datalistadoProductosMovimientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        //variables publicas estaticas para realizar llamado al reporte filtrado
        public static string tipo_de_movimiento;
        public static DateTime fecha;
        public static int idusuario;
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tipo_de_movimiento = txtTipoMovi.Text;
            fecha = txtfechaM.Value;
            idusuario = Convert.ToInt32(txtidUsuario.Text);
            Formularios.Reportes_Kardex.Reportes_Kardex_Diseño.frmMovimientosFiltros frmMoviFiltros = new Reportes_Kardex.Reportes_Kardex_Diseño.frmMovimientosFiltros();
            frmMoviFiltros.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (txtbuscarMovimiento.Text == "BUSCAR PRODUCTO" | txtbuscarMovimiento.Text == "")
            {
                datalistadoProductosMovimientos.Visible = false;
            }
            else
            {
                datalistadoProductosMovimientos.Visible = true;
                buscarProductosMovimientos();
            }
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            KardexEntrada frmentrada = new KardexEntrada();
            frmentrada.ShowDialog();
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            KardexSalida frmsalida = new KardexSalida();
            frmsalida.ShowDialog();
        }
    }
}
