using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_Comercial.Logica
{
    public class LCreditoPorCobrar
    {

        public int idCreditoC { get; set; }
        public int Id_Caja { get; set; }
        public int idCliente { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public DateTime Fecha_Vencimiento { get; set;}
        public double Total { get; set; }
        public double Saldo { get; set; }
        public string Estado { get; set; }

    }
}
