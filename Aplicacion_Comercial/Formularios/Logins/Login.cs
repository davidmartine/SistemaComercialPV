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
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Management;
using System.Xml;
using Telerik.Reporting.Charting;
using Aplicacion_Comercial.Datos;

namespace Aplicacion_Comercial.Formularios.Logins
{
   
    public partial class LOGIN : Form
    {
       
        int contador;
        int contadorCajas;
        int contador_Movimientos_de_caja;
        public static int idusuariovariable;
        public static int idcajavariable;
        int idUsuarioVerificador;
        string lblSerialPc;
        string lblSerialPcLocal;
        string Cajero = "CAJERO (Si esta autorizado para manejar dinero)";
        string Vendedor = "SOLO VENTAS (No esta autorizado para manejar dinero)";
        string Administrador = "ADMINISTRADOR (Control Total)";
        string lblRol;
        string txtLogin;
        string lblApertura_De_caja;
        string ResultadoLicencia;
        string FechaFinal;
        string Ip;

        public LOGIN()
              
        {
            InitializeComponent();
        }
        public void DIBUJARusuarios()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("SELECT * FROM USUARIO2 WHERE Estado = 'ACTIVO'", con);

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Label b = new Label();
                    Panel p1 = new Panel();
                    PictureBox I1 = new PictureBox();

                    b.Text = rdr["Login"].ToString();
                    b.Name = rdr["idUsuario"].ToString();
                    b.Size = new System.Drawing.Size(175, 25);
                    b.Font = new System.Drawing.Font("Segoe UI", 14);
                    b.BackColor = Color.FromArgb(33, 85, 168);
                    b.ForeColor = Color.White;
                    b.Dock = DockStyle.Bottom;
                    b.TextAlign = ContentAlignment.MiddleCenter;
                    b.Cursor = Cursors.Hand;

                    p1.Size = new System.Drawing.Size(155, 167);
                    p1.BorderStyle = BorderStyle.None;
                    p1.BackColor = Color.FromArgb(0, 33, 56);


                    I1.Size = new System.Drawing.Size(175, 132);
                    I1.Dock = DockStyle.Top;
                    I1.BackgroundImage = null;
                    byte[] bi = (Byte[])rdr["Icono"];

                    MemoryStream ms = new MemoryStream(bi);
                    I1.Image = Image.FromStream(ms);
                    I1.SizeMode = PictureBoxSizeMode.Zoom;
                    I1.Tag = rdr["Login"].ToString();
                    I1.Cursor = Cursors.Hand;

                    p1.Controls.Add(b);
                    p1.Controls.Add(I1);
                    b.BringToFront();
                    flowLayoutPanel1.Controls.Add(p1);

