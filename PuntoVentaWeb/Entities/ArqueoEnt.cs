using System.ComponentModel;

namespace PuntoVentaWeb.Entities
{
    public class ArqueoEnt
    {
		[DisplayName("Id de Arqueo")]
		public int IdArqueo { get; set; }
		[DisplayName("Id de Caja")]
		public int IdCaja { get; set; }

		[DisplayName("Billetes de ₡1000")]
		public int? Billetes1000 { get; set; }

		[DisplayName("Billetes de ₡2000")]
		public int? Billetes2000 { get; set; }

		[DisplayName("Billetes de ₡5000")]
		public int? Billetes5000 { get; set; }

		[DisplayName("Billetes de ₡10000")]
		public int? Billetes10000 { get; set; }

		[DisplayName("Billetes de ₡20000")]
		public int? Billetes20000 { get; set; }

		[DisplayName("Monedas de ₡5")]
		public int? Monedas5 { get; set; }

		[DisplayName("Monedas de ₡10")]
		public int? Monedas10 { get; set; }

		[DisplayName("Monedas de ₡25")]
		public int? Monedas25 { get; set; }

		[DisplayName("Monedas de ₡50")]
		public int? Monedas50 { get; set; }

		[DisplayName("Monedas de ₡100")]
		public int? Monedas100 { get; set; }

		[DisplayName("Monedas de ₡500")]
		public int? Monedas500 { get; set; }

		[DisplayName("Fecha")]
		public DateTime Fecha { get; set; }

    }

    public class ArqueoRespuesta
    {
        public ArqueoRespuesta()
        {
            Codigo = "1";
            Mensaje = string.Empty;
            Dato = null;
            Datos = null;
        }

        public string Codigo { get; set; }
        public string Mensaje { get; set; }
        public ArqueoEnt? Dato { get; set; }
        public List<ArqueoEnt>? Datos { get; set; }
    }

    
}
