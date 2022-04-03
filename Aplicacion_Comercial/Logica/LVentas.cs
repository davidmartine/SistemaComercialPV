using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_Comercial.Logica
{
    public class LVentas
    {
        public int idVenta { get; set; }
        public int idUsuario { get; set; }
        public int idCaja { get; set; }
        public int idCliente { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaVenta { get; set; }
        public double MontoTotal { get; set; }
        public string TipoPago { get; set; }
        public string Estado { get; set; }
        public double Impuesto { get; set; }
        public string Comprobante { get; set; }
        public string FechaPago { get; set; }
        public string Accion { get; set; }
        public double Saldo { get; set; }
        public double PagoCon { get; set; }
        public double PorcentajeImpuesto { get; set; }
        public string ReferenciaTarjeta { get; set; }
        public double Vuelto { get; set; }
        public double Efectivo { get; set; }
        public double Credito { get; set; }
        public double Tarjeta { get; set; }

    
    }
}
