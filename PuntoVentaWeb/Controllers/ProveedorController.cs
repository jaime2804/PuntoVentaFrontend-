using Microsoft.AspNetCore.Mvc;
using PuntoVentaWeb.Entities;
using PuntoVentaWeb.Services;

namespace PuntoVentaWeb.Controllers
{
	[FiltroSesiones]
	public class ProveedorController(IProveedorModel _proveedorModel) : Controller
    {
        //Abre la vista:
        [HttpGet]
        public IActionResult RegistrarProveedor()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult RegistrarProveedor(ProveedorEnt entidad)
        {
            if (ModelState.IsValid)
            {
                var respuesta = _proveedorModel.RegistrarProveedor(entidad);
                if (respuesta?.Codigo == "1")
                {
                    return Json(new { success = true, message = "Proveedor registrado exitosamente." });
                }
                else
                {
                    return Json(new { success = false, message = respuesta?.Mensaje ?? "Error al registrar proveedor." });
                }
            }

            return Json(new { success = false, message = "Los datos enviados no son válidos." });
        }


        [HttpGet]
        public IActionResult ConsultarProveedores()
        {
            var respuestaModelo = _proveedorModel.ConsultarProveedores();

            if (respuestaModelo?.Codigo == "1")
                return View(respuestaModelo?.Datos);
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return View(new List<ProveedorEnt>());
            }
        }

        [HttpGet]
        public IActionResult ActualizarProveedor(long IdProveedor)
        {
            var respuestaModelo = _proveedorModel.ConsultarUnProveedor(IdProveedor);
            return View(respuestaModelo?.Dato);
        }

        [HttpPost]
        public IActionResult ActualizarProveedor(ProveedorEnt entidad)
        {
            var respuestaModelo = _proveedorModel.ActualizarProveedor(entidad);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                // Respuesta para solicitudes AJAX
                if (respuestaModelo?.Codigo == "1")
                {
                    return Json(new { success = true, message = "Proveedor actualizado correctamente." });
                }
                else
                {
                    return Json(new { success = false, message = respuestaModelo?.Mensaje ?? "Error al actualizar el proveedor." });
                }
            }
            else
            {
                // Respuesta para solicitudes normales (no AJAX)
                if (respuestaModelo?.Codigo == "1")
                    return RedirectToAction("ConsultarProveedores", "Proveedor");
                else
                {
                    ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                    return View();
                }
            }
        }


        [HttpPost]
        public IActionResult EliminarProveedor(ProveedorEnt entidad)
        {
            var respuestaModelo = _proveedorModel.EliminarProveedor(entidad.IdProveedor);

            if (respuestaModelo?.Codigo == "1")
                return RedirectToAction("ConsultarProveedores", "Proveedor");
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return View();
            }
        }

    }
}
