using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_Comercial.Logica
{
    public class LMCajaCierre
    {
        public int idCierreCaja { get; set; }
        public DateTime FechaIniciio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaCierre { get; set; }
        public double Ingresos { get; set; }
        public double Egresos { get; set; }
        public double SaldoQuedaEnCaja { get; set; }
        public int idUsuario { get; set; }
        public double TotalCalculado { get; set; }
        public double TotalReal { get; set; }
        public string Estado { get; set; }
        public double Direferencia { get; set; }
        public int idCaja { get; set; }

    }
}
