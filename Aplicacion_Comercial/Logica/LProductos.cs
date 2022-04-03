using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_Comercial.Logica
{
    public class LProductos
    {
        public int idProducto { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public int idGrupo { get; set; }
        public string UsaInventario { get; set; }
        public string Stock { get; set; }
        public double PrecioCompra { get; set; }
        public string FechaVencimiento { get; set; }
        public double PrecioVenta { get; set; }
        public string Codigo { get; set; }
        public string SeVendeA { get; set; }
        public string Impuesto { get; set; }
        public double StockMinimo { get; set; }
        public double PrecioMayoreo { get; set; }
        public double ApartirDe { get; set; } 

    }
}
