using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_Comercial.Logica
{
    public class LKardex
    {
        public int idKardex { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
        public double Cantidad { get; set; }
        public int idProducto { get; set; }
        public int idUsuario { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public double CostoUnitario { get; set; }
        public double Habia { get; set; }
        public double Hay { get; set; }
        public int idCaja { get; set; }
    }
}
