using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PuntoVentaWeb.Entities;
using PuntoVentaWeb.Models;
using PuntoVentaWeb.Services;

namespace PuntoVentaWeb.Controllers
{
	[FiltroSesiones]
	public class ArqueoController(IArqueoModel _ArqueoModel) : Controller
    {

        //------------------------------------------------------------------------------------------Caja---------------------------------------------------------------------------------------- //

        [HttpGet]
        public IActionResult CrearCaja()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearCaja(CajaEnt entidad)
        {
            var RespuestaApi = _ArqueoModel.CrearCaja(entidad);

            if (RespuestaApi?.Codigo == "1")
                return RedirectToAction("ObtenerTodosArqueos", "Arqueo");
            else
            {
                return RedirectToAction("ObtenerTodosArqueos", "Arqueo");
            }
        }


        [HttpPost]
        public IActionResult EliminarCaja(CajaEnt entidad)
        {
            var respuestaModelo = _ArqueoModel.EliminarCaja(entidad.IdCaja);

            if (respuestaModelo?.Codigo == "1")
                return RedirectToAction("ObtenerTodosArqueos", "Arqueo");
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return RedirectToAction("ObtenerTodosArqueos", "Arqueo");
            }
        }


        [HttpGet]
        public IActionResult ObtenerTodosArqueos()
        {
            var respuestaModelo = _ArqueoModel.ObtenerTodosArqueos();

            if (respuestaModelo?.Codigo == "1")
                return View(respuestaModelo?.Datos);
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return View(new List<CajaEnt>());
            }
        }


        //------------------------------------------------------------------------------------------Arqueos---------------------------------------------------------------------------------------- //

        [HttpGet]
        public IActionResult CalcularCierreSemanal()
        {
            var respuestaModelo = _ArqueoModel.CalcularCierreSemanal();

            if (respuestaModelo?.Codigo == "1")
                return View(respuestaModelo?.Datos);
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return View(new List<CierreSemanalEnt>());
            }
        }

        [HttpGet]
        public IActionResult RegistrarArqueo(int IdCaja)
        {
            var respuestaModelo = _ArqueoModel.ObtenerCajaPorArqueoId(IdCaja);
            return View(respuestaModelo?.Dato);
        }

        [HttpPost]
        public IActionResult RegistrarArqueo(ArqueoEnt entidad)
        {
            var RespuestaApi = _ArqueoModel.RegistrarArqueo(entidad);

            if (RespuestaApi?.Codigo == "1")
                return RedirectToAction("ObtenerTodosArqueos", "Arqueo");
            else
            {
                return RedirectToAction("ObtenerTodosArqueos", "Arqueo");
            }
        }

        //------------------------------------------------------------------------------------------Movimientos---------------------------------------------------------------------------------------- //

        [HttpGet]
        public IActionResult ObtenerMovimientos()
        {
            var respuestaModelo = _ArqueoModel.ObtenerMovimientos();

            if (respuestaModelo?.Codigo == "1")
                return View(respuestaModelo?.Datos);
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return View(new List<MovimientoEnt>());
            }
        }


		[HttpGet]
		public IActionResult ConsultarUnMovimiento(int IdCaja)
		{
			var respuestaModelo = _ArqueoModel.ConsultarUnMovimiento(IdCaja);

			if (respuestaModelo?.Codigo == "1")
				return View(respuestaModelo?.Datos);
			else
			{
				ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
				return View(new List<MovimientoEnt>());
			}

		}


		[HttpGet]
        public IActionResult RegistrarMovimiento(int IdCaja)
        {
            var respuestaModelo = _ArqueoModel.ObtenerCajaPorMovimientoId(IdCaja);
            return View(respuestaModelo?.Dato);
        }

        [HttpPost]
        public IActionResult RegistrarMovimiento(MovimientoEnt entidad)
        {
            var RespuestaApi = _ArqueoModel.RegistrarMovimiento(entidad);

            if (RespuestaApi?.Codigo == "1")
                return RedirectToAction("ObtenerTodosArqueos", "Arqueo");
            else
            {
                return RedirectToAction("ObtenerTodosArqueos", "Arqueo");
            }
        }

    }
}

