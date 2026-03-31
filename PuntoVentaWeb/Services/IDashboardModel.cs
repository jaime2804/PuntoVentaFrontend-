using PuntoVentaWeb.Entities;
using static PuntoVentaWeb.Entities.DashboardEnt;

namespace PuntoVentaWeb.Services
{
    public interface IDashboardModel
	{
        DashboardRespuesta? ObtenerDashboard();
        
    }
}
