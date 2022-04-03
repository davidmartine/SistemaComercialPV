using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Globalization;
using Aplicacion_Comercial.Datos;
using System.IO.Ports;
using Aplicacion_Comercial.Logica;

namespace Aplicacion_Comercial.Formularios.VENTAS_MENU_PRINCIPAL
{
    public partial class Ventas_Menu_Principal : Form
    {
        public Ventas_Menu_Principal()
        {
            InitializeComponent();
        }

        int contador_stock_detalle_de_venta;
        int idproducto;
        int idClienteEstandar;
        public static int idusuario_que_inicio_sesion;
        public static int idVenta;
        int iddetalleventa;
        int Contador;
        public static double txtpantalla;
        double lblStock_de_Productos;
        public static double total;
        public static int Id_caja;
        string SerialPC;
        string sevendePor;
        string txtventagenerada;
        double txtprecio_unitario;
        double Cantidad;
        string usainventarios;
        string Inventarios;
        Panel panel_mostrador_de_productos = new Panel();
        string ResultadoLicencia;
        string FechaFinal;
        string Tema;
        int ContadorVentasEspera;
        string Ip;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void VENTAS_MENU_PRINCIPALOK_Load(object sender, EventArgs e)
        {
            Validar_licencia();
            Logica.BasesPCProgram.cambiar_idioma_regional();
            Logica.BasesPCProgram.obtener_serial_pc(ref SerialPC);
            Datos.ObtenerDatos.obtener_id_caja_por_serial(ref Id_caja);
            MOSTRAR_TIPO_DE_BUSQUEDA();
            Obtener_id_de_cliente_estandar();
            Datos.ObtenerDatos.mostrar_inicios_de_sesion(ref idusuario_que_inicio_sesion);

            if (Tipo_de_busqueda == "TECLADO")
            {
                //lbltipodebusqueda2.Text = "Buscar con TECLADO";
                BTNLECTORA.BackColor = Color.WhiteSmoke;
                BTNTECLADO.BackColor = Color.LightGreen;
            }
            else
            {
                //lbltipodebusqueda2.Text = "Buscar con LECTORA de Codigos de Barras";
                BTNLECTORA.BackColor = Color.LightGreen;
                BTNTECLADO.BackColor = Color.WhiteSmoke;
            }
            validar_tema_caja();
            Limpiar_para_venta_nueva();
            obtener_ip_local();


        }
        private void obtener_ip_local()
        {

            this.Text = Logica.BasesPCProgram.ObtenerIP(ref Ip);

        }

        private void validar_tema_caja()
        {
             ObtenerDatos.mostrar_tema_caja(ref Tema);
            if(Tema== "REDENTOR")
            {
                tema_claro();
                IndicadorTema.Checked = false;
            }
            else
            {
                tema_oscuro();
                IndicadorTema.Checked = true;
            }
        }

        private void Validar_licencia()
        {

            CADLicencias funcion = new CADLicencias();
            funcion.Validar_licencias(ref ResultadoLicencia, ref FechaFinal);
            if (ResultadoLicencia == "VENCIDA")
            {
                Datos.CADLicencias.Editar_marcas_vencidas();
                this.Dispose();
                Formularios.Licencias_y_Membresias.Licencias_Membresias frmlicencias = new Licencias_y_Membresias.Licencias_Membresias();
                frmlicencias.ShowDialog();
            }
        }

        private void Limpiar_para_venta_nueva()
        {
            idVenta = 0;
            Listarproductosagregados();
            txtventagenerada = "VENTA NUEVA";
            sumar();
            PanelEnespera.Visible = false;
            panelBienvenida.Visible = true;
            PanelOperaciones.Visible = false;
            contar_ventas_espera();
        }


