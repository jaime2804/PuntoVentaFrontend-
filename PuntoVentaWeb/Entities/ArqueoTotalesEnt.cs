using System.ComponentModel;

namespace PuntoVentaWeb.Entities
{
    public class ArqueoTotalesEnt
    {
		[DisplayName("Total de Billetes")]
		public decimal TotalBilletes { get; set; }
		[DisplayName("Total de Monedas")]
		public decimal TotalMonedas { get; set; }
		[DisplayName("Total de Efectivo")]
		public decimal TotalEfectivo { get; set; }
    }

    public class ArqueoTotalesRespuesta
    {
        public ArqueoTotalesRespuesta()
        {
            Codigo = "1";
            Mensaje = string.Empty;
            Dato = null;
            Datos = null;
        }

        public string Codigo { get; set; }
        public string Mensaje { get; set; }
        public ArqueoTotalesEnt? Dato { get; set; }
        public List<ArqueoTotalesEnt>? Datos { get; set; }
    }
}