using PuntoVentaWeb.Entities;
using static PuntoVentaWeb.Entities.InventarioEnt;
using static PuntoVentaWeb.Entities.InventarioEnt;

namespace PuntoVentaWeb.Services
{
    public interface IInventarioModel
    {
        InventarioRespuesta? ConsultarInventario();

    }
}
