using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_Comercial.Logica
{
    public class LControlCobros
    {
        public int idControlCobros { get; set; }
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; }
        public int idCliente { get; set; }
        public int idUsuario { get; set; }
        public int Id_Caja { get; set; }
        public string Comprobante { get; set; }
        public double Efectivo { get; set; }
        public double Tarjeta { get; set; }

    }
}