        private void sumar()
        {
            try
            {

                int x;
                x = datalistadoDetalleVenta.Rows.Count;
                if (x == 0)
                {
                    txt_total_suma.Text = "0.00";
                }

                double totalpagar;
                totalpagar = 0;
                foreach (DataGridViewRow fila in datalistadoDetalleVenta.Rows)
                {

                    totalpagar += Convert.ToDouble(fila.Cells["Importe"].Value);
                    txt_total_suma.Text = Convert.ToString(totalpagar);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void LISTAR_PRODUCTOS_Abuscador()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                Conexiones.CADMaestra.abrir();
                da = new SqlDataAdapter("Buscar_Producto_OK", Conexiones.CADMaestra.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@LetraB", txtbuscar.Text);
                da.Fill(dt);
                DATALISTADO_PRODUCTOS_OKA.DataSource = dt;
                Conexiones.CADMaestra.cerrar();
                DATALISTADO_PRODUCTOS_OKA.Columns[0].Visible = false;
                DATALISTADO_PRODUCTOS_OKA.Columns[1].Visible = false;
                DATALISTADO_PRODUCTOS_OKA.Columns[2].Width = 600;
                DATALISTADO_PRODUCTOS_OKA.Columns[3].Visible = false;
                DATALISTADO_PRODUCTOS_OKA.Columns[4].Visible = false;
                DATALISTADO_PRODUCTOS_OKA.Columns[5].Visible = false;
                DATALISTADO_PRODUCTOS_OKA.Columns[6].Visible = false;
                DATALISTADO_PRODUCTOS_OKA.Columns[7].Visible = false;
                DATALISTADO_PRODUCTOS_OKA.Columns[8].Visible = false;
                DATALISTADO_PRODUCTOS_OKA.Columns[9].Visible = false;
                DATALISTADO_PRODUCTOS_OKA.Columns[10].Visible = false;
            }
            catch (Exception ex)
            {
                Conexiones.CADMaestra.cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }



        string Tipo_de_busqueda;
        private void MOSTRAR_TIPO_DE_BUSQUEDA()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Conexiones.CADMaestra.conexion;
            SqlCommand com = new SqlCommand("SELECT Modo_de_Busqueda FROM Empresa", con);

            try
            {
                con.Open();
                Tipo_de_busqueda = Convert.ToString(com.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }


        private void btnTecladoVirtual_Click(object sender, EventArgs e)
        {

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {

        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {

        }



        private void MenuStrip9_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }



        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            if (Tipo_de_busqueda == "LECTORA")
            {
                validar_ventas_nuevas();
                //lbltipodebusqueda2.Visible = false;
                TimerBUSCADORcodigodebarras.Start();
            }
            else if (Tipo_de_busqueda == "TECLADO")
            {
                if (txtbuscar.Text == "")
                {
                    ocultar_mostrar_productos();

                }
                else if (txtbuscar.Text != "")
                {
                    mostrar_productos();
                }
                LISTAR_PRODUCTOS_Abuscador();

            }

        }
        private void mostrar_productos()
        {
            // panel_mostrador_de_productos.Size =new System.Drawing.Size(294, 40);
            // panel_mostrador_de_productos.BackColor = Color.White;
            //panel_mostrador_de_productos.Location = new Point(panelMostradorProductos.Location.X, panelMostradorProductos.Location.Y);
            //panel_mostrador_de_productos.Size = new System.Drawing.Size(294, 40);
            //panel_mostrador_de_productos.Visible = true;
            DATALISTADO_PRODUCTOS_OKA.Visible = true;
            DATALISTADO_PRODUCTOS_OKA.Dock = DockStyle.Fill;
            DATALISTADO_PRODUCTOS_OKA.BackgroundColor = Color.White;
            DATALISTADO_PRODUCTOS_OKA.BringToFront();
            DATALISTADO_PRODUCTOS_OKA.Size = new System.Drawing.Size(294, 40);
            //lbltipodebusqueda2.Visible = false;
            //panel_mostrador_de_productos.Controls.Add(DATALISTADO_PRODUCTOS_OKA);

            // this.Controls.Add(panel_mostrador_de_productos);
            //panel_mostrador_de_productos.BringToFront();
        }
        private void ocultar_mostrar_productos()
        {
            //panel_mostrador_de_productos.Visible = false;
            DATALISTADO_PRODUCTOS_OKA.Visible = false;
            //lbltipodebusqueda2.Visible = true;
        }
        private void DATALISTADO_PRODUCTOS_OKA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DATALISTADO_PRODUCTOS_OKA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            validar_ventas_nuevas();
            txtbuscar.Text = DATALISTADO_PRODUCTOS_OKA.SelectedCells[10].Value.ToString();
            idproducto = Convert.ToInt32(DATALISTADO_PRODUCTOS_OKA.SelectedCells[1].Value.ToString());
            vender_por_teclado();

        }

        private void validar_ventas_nuevas()
        {
            if (datalistadoDetalleVenta.RowCount == 0)
            {
                Limpiar_para_venta_nueva();
            }
        }

        private void vender_por_teclado()
        {
            // mostramos los registros del producto en el detalle de venta
            mostrar_stock_de_detalle_de_ventas();
            contar_stock_detalle_ventas();

            if (contador_stock_detalle_de_venta == 0)
            {
                // Si es producto no esta agregado a las ventas se tomara el Stock de la tabla Productos
                lblStock_de_Productos = Convert.ToDouble(DATALISTADO_PRODUCTOS_OKA.SelectedCells[4].Value.ToString());
            }
            else
            {
                //en caso que el producto ya este agregado al detalle de venta se va a extraer el Stock de la tabla Detalle_de_venta
                lblStock_de_Productos = Convert.ToDouble(datalistado_stock_detalle_venta.SelectedCells[1].Value.ToString());
            }
            //Extraemos los datos del producto de la tabla Productos directamente
            usainventarios = DATALISTADO_PRODUCTOS_OKA.SelectedCells[3].Value.ToString();
            lbldescripcion.Text = DATALISTADO_PRODUCTOS_OKA.SelectedCells[9].Value.ToString();
            lblcodigo.Text = DATALISTADO_PRODUCTOS_OKA.SelectedCells[10].Value.ToString();
            lblcosto.Text = DATALISTADO_PRODUCTOS_OKA.SelectedCells[5].Value.ToString();
            sevendePor = DATALISTADO_PRODUCTOS_OKA.SelectedCells[8].Value.ToString();
            txtprecio_unitario = Convert.ToDouble(DATALISTADO_PRODUCTOS_OKA.SelectedCells[6].Value.ToString());
            //Preguntamos que tipo de producto sera el que se agrege al detalle de venta
            if (sevendePor == "Granel")
            {
                vender_a_granel();
            }
            else if (sevendePor == "Unidad")
            {
                txtpantalla = 1;
                vender_por_unidad();
            }

        }
        private void vender_a_granel()
        {

            Formularios.VENTAS_MENU_PRINCIPAL.Cantidad_Granel frm = new Cantidad_Granel();
            frm.preciounitario = txtprecio_unitario;
            frm.FormClosing += Frm_FormClosing;
            frm.ShowDialog();


        }


        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ejecutar_ventas_a_granel();
        }



        public void ejecutar_ventas_a_granel()
        {

            ejecutar_insertar_ventas();
            if (txtventagenerada == "VENTA GENERADA")
            {
                insertar_detalle_venta();
                Listarproductosagregados();
                txtbuscar.Text = "";
                txtbuscar.Focus();

            }

        }
        private void Obtener_id_de_cliente_estandar()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Conexiones.CADMaestra.conexion;
            SqlCommand com = new SqlCommand("SELECT idCliente FROM Clientes WHERE Estado='0'", con);
            try
            {
                con.Open();
                idClienteEstandar = Convert.ToInt32(com.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

        }

        private void Obtener_id_venta_recien_Creada()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Conexiones.CADMaestra.conexion;
            SqlCommand com = new SqlCommand("Mostrar_idVenta_por_idCaja", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id_Caja", Id_caja);
            try
            {
                con.Open();
                idVenta = Convert.ToInt32(com.ExecuteScalar());
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Mostrar_idVenta_por_idCaja");
            }
        }
        private void vender_por_unidad()
        {
            try
            {
                if (txtbuscar.Text == DATALISTADO_PRODUCTOS_OKA.SelectedCells[10].Value.ToString())
                {
                    DATALISTADO_PRODUCTOS_OKA.Visible = true;
                    ejecutar_insertar_ventas();
                    if (txtventagenerada == "VENTA GENERADA")
                    {
                        insertar_detalle_venta();
                        Listarproductosagregados();
                        txtbuscar.Text = "";
                        txtbuscar.Focus();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void ejecutar_insertar_ventas()
        {
            if (txtventagenerada == "VENTA NUEVA")
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = Conexiones.CADMaestra.conexion;
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand("Insertar_Ventas", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUsuario", idusuario_que_inicio_sesion);
                    cmd.Parameters.AddWithValue("@Id_Caja", Id_caja);
                    cmd.Parameters.AddWithValue("@idCliente", idClienteEstandar);
                    cmd.Parameters.AddWithValue("@Numero_de_Documento", 0);
                    cmd.Parameters.AddWithValue("@Fecha_de_Venta", DateTime.Today);
                    cmd.Parameters.AddWithValue("@Monto_Total", 0);
                    cmd.Parameters.AddWithValue("@Tipo_de_Pago", 0);
                    cmd.Parameters.AddWithValue("@Estado", "EN ESPERA");
                    cmd.Parameters.AddWithValue("@Impuesto", 0);
                    cmd.Parameters.AddWithValue("@Comprobante", 0);
                    cmd.Parameters.AddWithValue("@Fecha_de_Pago", DateTime.Today);
                    cmd.Parameters.AddWithValue("@Accion", "VENTA");
                    cmd.Parameters.AddWithValue("@Saldo", 0);
                    cmd.Parameters.AddWithValue("@Pago_con", 0);
                    cmd.Parameters.AddWithValue("@Porcentaje_Impuesto", 0);
                    cmd.Parameters.AddWithValue("@Referencia_Tarjeta", 0);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Obtener_id_venta_recien_Creada();
                    txtventagenerada = "VENTA GENERADA";
                    mostrar_panel_de_Cobro();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }

            }
        }
        private void mostrar_panel_de_Cobro()
        {
            panelBienvenida.Visible = false;
            PanelOperaciones.Visible = true;
        }
        private void Listarproductosagregados()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                da = new SqlDataAdapter("Mostrar_Productos_a_Ventas", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idVenta", idVenta);
                da.Fill(dt);
                datalistadoDetalleVenta.DataSource = dt;
                con.Close();
                datalistadoDetalleVenta.Columns[0].Width = 50;
                datalistadoDetalleVenta.Columns[1].Width = 50;
                datalistadoDetalleVenta.Columns[2].Width = 50;
                datalistadoDetalleVenta.Columns[3].Visible = false;
                datalistadoDetalleVenta.Columns[4].Width = 250;
                datalistadoDetalleVenta.Columns[5].Width = 100;
                datalistadoDetalleVenta.Columns[6].Width = 100;
                datalistadoDetalleVenta.Columns[7].Width = 100;
                datalistadoDetalleVenta.Columns[8].Visible = false;
                datalistadoDetalleVenta.Columns[9].Visible = false;
                datalistadoDetalleVenta.Columns[10].Visible = false;
                datalistadoDetalleVenta.Columns[11].Width = datalistadoDetalleVenta.Width - (datalistadoDetalleVenta.Columns[0].Width - datalistadoDetalleVenta.Columns[1].Width - datalistadoDetalleVenta.Columns[2].Width -
                datalistadoDetalleVenta.Columns[4].Width - datalistadoDetalleVenta.Columns[5].Width - datalistadoDetalleVenta.Columns[6].Width - datalistadoDetalleVenta.Columns[7].Width);
                datalistadoDetalleVenta.Columns[12].Visible = false;
                datalistadoDetalleVenta.Columns[13].Visible = false;
                datalistadoDetalleVenta.Columns[14].Visible = false;
                datalistadoDetalleVenta.Columns[15].Visible = false;
                datalistadoDetalleVenta.Columns[16].Visible = false;
                datalistadoDetalleVenta.Columns[17].Visible = false;
                datalistadoDetalleVenta.Columns[18].Visible = false;
                if(Tema == "REDENTOR")
                {
                    Logica.BasesPCProgram.Multilinea(ref datalistadoDetalleVenta);
                }
                else
                {
                    Logica.BasesPCProgram.MultilineaTemaOscuro(ref datalistadoDetalleVenta);
                }

                sumar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void insertar_detalle_venta()
        {
            try
            {
                if (usainventarios == "SI")
                {
                    if (lblStock_de_Productos >= txtpantalla)
                    {
                        insertar_detalle_venta_Validado();
                    }
                    else
                    {
                        TimerLABEL_STOCK.Start();
                    }
                }

                else if (usainventarios == "NO")
                {
                    insertar_detalle_venta_SIN_VALIDAR();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

        }
        private void insertar_detalle_venta_Validado()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Insertar_Detalle_Venta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idVenta", idVenta);
                cmd.Parameters.AddWithValue("@idProducto", idproducto);
                cmd.Parameters.AddWithValue("@Cantidad", txtpantalla);
                cmd.Parameters.AddWithValue("@Precio_Unitario", txtprecio_unitario);
                cmd.Parameters.AddWithValue("@Moneda", 0);
                cmd.Parameters.AddWithValue("@Unidad_de_Medida", "Unidad");
                cmd.Parameters.AddWithValue("@Cantidad_Mostrada", txtpantalla);
                cmd.Parameters.AddWithValue("@Estado", "EN ESPERA");
                cmd.Parameters.AddWithValue("@Descripcion", lbldescripcion.Text);
                cmd.Parameters.AddWithValue("@Codigo_Producto", lblcodigo.Text);
                cmd.Parameters.AddWithValue("@Stock", lblStock_de_Productos);
                cmd.Parameters.AddWithValue("@Se_Vende_a", sevendePor);
                cmd.Parameters.AddWithValue("@Costo", lblcosto.Text);
                cmd.Parameters.AddWithValue("@Usa_Inventario", usainventarios);
                cmd.ExecuteNonQuery();
                con.Close();
                disminuir_stock_en_detalle_de_venta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }
        }

        private void insertar_detalle_venta_SIN_VALIDAR()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Insertar_Detalle_Venta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idVenta", idVenta);
                cmd.Parameters.AddWithValue("@idProducto", idproducto);
                cmd.Parameters.AddWithValue("@Cantidad", txtpantalla);
                cmd.Parameters.AddWithValue("@Precio_Unitario", txtprecio_unitario);
                cmd.Parameters.AddWithValue("@Moneda", 0);
                cmd.Parameters.AddWithValue("@Unidad_de_Medida", "Unidad");
                cmd.Parameters.AddWithValue("@Cantidad_Mostrada", txtpantalla);
                cmd.Parameters.AddWithValue("@Estado", "EN ESPERA");
                cmd.Parameters.AddWithValue("@Descripcion", lbldescripcion.Text);
                cmd.Parameters.AddWithValue("@Codigo_Producto", lblcodigo.Text);
                cmd.Parameters.AddWithValue("@Stock", lblStock_de_Productos);
                cmd.Parameters.AddWithValue("@Se_Vende_a", sevendePor);
                cmd.Parameters.AddWithValue("@Costo", lblcosto.Text);
                cmd.Parameters.AddWithValue("@Usa_inventarios", usainventarios);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }
        }

        private void contar_stock_detalle_ventas()
        {
            int x;
            x = datalistado_stock_detalle_venta.Rows.Count;
            contador_stock_detalle_de_venta = (x);
        }
        private void mostrar_stock_de_detalle_de_ventas()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                da = new SqlDataAdapter("Mostrar_Stock_de_Detalle_de_Venta", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idProducto", idproducto);
                da.Fill(dt);
                datalistado_stock_detalle_venta.DataSource = dt;
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }
        }

        private void ejecutar_editar_detalle_venta_sumar()
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                cmd = new SqlCommand("Editar_Datalle_Venta_Sumar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProducto", idproducto);
                cmd.Parameters.AddWithValue("@Cantidad", txtpantalla);
                cmd.Parameters.AddWithValue("@Cantidad_Mostrada", txtpantalla);
                cmd.Parameters.AddWithValue("@idVenta", idVenta);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {


            }

        }
        private void disminuir_stock_en_detalle_de_venta()
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Disminuir_Stock_En_Detalle_De_Venta", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Producto1", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", txtpantalla);
                cmd.ExecuteNonQuery();
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception)
            {


            }
        }
        private void Obtener_datos_del_detalle_de_venta()
        {

            try
            {
                iddetalleventa = Convert.ToInt32(datalistadoDetalleVenta.SelectedCells[9].Value.ToString());
                idproducto = Convert.ToInt32(datalistadoDetalleVenta.SelectedCells[8].Value.ToString());
                sevendePor = datalistadoDetalleVenta.SelectedCells[17].Value.ToString();
                usainventarios = datalistadoDetalleVenta.SelectedCells[16].Value.ToString();
                Cantidad = Convert.ToDouble(datalistadoDetalleVenta.SelectedCells[5].Value);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void editar_detalle_venta_sumar()
        {

            // txtpantalla = 1;
            if (usainventarios == "SI")
            {
                lblStock_de_Productos = Convert.ToDouble(datalistadoDetalleVenta.SelectedCells[15].Value.ToString());
                if (lblStock_de_Productos > 0)
                {

                    ejecutar_editar_detalle_venta_sumar();
                    disminuir_stock_en_detalle_de_venta();
                }
                else
                {
                    TimerLABEL_STOCK.Start();
                }

            }
            else
            {
                ejecutar_editar_detalle_venta_sumar();
            }
            Listarproductosagregados();
        }
        private void editar_detalle_venta_restar()
        {
            //txtpantalla = 1;
            if (usainventarios == "SI")
            {
                ejecutar_editar_detalle_venta_restar();
                aumentar_stock_en_detalle_de_venta();
            }
            else
            {
                ejecutar_editar_detalle_venta_restar();
            }
            Listarproductosagregados();
        }
        private void aumentar_stock_en_detalle_de_venta()
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Aumentar_Stock_En_Detalle_De_Venta", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProducto", idproducto);
                cmd.Parameters.AddWithValue("@Cantidad", txtpantalla);
                cmd.ExecuteNonQuery();
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception)
            {

            }
        }
        private void ejecutar_editar_detalle_venta_restar()
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                cmd = new SqlCommand("Editar_Detalle_Venta_Restar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDetalleVenta", iddetalleventa);
                cmd.Parameters.AddWithValue("@idProducto", idproducto);
                cmd.Parameters.AddWithValue("@Cantidad", txtpantalla);
                cmd.Parameters.AddWithValue("@Cantidad_Mostrada", txtpantalla);
                cmd.Parameters.AddWithValue("@idVenta", idVenta);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void datalistadoDetalleVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Obtener_datos_del_detalle_de_venta();

