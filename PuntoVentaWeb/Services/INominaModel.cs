using PuntoVentaWeb.Entities;
using static PuntoVentaWeb.Entities.EmpleadoEnt;
using static PuntoVentaWeb.Entities.NominaEnt;

namespace PuntoVentaWeb.Services
{
    public interface INominaModel
    {

        NominaRespuesta? CrearNomina(NominaEnt nomina);

        NominaRespuesta? ObtenerEmpleadoPorId(int Cedula);
        List<NominaEnt> ObtenerNominas();
    }
}