using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;
using Telerik.Reporting.Processing;
using Telerik.Reporting.Drawing;


namespace Aplicacion_Comercial.Formularios.VENTAS_MENU_PRINCIPAL
{
    public partial class Medios_De_Pago : Form
    {
        public Medios_De_Pago()
        {
            InitializeComponent();
        }
        private PrintDocument DOCUMENTO;
        string moneda;
        int idcliente;
        int idventa;
        double total;
        double vuelto = 0;
        double efectivo_calculado = 0;
        double restante = 0;
        int INDICADOR_DE_FOCO;
        bool SECUENCIA1 = true;
        bool SECUENCIA2 = true;
        bool SECUENCIA3 = true;
        string indicador;
        string indicador_de_tipo_de_pago_string;
        string txttipo;
        string TXTTOTAL_STRING;
        string lblproceso;
        double credito = 0;
        int idcomprobante;
        string lblSerialPC;
        private void MEDIOS_DE_PAGO_Load(object sender, EventArgs e)
        {
            cambiar_el_formato_de_separador_de_decimales();
            MOSTRAR_comprobante_serializado_POR_DEFECTO();
            validar_tipos_de_comprobantes();
            obtener_serial_pc();
            mostrar_moneda_de_empresa();
            configuraciones_de_diseño();
            Obtener_id_de_venta();
            mostrar_impresora();
            cargar_impresoras_del_equipo();

            calcular_restante();
        }

