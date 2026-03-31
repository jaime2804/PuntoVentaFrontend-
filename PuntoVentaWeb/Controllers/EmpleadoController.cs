using Microsoft.AspNetCore.Mvc;
using PuntoVentaWeb.Entities;
using PuntoVentaWeb.Models;
using PuntoVentaWeb.Services;

namespace PuntoVentaWeb.Controllers
{
	[FiltroSesiones]
	public class EmpleadoController(IEmpleadoModel _EmpleadoModel) : Controller
    {
        //Abre la vista:
        [HttpGet]
        public IActionResult RegistrarEmpleado()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarEmpleado(EmpleadoEnt entidad)
        {
            if (ModelState.IsValid)
            {
                var respuesta = _EmpleadoModel.RegistrarEmpleado(entidad);
                if (respuesta?.Codigo == "1")
                {
                    return Json(new { success = true, message = "Empleado registrado exitosamente." });
                }
                else
                {
                    return Json(new { success = false, message = respuesta?.Mensaje ?? "Error al registrar Empleado." });
                }
            }

            return Json(new { success = false, message = "Los datos enviados no son válidos." });
        }

        [HttpGet]
        public IActionResult ConsultarEmpleados()
        {
            var respuestaModelo = _EmpleadoModel.ConsultarEmpleados();

            if (respuestaModelo?.Codigo == "1")
                return View(respuestaModelo?.Datos);
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return View(new List<EmpleadoEnt>());
            }
        }

        [HttpGet]
        public IActionResult ActualizarEmpleado(int Cedula)
        {
            var respuestaModelo = _EmpleadoModel.ObtenerEmpleadoPorId(Cedula);
            return View(respuestaModelo?.Dato);
        }

        [HttpPost]
        public IActionResult ActualizarEmpleado(EmpleadoEnt entidad)
        {
            var respuestaModelo = _EmpleadoModel.ActualizarEmpleado(entidad);

            if (respuestaModelo?.Codigo == "1")
                return RedirectToAction("ConsultarEmpleados", "Empleado");
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return View();
            }
        }

        [HttpPost]
        public IActionResult EliminarEmpleado(int IdEmpleado)
        {
            var respuestaModelo = _EmpleadoModel.EliminarEmpleado(IdEmpleado);

            if (respuestaModelo?.Codigo == "1")
                return RedirectToAction("ConsultarEmpleados", "Empleado");
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje ?? "Error al eliminar el empleado";
                return View();
            }
        }

    }
}