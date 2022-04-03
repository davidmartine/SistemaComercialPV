using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
namespace Aplicacion_Comercial.Conexiones
{
    class Desencryptacion
    {
        static private AES aes = new AES();
        static public string CnString;
        static string dbcnString;
        public static string appPwdUnique = "SYSGETCO.COMERC.PuntoVenta.A4sfc45rtrdfhgbddsgfhfghytgfsdvadc";


        public static object checkServer()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ConnectionString.xml");
            XmlElement root = doc.DocumentElement;
            dbcnString = root.Attributes[0].Value;
            CnString = (aes.Decrypt(dbcnString, appPwdUnique, int.Parse("256")));
            return CnString;

        }


        internal class label
        {

        }
        public static object UsuariosEncryp()
        {
            XmlDocument doc = new XmlDocument();
            label root = new label();

            dbcnString = root.ToString();
            CnString = (aes.Decrypt(dbcnString, appPwdUnique, int.Parse("256")));
            return CnString;

        }
    }
}
