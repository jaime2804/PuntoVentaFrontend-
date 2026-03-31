using Microsoft.AspNetCore.Mvc;
using PuntoVentaWeb.Entities;
using PuntoVentaWeb.Services;

namespace PuntoVentaWeb.Controllers
{
	[FiltroSesiones]
	public class DashboardController : Controller
    {
        private readonly IDashboardModel _dashboardModel;

        public DashboardController(IDashboardModel dashboardModel)
        {
            _dashboardModel = dashboardModel;
        }

        [HttpGet]
        public IActionResult ObtenerDashboard()
        {
            var respuestaModelo = _dashboardModel.ObtenerDashboard();

            if (respuestaModelo?.Codigo == "1")
                return View(respuestaModelo?.Dato); // Asegúrate de pasar `Dato` y no `Datos`
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return View(new DashboardEnt()); // Pasar un objeto vacío si hay error
            }
        }
    }
}
