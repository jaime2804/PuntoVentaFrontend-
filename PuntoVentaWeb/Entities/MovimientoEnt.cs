using System.ComponentModel;

namespace PuntoVentaWeb.Entities
{
   
   

    public class MovimientoEnt
    {
		[DisplayName("ID del Movimiento")]
		public int IdMovimiento { get; set; }

		[DisplayName("ID de la Caja")]
		public int IdCaja { get; set; }

		[DisplayName("Tipo de Movimiento")]
		public string TipoMovimiento { get; set; }  // Ejemplo: "Ingreso" o "Egreso"

		[DisplayName("Monto del movimiento")]
		public decimal Monto { get; set; }

		[DisplayName("Descripción")]
		public string Descripcion { get; set; }

		[DisplayName("Fecha")]
		public DateTime Fecha { get; set; }


    }


    public class MovimientoRespuesta
    {
        public MovimientoRespuesta()
        {
            Codigo = "1";
            Mensaje = string.Empty;
            Dato = null;
            Datos = null;
        }

        public string Codigo { get; set; }
        public string Mensaje { get; set; }
        public MovimientoEnt? Dato { get; set; }
        public List<MovimientoEnt>? Datos { get; set; }
    }
}
