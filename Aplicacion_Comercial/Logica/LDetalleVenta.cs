using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_Comercial.Logica
{
    public class LDetalleVenta
    {
        public int idDetalleVenta { get; set; }
        public int idVenta { get; set; }
        public int idProducto { get; set; }
        public double Cantidad { get; set; }
        public double Precio_Mayoreo { get; set; }
        public string Moneda { get; set; }
        public string Unidad_de_Medida { get; set; }
        public double Cantidad_Mostrada { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public string Codigo_Producto { get; set; }
        public string Stock { get; set; }
        public string Se_vende_a { get; set; }
        public double Costo { get; set; }
        public string Usa_Inventario { get; set; }
    }
}