            if (e.ColumnIndex == this.datalistadoDetalleVenta.Columns["S"].Index)
            {
                txtpantalla = 1;
                editar_detalle_venta_sumar();
            }
            if (e.ColumnIndex == this.datalistadoDetalleVenta.Columns["R"].Index)
            {
                txtpantalla = 1;
                editar_detalle_venta_restar();
                eliminar_ventas();
            }


            if (e.ColumnIndex == this.datalistadoDetalleVenta.Columns["EL"].Index)
            {

                int iddetalle_venta = Convert.ToInt32(datalistadoDetalleVenta.SelectedCells[9].Value);
                try
                {
                    SqlCommand cmd;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = Conexiones.CADMaestra.conexion;
                    con.Open();
                    cmd = new SqlCommand("Eliminar_Detalle_Venta", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idDetalleVenta", iddetalle_venta);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    txtpantalla =Convert.ToDouble(datalistadoDetalleVenta.SelectedCells[5].Value);
                    aumentar_stock_en_detalle_de_venta();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }

                Listarproductosagregados();
                eliminar_ventas();
            }
        }

        private void eliminar_ventas()
        {
            contar_tablas_ventas();
            if (Contador == 0)
            {
                eliminar_venta_al_agregar_productos();
                Limpiar_para_venta_nueva();
            }
        }
        private void eliminar_venta_al_agregar_productos()
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                cmd = new SqlCommand("Eliminar_Venta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idVenta", idVenta);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void contar_tablas_ventas()
        {
            int x;
            x = datalistadoDetalleVenta.Rows.Count;
            Contador = (x);
        }


