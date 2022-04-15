using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion_Comercial.Formularios.CorreoBase
{
    public partial class ConfigurarCorreoBase : Form
    {
        public ConfigurarCorreoBase()
        {
            InitializeComponent();
        }

        private void ConfigurarCorreoBase_Load(object sender, EventArgs e)
        {

        }
        private void btnSincronizar_Click_1(object sender, EventArgs e)
        {
            bool Estado;
            Estado = Logica.BasesPCProgram.enviarCorreo(emisor: txtCorreo.Text, password: txtPassword.Text, mensaje: "SINCRONIZACION CON SYSGETCO CREADA CORRECTAMENTE", asunto: "SINCRONIZACION CON SYSGETCO", destinatario: txtCorreo.Text, ruta: "-");
            if (Estado == true)
            {
                Editar_correo_base();
                MessageBox.Show("SINCRONIZACION CREADA CORRECTAMENTE", "SINCRONIZACION CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("SINCRONIZACION FALLIDA,INTENTA NUEVAMENTE MIRA LAS INSTACCIONES COMO LO INDICA EL VIDEO", "SINCRONIZACION FALLIDA", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Editar_correo_base()
        {
            Logica.LCorreoBase correo_parametros = new Logica.LCorreoBase();
            Datos.CADEditarDatos funcion = new Datos.CADEditarDatos();
            correo_parametros.Corrreo = Logica.BasesPCProgram.Encriptar(txtCorreo.Text);
            correo_parametros.Password = Logica.BasesPCProgram.Encriptar(txtPassword.Text);
            correo_parametros.EstadoCorreo = Logica.BasesPCProgram.Encriptar("SINCRONIZADO");
            funcion.Editar_base_correo(correo_parametros);


        }

        private void pcbTutorial_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/");

        }

        
    }
}
