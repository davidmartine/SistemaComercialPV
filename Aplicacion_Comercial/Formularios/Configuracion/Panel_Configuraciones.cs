using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design;
using System.Windows.Forms;

namespace Aplicacion_Comercial.Formularios.Configuracion
{
    public partial class Panel_Configuraciones : Form
    {
        public Panel_Configuraciones()
        {
            InitializeComponent();
        }

        private void Panel_Configuraciones_Load(object sender, EventArgs e)
        {
            //panel1.Location = new Point((Width - panel1.Width) / 2, (Height - panel1.Height) / 2);
        }


        private void productos()
        {
            this.Dispose();
            Formularios.Productos.Productos frmProductos = new Productos.Productos();
            frmProductos.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            productos();
        }

        private void editar_configuracion_empresa()
        {
            this.Dispose();
            Formularios.Configuracion_Empresa.Empresa_Confi frmEmpresaConfig = new Configuracion_Empresa.Empresa_Confi();
            frmEmpresaConfig.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            editar_configuracion_empresa();
        }

        private void editar_usuarios()
        {
            this.Dispose();
            Formularios.Usuarios_y_Permisos.usuarios frmUsuarios = new Usuarios_y_Permisos.usuarios();
            frmUsuarios.ShowDialog();
        }

        private void editar_clientes()
        {
            Formularios.Clientes_Proveedores.Clientes frmclientes = new Clientes_Proveedores.Clientes();
            frmclientes.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            editar_usuarios();
        }
        private void copias_base_datos()
        {
            Formularios.Copias_BaseDatos.Crear_CopiasDB copiasDB = new Copias_BaseDatos.Crear_CopiasDB();
            copiasDB.ShowDialog();
        }

        private void configurar_correo()
        {
            Formularios.CorreoBase.ConfigurarCorreoBase frmconfigurarcorreo = new CorreoBase.ConfigurarCorreoBase();
            frmconfigurarcorreo.ShowDialog();
        }
        private void balanza() 
        {
            Formularios.BalanzaElectronica.Balanza frmbalanza = new BalanzaElectronica.Balanza();
            frmbalanza.ShowDialog();

        }

        private void btnEditarEmpresa_Click(object sender, EventArgs e)
        {
            editar_configuracion_empresa();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            editar_usuarios();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            productos();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            editar_clientes();
        }


        private void btnBalanza_Click_1(object sender, EventArgs e)
        {
            balanza();
        }

        private void btnCorreo_Click(object sender, EventArgs e)
        {
            configurar_correo();
        }

        private void btnBaseDatos_Click(object sender, EventArgs e)
        {
            copias_base_datos();
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            mostrar_caja();
        }

        private void mostrar_caja()
        {
            this.Dispose();
            Formularios.Caja.Control_de_Caja frmcontrolcaja = new Caja.Control_de_Caja();
            frmcontrolcaja.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            mostrar_caja();
        }

        private void btnSerializacion_Click(object sender, EventArgs e)
        {
            serializacion();
        }

        private void serializacion()
        {
            this.Dispose();
            Formularios.Serializacion_de_Comprobantes.Serializacion frmserializacion = new Serializacion_de_Comprobantes.Serializacion();
            frmserializacion.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            serializacion();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            editar_clientes();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            proveedores();
        }

        private void proveedores()
        {
            this.Dispose();
            Formularios.Clientes_Proveedores.Proveedores frmproveedores = new Clientes_Proveedores.Proveedores();
            frmproveedores.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            proveedores();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            diseno_comprobantes();
        }

        private void diseno_comprobantes()
        {
            this.Dispose();
            Formularios.Serializacion_de_Comprobantes.Serializacion frmserializacion = new Serializacion_de_Comprobantes.Serializacion();
            frmserializacion.ShowDialog();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            diseno_comprobantes();
        }

        private void btnImpresora_Click(object sender, EventArgs e)
        {
            impresora();
        }

        private void impresora()
        {
            this.Dispose();
            Formularios.Impresoras.frmImpresoras frmimpresoras = new Impresoras.frmImpresoras();
            frmimpresoras.ShowDialog();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            impresora();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            balanza();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            configurar_correo();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            copias_base_datos();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Formularios.Admin_Control.Adminitrador_Principal frmadminitrador = new Admin_Control.Adminitrador_Principal();
            frmadminitrador.ShowDialog();
        }
    }
}
