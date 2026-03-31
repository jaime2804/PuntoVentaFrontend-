using PuntoVentaWeb.Entities;
using System.Collections.Generic;

namespace PuntoVentaWeb.Services
{
    public interface ICarritoModel
    {
        Carrito GetCarrito();
        void AgregarProducto(string productoId, int cantidad);
        void EliminarProducto(string productoId);
        void AgregarProductoPorId(string productoId);
        void VaciarCarrito();
    }
}
