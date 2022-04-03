using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_Comercial.Logica
{
    public class LCreditoPorPagar
    {

        public int idCredito { get; set; }
        public int Id_Caja { get; set; }
        public int idProveedor { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public double Total { get; set; }
        public double Saldo { get; set; }
        public string Estado { get; set; }



    }
}
