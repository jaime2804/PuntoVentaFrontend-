using PuntoVentaWeb.Entities;
using static PuntoVentaWeb.Entities.ProductoEnt;

namespace PuntoVentaWeb.Services
{
    public interface IProductoModel
    {
        ProductoRespuesta? ConsultarProductos();
        ProductoRespuesta? ConsultarUnProducto(string IdProducto);

        ProductoRespuesta? RegistrarProducto(ProductoEnt entidad);
        ProductoRespuesta? ActualizarProducto(ProductoEnt entidad);

        ProductoRespuesta? EliminarProducto(string IdProducto);
    }
}
