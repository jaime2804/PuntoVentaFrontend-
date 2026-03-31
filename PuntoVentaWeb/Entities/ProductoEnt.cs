using System.ComponentModel.DataAnnotations;

namespace PuntoVentaWeb.Entities
{
    public class ProductoEnt
    {
        
            public string IdProducto { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }

        [Range(0, 100, ErrorMessage = "El stock debe ser un número entre 0 y 1000.")]
        public int Stock { get; set; }


        public int IdCategoria { get; set;}

        public string? NombreCategoria { get; set; }
        }
    public class ProductoRespuesta
    {
        public ProductoRespuesta()
        {
            Codigo = "1";
            Mensaje = string.Empty;
            Dato = null;
            Datos = null;
        }

        public string Codigo { get; set; }
        public string Mensaje { get; set; }
        public ProductoEnt? Dato { get; set; }
        public List<ProductoEnt>? Datos { get; set; }
    }
}