        void calcular_restante()
        {
            try
            {
                double efectivo = 0;
                double tarjeta = 0;
              
                if(txtefectivo2.Text =="")
                {
                    efectivo = 0;
                }
                else
                {
                    efectivo = Convert.ToDouble(txtefectivo2.Text);
                }
                if (txtcredito2.Text =="")
                {
                    credito = 0;
                }
                else
                {
                    credito = Convert.ToDouble (txtcredito2.Text);
                }
                if(txttarjeta2.Text =="")
                {
                    tarjeta = 0;
                } 
                else
                {
                    tarjeta = Convert.ToDouble(txttarjeta2.Text);
                }

                if (txtefectivo2.Text == "0.00")
                {
                    efectivo = 0;
                }
                if (txtcredito2.Text == "0.00")
                {
                    credito = 0;
                }
                if (txttarjeta2.Text == "0.00")
                {
                    tarjeta = 0;

                }

                if (txtefectivo2.Text == ".")
                {
                    efectivo = 0;
                }
                if (txtcredito2.Text == ".")
                {
                    tarjeta = 0;
                }
                if (txttarjeta2.Text == ".")
                {
                    credito = 0;
                }
                ///////
                //Total= 5 
                //Efectivo= 10
                // Tarjeta = 22
                //EC=E-(T+TA)
                //EC= 10-(5+22)
                //EC= 3
                //V=E-(T-TA)
                //V=10-(5-2)
                //V=7
       
                try
                {
                    if (efectivo>total)
                    {
                        efectivo_calculado = efectivo - (total + credito + tarjeta);
                        if (efectivo_calculado <0)
                        {
                            vuelto = 0;
                                TXTVUELTO.Text = "0";
                            txtrestante.Text =Convert.ToString ( efectivo_calculado);
                            restante = efectivo_calculado;
                        }
                        else
                        {
                            vuelto = efectivo - (total - credito - tarjeta);
                            TXTVUELTO.Text = Convert.ToString ( vuelto);
                            restante = efectivo - (total + credito + tarjeta+efectivo_calculado );
                            txtrestante.Text = Convert.ToString ( restante);
                            txtrestante.Text = decimal.Parse(txtrestante.Text).ToString("##0.00");
                        }
                      
                    }
                    else
                    {
                        vuelto = 0;
                        TXTVUELTO.Text = "0";
                        efectivo_calculado = efectivo;
                        restante = total - efectivo_calculado - credito - tarjeta;
                        txtrestante.Text = Convert.ToString(restante);
                        txtrestante.Text = decimal.Parse(txtrestante.Text).ToString("##0.00");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        void mostrar_impresora()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Mostrar_Impresoras_por_Caja", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Serial", lblSerialPC);
                try
                {
                    Conexiones.CADMaestra.abrir();
                    txtImpresora.Text = Convert.ToString(cmd.ExecuteScalar());
                    Conexiones.CADMaestra.cerrar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace );
            }
        }
        void cargar_impresoras_del_equipo()
        {
            txtImpresora.Items.Clear();
            for (var I=0;I< PrinterSettings.InstalledPrinters.Count;I++)
            {
                txtImpresora.Items.Add(PrinterSettings.InstalledPrinters[I]);
            }
            txtImpresora.Items.Add("Ninguna");
        }
        void Obtener_id_de_venta()
        {
            idventa = Ventas_Menu_Principal.idVenta;
        }
        void configuraciones_de_diseño()
        {
            TXTVUELTO.Text = "0.0";
            txtrestante.Text = "0.0";
            TXTTOTAL.Text = moneda + " " + Ventas_Menu_Principal.total;
            total = Ventas_Menu_Principal.total;
            txtefectivo2.Text =Convert.ToString (total);
            idcliente = 0;

        }
        void mostrar_moneda_de_empresa()
        {
            SqlCommand cmd = new SqlCommand("SELECT Moneda FROM Empresa", Conexiones.CADMaestra.conectar);
            try
            {
                Conexiones.CADMaestra.abrir();
                moneda =Convert.ToString  (cmd.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public void obtener_serial_pc()
        {
           Logica.BasesPCProgram.obtener_serial_pc (ref lblSerialPC);
        }
        public void cambiar_el_formato_de_separador_de_decimales()
        {

            Conexiones.Cambiar_el_separador_de_decimales.cambiar();
        }
        private void MOSTRAR_comprobante_serializado_POR_DEFECTO()
        {
            SqlCommand cmd = new SqlCommand("SELECT Tipo_Documento FROM Serializacion WHERE Por_Defecto='SI'", Conexiones.CADMaestra.conectar);
            try
            {
                Conexiones.CADMaestra.abrir();
                lblComprobante.Text = Convert.ToString(cmd.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dibujarCOMPROBANTES();
        }
        private void dibujarCOMPROBANTES()
        {
            FlowLayoutPanel3.Controls.Clear();
            try
            {
                Conexiones.CADMaestra.abrir();
                string query = "SELECT Tipo_Documento FROM Serializacion WHERE Destino='VENTAS'";
                SqlCommand cmd = new SqlCommand(query, Conexiones.CADMaestra.conectar);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Button b = new Button();
                    b.Text = rdr["Tipo_Documento"].ToString();
                    b.Size = new System.Drawing.Size(191, 60);
                    b.BackColor = Color.FromArgb(70, 70, 71);
                    b.Font = new System.Drawing.Font("Georgia", 14);
                    b.FlatStyle = FlatStyle.Flat;
                    b.ForeColor = Color.WhiteSmoke;
                    FlowLayoutPanel3.Controls.Add(b);
                    if (b.Text == lblComprobante.Text)
                    {
                        b.Visible = false;
                    }
                    b.Click += miEvento;
                }
                    Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void miEvento(System.Object sender, EventArgs e)
        {
            lblComprobante.Text = ((Button)sender).Text;
            dibujarCOMPROBANTES();
            validar_tipos_de_comprobantes();
            identificar_el_tipo_de_pago();
            if (lblComprobante.Text =="FACTURA" && txttipo =="CREDITO")
            {
                PANEL_CLIENTE_FACTURA.Visible = false;
            }
            if (lblComprobante.Text == "FACTURA" && txttipo == "EFECTIVO")
            {
                PANEL_CLIENTE_FACTURA.Visible = true;
                lblindicador_de_factura_1.Text = "Cliente: (Obligatorio)";
                lblindicador_de_factura_1.ForeColor = Color.FromArgb(255, 192, 192);

            }
            else if (lblComprobante.Text != "FACTURA" && txttipo == "EFECTIVO")
            {
                PANEL_CLIENTE_FACTURA.Visible = true;
                lblindicador_de_factura_1.Text = "Cliente: (Opcional)";
                lblindicador_de_factura_1.ForeColor = Color.DimGray;

            }

            if (lblComprobante.Text == "FACTURA" && txttipo == "TARJETA")
            {
                PANEL_CLIENTE_FACTURA.Visible = true;
                lblindicador_de_factura_1.Text = "Cliente: (Obligatorio)";
                lblindicador_de_factura_1.ForeColor = Color.FromArgb(255, 192, 192);

            }
            else if (lblComprobante.Text != "FACTURA" && txttipo == "TARJETA")
            {
                PANEL_CLIENTE_FACTURA.Visible = true;
                lblindicador_de_factura_1.Text = "Cliente: (Opcional)";
                lblindicador_de_factura_1.ForeColor = Color.DimGray;
            }


        }

        void validar_tipos_de_comprobantes()
        {
            buscar_Tipo_de_documentos_para_insertar_en_ventas();
            try
            {
                int numerofin;
                
                txtserie.Text = dtComprobantes.SelectedCells[2].Value.ToString();

                numerofin = Convert.ToInt32 ( dtComprobantes.SelectedCells[4].Value);
                idcomprobante= Convert.ToInt32(dtComprobantes.SelectedCells[5].Value);
                txtnumerofin.Text =Convert.ToString  ( numerofin + 1);
                lblCantidad_de_numeros.Text = dtComprobantes.SelectedCells[3].Value.ToString();
                lblCorrelativoconCeros.Text = Conexiones.AgregarCerosAdelanteDeNumeros.ceros(txtnumerofin.Text, Convert.ToInt32(lblCantidad_de_numeros.Text));
            }
            catch (Exception)
            {

            }
        }
         void buscar_Tipo_de_documentos_para_insertar_en_ventas()
        {
            DataTable dt = new DataTable();
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Buscar_Tipo_De_Documentos_Para_Insertar_En_Ventas", Conexiones.CADMaestra.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Letra", lblComprobante.Text);
                da.Fill(dt);
                dtComprobantes.DataSource = dt;
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
            }
        }
        private void txtefectivo2_TextChanged(object sender, EventArgs e)
        {
            calcular_restante();
        }

        private void txttarjeta2_TextChanged(object sender, EventArgs e)
        {
            calcular_restante();
        }

        private void txtcredito2_TextChanged(object sender, EventArgs e)
        {
            calcular_restante();
            hacer_visible_panel_de_clientes_a_credito();
        }
        void hacer_visible_panel_de_clientes_a_credito()
        {
            try
            {
                double textocredito = 0;
                if (txtcredito2.Text ==".")
                {
                    textocredito = 0;
                }
                if (txtcredito2.Text =="")
                {
                    textocredito = 0;
                }
                else
                {
                    textocredito = Convert.ToDouble(txtcredito2.Text);
                }

                if (textocredito>0)
                {
                    pcredito.Visible = true;
                }
                else
                {
                    pcredito.Visible = false;
                    idcliente = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO==1)
            {
                txtefectivo2.Text = txtefectivo2.Text + "1";
            }
            else if (INDICADOR_DE_FOCO==2)
            {
                txttarjeta2.Text = txttarjeta2.Text + "1";
            }
            else if (INDICADOR_DE_FOCO==3)
            {
                txtcredito2.Text = txtcredito2.Text + "1";
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtefectivo2.Text = txtefectivo2.Text + "2";
            }
            else if (INDICADOR_DE_FOCO == 2)
            {
                txttarjeta2.Text = txttarjeta2.Text + "2";
            }
            else if (INDICADOR_DE_FOCO == 3)
            {
                txtcredito2.Text = txtcredito2.Text + "2";
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtefectivo2.Text = txtefectivo2.Text + "3";
            }
            else if (INDICADOR_DE_FOCO == 2)
            {
                txttarjeta2.Text = txttarjeta2.Text + "3";
            }
            else if (INDICADOR_DE_FOCO == 3)
            {
                txtcredito2.Text = txtcredito2.Text + "3";
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtefectivo2.Text = txtefectivo2.Text + "4";

            }
            else if (INDICADOR_DE_FOCO == 2)
            {
                txttarjeta2.Text = txttarjeta2.Text + "4";
            }
            else if (INDICADOR_DE_FOCO == 3)
            {
                txtcredito2.Text = txtcredito2.Text + "4";
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtefectivo2.Text = txtefectivo2.Text + "5";

            }
            else if (INDICADOR_DE_FOCO == 2)
            {
                txttarjeta2.Text = txttarjeta2.Text + "5";
            }
            else if (INDICADOR_DE_FOCO == 3)
            {
                txtcredito2.Text = txtcredito2.Text + "5";
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtefectivo2.Text = txtefectivo2.Text + "6";

            }
            else if (INDICADOR_DE_FOCO == 2)
            {
                txttarjeta2.Text = txttarjeta2.Text + "6";
            }
            else if (INDICADOR_DE_FOCO == 3)
            {
                txtcredito2.Text = txtcredito2.Text + "6";
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtefectivo2.Text = txtefectivo2.Text + "7";

            }
            else if (INDICADOR_DE_FOCO == 2)
            {
                txttarjeta2.Text = txttarjeta2.Text + "7";
            }
            else if (INDICADOR_DE_FOCO == 3)
            {
                txtcredito2.Text = txtcredito2.Text + "7";
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtefectivo2.Text = txtefectivo2.Text + "8";

            }
            else if (INDICADOR_DE_FOCO == 2)
            {
                txttarjeta2.Text = txttarjeta2.Text + "8";
            }
            else if (INDICADOR_DE_FOCO == 3)
            {
                txtcredito2.Text = txtcredito2.Text + "8";
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtefectivo2.Text = txtefectivo2.Text + "9";

            }
            else if (INDICADOR_DE_FOCO == 2)
            {
                txttarjeta2.Text = txttarjeta2.Text + "9";
            }
            else if (INDICADOR_DE_FOCO == 3)
            {
                txtcredito2.Text = txtcredito2.Text + "9";
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtefectivo2.Text = txtefectivo2.Text + "0";

            }
            else if (INDICADOR_DE_FOCO == 2)
            {
                txttarjeta2.Text = txttarjeta2.Text + "0";
            }
            else if (INDICADOR_DE_FOCO == 3)
            {
                txtcredito2.Text = txtcredito2.Text + "0";
            }
        }

        private void btnpunto_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                if (SECUENCIA1 == true  ) 
                {
                    txtefectivo2.Text = txtefectivo2.Text + ".";
                    SECUENCIA1 = false;
                }
           
                 else
               {
                    return;
                }

            }
            else if (INDICADOR_DE_FOCO == 2)
            {
                if (SECUENCIA2 == true)
                {
                    txttarjeta2 .Text = txttarjeta2.Text + ".";
                    SECUENCIA2 = false;
                }

                else
                {
                    return;
                }

            }
            else if (INDICADOR_DE_FOCO == 3)
            {
                if (SECUENCIA3 == true)
                {
                    txtcredito2 .Text = txtcredito2.Text + ".";
                    SECUENCIA3 = false;
                }

                else
                {
                    return;
                }

            }

        }

        private void btnborrartodo_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO==1)
            {
                txtcredito2.Clear();
                SECUENCIA1 = true;
            }
            else if (INDICADOR_DE_FOCO==2)
            {
                txttarjeta2.Clear();
                SECUENCIA2 = true;
            }
            else if (INDICADOR_DE_FOCO ==3)
            {
                txtcredito2.Clear();
                SECUENCIA3 = true;
            }
        }

        private void FlowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtclientesolicitabnte3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtclientesolicitabnte2_TextChanged(object sender, EventArgs e)
        {
            buscarclientes2();
            datalistadoclientes2.Visible = true;
        }
        void buscarclientes2()
        {
            

            try
            {
                DataTable dt = new DataTable();
                Datos.ObtenerDatos.buscar_cliente(ref dt,txtclientesolicitabnte2.Text);
                datalistadoclientes2.DataSource = dt;
                datalistadoclientes2.Columns[1].Visible = false;
                datalistadoclientes2.Columns[3].Visible = false;
                datalistadoclientes2.Columns[4].Visible = false;
                datalistadoclientes2.Columns[5].Visible = false;
                datalistadoclientes2.Columns[2].Width = 420;
            }
            catch (Exception)
            {
                
            }
        }

        private void datalistadoclientes2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datalistadoclientes2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idcliente = Convert.ToInt32(datalistadoclientes2.SelectedCells[1].Value.ToString());
            txtclientesolicitabnte2.Text = datalistadoclientes2.SelectedCells[2].Value.ToString();
            datalistadoclientes2.Visible = false;

        }

        private void ToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            PanelregistroClientes.Visible = true;
            PanelregistroClientes.Dock = DockStyle.Fill;
            PanelregistroClientes.BringToFront();
            limpiar_datos_de_registrodeclientes();

        }
        void limpiar_datos_de_registrodeclientes()
        {
            txtnombrecliente.Clear();
            txtdirecciondefactura.Clear();
            txtcelular.Clear();
            txtrucdefactura.Clear();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            insertar_cliente();
            PanelregistroClientes.Visible = false;
        }
        void insertar_cliente()
        {
            if (txtnombrecliente.Text != "")
            {

                if (txtdirecciondefactura.Text == "")
                {
                    txtdirecciondefactura.Text = "0";
                }
                if (txtrucdefactura.Text == "")
                {
                    txtrucdefactura.Text = "0";
                }
                if (txtcelular.Text == "")
                {
                    txtcelular.Text = "0";
                }


                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = Conexiones.CADMaestra.conexion;
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand("Insertar_Cliente", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", txtnombrecliente.Text);
                    cmd.Parameters.AddWithValue("@Direccion_para_Factura", txtdirecciondefactura.Text);
                    cmd.Parameters.AddWithValue("@Ruc", txtrucdefactura.Text);
                    cmd.Parameters.AddWithValue("@Movil", txtcelular.Text);
                    cmd.Parameters.AddWithValue("@Cliente", "SI");
                    cmd.Parameters.AddWithValue("@Proveedor", "NO");
                    cmd.Parameters.AddWithValue("@Estado", "ACTIVO");
                    cmd.Parameters.AddWithValue("@Saldo", 0);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            PanelregistroClientes.Visible = false;
        }

        private void txtefectivo2_Click(object sender, EventArgs e)
        {
            calcular_restante();
            INDICADOR_DE_FOCO = 1;
            if (txtrestante.Text =="0.00")
            {
                txtefectivo2.Text = "";
            }
            else
            {
                txtefectivo2.Text = txtrestante.Text;
            }
        }

        private void txttarjeta2_Click(object sender, EventArgs e)
        {
            calcular_restante();
            INDICADOR_DE_FOCO = 2;
            if (txtrestante.Text == "0.00")
            {
                txttarjeta2 .Text = "";
            }
            else
            {
                txttarjeta2.Text = txtrestante.Text;
            }
        }

        private void txtcredito2_Click(object sender, EventArgs e)
        {
            calcular_restante();
            INDICADOR_DE_FOCO = 3;
            if (txtrestante.Text == "0.00")
            {
                txtcredito2 .Text = "";
            }
            else
            {
                txtcredito2.Text = txtrestante.Text;
                hacer_visible_panel_de_clientes_a_credito();
            }
        }

        private void TGuardarSinImprimir_Click(object sender, EventArgs e)
        {
            if (restante ==0)
            {
             indicador = "VISTA PREVIA";
            identificar_el_tipo_de_pago();
            INGRESAR_LOS_DATOS();                   
            }
            else
            {
                MessageBox.Show("El restante debe ser 0", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
 
        void INGRESAR_LOS_DATOS()
        {
            CONVERTIR_TOTAL_A_LETRAS();
            completar_con_ceros_los_texbox_de_otros_medios_de_pago();
            if (txttipo =="EFECTIVO" && vuelto >=0)
            {
                vender_en_efectivo();

            }
            else if (txttipo == "EFECTIVO" && vuelto < 0)
            {
               MessageBox.Show("El vuelto no puede ser menor a el Total pagado ", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            // condicional para creditos
            if (txttipo == "CREDITO" && datalistadoclientes2.Visible == false)
            {
                vender_en_efectivo();
            }
            else if (txttipo == "CREDITO" && datalistadoclientes2.Visible == true)
            {
             MessageBox.Show("Seleccione un Cliente para Activar Pago a Credito", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (txttipo == "TARJETA")
            {
                vender_en_efectivo();
            }


            if (txttipo == "MIXTO")
            {
                vender_en_efectivo();
            }

        }
        void vender_en_efectivo()
        {
            if (idcliente==0 )
            {
                MOSTRAR_cliente_standar();
            }
            if (lblComprobante.Text == "FACTURA" && idcliente == 0 && txttipo != "CREDITO")
            {
                MessageBox.Show("Seleccione un Cliente, para Facturas es Obligatorio", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (lblComprobante.Text == "FACTURA" && idcliente != 0)
            {
                procesar_venta_efectivo();
            }

            else if (lblComprobante.Text != "FACTURA" && txttipo != "CREDITO")
            {
                procesar_venta_efectivo();
            }
            else if (lblComprobante.Text != "FACTURA" && txttipo == "CREDITO")
            {
                procesar_venta_efectivo();
            }



           
        }
        void procesar_venta_efectivo()
        {
            actualizar_serie_mas_uno();
            validar_tipos_de_comprobantes();
            CONFIRMAR_VENTA_EFECTIVO();
            if (lblproceso=="PROCEDE")
            {                            
                disminuir_stock_productos();
                INSERTAR_KARDEX_SALIDA();
                aumentar_monto_a_cliente();
                validar_tipo_de_impresion();
            }
        }
        void INSERTAR_KARDEX_SALIDA()
        {
            try
            {
                foreach (DataGridViewRow row in datalistadoDetalleVenta.Rows )
                {
                    int Id_producto = Convert.ToInt32(row.Cells["idProducto"].Value);
                    double cantidad = Convert.ToDouble(row.Cells["Cant"].Value);
                    string STOCK = Convert.ToString(row.Cells["Stock"].Value);
                    if (STOCK != "Ilimitado")
                    {
                        Conexiones.CADMaestra.abrir();
                        SqlCommand cmd = new SqlCommand("Insertar_Kardex_Salida", Conexiones.CADMaestra.conectar );
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Motivo", "Venta #" + lblComprobante.Text + " " + lblCorrelativoconCeros.Text);
                        cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                        cmd.Parameters.AddWithValue("@idProducto", Id_producto);
                        cmd.Parameters.AddWithValue("@idUsuario", Ventas_Menu_Principal.idusuario_que_inicio_sesion);
                        cmd.Parameters.AddWithValue("@Tipo", "SALIDA");
                        cmd.Parameters.AddWithValue("@Estado", "DESPACHO CONFIRMADO");
                        cmd.Parameters.AddWithValue("@id_Caja", Ventas_Menu_Principal.Id_caja);
                        cmd.ExecuteNonQuery();
                        Conexiones.CADMaestra.cerrar();

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }
        void mostrar_productos_agregados_a_venta()
        {
            try
            {
                DataTable dt = new DataTable();
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Mostrar_Productos_a_Ventas", Conexiones.CADMaestra.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idVenta", idventa);
                da.Fill(dt);
                datalistadoDetalleVenta.DataSource = dt;
                Conexiones.CADMaestra.cerrar();

            }
            catch (Exception ex)
            {
                Conexiones.CADMaestra.cerrar();
                MessageBox.Show(ex.Message);
            }
        }
        void disminuir_stock_productos()
        {
            mostrar_productos_agregados_a_venta();
            foreach (DataGridViewRow row in datalistadoDetalleVenta.Rows )
            {
                int idproducto = Convert.ToInt32(row.Cells["idProducto"].Value);
                double cantidad = Convert.ToInt32(row.Cells["Cant"].Value);
                try
                  {
                     MessageBox.Show("entramos");
                     Conexiones.CADMaestra.abrir();
                     SqlCommand cmd = new SqlCommand("Disminuir_Stock_Productos", Conexiones.CADMaestra.conectar);
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@idProducto", idproducto);
                     cmd.Parameters.AddWithValue("@Stock", cantidad);
                     cmd.ExecuteNonQuery(); 
                     Conexiones.CADMaestra.cerrar();
                  }
                   catch (Exception ex)
                  {
                    Conexiones.CADMaestra.cerrar();
                    MessageBox.Show(ex.Message);
                  }
            }
          

        }
        void actualizar_serie_mas_uno()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexiones.CADMaestra.abrir();
                cmd = new SqlCommand("Actualizar_Serializacion_Mas_Uno", Conexiones.CADMaestra.conectar );
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idSerializacion", idcomprobante);           
                cmd.ExecuteNonQuery();
                Conexiones.CADMaestra.cerrar();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void validar_tipo_de_impresion()
        {
           if ( indicador =="VISTA PREVIA")
            {
                mostrar_ticket_impreso_VISTA_PREVIA();
            }
           else if (indicador =="DIRECTO")
            {
                imprimir_directo();
            }
        }
        void imprimir_directo()
        {
            mostrar_Ticket_lleno();
            try
            {
                DOCUMENTO = new PrintDocument();
                DOCUMENTO.PrinterSettings.PrinterName = txtImpresora.Text;
                if (DOCUMENTO.PrinterSettings.IsValid )
                {
                    PrinterSettings printerSettings = new PrinterSettings();
                    printerSettings.PrinterName = txtImpresora.Text;
                    ReportProcessor reportProcessor = new ReportProcessor();
                    reportProcessor.PrintReport(reportViewer2.ReportSource, printerSettings);
                }
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.StackTrace);
            }
        }
        void mostrar_Ticket_lleno()
        {
            Formularios.Reportes_Kardex.Reportes_de_Comprobantes.TicketReporte rpt = new Reportes_Kardex.Reportes_de_Comprobantes.TicketReporte();
            DataTable dt = new DataTable();
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Mostrar_Ticket_Impreso", Conexiones.CADMaestra.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idVenta", idventa);
                da.SelectCommand.Parameters.AddWithValue("@Total_en_letras", txtnumeroconvertidoenletra.Text);
                da.Fill(dt);
                rpt = new Formularios.Reportes_Kardex.Reportes_de_Comprobantes.TicketReporte();
                rpt.table1.DataSource = dt;
                rpt.DataSource = dt;
                reportViewer2.Report = rpt;
                reportViewer2.RefreshReport();
                Conexiones.CADMaestra.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        void mostrar_ticket_impreso_VISTA_PREVIA()
        {
            PanelImpresionvistaprevia.Visible = true;
            PanelImpresionvistaprevia.Dock = DockStyle.Fill;
            panelGuardado_de_datos.Dock = DockStyle.None;
            panelGuardado_de_datos.Visible = false;

            Formularios.Reportes_Kardex.Reportes_de_Comprobantes.TicketReporte rpt = new Reportes_Kardex.Reportes_de_Comprobantes.TicketReporte();
            DataTable dt = new DataTable();
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Mostrar_Ticket_Impreso", Conexiones.CADMaestra.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idVenta", idventa);
                da.SelectCommand.Parameters.AddWithValue("@Total_en_letras", txtnumeroconvertidoenletra.Text);
                da.Fill(dt);
                rpt = new Formularios.Reportes_Kardex.Reportes_de_Comprobantes.TicketReporte();
                rpt.table1.DataSource = dt;
                rpt.DataSource = dt;
                reportViewer1.Report = rpt;
                reportViewer1.RefreshReport();
                Conexiones.CADMaestra.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

        }
        void CONFIRMAR_VENTA_EFECTIVO()
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Confirmar_Venta", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idVenta", idventa);
                cmd.Parameters.AddWithValue("@Monto_Total", total);
                cmd.Parameters.AddWithValue("@Impuesto", 0);
                cmd.Parameters.AddWithValue("@Saldo", vuelto);
                cmd.Parameters.AddWithValue("@Tipo_de_Pago", txttipo );
                cmd.Parameters.AddWithValue("@Estado", "CONFIRMADO");
                cmd.Parameters.AddWithValue("@Comprobante", lblComprobante.Text);
                cmd.Parameters.AddWithValue("@Numero_de_Documento", (txtserie.Text + "-" + lblCorrelativoconCeros.Text));
                cmd.Parameters.AddWithValue("@Fecha_de_Venta", DateTime.Now);
                cmd.Parameters.AddWithValue("@Accion", "VENTA");
                cmd.Parameters.AddWithValue("@Fecha_de_Pago", txtfecha_de_pago.Value);
                cmd.Parameters.AddWithValue("@idCliente", idcliente);
                cmd.Parameters.AddWithValue("@Pago_con", txtefectivo2.Text);
                cmd.Parameters.AddWithValue("@Referencia_Tarjeta", "NULO");
                cmd.Parameters.AddWithValue("@Vuelto", vuelto);
                cmd.Parameters.AddWithValue("@Efectivo", efectivo_calculado);
                cmd.Parameters.AddWithValue("@Credito", txtcredito2.Text);
                cmd.Parameters.AddWithValue("@Tarjeta", txttarjeta2.Text);
                cmd.ExecuteNonQuery();
                Conexiones.CADMaestra.cerrar();
                lblproceso = "PROCEDE";              
            }
            catch (Exception ex)
            {
                Conexiones.CADMaestra.cerrar();
                lblproceso = "NO PROCEDE";
                MessageBox.Show(ex.Message);
            }
        }
        void aumentar_monto_a_cliente()
        {
            if (credito>0)
            {
             try
             {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Aumentar_Saldo_A_Cliente", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", idcliente);
                cmd.Parameters.AddWithValue("@Saldo", txtcredito2.Text);
                cmd.ExecuteNonQuery();
                Conexiones.CADMaestra.cerrar();

             }
            catch (Exception ex)
             {
                Conexiones.CADMaestra.cerrar();            
                MessageBox.Show(ex.StackTrace);
             }
             }
          
        }
        void MOSTRAR_cliente_standar()
        {
            SqlCommand com = new SqlCommand("SELECT idCliente FROM Clientes WHERE Nombre='GENERICO'", Conexiones.CADMaestra.conectar);
            try
            {
                Conexiones.CADMaestra.abrir();
                idcliente = Convert.ToInt32(com.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        void completar_con_ceros_los_texbox_de_otros_medios_de_pago()
        {
            if (txtefectivo2.Text == "")
            {
                txtefectivo2.Text = "0";
            }
            if (txtcredito2.Text == "")
            {
                txtcredito2.Text = "0";
            }
            if (txttarjeta2.Text == "")
            {
                txttarjeta2.Text = "0";
            }
            if (TXTVUELTO.Text == "")
            {
                TXTVUELTO.Text = "0";
            }
        }
        void CONVERTIR_TOTAL_A_LETRAS()
        {
            try
            {
             TXTTOTAL.Text = Convert.ToString(total);
             TXTTOTAL.Text = decimal.Parse(TXTTOTAL.Text).ToString("##0.00");
             int numero = Convert.ToInt32(Math.Floor(Convert.ToDouble(total)));
            TXTTOTAL_STRING = Conexiones.Total_Letras.Num2Text(numero);
            string[] a = TXTTOTAL.Text.Split('.');
            txttotaldecimal.Text = a[1];
            txtnumeroconvertidoenletra.Text = TXTTOTAL_STRING + " CON " + txttotaldecimal.Text + "/100 ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
  
        }
        void identificar_el_tipo_de_pago()
        {
            int indicadorEfectivo = 4;
            int indicadorCredito = 2;
            int indicadorTarjeta = 3;

            // validacion para evitar valores vacios
            if (txtefectivo2.Text =="")
            {
                txtefectivo2.Text = "0";
            }
            if (txttarjeta2 .Text == "")
            {
                txttarjeta2.Text = "0";
            }
            if (txtcredito2 .Text == "")
            {
                txtcredito2.Text = "0";
            }
            //validacion de .
            if (txtefectivo2.Text ==".")
            {
                txtefectivo2.Text = "0";
            }
            if (txttarjeta2 .Text == ".")
            {
                txttarjeta2.Text = "0";
            }
            if (txtcredito2 .Text == ".")
            {
                txtcredito2.Text = "0";
            }
            //validacion de 0
            if (txtefectivo2.Text =="0")
            {
                indicadorEfectivo = 0;
            }
            if (txttarjeta2 .Text == "0")
            {
                indicadorTarjeta = 0;
            }
            if (txtcredito2 .Text == "0")
            {
                indicadorCredito  = 0;
            }
            //calculo de indicador
            int calculo_identificacion = indicadorCredito + indicadorEfectivo + indicadorTarjeta;
            //consulta al identificador
            if (calculo_identificacion ==4)
            {
                indicador_de_tipo_de_pago_string = "EFECTIVO";
            }
            if (calculo_identificacion == 2)
            {
                indicador_de_tipo_de_pago_string = "CREDITO";
            }
            if (calculo_identificacion == 3)
            {
                indicador_de_tipo_de_pago_string = "TARJETA";
            }
            if (calculo_identificacion >4)
            {
                indicador_de_tipo_de_pago_string = "MIXTO";
            }
            txttipo = indicador_de_tipo_de_pago_string;

        }

        private void btnGuardarImprimirdirecto_Click(object sender, EventArgs e)
        {
            
        }
        void editar_eleccion_de_impresora()
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Editar_Eleccion_Impresora", Conexiones.CADMaestra.conectar );
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Caja", Ventas_Menu_Principal.Id_caja);
                cmd.Parameters.AddWithValue("@Impresora_Ticket", txtImpresora.Text);
                cmd.ExecuteNonQuery();
                Conexiones.CADMaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (restante == 0)
            {
                if (txtImpresora.Text != "Ninguna")
                {
                    editar_eleccion_de_impresora();
                    indicador = "DIRECTO";
                    identificar_el_tipo_de_pago();
                    INGRESAR_LOS_DATOS();
                }
                else
                {
                    MessageBox.Show("Seleccione una Impresora", "Impresora Inexistente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("El restante debe ser 0", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void TXTTOTAL_Click(object sender, EventArgs e)
        {
        }

        private void txtefectivo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Logica.BasesPCProgram.separador_de_numeros(txtefectivo2, e);
        }

        private void txttarjeta2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Logica.BasesPCProgram.separador_de_numeros(txttarjeta2, e);
        }

        private void txtcredito2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Logica.BasesPCProgram.separador_de_numeros(txtcredito2, e);
        }
    }
}
