﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using System.Data.OleDb;
using System.IO;
using System.Threading;
using System.Management;

namespace Aplicacion_Comercial.Formularios.Productos
{
    public partial class Productos : Form
    {
        int txtcontador;
       
        public Productos()
        {
            InitializeComponent();
        }

        private int lblIdSerialPC;


        private void Productos_ok_Load(object sender, EventArgs e)
        {

            Logica.BasesPCProgram.cambiar_idioma_regional();


            PANELDEPARTAMENTO.Visible = false;
            txtbusca.Text = "Buscar...";
            sumar_costo_de_inventario_CONTAR_PRODUCTOS();
            buscar();
            mostrar_grupos();
            Datos.ObtenerDatos.mostrar_inicios_de_sesion(ref idUsuario);
            Datos.ObtenerDatos.obtener_id_caja_por_serial(ref idCaja);
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            PANELDEPARTAMENTO.Visible = true;
            CheckInventarios.Checked = true;
            PANELINVENTARIO.Visible = true;
            PanelGRUPOSSELECT.Visible = true;
            btnGuardar_grupo.Visible = false;
            BtnGuardarCambios.Visible = false;
            BtnCancelar.Visible = false;
            btnNuevoGrupo.Visible = true;
            mostrar_grupos();
            txtgrupo.Clear();
            txtPorcentajeGanancia.Clear();
            lblEstadoCodigo.Text = "NUEVO";
            PanelGRUPOSSELECT.Visible = true;
            btnGuardar_grupo.Visible = false;
            BtnGuardarCambios.Visible = false;
            BtnCancelar.Visible = false;
            btnNuevoGrupo.Visible = true;
            mostrar_grupos();

            txtapartirde.Text = "0";
            txtstock2.ReadOnly = false;
            Panel25.Enabled = true;
            Panel21.Visible = false;
            Panel22.Visible = false;
            Panel18.Visible = false;
            TXTIDPRODUCTOOk.Text = "0";
          
            PANELINVENTARIO.Visible = true;

            txtdescripcion.AutoCompleteCustomSource = Aplicacion_Comercial.Conexiones.DataHelper.LoadAutoComplete();
            txtdescripcion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtdescripcion.AutoCompleteSource = AutoCompleteSource.CustomSource;

            PANELDEPARTAMENTO.Visible = true;
            porunidad.Checked = true;
            No_aplica_fecha.Checked = false;
            Panel6.Visible = false;

            LIMPIAR();
            btnagregaryguardar.Visible = true;
            btnagregar.Visible = false;


            txtdescripcion.Text = "";
            PANELINVENTARIO.Visible = true;


            TGUARDAR.Visible = true;
            TGUARDARCAMBIOS.Visible =false;



        }
        internal void LIMPIAR()
        {
            txtidproducto.Text = "";
            txtdescripcion.Text = "";
            txtcosto.Text = "0";
            TXTPRECIODEVENTA2.Text = "0";
            txtpreciomayoreo.Text = "0";
            txtgrupo.Text = "";

            agranel.Checked = false;
            txtstockminimo.Text = "0";
            txtstock2.Text = "0";
            lblEstadoCodigo.Text = "NUEVO";
        }
        public static int idUsuario;
        public static int idCaja;

