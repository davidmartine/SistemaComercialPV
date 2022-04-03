using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_Comercial.Logica
{
    public class LEmpresa
    {
        public int idEmpresa { get; set; }
        public string Nombre_Empresa { get; set; }
        public byte[] Logo { get; set; }
        public string Impuesto { get; set; }
        public double Porcentaje_Impuesto { get; set; }
        public string Moneda { get; set; }
        public string Trabaja_Con_Impuestos { get; set; }
        public string Modo_De_Busqueda { get; set; }
        public string Carpeta_Para_Copias_De_Seguridad { get; set; }
        public string Correo_Para_Envio_De_Reportes { get; set; }
        public string Ultima_Fecha_De_Copia_De_Seguridad { get; set; }
        public DateTime Ultima_Fecha_De_Copia_Date { get; set; }
        public int Fecuencia_De_Copias { get; set; }
        public string Estado { get; set; }
        public string Tipo_Empresa { get; set; }
        public string Pais { get; set; }
        public string Redondeo_Total { get; set; }


    }
}
