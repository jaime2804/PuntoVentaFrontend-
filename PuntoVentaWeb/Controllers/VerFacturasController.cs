using Microsoft.AspNetCore.Mvc;
using PuntoVentaWeb.Entities;
using PuntoVentaWeb.Models;
using PuntoVentaWeb.Services;

namespace PuntoVentaWeb.Controllers
{
	[FiltroSesiones]
	public class VerFacturasController(IVerFacturasModel iVerFacturasModel ) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public IActionResult ConsultarFacturas(DateTime? fechaInicio, DateTime? fechaFin, bool busquedaRealizada = false)
        {
            if (!busquedaRealizada)
            {
                // No mostrar alerta si no se ha hecho una búsqueda
                ViewBag.ShowAlert = false;
                return View(new List<VerFacturasEnt>());
            }

            if (!fechaInicio.HasValue || !fechaFin.HasValue)
            {
                ViewBag.ShowAlert = true;
                ViewBag.MsjPantalla = "Por favor, seleccione un rango de fechas válido.";
                return View(new List<VerFacturasEnt>());
            }

            var respuestaModelo = iVerFacturasModel.ConsultarFacturas(fechaInicio.Value, fechaFin.Value);

            if (respuestaModelo?.Codigo == "1")
            {
                ViewBag.ShowAlert = false;
                return View(respuestaModelo.Datos);
            }
            else
            {
                ViewBag.ShowAlert = true;
                ViewBag.MsjPantalla = "No se encontraron facturas en el rango de fechas especificado.";
                return View(new List<VerFacturasEnt>());
            }
        }




    }
}