                    b.Click += new EventHandler(mieventoLabel);
                    I1.Click += new EventHandler(miEventoImagen);
                }
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

        }
        private  void mostrar_roles()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Conexiones.CADMaestra.conexion;
            SqlCommand com = new SqlCommand("mostrar_permisos_por_usuario_ROL_UNICO", con);
            com.CommandType = CommandType.StoredProcedure ;
            com.Parameters.AddWithValue("@idUsuario", idusuariovariable);
            try
            {
                con.Open();
                lblRol = Convert.ToString(com.ExecuteScalar());
                con.Close ();
                

            }
            catch (Exception ex)
            {
                
            }
        }
        private void miEventoImagen(System.Object sender, EventArgs e)
        {
            txtLogin = Convert.ToString(((PictureBox)sender).Tag);
            panelIniciarSesionContraseña.Visible = true;
            panelUsuarios.Visible = false;
            
        }
        
        private void mieventoLabel (System.Object sender, EventArgs e)
        {
            txtLogin = ((Label)sender).Text;
            panelIniciarSesionContraseña.Visible = true;
            panelUsuarios.Visible = false;
            
        }
        private void LOGIN_Load(object sender, EventArgs e)
        {
            
            validar_conexion();
            escalar_paneles();
            Logica.BasesPCProgram.obtener_serial_pc(ref lblSerialPc);
            obtener_ip_local();
        }

        private void obtener_ip_local()
        {
            
            panel1.Text=Logica.BasesPCProgram.ObtenerIP(ref Ip);
            
        }

        private void Validar_licencia()
        {
            try
            {
                CADLicencias funcion = new CADLicencias();
                funcion.Validar_licencias(ref ResultadoLicencia,ref FechaFinal);
                if(ResultadoLicencia == "?ACTIVO?")
                {
                    lblEstadoLicencia.Text = "LICENCIA DE PRUEBA ACTIVADA HASTA EL: " + FechaFinal;

                }
                if(ResultadoLicencia == "¿ACTIVADO PRO?")
                {
                    lblEstadoLicencia.Text = "LICENCIA PROFESIONAL ACTIVADA HASTA EL: " + FechaFinal;
                }
                if(ResultadoLicencia == "VENCIDA")
                {
                    Datos.CADLicencias.Editar_marcas_vencidas();
                    this.Dispose();
                    Formularios.Licencias_y_Membresias.Licencias_Membresias frmlicencias = new Licencias_y_Membresias.Licencias_Membresias();
                    frmlicencias.ShowDialog();
                }
            }
            catch (Exception)
            {

            }
        }

        private void escalar_paneles()
        {
            panelUsuarios.Size = new System.Drawing.Size(1005, 649);
            panelIniciarSesionContraseña.Size = new System.Drawing.Size(397, 654);
            ptbSimulacion.BringToFront();
            ptbSimulacion.Dock = DockStyle.Fill;
            //ptbSimulacion.Size = new System.Drawing.Size(397, 654);
            PanelRestaurarCuenta.Size = new System.Drawing.Size(397, 654);

            panelIniciarSesionContraseña.Visible = false;
            ptbSimulacion.Location = new Point((Width - ptbSimulacion.Width) / 2, (Height - ptbSimulacion.Height) / 2);
            panelIniciarSesionContraseña.Location = new Point((Width - panelIniciarSesionContraseña.Width) / 2, (Height - panelIniciarSesionContraseña.Height) / 2);

            panelUsuarios.Location = new Point((Width - panelUsuarios.Width) / 2, (Height - panelUsuarios.Height) / 2);
            PanelRestaurarCuenta.Location = new Point((Width - PanelRestaurarCuenta.Width) / 2, (Height - PanelRestaurarCuenta.Height) / 2);
           // button1.Location = new Point((Width - panel6.Width) / 2, (Height - panel6.Width) / 2);
        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {

        }

        private void listar_cierres_de_caja()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                da = new SqlDataAdapter("MOSTRAR_MOVIMIENTOS_DE_CAJA_POR_SERIAL", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@serial", lblSerialPc);
                da.Fill(dt);
                datalistado_detalle_cierre_de_caja.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void txtpaswwor_TextChanged(object sender, EventArgs e)
        {
            Iniciar_sesion_correcto();
        }
        private void contar_cierres_de_caja()
        {
            int x;

            x = datalistado_detalle_cierre_de_caja.Rows.Count;
            contadorCajas = (x);

        }
        private void aperturar_detalle_de_cierre_caja()
        {
            try
            {


                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_DETALLE_cierre_de_caja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fechaini",DateTime.Now );
                cmd.Parameters.AddWithValue("@fechafin", DateTime.Now);
                cmd.Parameters.AddWithValue("@fechacierre", DateTime.Now);
                cmd.Parameters.AddWithValue("@ingresos", "0.00");
                cmd.Parameters.AddWithValue("@egresos", "0.00");
                cmd.Parameters.AddWithValue("@saldo", "0.00");
                cmd.Parameters.AddWithValue("@idusuario", idusuariovariable);
                cmd.Parameters.AddWithValue("@totalcaluclado", "0.00");
                cmd.Parameters.AddWithValue("@totalreal", "0.00");
                cmd.Parameters.AddWithValue("@estado", "CAJA APERTURADA");
                cmd.Parameters.AddWithValue("@diferencia", "0.00");
                cmd.Parameters.AddWithValue("@id_caja", idcajavariable);
                cmd.ExecuteNonQuery();
                con.Close();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void obtener_idusuario()
        {
            try
            {
                idusuariovariable =Convert.ToInt32(datalistado.SelectedCells[1].Value);
            }
            catch(Exception)
            {

            }
        }
        private void Iniciar_sesion_correcto()
        {
            cargarusuarios();
            contar();
            

            if (contador > 0)
            {
                obtener_idusuario();
                mostrar_roles();

                if (lblRol != Cajero)
                {
                    timerValidaRol.Start();
                }
                else if(lblRol == Cajero)
                {
                    validar_aperturas_de_caja();
                }
            }
        }

        private void obtener_usuario_que_aperturo_caja()
        {
            try
            {
                lblusuario_queinicioCaja.Text = datalistado_detalle_cierre_de_caja.SelectedCells[1].Value.ToString();
                lblnombredeCajero.Text = datalistado_detalle_cierre_de_caja.SelectedCells[2].Value.ToString();
            }
            catch(Exception)
            {

            }
        }
        private void validar_aperturas_de_caja()
        {
            try
            {
                listar_cierres_de_caja();
                contar_cierres_de_caja();
                if (contadorCajas == 0)
                {
                    aperturar_detalle_de_cierre_caja();
                    lblApertura_De_caja = "Nuevo*****";
                    timerValidaRol.Start();

                }
                else
                {
                    mostrar_movimientos_de_caja_por_serial_y_usuario();
                    contrar_movimientos_de_caja_por_usuario();

                    if (contador_Movimientos_de_caja == 0)
                    {
                        obtener_usuario_que_aperturo_caja();
                        MessageBox.Show("Para poder continuar con el Turno de *" + lblnombredeCajero.Text + "* ,Inicia sesion con el Usuario " + lblusuario_queinicioCaja.Text + " -ó-el Usuario *admin*", "Caja Iniciada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        lblApertura_De_caja = "Aperturado";
                        timerValidaRol.Start();

                    }
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void mostrar_movimientos_de_caja_por_serial_y_usuario()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                da = new SqlDataAdapter("MOSTRAR_MOVIMIENTOS_DE_CAJA_POR_SERIAL_y_usuario", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@serial", lblSerialPc);
                da.SelectCommand.Parameters.AddWithValue("@idusuario", idusuariovariable);
                da.Fill(dt);
                datalistado_movimientos_validar.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }


        }
        private void contrar_movimientos_de_caja_por_usuario()
        {
            int x;

            x = datalistado_movimientos_validar.Rows.Count;
            contador_Movimientos_de_caja = (x);

        }
        private void contar()
        {
            int x;
         
            x = datalistado.Rows.Count;
            contador= (x);
        }
        private void cargarusuarios()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                da = new SqlDataAdapter("validar_usuario", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@password",Logica.BasesPCProgram.Encriptar(txtpaswwor.Text));
                da.SelectCommand.Parameters.AddWithValue("@login", txtLogin);
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }

          

        }

        private void mostrar_correos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                da = new SqlDataAdapter("select Correo from USUARIO2 where Estado='ACTIVO'", con);
                da.Fill(dt);
                txtcorreo.DisplayMember = "Correo";
                txtcorreo.ValueMember = "Correo";
                txtcorreo.DataSource = dt;
                con.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }



        }
        private void button1_Click(object sender, EventArgs e)
        {
            PanelRestaurarCuenta.Visible = true;
            panelUsuarios.Visible = false;
            mostrar_correos();

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            PanelRestaurarCuenta.Visible = false;
            panelUsuarios.Visible = true;

        }

        private void mostrar_usuarios_por_correo()
        {
            try
            {
                //string resultado;                       
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;           
                SqlCommand   da = new SqlCommand ("buscar_USUARIO_por_correo", con);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@correo", txtcorreo.Text);
                con.Open();
                lblResultadoContraseña.Text  =  Convert.ToString (da.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }
        
        private void Button3_Click(object sender, EventArgs e)

        {
            Enviar_correo();

        }
        
        private void Enviar_correo()
        {
            mostrar_usuarios_por_correo();
            richTextBox1.Text = richTextBox1.Text.Replace("@pass", lblResultadoContraseña.Text);
            Logica.BasesPCProgram.enviarCorreo("juandaxrxn@gmail.com", "conmutador0+", richTextBox1.Text, "Solicitud de Contraseña", txtcorreo.Text, "");
        }
        private void MOSTRAR_CAJA_POR_SERIAL()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                da = new SqlDataAdapter("mostrar_cajas_por_Serial_de_DiscoDuro", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Serial", lblSerialPc);
                da.Fill(dt);
                datalistado_caja.DataSource = dt;
                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }


        }
        string indicador;
        private void mostrar_usuarios_registrados()
        {
            try
            {

                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("SELECT idUsuario FROM USUARIO2", Conexiones.CADMaestra.conectar);
                idUsuarioVerificador = Convert.ToInt32(cmd.ExecuteScalar());
                Conexiones.CADMaestra.cerrar();
                indicador = "CORRECTO";
            }
            catch (Exception)
            {

                indicador = "INCORRECTO";
                idUsuarioVerificador = 0;
            }
        }

        private void mostrar_licencia_temporal()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                da = new SqlDataAdapter("SELECT * FROM Marca", con);
                da.Fill(dt);
                datalistado_licencia_temporal.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void validar_conexion()
        {
            mostrar_usuarios_registrados();
            // MessageBox.Show(indicador);
            if (indicador == "CORRECTO")
            {

                if (idUsuarioVerificador == 0)
                {
                    //this.Hide();
                    this.Dispose();
                    Formularios.Asistente_de_Instalacion_Servidor.Registro_Empresa frmRegistroEmpresa = new Asistente_de_Instalacion_Servidor.Registro_Empresa();
                    frmRegistroEmpresa.ShowDialog();
                    
                    
                }
                else
                {
                    Validar_licencia();
                    DIBUJARusuarios();
                }

            }
            if (indicador == "INCORRECTO")
            {
                //this.Hide();
                this.Dispose();
                Formularios.Asistente_de_Instalacion_Servidor.Eleccion_Servidor_Remoto frmAsistenteInstalacionServidor = new Asistente_de_Instalacion_Servidor.Eleccion_Servidor_Remoto();
                frmAsistenteInstalacionServidor.ShowDialog();
                
            }
            try
            {

                //ManagementObject MOS = new ManagementObject(@"Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'");
                //ManagementObjectSearcher MOS = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                //foreach(ManagementObject getserial in MOS.Get())
                //{
                //    lblSerialPc.Text = getserial.Properties["SerialNumber"].Value.ToString();
                //    lblSerialPc.Text = lblSerialPc.Text.Trim();
                Logica.BasesPCProgram.obtener_serial_pc(ref lblSerialPc);
                MOSTRAR_CAJA_POR_SERIAL();
                try
                {
                    idcajavariable =Convert.ToInt32(datalistado_caja.SelectedCells[1].Value);
                    lblcaja.Text = datalistado_caja.SelectedCells[2].Value.ToString();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }

                /// }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            mostrar_licencia_temporal();
            try
            {
                dtpFecha_Final_Licencia_Temporal.Value = Convert.ToDateTime(Logica.BasesPCProgram.Desencriptar(datalistado_licencia_temporal.SelectedCells[3].Value.ToString()));
                lblSerialPcLocal = (Logica.BasesPCProgram.Desencriptar(datalistado_licencia_temporal.SelectedCells[2].Value.ToString()));
                lblEstadoLicenciaLocal.Text = (Logica.BasesPCProgram.Desencriptar(datalistado_licencia_temporal.SelectedCells[4].Value.ToString()));
                dtpFecha_Inicio_Licencia.Value = Convert.ToDateTime(Logica.BasesPCProgram.Desencriptar(datalistado_licencia_temporal.SelectedCells[5].Value.ToString()));

            }
            catch(Exception)
            {

            }
            /*if(lblEstadoLicenciaLocal.Text != "VENCIDO")
            {
                string FechaHoy = Convert.ToString(DateTime.Now);
                DateTime Fecha_ddmmyy = Convert.ToDateTime(FechaHoy.Split(' ')[0]);
                if(dtpFecha_Final_Licencia_Temporal.Value >= Fecha_ddmmyy)
                {
                    if(dtpFecha_Inicio_Licencia.Value <= Fecha_ddmmyy)
                    {
                        if(lblEstadoLicenciaLocal.Text == "?ACTIVO?")
                        {
                            ingresar_por_licencia_temporal();
                        }
                        else if(lblEstadoLicenciaLocal.Text == "?ACTIVADO PRO?")
                        {
                            ingresar_licencia_de_pago();
                        }
                     
                    }
                    else
                    {
                        Dispose();
                        Formularios.Licencias_y_Membresias.Membresias frmMembresias = new Licencias_y_Membresias.Membresias();
                        frmMembresias.ShowDialog();
                        

                    }

                } 
                else
                {
                    Dispose();
                    Formularios.Licencias_y_Membresias.Membresias frmMembresias = new Licencias_y_Membresias.Membresias();
                    frmMembresias.ShowDialog();
                    
                }


            }
            else
            {
                Dispose();
                Formularios.Licencias_y_Membresias.Membresias frmMembresias = new Licencias_y_Membresias.Membresias();
                frmMembresias.ShowDialog();
                

            }*/
        }

        private void ingresar_por_licencia_temporal()
        {
            lblEstadoLicencia.Text = "LICENCIA DE PRUEBA ACTIVADA EL: " + dtpFecha_Final_Licencia_Temporal.Text;
        }

        private void ingresar_licencia_de_pago()
        {
            lblEstadoLicencia.Text = "LICENCIA PROFESIONAL ACTIVADA HASTA EL: " + dtpFecha_Final_Licencia_Temporal.Text;
        }
        //int txtcontador_usuarios;
       

        private void Btn0_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "0";

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "9";
        }

        private void btnborrartodo_Click(object sender, EventArgs e)
        {
            txtpaswwor.Clear();

        }
        public static string Mid(string param, int startIndex, int length)
        {
            string result = param.Substring(startIndex, length);
            return result;
        }

        
        private void btnborrarderecha_Click(object sender, EventArgs e)
        {
            try
            {
                int largo;
                if (txtpaswwor.Text != "")
                    {
                    largo = txtpaswwor.Text.Length;
                    txtpaswwor.Text =Mid(txtpaswwor.Text, 1, largo - 1);
                    }
            }
            catch(Exception)
            {

            }
        }
        
        private void tver_Click(object sender, EventArgs e)
        {

            txtpaswwor.PasswordChar = '\0';
            tocultar.Visible = true;
            tver.Visible = false ;
        }

        private void tocultar_Click(object sender, EventArgs e)
        {
            txtpaswwor.PasswordChar  = '*';
            tocultar.Visible = false ;
            tver.Visible = true ;
        }

        private void btn_insertar_Click(object sender, EventArgs e)
        {
            
        }

        private void editar_inicio_de_sesion()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Conexiones.CADMaestra.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Editar_Inicio_De_Sesion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idusuariovariable);
                cmd.Parameters.AddWithValue("@idSerial_PC", lblSerialPc);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
          

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
        }

        private void txtcorreo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void timerValidaRol_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                BackColor = Color.FromArgb(0, 30, 49);
                progressBar1.Value = progressBar1.Value + 10;
                ptbSimulacion.Visible = true;

            }
            else
            {
                progressBar1.Value = 0;
                timerValidaRol.Stop();

                if (lblRol == Administrador)
                {
                    editar_inicio_de_sesion();
                    this.Dispose();
                    Formularios.Admin_Control.Adminitrador_Principal frmAdminPrincipal = new Admin_Control.Adminitrador_Principal();
                    frmAdminPrincipal.ShowDialog();
                    
                }
                else
                {
                    if (lblApertura_De_caja == "Nuevo*****" & lblRol == Cajero)
                    {
                        editar_inicio_de_sesion();
                        this.Dispose();
                        Formularios.Caja.Apertura_de_Caja frm = new Caja.Apertura_de_Caja();
                        frm.ShowDialog();
                        
                        
                    }
                    else if (lblApertura_De_caja == "Aperturado" & lblRol == Cajero)
                    {
                        editar_inicio_de_sesion();
                        this.Dispose();
                        Formularios.VENTAS_MENU_PRINCIPAL.Ventas_Menu_Principal frm = new VENTAS_MENU_PRINCIPAL.Ventas_Menu_Principal();
                        frm.ShowDialog();
                        
                    }
                    else if (lblRol == Vendedor)
                    {
                        editar_inicio_de_sesion();
                        this.Dispose();
                        Formularios.VENTAS_MENU_PRINCIPAL.Ventas_Menu_Principal frm = new VENTAS_MENU_PRINCIPAL.Ventas_Menu_Principal();
                        frm.ShowDialog();
                        

                    }
                }

            }
        }

        private void btn_insertar_Click_1(object sender, EventArgs e)
        {
            //Iniciar_sesion_correcto();
            MessageBox.Show("Usuario o contraseña Incorrectos", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtpaswwor.Clear();
        }

        private void btnCambiarUsuario_Click(object sender, EventArgs e)
        {
            panelIniciarSesionContraseña.Visible = false;
            panelUsuarios.Visible = true;
        }

        private void btnRecuperarPassword_Click(object sender, EventArgs e)
        {
            panelIniciarSesionContraseña.Visible = false;
            PanelRestaurarCuenta.Visible = true;
            mostrar_correos();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