        private void datalistadoDetalleVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datalistadoDetalleVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Obtener_datos_del_detalle_de_venta();
            if (e.KeyChar == Convert.ToChar("+"))
            {
                editar_detalle_venta_sumar();
            }
            if (e.KeyChar == Convert.ToChar("-"))
            {
                editar_detalle_venta_restar();
                contar_tablas_ventas();
                if (Contador == 0)
                {
                    eliminar_venta_al_agregar_productos();
                    txtventagenerada = "VENTA NUEVA";
                }
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "2";

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "0";
        }

        bool SECUENCIA = true;
        private void btnSeparador_Click(object sender, EventArgs e)
        {
            if (SECUENCIA == true)
            {
                txtmonto.Text = txtmonto.Text + ".";
                SECUENCIA = false;
            }
            else
            {
                return;
            }
        }

        private void txtmonto_TextChanged(object sender, EventArgs e)
        {
            //if (SECUENCIA == true)
            //{
            //    txtmonto.Text = txtmonto.Text + ".";
            //    SECUENCIA = false;
            //}
            //else
            //{
            //    return;
            //}
        }

        private void txtmonto_KeyPress(object sender, KeyPressEventArgs e)
        {

            Logica.BasesPCProgram.separador_de_numeros(txtmonto, e);
        }

