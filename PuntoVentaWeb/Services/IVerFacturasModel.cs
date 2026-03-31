using static PuntoVentaWeb.Entities.VerFacturasEnt;

namespace PuntoVentaWeb.Services
{
    public interface IVerFacturasModel
    {

        VerFacturasRespuesta ConsultarFacturas(DateTime fechaInicio, DateTime fechaFin);
    }
}
