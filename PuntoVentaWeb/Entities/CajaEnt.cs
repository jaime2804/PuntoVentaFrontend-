using System.ComponentModel;

namespace PuntoVentaWeb.Entities
{
    public class CajaEnt
    {
		[DisplayName("ID de la Caja")]

		public int IdCaja { get; set; }

        [DisplayName("Monto Inicial")]
        public decimal MontoInicial { get; set; }

        [DisplayName("Fecha de Creacion")]
        public DateTime FechaCreacion { get; set; }

        [DisplayName("Monto Actual")]
        public decimal MontoActual { get; set; }

        [DisplayName("Estado de Caja")]
        public string Estado { get; set; }
    }


    public class CajaRespuesta
    {
        public CajaRespuesta()
        {
            Codigo = "1";
            Mensaje = string.Empty;
            Dato = null;
            Datos = null;
        }

        public string Codigo { get; set; }
        public string Mensaje { get; set; }
        public CajaEnt? Dato { get; set; }
        public List<CajaEnt>? Datos { get; set; }
        // Lista de movimientos asociados
        public List<CajaEnt> Movimientos { get; set; } = new List<CajaEnt>();
    }
}