        private void mostrar_grupos()
        {
            PanelGRUPOSSELECT.Visible = true;
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();

                da = new SqlDataAdapter("mostrar_grupo_de_productos", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Buscar", txtgrupo.Text);
                da.Fill(dt);
                datalistadoGrupos.DataSource = dt;
                con.Close();

                datalistadoGrupos.DataSource = dt;
                datalistadoGrupos.Columns[2].Visible = false;
                datalistadoGrupos.Columns[3].Width = 500;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

            Logica.BasesPCProgram.Multilinea(ref datalistado);
        }

        private void btnGuardar_grupo_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_grupo_de_productos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Linea", txtgrupo.Text);
                cmd.Parameters.AddWithValue("@Por_defecto", "NO");
                cmd.ExecuteNonQuery();
                con.Close();
                mostrar_grupos();

                lblIdGrupo.Text = datalistadoGrupos.SelectedCells[2].Value.ToString();
                txtgrupo.Text = datalistadoGrupos.SelectedCells[3].Value.ToString();

                PanelGRUPOSSELECT.Visible = false;
                btnGuardar_grupo.Visible = false;
                BtnGuardarCambios.Visible = false;
                BtnCancelar.Visible = false;
                btnNuevoGrupo.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void btnNuevoGrupo_Click(object sender, EventArgs e)
        {
            txtgrupo.Text = "Escribe el Nuevo GRUPO";
            txtgrupo.SelectAll();
            txtgrupo.Focus();

            PanelGRUPOSSELECT.Visible = false;
            btnGuardar_grupo.Visible = true;
            BtnGuardarCambios.Visible = false;
            BtnCancelar.Visible = true;
            btnNuevoGrupo.Visible = false;
        }

        private void txtgrupo_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void BtnCancelar_Click_1(object sender, EventArgs e)
        {
            PanelGRUPOSSELECT.Visible = false;
            btnGuardar_grupo.Visible = false;
            BtnGuardarCambios.Visible = false;
            BtnCancelar.Visible = false;
            btnNuevoGrupo.Visible = true;
            txtgrupo.Clear();
            mostrar_grupos();
         
        }
        private void TGUARDAR_Click_1(object sender, EventArgs e)
        {
            
        }
        private void insertar_productos()
        {
            if (txtpreciomayoreo.Text == "0" | txtpreciomayoreo.Text == "") txtapartirde.Text = "0";

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_Productos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Descripcion", txtdescripcion.Text);
                cmd.Parameters.AddWithValue("@Imagen", ".");
                cmd.Parameters.AddWithValue("@Precio_de_compra", txtcosto.Text);
                cmd.Parameters.AddWithValue("@Precio_de_venta", TXTPRECIODEVENTA2.Text);
                cmd.Parameters.AddWithValue("@Codigo", txtcodigodebarras.Text);
                cmd.Parameters.AddWithValue("@A_partir_de", txtapartirde.Text);
                cmd.Parameters.AddWithValue("@Impuesto", 0);
                cmd.Parameters.AddWithValue("@Precio_mayoreo", txtpreciomayoreo.Text);
                if (porunidad.Checked == true) txtse_vende_a.Text = "Unidad";
                if (agranel.Checked == true) txtse_vende_a.Text = "Granel";

                cmd .Parameters.AddWithValue("@Se_vende_a", txtse_vende_a.Text);
                cmd .Parameters.AddWithValue("@idGrupo", lblIdGrupo.Text);
                if (PANELINVENTARIO.Visible == true)
                {
                    cmd.Parameters.AddWithValue("@Usa_inventario", "SI");
                    cmd.Parameters.AddWithValue("@Stock_minimo", txtstockminimo.Text);
                    cmd.Parameters.AddWithValue("@Stock", txtstock2.Text);

                    if (No_aplica_fecha.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@Fecha_vencimiento", "NO APLICA");
                    }

                    if (No_aplica_fecha.Checked == false)
                    {
                        cmd.Parameters.AddWithValue("@Fecha_vencimiento", txtfechaoka.Text);
                    }


                }
                if (PANELINVENTARIO.Visible == false)
                {
                    cmd.Parameters.AddWithValue("@Usa_inventario", "NO");
                    cmd.Parameters.AddWithValue("@Stock_minimo", 0);
                    cmd.Parameters.AddWithValue("@Fecha_vencimiento", "NO APLICA");
                    cmd.Parameters.AddWithValue("@Stock", "Ilimitado");

                }

                // no hay donde muestre el id usuario tiene que muestrar el id usuarioese el problema 
                //con una lbel ? como muestras en login el usuario el mismo metodo usa 
             
                cmd.Parameters.AddWithValue("@Fecha", DateTime.Today);
                cmd.Parameters.AddWithValue("@Motivo", "Registro inicial de Producto");
                cmd.Parameters.AddWithValue("@Cantidad", txtstock2.Text);
                cmd.Parameters.AddWithValue("@idUsuario",Logins.LOGIN.idusuariovariable);
                cmd.Parameters.AddWithValue("@Tipo", "ENTRADA");
                cmd.Parameters.AddWithValue("@Estado", "CONFIRMADO");
                cmd.Parameters.AddWithValue("@Id_Caja", idCaja);
                cmd.ExecuteNonQuery();
               
           
                con.Close();
                PANELDEPARTAMENTO.Visible = false;
                txtbusca.Text = txtdescripcion.Text;
                buscar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

        }
        private void editar_productos()
        {
            if (txtpreciomayoreo.Text == "0" | txtpreciomayoreo.Text == "") txtapartirde.Text = "0";

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("editar_producto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProducto", TXTIDPRODUCTOOk.Text);
                cmd.Parameters.AddWithValue("@Descripcion", txtdescripcion.Text);
                cmd.Parameters.AddWithValue("@Imagen", ".");

                cmd.Parameters.AddWithValue("@Precio_de_compra", txtcosto.Text);
                cmd.Parameters.AddWithValue("@Precio_de_venta", TXTPRECIODEVENTA2.Text);
                cmd.Parameters.AddWithValue("@Codigo", txtcodigodebarras.Text);
                cmd.Parameters.AddWithValue("@A_partir_de", txtapartirde.Text);
                cmd.Parameters.AddWithValue("@Impuesto", 0);
                cmd.Parameters.AddWithValue("@Precio_mayoreo", txtpreciomayoreo.Text);
                if (porunidad.Checked == true) txtse_vende_a.Text = "Unidad";
                if (agranel.Checked == true) txtse_vende_a.Text = "Granel";

                cmd.Parameters.AddWithValue("@Se_vende_a", txtse_vende_a.Text);
                cmd.Parameters.AddWithValue("@idGrupo", lblIdGrupo.Text);
                if (PANELINVENTARIO.Visible == true)
                {
                    cmd.Parameters.AddWithValue("@Usa_inventario", "SI");
                    cmd.Parameters.AddWithValue("@Stock_minimo", txtstockminimo.Text);
                    cmd.Parameters.AddWithValue("@Stock", txtstock2.Text);

                    if (No_aplica_fecha.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@Fecha_vencimiento", "NO APLICA");
                    }

                    if (No_aplica_fecha.Checked == false)
                    {
                        cmd.Parameters.AddWithValue("@Fecha_vencimiento", txtfechaoka.Text);
                    }


                }
                if (PANELINVENTARIO.Visible == false)
                {
                    cmd.Parameters.AddWithValue("@Usa_inventario", "NO");
                    cmd.Parameters.AddWithValue("@Stock_minimo", 0);
                    cmd.Parameters.AddWithValue("@Fecha_vencimiento", "NO APLICA");
                    cmd.Parameters.AddWithValue("@Stock", "Ilimitado");

                }

                cmd.ExecuteNonQuery();


                con.Close();
                PANELDEPARTAMENTO.Visible = false;
                txtbusca.Text = txtdescripcion.Text;
                buscar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

        }
        private void buscar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();

                da = new SqlDataAdapter("Buscar_Producto_por_Descripcion", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Letra", txtbusca.Text);
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();

                datalistado.Columns[2].Visible = false;
                datalistado.Columns[7].Visible = false;
                datalistado.Columns[10].Visible = false;
                datalistado.Columns[15].Visible = false;
                datalistado.Columns[16].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }

            Logica.BasesPCProgram.Multilinea(ref datalistado);
            sumar_costo_de_inventario_CONTAR_PRODUCTOS();
        }
        internal void sumar_costo_de_inventario_CONTAR_PRODUCTOS()
        {

            //string resultado;
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
            //SqlCommand da = new SqlCommand("buscar_USUARIO_por_correo", con);
            //da.CommandType = CommandType.StoredProcedure;
            //da.Parameters.AddWithValue("@correo", txtcorreo.Text);

            //con.Open();
            //lblResultadoContraseña.Text = Convert.ToString(da.ExecuteScalar());
            //con.Close();

            string resultado;
            string queryMoneda;
            queryMoneda = "SELECT Moneda  FROM Empresa";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Conexiones.CADMaestra.conexion;
            SqlCommand comMoneda = new SqlCommand(queryMoneda, con);
            try
            {
                con.Open();
                resultado = Convert.ToString(comMoneda.ExecuteScalar()); //asignamos el valor del importe
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                resultado = "";
            }

            string importe;
            string query;
            query = "SELECT CONVERT(NUMERIC(18,2),sum(Productos.Precio_de_compra * Stock )) as suma FROM  Productos where  Usa_inventario ='SI'";

            SqlCommand com = new SqlCommand(query, con);
            try
            {
                con.Open();
                importe = Convert.ToString(com.ExecuteScalar()); //asignamos el valor del importe
                con.Close();
                lblcosto_inventario.Text = resultado + " " + importe;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);

                lblcosto_inventario.Text = resultado + " " + 0;
            }