        private void btnborrartodo_Click(object sender, EventArgs e)
        {
            txtmonto.Clear();
            SECUENCIA = true;
        }

        private void TimerBUSCADORcodigodebarras_Tick(object sender, EventArgs e)
        {
            TimerBUSCADORcodigodebarras.Stop();
            vender_por_lectora_de_barras();
        }
        private void vender_por_lectora_de_barras()
        {
            try
            {
                if (txtbuscar.Text == "")
                {
                    DATALISTADO_PRODUCTOS_OKA.Visible = false;
                    //lbltipodebusqueda2.Visible = true;
                }
                if (txtbuscar.Text != "")
                {
                    DATALISTADO_PRODUCTOS_OKA.Visible = true;
                    //lbltipodebusqueda2.Visible = false;
                    LISTAR_PRODUCTOS_Abuscador();

                    idproducto = Convert.ToInt32(DATALISTADO_PRODUCTOS_OKA.SelectedCells[1].Value.ToString());
                    mostrar_stock_de_detalle_de_ventas();
                    contar_stock_detalle_ventas();

                    if (contador_stock_detalle_de_venta == 0)
                    {
                        lblStock_de_Productos = Convert.ToDouble(DATALISTADO_PRODUCTOS_OKA.SelectedCells[4].Value.ToString());
                    }
                    else
                    {
                        lblStock_de_Productos = Convert.ToDouble(datalistado_stock_detalle_venta.SelectedCells[1].Value.ToString());
                    }
                    usainventarios = DATALISTADO_PRODUCTOS_OKA.SelectedCells[3].Value.ToString();
                    lbldescripcion.Text = DATALISTADO_PRODUCTOS_OKA.SelectedCells[9].Value.ToString();
                    lblcodigo.Text = DATALISTADO_PRODUCTOS_OKA.SelectedCells[10].Value.ToString();
                    lblcosto.Text = DATALISTADO_PRODUCTOS_OKA.SelectedCells[5].Value.ToString();
                    txtprecio_unitario = Convert.ToDouble(DATALISTADO_PRODUCTOS_OKA.SelectedCells[6].Value.ToString());
                    sevendePor = DATALISTADO_PRODUCTOS_OKA.SelectedCells[8].Value.ToString();
                    if (sevendePor == "Unidad")
                    {
                        txtpantalla = 1;
                        vender_por_unidad();
                    }

                }
                
            }
            catch (Exception)
            {

            }
            
        }
        private void lbltipodebusqueda2_Click(object sender, EventArgs e)
        {

        }
        private void editar_detalle_venta_CANTIDAD()
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                cmd = new SqlCommand("editar_detalle_venta_CANTIDAD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_producto", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", txtmonto.Text);
                cmd.Parameters.AddWithValue("@Cantidad_mostrada", txtmonto.Text);
                cmd.Parameters.AddWithValue("@Id_venta", idVenta);
                cmd.ExecuteNonQuery();
                con.Close();
                Listarproductosagregados();
                txtmonto.Clear();
                txtmonto.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void frm_FormClosed(Object sender, FormClosedEventArgs e)
        {
            Limpiar_para_venta_nueva();
        }

        private void Panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TimerLABEL_STOCK_Tick(object sender, EventArgs e)
        {
            if (ProgressBarETIQUETA_STOCK.Value < 100)
            {
                ProgressBarETIQUETA_STOCK.Value = ProgressBarETIQUETA_STOCK.Value + 10;
                LABEL_STOCK.Visible = true;
                LABEL_STOCK.Dock = DockStyle.Fill;
            }
            else
            {
                LABEL_STOCK.Visible = false;
                LABEL_STOCK.Dock = DockStyle.None;
                ProgressBarETIQUETA_STOCK.Value = 0;
                TimerLABEL_STOCK.Stop();
            }
        }

        private void befectivo_Click_1(object sender, EventArgs e)
        {
            total = Convert.ToDouble(txt_total_suma.Text);
            Formularios.VENTAS_MENU_PRINCIPAL.Medios_De_Pago frmMedios_De_Pago = new Medios_De_Pago();
            frmMedios_De_Pago.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            frmMedios_De_Pago.ShowDialog();
        }

        private void btnINSVarios_Click(object sender, EventArgs e)
        {

        }

        private void btnrestaurar_Click_1(object sender, EventArgs e)
        {
            Formularios.VENTAS_MENU_PRINCIPAL.Ventas_en_Espera frmVentas_En_Espera = new Ventas_en_Espera();
            frmVentas_En_Espera.FormClosing += Frm_FormClosing1;
            frmVentas_En_Espera.ShowDialog();
        }

        private void Frm_FormClosing1(object sender, FormClosingEventArgs e)
        {
            Listarproductosagregados();
            mostrar_panel_de_Cobro();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (datalistadoDetalleVenta.RowCount > 0)
            {
                DialogResult pregunta = MessageBox.Show("¿REALMENTE DESEA ELIMINAR ESTA VENTA?", "ELIMINANDO REGISTROS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (pregunta == DialogResult.OK)
                {
                    Datos.CADEliminarDatos.eliminar_venta(idVenta);
                    Limpiar_para_venta_nueva();
                }
            }


        }

        private void btnespera_Click(object sender, EventArgs e)
        {
            if (datalistadoDetalleVenta.RowCount > 0)
            {
                PanelEnespera.Visible = true;
                PanelEnespera.BringToFront();
                PanelEnespera.Dock = DockStyle.Fill;
                txtnombre.Clear();
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            ocularPanelenEspera();
        }

        private void ocularPanelenEspera()
        {
            PanelEnespera.Visible = false;
            PanelEnespera.Dock = DockStyle.None;
        }
        private void btnGuardarEspera_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtnombre.Text))
            {
                editarVentaEspera();
            }
            else
            {
                MessageBox.Show("Ingrese una referencia");
            }

        }
        private void editarVentaEspera()

