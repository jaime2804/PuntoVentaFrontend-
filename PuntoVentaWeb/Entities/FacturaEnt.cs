using PuntoVentaWeb.Controllers;

namespace PuntoVentaWeb.Entities
{
    public class FacturaEnt
    {


            public int IdDetalle { get; }
            public int IdFactura { get; set; }
            public string? IdProducto { get; set; }
            public string? NombreProducto { get; set; }
            public int Cantidad { get; set; }
            public decimal PrecioUnitario { get; set; }
            public decimal TotalDetalle { get; set; }
            public string? Fecha {  get; set; }

            public decimal SubTotal { get; set; }
            public decimal IVA { get; set; }
            public decimal TotalFactura { get; set; }
            public decimal Pago { get; set; }
        public string? TipoPago { get; set; }
        public decimal Cambio { get; set; }


        public int NuevaFactura { get; set; }
            public int IdCajero { get; set; }
            public int Descuento { get; set; }

        

        public class FacturaRespuesta
        {
            public FacturaRespuesta()
            {
                Codigo = "1";
                Mensaje = string.Empty;
                Dato = null;
                Datos = null;
            }

            public string Codigo { get; set; }
            public string Mensaje { get; set; }
            public FacturaEnt? Dato { get; set; }
            public List<FacturaEnt>? Datos { get; set; }

        }
    }

}
