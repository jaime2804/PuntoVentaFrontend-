using Microsoft.AspNetCore.Mvc;
using PuntoVentaWeb.Entities;
using PuntoVentaWeb.Models;
using PuntoVentaWeb.Services;

namespace PuntoVentaWeb.Controllers
{
	[FiltroSesiones]
	public class InventarioController(IInventarioModel _InventarioModel) : Controller
    {
        
        [HttpGet]
        public IActionResult ConsultarInventario()
        {
            var respuestaModelo = _InventarioModel.ConsultarInventario();

            if (respuestaModelo?.Codigo == "1")
                return View(respuestaModelo?.Datos);
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return View(new List<InventarioEnt>());
            }
        }

    }
}
