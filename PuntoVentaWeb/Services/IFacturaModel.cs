
using PuntoVentaWeb.Entities;
using static PuntoVentaWeb.Entities.FacturaEnt;


namespace PuntoVentaWeb.Services
{
    public interface IFacturaModel
    {

        FacturaRespuesta? RegistrarFactura(FacturaEnt entidad);
        FacturaRespuesta? ConsultarFactura();

        FacturaRespuesta? ConsultarUnaFactura(int IdFactura);
        FacturaRespuesta? ConsultarUltimaFactura();
    }
}
