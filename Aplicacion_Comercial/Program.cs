using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion_Comercial
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Formularios.Logins.LOGIN frmLogin = new Formularios.Logins.LOGIN();
            //Formularios.Configuracion.Panel_Configuraciones frmLogin = new Formularios.Configuracion.Panel_Configuraciones();
            frmLogin.FormClosed += FrmLogin_FormClosed;
            frmLogin.ShowDialog();
            Application.Run();

        }

        private static void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }
    }
}