        {
            Datos.CADEditarDatos.ingresar_nombre_a_venta_en_espera(idVenta, txtnombre.Text);
            Limpiar_para_venta_nueva();
            ocularPanelenEspera();
        }
        private void btnAutomaticoEspera_Click(object sender, EventArgs e)
        {
            txtnombre.Text = "Ticket" + idVenta;
            editarVentaEspera();
        }



        private void BTNLECTORA_Click_1(object sender, EventArgs e)
        {
            //lbltipodebusqueda2.Text = "Buscar con LECTORA de Codigos de Barras";
            Tipo_de_busqueda = "LECTORA";
            BTNLECTORA.BackColor = Color.LightGreen;
            BTNTECLADO.BackColor = Color.WhiteSmoke;
            txtbuscar.Clear();
            txtbuscar.Focus();
        }

        private void BTNTECLADO_Click_1(object sender, EventArgs e)
        {
            //lbltipodebusqueda2.Text = "Buscar con  TECLADO";
            Tipo_de_busqueda = "TECLADO";
            BTNTECLADO.BackColor = Color.LightGreen;
            BTNLECTORA.BackColor = Color.WhiteSmoke;
            txtbuscar.Clear();
            txtbuscar.Focus();
        }

        private void btnverMovimientosCaja_Click(object sender, EventArgs e)
        {
            Formularios.Caja.Listado_Gastos_Ingresos frmListados_Gastos_Ingresos = new Caja.Listado_Gastos_Ingresos();
            frmListados_Gastos_Ingresos.ShowDialog();
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {
            Formularios.Gastos_Varios.Gastos frmGastos_Varios = new Gastos_Varios.Gastos();
            frmGastos_Varios.ShowDialog();
        }

        private void btnIngresosCaja_Click(object sender, EventArgs e)
        {
            Formularios.Ingresos_Varios.IngresosVarios frmingresosVarios = new Ingresos_Varios.IngresosVarios();
            frmingresosVarios.ShowDialog();
        }

        private void BtnCerrar_turno_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Formularios.Caja.Cierre_de_Caja frmcierrecaja = new Caja.Cierre_de_Caja();
            frmcierrecaja.ShowDialog();
        }

