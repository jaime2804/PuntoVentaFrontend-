using Microsoft.AspNetCore.Mvc;
using PuntoVentaWeb.Entities;
using PuntoVentaWeb.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using PuntoVentaWeb.Models;
using System.Threading.Tasks;
using static PuntoVentaWeb.Entities.UsuarioEnt;

namespace PuntoVentaWeb.Controllers
{
	
	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioModel _usuarioModel;
        private readonly IComunModel _comunModel;

        public UsuarioController(IUsuarioModel usuarioModel, IComunModel comunModel)
        {
            _usuarioModel = usuarioModel;
            _comunModel = comunModel;
        }
        [FiltroSesiones]
        [HttpGet]
        public IActionResult RegistrarUsuario()
        {
            ViewBag.Roles = GetRoles();
            return View();
        }
        [FiltroSesiones]
        [HttpPost]
        public async Task<IActionResult> RegistrarUsuario(UsuarioEnt entidad)
        {
            entidad.Contrasenna = _comunModel.Encrypt(entidad.Contrasenna!);
            if (ModelState.IsValid)
            {
                var respuesta = await _usuarioModel.RegistrarUsuarioAsync(entidad);
                if (respuesta?.Codigo == "1")
                {
                    return Json(new { success = true, message = "Usuario registrado exitosamente." });
                }
                else
                {
                    return Json(new { success = false, message = respuesta?.Mensaje ?? "Error al registrar usuario." });
                }
            }

            return Json(new { success = false, message = "Los datos enviados no son válidos." });
      
        }

        private List<SelectListItem> GetRoles()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Admin" },
                new SelectListItem { Value = "2", Text = "User" }
            };
        }

        [HttpGet]
        public IActionResult LoginUsuario()
        {
            return View();
        }


		[HttpPost]
        public async Task<IActionResult> LoginUsuario(UsuarioEnt entidad)
        {
            if (ModelState.IsValid)
            {
                entidad.Contrasenna = _comunModel.Encrypt(entidad.Contrasenna!);
                var respuestaApi = await _usuarioModel.LoginUsuarioAsync(entidad);

                if (respuestaApi?.Codigo == "1" && respuestaApi.Dato != null)
                {
                    var datos = respuestaApi.Dato;

                    // Guarda los datos del usuario en la sesión
                    HttpContext.Session.SetString("TOKEN", datos.Token!);
                    HttpContext.Session.SetString("NOMBRE", datos.Nombre!);
                    HttpContext.Session.SetInt32("IdUsuario", datos.IdUsuario!);
                    HttpContext.Session.SetString("ROL", datos.IdRol.ToString());

                    // Detecta si la solicitud es Ajax
                    if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    {
                        return Json(new { success = true, message = "Inicio de sesión exitoso." });
                    }

                    // Redirige al Dashboard si no es una solicitud Ajax
                    return RedirectToAction("ObtenerDashboard", "Dashboard");
                }
                else
                {
                    string mensajeError = respuestaApi?.Mensaje ?? "Credenciales incorrectas.";

                    if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    {
                        return Json(new { success = false, message = mensajeError });
                    }

                    ViewData["Mensaje"] = mensajeError;
                    return View(entidad);
                }
            }

            // Si el modelo no es válido
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Json(new { success = false, message = "Los datos proporcionados no son válidos." });
            }

            return View(entidad);
        }

		[FiltroSesiones]
		[HttpGet]
        public async Task<IActionResult> ConsultarUsuarios()
        {
            var respuestaApi = await _usuarioModel.ConsultarUsuariosAsync();
            if (respuestaApi?.Codigo == "1" && respuestaApi.Datos != null)
            {
                var datos = respuestaApi.Datos;
                return View(datos);
            }

            return View(new List<UsuarioEnt>());
        }
		[FiltroSesiones]
		[HttpGet]
        public async Task<IActionResult> ActualizarUsuario(int IdUsuario)
        {
            var respuestaModelo = await _usuarioModel.ConsultarUnUsuarioAsync(IdUsuario);
            if (respuestaModelo?.Codigo == "1")
            {
                return View(respuestaModelo.Dato);
            }
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return RedirectToAction("ConsultarUsuarios");
            }
        }
		[FiltroSesiones]
		[HttpPost]
        public async Task<IActionResult> ActualizarUsuario(UsuarioEnt entidad)
        {
            var respuestaModelo = await _usuarioModel.ActualizarUsuarioAsync(entidad);
            if (respuestaModelo?.Codigo == "1")
            {
                return RedirectToAction("ConsultarUsuarios");
            }
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return View(entidad);
            }
        }
		[FiltroSesiones]
		[HttpPost]
        public async Task<IActionResult> EliminarUsuario(UsuarioEnt entidad)
        {
            var respuestaModelo = await _usuarioModel.EliminarUsuarioAsync(entidad.IdUsuario);
            if (respuestaModelo?.Codigo == "1")
                return RedirectToAction("ConsultarUsuarios");
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return View();
            }
        }
		[FiltroSesiones]
		[HttpGet]
        public IActionResult Salir()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginUsuario", "Usuario");
        }
    }
}