            string conteoresultado;
            string querycontar;
            querycontar = "select count(idProducto) from Productos ";
            SqlCommand comcontar = new SqlCommand(querycontar, con);
            try
            {
                con.Open();
                conteoresultado = Convert.ToString(comcontar.ExecuteScalar()); //asignamos el valor del importe
                con.Close();
                lblcantidad_productos.Text = conteoresultado;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);

                conteoresultado = "";
                lblcantidad_productos.Text = "0";
            }

        }
        private void CheckInventarios_CheckedChanged(object sender, EventArgs e)
        {


       
            if (TXTIDPRODUCTOOk.Text != "0" & Convert.ToDouble(txtstock2.Text)  > 0)
            {
                if (CheckInventarios.Checked == false)
                {
                    MessageBox.Show("Hay Aun En Stock, Dirijete al Modulo Inventarios para Ajustar el Inventario a cero", "Stock Existente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    PANELINVENTARIO.Visible = true;
                    CheckInventarios.Checked = true;
                }
            }

            if (TXTIDPRODUCTOOk.Text != "0" & Convert.ToDouble(txtstock2.Text) == 0)
            {
                if (CheckInventarios.Checked == false)
                {
                    PANELINVENTARIO.Visible = false;

                }
            }

            if (TXTIDPRODUCTOOk.Text == "0" )
            {
                if (CheckInventarios.Checked == false)
                {
                    PANELINVENTARIO.Visible = false;

                }
            }

            if (CheckInventarios.Checked == true)
            {

                PANELINVENTARIO.Visible = true;
            }
           
        }

        private void PANELINVENTARIO_Paint(object sender, PaintEventArgs e)
        {

        }

        private void datalistadoGrupos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datalistadoGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.datalistadoGrupos.Columns["EliminarG"].Index)
            {
                DialogResult result;
                result = MessageBox.Show("¿Realmente desea eliminar este Grupo?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    SqlCommand cmd;
                    try
                    {
                        foreach (DataGridViewRow row in datalistadoGrupos.SelectedRows)
                        {

                            int onekey = Convert.ToInt32(row.Cells["Idline"].Value);

                            try
                            {

                                try
                                {

                                    SqlConnection con = new SqlConnection();
                                    con.ConnectionString = Conexiones.CADMaestra.conexion;
                                    con.Open();
                                    cmd = new SqlCommand("eliminar_grupo", con);
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    cmd.Parameters.AddWithValue("@idLine", onekey);
                                    cmd.ExecuteNonQuery();

                                    con.Close();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message);
                            }

                        }
                        txtgrupo.Text = "GENERAL";
                        mostrar_grupos();
                        lblIdGrupo.Text = datalistadoGrupos.SelectedCells[2].Value.ToString();
                        PanelGRUPOSSELECT.Visible = true;
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            if (e.ColumnIndex == this.datalistadoGrupos.Columns["EditarG"].Index)

            {
            lblIdGrupo.Text = datalistadoGrupos.SelectedCells[2].Value.ToString();
            txtgrupo .Text = datalistadoGrupos.SelectedCells[3].Value.ToString();
            PanelGRUPOSSELECT.Visible = false;
            btnGuardar_grupo.Visible = false;
            BtnGuardarCambios.Visible = true;
            BtnCancelar.Visible = true;
            btnNuevoGrupo.Visible = false;
            }
            if (e.ColumnIndex == this.datalistadoGrupos.Columns["Grupo"].Index)
            {
                lblIdGrupo.Text = datalistadoGrupos.SelectedCells[2].Value.ToString();
                txtgrupo.Text = datalistadoGrupos.SelectedCells[3].Value.ToString();
                PanelGRUPOSSELECT.Visible = false;
                btnGuardar_grupo.Visible = false;
                BtnGuardarCambios.Visible = false;
                BtnCancelar.Visible = false;
                btnNuevoGrupo.Visible = true;
                if ( lblEstadoCodigo.Text == "NUEVO")
                    {
                    GENERAR_CODIGO_DE_BARRAS_AUTOMATICO();
                    }

            }


        }
        private void GENERAR_CODIGO_DE_BARRAS_AUTOMATICO()
        {
            Double resultado;
            string queryMoneda;
            queryMoneda = "SELECT max(idProducto)  FROM Productos";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Conexiones.CADMaestra.conexion;
            SqlCommand comMoneda = new SqlCommand(queryMoneda, con);
            try
            {
                con.Open();
                resultado = Convert.ToDouble(comMoneda.ExecuteScalar()) + 1; 
                con.Close();
            }
            catch (Exception ex)
            {
                resultado = 1;
            }

            string Cadena = txtgrupo.Text;
            string[] Palabra;
            String espacio=" ";
            Palabra = Cadena.Split(Convert.ToChar(espacio));
            try
            {
    
                txtcodigodebarras.Text = resultado + Palabra[0].Substring(0, 2) + 369;
            }
            catch (Exception ex)
            {
            }
        }
        private void mostrar_descripcion_produco_sin_repetir()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();

                da = new SqlDataAdapter("mostrar_descripcion_producto_sin_repetir", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Buscar", txtdescripcion.Text);
                da.Fill(dt);
                DATALISTADO_PRODUCTOS_OKA.DataSource = dt;
                con.Close();

                datalistado.Columns[1].Width = 500;
          

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

          

        }
        private void contar()
        {
            int x;

            x = DATALISTADO_PRODUCTOS_OKA.Rows.Count;
            txtcontador  = (x);

        }
        private void txtdescripcion_TextChanged_1(object sender, EventArgs e)
        {
           
           
        }

        private void DATALISTADO_PRODUCTOS_OKA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DATALISTADO_PRODUCTOS_OKA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtdescripcion.Text = DATALISTADO_PRODUCTOS_OKA.SelectedCells[1].Value.ToString();
                DATALISTADO_PRODUCTOS_OKA.Visible = false;
            }
            catch (Exception ex)
            {

            }
        }
        bool SECUENCIA = true;
        private void txtcosto_TextChanged_1(object sender, EventArgs e)
        {
            //if (SECUENCIA == true)
            //{
            //    txtcosto .Text = txtcosto.Text + ".";
            //    SECUENCIA = false;
            //}
            //else
            //{
            //    return;

            //}
        }

    
        private void txtcosto_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //{
            //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            //    {
            //        e.Handled = true;
            //    }

            //    if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            //    {
            //        e.Handled = true;
            //    }

            //}
            //if ((e.KeyChar != '.') || (e.KeyChar != ',')) 
            //{
            //    //char letras2 = '.';
                
            //    string CultureName = Thread.CurrentThread.CurrentCulture.Name;
            //    CultureInfo ci = new CultureInfo(CultureName);
                
            //        // Forcing use of decimal separator for numerical values
            //        ci.NumberFormat.NumberDecimalSeparator = ".";
            //        Thread.CurrentThread.CurrentCulture = ci;
            //    //e.KeyChar = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = (0);
            //}
            //Separador_de_Numeros(txtcosto, e);
        }

        public static void Separador_de_Numeros(System.Windows.Forms.TextBox CajaTexto, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (!(e.KeyChar == CajaTexto.Text.IndexOf('.')))
            {
                e.Handled = true;
            }


            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == ',')
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;

            }

        }

        private void txtbusca_TextChanged(object sender, EventArgs e)
        {
            buscar();
        }

        private void TGUARDARCAMBIOS_Click_1(object sender, EventArgs e)
        {
            
        }

        private void datalistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        internal void proceso_para_obtener_datos_de_productos()
        {
            try
            {

                Panel25.Enabled = true;
                DATALISTADO_PRODUCTOS_OKA.Visible = false;

                Panel6.Visible = false;
                TGUARDAR.Visible = false;
                TGUARDARCAMBIOS.Visible = true;
                PANELDEPARTAMENTO.Visible = true;


                btnNuevoGrupo.Visible = true;
                TXTIDPRODUCTOOk.Text = datalistado.SelectedCells[2].Value.ToString();
                lblEstadoCodigo.Text = "EDITAR";
                PanelGRUPOSSELECT.Visible = false;
                BtnGuardarCambios.Visible = false;
                btnGuardar_grupo.Visible = false;
                BtnCancelar.Visible = false;
                btnNuevoGrupo.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                
                txtidproducto.Text = datalistado.SelectedCells[2].Value.ToString();
                txtcodigodebarras.Text = datalistado.SelectedCells[3].Value.ToString();
                txtgrupo.Text = datalistado.SelectedCells[4].Value.ToString();

                txtdescripcion.Text = datalistado.SelectedCells[5].Value.ToString();
                txtnumeroigv.Text = datalistado.SelectedCells[6].Value.ToString();
                lblIdGrupo.Text = datalistado.SelectedCells[15].Value.ToString();
               

                LBL_ESSERVICIO.Text = datalistado.SelectedCells[7].Value.ToString();



                txtcosto.Text = datalistado.SelectedCells[8].Value.ToString();
                txtpreciomayoreo.Text = datalistado.SelectedCells[9].Value.ToString();
                LBLSEVENDEPOR.Text = datalistado.SelectedCells[10].Value.ToString();
                if (LBLSEVENDEPOR.Text == "Unidad")
                {
                    porunidad.Checked = true;

                }
                if (LBLSEVENDEPOR.Text == "Granel")
                {
                    agranel.Checked = true;
                }
                txtstockminimo.Text = datalistado.SelectedCells[11].Value.ToString();
                lblfechasvenci.Text = datalistado.SelectedCells[12].Value.ToString();
                if (lblfechasvenci.Text == "NO APLICA")
                {
                    No_aplica_fecha.Checked = true;
                }
                if (lblfechasvenci.Text != "NO APLICA")
                {
                    No_aplica_fecha.Checked = false;
                }
                txtstock2.Text = datalistado.SelectedCells[13].Value.ToString();
                TXTPRECIODEVENTA2.Text = datalistado.SelectedCells[14].Value.ToString();
                try
                {

                    double TotalVentaVariabledouble;
                    double TXTPRECIODEVENTA2V= Convert.ToDouble(TXTPRECIODEVENTA2.Text);
                    double txtcostov = Convert.ToDouble(txtcosto.Text);

                    TotalVentaVariabledouble = ((TXTPRECIODEVENTA2V - txtcostov) / (txtcostov)) * 100;

                    if (TotalVentaVariabledouble > 0)
                    {
                      this.txtPorcentajeGanancia.Text = Convert.ToString(TotalVentaVariabledouble);
                    }
                    else
                    {
                        //Me.txtPorcentajeGanancia.Text = 0
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                if (LBL_ESSERVICIO.Text == "SI")
                {
                   
                    PANELINVENTARIO.Visible = true;
                    PANELINVENTARIO.Visible = true;
                    txtstock2.ReadOnly = true;
                    CheckInventarios.Checked = true;

                }
                if (LBL_ESSERVICIO.Text == "NO")
                {
                    CheckInventarios.Checked = false;

                    PANELINVENTARIO.Visible = false;
                    PANELINVENTARIO.Visible = false;
                    txtstock2.ReadOnly = true;
                    txtstock2.Text = "0";
                    txtstockminimo.Text = "0";
                    No_aplica_fecha.Checked = true;
                    txtstock2.ReadOnly = false;
                }
                txtapartirde.Text = datalistado.SelectedCells[16].Value.ToString ();


                PanelGRUPOSSELECT.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.datalistado.Columns["Eliminar"].Index)
            {
                DialogResult result;
                result = MessageBox.Show("¿REALMENTE DESEA ELIMINAR ESTE PRODUCTO?", "ELIMINANDO ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    //SqlCommand cmd;
                    try
                    {
                        foreach (DataGridViewRow row in datalistado.SelectedRows)
                        {

                            int onekey = Convert.ToInt32(row.Cells["idProducto"].Value);
                                try
                                {

                                    SqlConnection con = new SqlConnection();
                                    con.ConnectionString = Conexiones.CADMaestra.conexion;
                                    con.Open();
                                    SqlCommand cmd = new SqlCommand();
                                    cmd = new SqlCommand("eliminar_producto", con);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@idProducto", onekey);
                                    cmd.ExecuteNonQuery();
                                    con.Close();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

                           

                        }
                        buscar();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.StackTrace);
                    }



                }

               

            }
                if (e.ColumnIndex == this.datalistado.Columns["Editar"].Index)
                {
                    proceso_para_obtener_datos_de_productos();
                }

        }

        private void txtstock2_MouseClick_1(object sender, MouseEventArgs e)
        {
            
        }

        private void ToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            DATALISTADO_PRODUCTOS_OKA.Visible = false;
        }

        private void btnGenerarCodigo_Click_1(object sender, EventArgs e)
        {
            GENERAR_CODIGO_DE_BARRAS_AUTOMATICO();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Panel25_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPorcentajeGanancia_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void TimerCalucular_porcentaje_ganancia_Tick(object sender, EventArgs e)
        {
            TimerCalucular_porcentaje_ganancia.Stop();
            try
            {


                double TotalVentaVariabledouble;
                double TXTPRECIODEVENTA2V = Convert.ToDouble(TXTPRECIODEVENTA2.Text);
                double txtcostov = Convert.ToDouble(txtcosto.Text);

                TotalVentaVariabledouble = ((TXTPRECIODEVENTA2V - txtcostov) / (txtcostov)) * 100;

                if (TotalVentaVariabledouble > 0)
                {
                    this.txtPorcentajeGanancia.Text = Convert.ToString(TotalVentaVariabledouble);
                }
                else
                {
                    //Me.txtPorcentajeGanancia.Text = 0
                }


            }
            catch (Exception)
            {
               
            }
        }

        private void TimerCalcular_precio_venta_Tick(object sender, EventArgs e)
        {
            TimerCalcular_precio_venta.Stop();

            try
            {             
                double TotalVentaVariabledouble;
                double txtcostov = Convert.ToDouble(txtcosto.Text);
                double txtPorcentajeGananciav = Convert.ToDouble(txtPorcentajeGanancia.Text);

                TotalVentaVariabledouble = txtcostov + ((txtcostov * txtPorcentajeGananciav) / 100);

                if (TotalVentaVariabledouble > 0 & txtPorcentajeGanancia.Focused == true)
                {
                    this.TXTPRECIODEVENTA2.Text = Convert.ToString(TotalVentaVariabledouble);
                }
                else
                {
                    //Me.txtPorcentajeGanancia.Text = 0
                }
            }
            catch (Exception)
            {

            }
        }

        private void datalistado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            proceso_para_obtener_datos_de_productos();
        }

        private void ToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            Formularios.Productos.Asistente_de_ImportacionExcel frmAsistenteExcel = new Asistente_de_ImportacionExcel();
            frmAsistenteExcel.ShowDialog();
        }

        private void Productos_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            Formularios.Configuracion.Panel_Configuraciones frmpanel_Configuraciones = new Configuracion.Panel_Configuraciones();
            frmpanel_Configuraciones.ShowDialog();
        }

        private void txtdescripcion_TextChanged(object sender, EventArgs e)
        {
            mostrar_descripcion_produco_sin_repetir();
            contar();


            if (txtcontador == 0)
            {
                DATALISTADO_PRODUCTOS_OKA.Visible = false;
            }
            if (txtcontador > 0)
            {
                DATALISTADO_PRODUCTOS_OKA.Visible = true;
            }
            if (TGUARDAR.Visible == false)
            {
                DATALISTADO_PRODUCTOS_OKA.Visible = false;
            }
        }

        private void txtcosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtPorcentajeGanancia_TextChanged(object sender, EventArgs e)
        {
            TimerCalucular_porcentaje_ganancia.Stop();

            TimerCalcular_precio_venta.Start();
            TimerCalucular_porcentaje_ganancia.Stop();
        }

        private void txtgrupo_TextChanged_1(object sender, EventArgs e)
        {
            mostrar_grupos();
        }

        private void txtstock2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (TXTIDPRODUCTOOk.Text != "0")
                {
                    Tmensajes.SetToolTip(txtstock2, "Para modificar el Stock Hazlo desde el Modulo de Inventarios");
                    Tmensajes.ToolTipTitle = "Accion denegada";
                    Tmensajes.ToolTipIcon = ToolTipIcon.Info;

                }
            }
            catch (Exception)
            {

            }
        }

        private void TGUARDARCAMBIOS_Click(object sender, EventArgs e)
        {
            double txtpreciomayoreoV = Convert.ToDouble(txtpreciomayoreo.Text);

            double txtapartirdeV = Convert.ToDouble(txtapartirde.Text);
            double txtcostoV = Convert.ToDouble(txtcosto.Text);
            double TXTPRECIODEVENTA2V = Convert.ToDouble(TXTPRECIODEVENTA2.Text);
            if (txtpreciomayoreo.Text == "") txtpreciomayoreo.Text = "0";
            if (txtapartirde.Text == "") txtapartirde.Text = "0";
            //TXTPRECIODEVENTA2.Text = TXTPRECIODEVENTA2.Text.Replace(lblmoneda.Text + " ", "");
            //TXTPRECIODEVENTA2.Text = System.String.Format(((decimal)TXTPRECIODEVENTA2.Text), "##0.00");
            if ((txtpreciomayoreoV > 0 & Convert.ToDouble(txtapartirde.Text) > 0) | (txtpreciomayoreoV == 0 & txtapartirdeV == 0))
            {
                if (txtcostoV >= TXTPRECIODEVENTA2V)
                {

                    DialogResult result;
                    result = MessageBox.Show("El precio de Venta es menor que el COSTO, Esto Te puede Generar Perdidas", "Producto con Perdidas", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (result == DialogResult.OK)
                    {
                        editar_productos();
                    }
                    else
                    {
                        TXTPRECIODEVENTA2.Focus();
                    }


                }
                else if (txtcostoV < TXTPRECIODEVENTA2V)
                {
                    editar_productos();
                }
            }
            else if (txtpreciomayoreoV != 0 | txtapartirdeV != 0)
            {
                MessageBox.Show("Estas configurando Precio mayoreo, debes completar los campos de Precio mayoreo y A partir de, si no deseas configurarlo dejalos en blanco", "Datos incompletos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            }
        }

        private void TGUARDAR_Click(object sender, EventArgs e)
        {
            double txtpreciomayoreoV = Convert.ToDouble(txtpreciomayoreo.Text);

            double txtapartirdeV = Convert.ToDouble(txtapartirde.Text);
            double txtcostoV = Convert.ToDouble(txtcosto.Text);
            double TXTPRECIODEVENTA2V = Convert.ToDouble(TXTPRECIODEVENTA2.Text);
            if (txtpreciomayoreo.Text == "") txtpreciomayoreo.Text = "0";
            if (txtapartirde.Text == "") txtapartirde.Text = "0";
            //TXTPRECIODEVENTA2.Text = TXTPRECIODEVENTA2.Text.Replace(lblmoneda.Text + " ", "");
            //TXTPRECIODEVENTA2.Text = System.String.Format(((decimal)TXTPRECIODEVENTA2.Text), "##0.00");
            if ((txtpreciomayoreoV > 0 & Convert.ToDouble(txtapartirde.Text) > 0) | (txtpreciomayoreoV == 0 & txtapartirdeV == 0))
            {
                if (txtcostoV >= TXTPRECIODEVENTA2V)
                {

                    DialogResult result;
                    result = MessageBox.Show("El precio de Venta es menor que el COSTO, Esto Te puede Generar Perdidas", "Producto con Perdidas", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (result == DialogResult.OK)
                    {
                        insertar_productos();
                    }
                    else
                    {
                        TXTPRECIODEVENTA2.Focus();
                    }


                }
                else if (txtcostoV < TXTPRECIODEVENTA2V)
                {
                    insertar_productos();
                }
            }
            else if (txtpreciomayoreoV != 0 | txtapartirdeV != 0)
            {
                MessageBox.Show("Estas configurando Precio mayoreo, debes completar los campos de Precio mayoreo y A partir de, si no deseas configurarlo dejalos en blanco", "Datos incompletos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PANELDEPARTAMENTO.Visible = false;
        }

        private void txtcosto_KeyPress_2(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != '.') || (e.KeyChar != ','))
            {
                //char letras2 = '.';

                string CultureName = Thread.CurrentThread.CurrentCulture.Name;
                CultureInfo ci = new CultureInfo(CultureName);

                // Forcing use of decimal separator for numerical values
                ci.NumberFormat.NumberDecimalSeparator = ".";
                Thread.CurrentThread.CurrentCulture = ci;
                //e.KeyChar = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = (0);
            }
            Separador_de_Numeros(txtcosto, e);
        }
    }
}
