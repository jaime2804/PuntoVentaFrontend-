using PuntoVentaWeb.Entities;
using static PuntoVentaWeb.Entities.ProveedorEnt;

namespace PuntoVentaWeb.Services
{
    public interface IProveedorModel
    {
        ProveedorRespuesta? ConsultarProveedores();
        ProveedorRespuesta? ConsultarUnProveedor(long IdProveedor);

        ProveedorRespuesta? RegistrarProveedor(ProveedorEnt entidad);
        ProveedorRespuesta? ActualizarProveedor(ProveedorEnt entidad);

        ProveedorRespuesta? EliminarProveedor(long IdProveedor);
    }
}