        private void btnAperturaCreditoPagar_Click(object sender, EventArgs e)
        {
            Formularios.Aperturas_de_Credito.Credito_por_Pagar frmcreditopagar = new Aperturas_de_Credito.Credito_por_Pagar();
            frmcreditopagar.ShowDialog();
        }

        private void btnAperturaCreditoPorPagar_Click(object sender, EventArgs e)
        {
            Formularios.Aperturas_de_Credito.Credito_por_Cobrar frmcobrar = new Aperturas_de_Credito.Credito_por_Cobrar();
            frmcobrar.ShowDialog();
        }

        private void Ventas_Menu_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿REALMENTE DESEA CERRAR EL SISTEMA", "CERRAR SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
                Formularios.Copias_BaseDatos.GeneradoAutomatico frmautomatico = new Copias_BaseDatos.GeneradoAutomatico();
                frmautomatico.ShowDialog();

            }
            else
            {
                e.Cancel = true;

            }
        }

        private void btnCobros_Click(object sender, EventArgs e)
        {
            Formularios.Cobros.Cobros frmcobros = new Cobros.Cobros();
            frmcobros.ShowDialog();
        }

        private void btnMayoreo_Click(object sender, EventArgs e)
        {
            editar_precio_mayoreo();
        }

        private void editar_precio_mayoreo()
        {
            if (datalistadoDetalleVenta.Rows.Count > 0)
            {
                LDetalleVenta detalleventa_parametros = new LDetalleVenta();
                CADEditarDatos funcion = new CADEditarDatos();
                detalleventa_parametros.idProducto = idproducto;
                detalleventa_parametros.idDetalleVenta = iddetalleventa;
                if (funcion.editar_precio_mayoreo(detalleventa_parametros) == true)
                {
                    Listarproductosagregados();
                }
            }

        }

        private void btnCantidad_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtmonto.Text))
            {
                if (datalistadoDetalleVenta.RowCount > 0)
                {

                    if (sevendePor == "Unidad")

                    {
                        string cadena = txtmonto.Text;
                        if (cadena.Contains("."))
                        {
                            MessageBox.Show("ESTE PPRODUCTO NO ACEPTA DECIMALES YA QUE ESTA CONFIGURADO PARA SER VENDIDO POR UNIDAD", "FORMATO INCORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            boton_cantidad();
                        }
                    }
                    else if (sevendePor == "Granel")
                    {
                        boton_cantidad();
                    }
                }
                else
                {
                    txtmonto.Clear();
                    txtmonto.Focus();
                }
            }

        }

        private void boton_cantidad()
        {
            double MontoIngresar;
            MontoIngresar = Convert.ToDouble(txtmonto.Text);
            double Cantidad2;
            Cantidad2 = Convert.ToDouble(datalistadoDetalleVenta.SelectedCells[5].Value);
            double stock;
            double condicional;
            string controlstock;
            controlstock = datalistadoDetalleVenta.SelectedCells[16].Value.ToString();
            if (controlstock == "SI")
            {
                stock = Convert.ToDouble(datalistadoDetalleVenta.SelectedCells[11].Value);
                condicional = Cantidad2 + stock;
                if (condicional >= MontoIngresar)
                {
                    if (MontoIngresar > Cantidad2)
                    {
                        txtpantalla = MontoIngresar - Cantidad2;
                        editar_detalle_venta_sumar();
                    }
                    else if (MontoIngresar < Cantidad2)
                    {
                        txtpantalla = Cantidad2 - MontoIngresar;
                        editar_detalle_venta_restar();
                    }
                }
                else
                {
                    TimerLABEL_STOCK.Start();
                }
            }
            else
            {
                if (MontoIngresar > Cantidad2)
                {
                    txtpantalla = MontoIngresar - Cantidad2;
                    editar_detalle_venta_sumar();
                }
                else if (MontoIngresar < Cantidad2)
                {
                    txtpantalla = Cantidad2 - MontoIngresar;
                    editar_detalle_venta_restar();
                }
            }


        }

        private void btnPrecio_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtmonto.Text))
            {
                LDetalleVenta detalleventa = new LDetalleVenta();
                CADEditarDatos editardatos = new CADEditarDatos();
                detalleventa.idDetalleVenta = iddetalleventa;
                detalleventa.Precio_Mayoreo =Convert.ToDouble(txtmonto.Text);
                if (editardatos.editar_precio_venta(detalleventa) == true) 
                {
                    Listarproductosagregados();  
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Formularios.Historial_Ventas.HistorialVentas frmhistorialventas = new Historial_Ventas.HistorialVentas();
            frmhistorialventas.ShowDialog();
        }

        private void IndicadorTema_CheckedChanged(object sender, EventArgs e)
        {
            if (IndicadorTema.Checked == true)
            {
                Tema = "OSCURO";
                editar_tema_caja();
                tema_oscuro();
                Listarproductosagregados();
            }
            else
            {
                Tema = "REDENTOR";
                editar_tema_caja();
                tema_claro();
                Listarproductosagregados();
            }
        }
        private void tema_oscuro()
        {
            //this.BackColor = Color.FromArgb(96, 93, 90);
            PanelV1.BackColor = Color.FromArgb(51, 51, 51);
            PanelV2.BackColor = Color.FromArgb(51, 51, 51);
            PanelV3.BackColor = Color.FromArgb(51, 51, 51);
            PanelV4.BackColor = Color.FromArgb(51, 51, 51);
            lblNombreSoftware.ForeColor = Color.White;
            btnAdmin.ForeColor = Color.White;
            txtbuscar.BackColor = Color.FromArgb(51, 51, 51);
            txtbuscar.ForeColor = Color.White;
            btnCobros.BackColor = Color.FromArgb(96, 93, 90);
            btnCobros.ForeColor = Color.White;
            btnPagos.BackColor = Color.FromArgb(96, 93, 90);
            btnPagos.ForeColor = Color.White;
            btnAperturaCreditoPorPagar.BackColor = Color.FromArgb(96, 93, 90);
            btnAperturaCreditoPorPagar.ForeColor = Color.White;
            btnAperturaCreditoPagar.BackColor = Color.FromArgb(96, 93, 90);
            btnAperturaCreditoPagar.ForeColor = Color.White;
            btnINSVarios.BackColor = Color.FromArgb(96, 93, 90);
            btnINSVarios.ForeColor = Color.White;
            btnMayoreo.BackColor = Color.FromArgb(96, 93, 90);
            btnMayoreo.ForeColor = Color.White;
            btnProductoRapido.BackColor = Color.FromArgb(96, 93, 90);
            btnProductoRapido.ForeColor = Color.White;
            btnIngresosCaja.BackColor = Color.FromArgb(96, 93, 90);
            btnIngresosCaja.ForeColor = Color.White;
            btnGastos.BackColor = Color.FromArgb(96, 93, 90);
            btnGastos.ForeColor = Color.White;
            uI_TecladoBasico1.BackColor = Color.FromArgb(96, 93, 90);
            uI_TecladoBasico1.ForeColor = Color.White;
            btnespera.BackColor = Color.FromArgb(96, 93, 90);
            btnespera.ForeColor = Color.White;
            btnrestaurar.BackColor = Color.FromArgb(96, 93, 90);
            btnrestaurar.ForeColor = Color.White;
            btneliminar.BackColor = Color.FromArgb(96, 93, 90);
            btneliminar.ForeColor = Color.White;
            btnVentasDevolucion.BackColor = Color.FromArgb(96, 93, 90);
            btnVentasDevolucion.ForeColor = Color.White;
            lblTema.BackColor = Color.FromArgb(96, 93, 90);
            lblTema.ForeColor = Color.White;
            PanelOperaciones.BackColor = Color.FromArgb(51, 51, 51);
            Listarproductosagregados();
            panelBienvenida.BackColor = Color.FromArgb(51, 51, 51);
            label8.ForeColor = Color.White;
            PanelEspera.BackColor = Color.FromArgb(96, 93, 90);

        }
        private void tema_claro()
        {
            PanelV1.BackColor = Color.White;
            PanelV2.BackColor = Color.White;
            PanelV3.BackColor = Color.White;
            PanelV4.BackColor = Color.Gainsboro;
            lblNombreSoftware.ForeColor = Color.Black;
            btnAdmin.ForeColor = Color.Black;
            txtbuscar.BackColor = Color.White;
            txtbuscar.ForeColor = Color.Black;
            btnCobros.BackColor = Color.White;
            btnCobros.ForeColor = Color.Black;
            btnPagos.BackColor = Color.White;
            btnPagos.ForeColor = Color.Black;
            btnAperturaCreditoPorPagar.BackColor = Color.White;
            btnAperturaCreditoPorPagar.ForeColor = Color.Black;
            btnAperturaCreditoPagar.BackColor = Color.White;
            btnAperturaCreditoPagar.ForeColor = Color.Black;
            btnINSVarios.BackColor = Color.White;
            btnINSVarios.ForeColor = Color.Black;
            btnMayoreo.BackColor = Color.White;
            btnMayoreo.ForeColor = Color.Black;
            btnProductoRapido.BackColor = Color.White;
            btnProductoRapido.ForeColor = Color.Black;
            btnIngresosCaja.BackColor = Color.White;
            btnIngresosCaja.ForeColor = Color.Black;
            btnGastos.BackColor = Color.White;
            btnGastos.ForeColor = Color.Black;
            uI_TecladoBasico1.BackColor = Color.White;
            uI_TecladoBasico1.ForeColor = Color.Black;
            btnespera.BackColor = Color.White;
            btnespera.ForeColor = Color.Black;
            btnrestaurar.BackColor = Color.White;
            btnrestaurar.ForeColor = Color.Black;
            btneliminar.BackColor = Color.White;
            btneliminar.ForeColor = Color.Black;
            btnVentasDevolucion.BackColor = Color.White;
            btnVentasDevolucion.ForeColor = Color.Black;
            lblTema.BackColor = Color.White;
            lblTema.ForeColor = Color.Black;
            PanelOperaciones.BackColor = Color.White;
            Listarproductosagregados();
            panelBienvenida.BackColor = Color.White;
            label8.ForeColor = Color.Black;
            PanelEspera.BackColor = Color.White;
        }

        private void editar_tema_caja()
        {
            LCaja caja = new LCaja();
            CADEditarDatos datos = new CADEditarDatos();
            caja.Tema = Tema;
            datos.editar_tema_caja(caja);
            
        }
        
        private void contar_ventas_espera()
        {
            Datos.ObtenerDatos.contar_ventas_espera(ref ContadorVentasEspera);
            if (ContadorVentasEspera == 0)
            {
                PanelEspera.Visible = false;
            }
            else
            {
                PanelEspera.Visible = true;
                lblContadorVentasEspera.Text =Convert.ToString(ContadorVentasEspera);
            }
        }
       
    }
}
