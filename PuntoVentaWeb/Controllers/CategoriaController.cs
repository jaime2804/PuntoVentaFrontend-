using Microsoft.AspNetCore.Mvc;
using PuntoVentaWeb.Entities;
using PuntoVentaWeb.Services;

namespace PuntoVentaWeb.Controllers
{
	[FiltroSesiones]
	public class CategoriaController : Controller
    {
        private readonly ICategoriaModel _categoriaModel;

        public CategoriaController(ICategoriaModel categoriaModel)
        {
            _categoriaModel = categoriaModel;
        }

        // Método para abrir la vista de registro de categoría
        [HttpGet]
        public IActionResult RegistrarCategoria()
        {
            return View();
        }

        // Método de verificación de existencia de categoría por nombre
        [HttpGet]
        public IActionResult ExisteCategoria(string nombre)
        {

            var respuestaModelo = _categoriaModel.ConsultarCategorias();

            bool existe = respuestaModelo?.Datos?.Any(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)) ?? false;

            return Json(new { existe });
        }

        // Método para registrar una nueva categoría
        [HttpPost]
        public IActionResult RegistrarCategoria(CategoriaEnt entidad)
        {
            
            var existeCategoria = ExisteCategoria(entidad.Nombre) as JsonResult;
            var existe = (bool)((dynamic)existeCategoria.Value).existe;

            if (existe)
            {
                
                ViewBag.MsjPantalla = "La categoría ya existe.";
                return View(entidad);
            }

            
            var RespuestaApi = _categoriaModel.RegistrarCategoria(entidad);

            if (RespuestaApi?.Codigo == "1")
                return RedirectToAction("ConsultarCategorias", "Categoria");
            else
            {
                ViewBag.MsjPantalla = RespuestaApi?.Mensaje;
                return View(entidad);
            }
        }


        // Método para consultar todas las categorías
        [HttpGet]
        public IActionResult ConsultarCategorias()
        {
            var respuestaModelo = _categoriaModel.ConsultarCategorias();

            if (respuestaModelo?.Codigo == "1")
                return View(respuestaModelo?.Datos);
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return View(new List<CategoriaEnt>());
            }
        }

        // Método para abrir la vista de actualización de una categoría específica
        [HttpGet]
        public IActionResult ActualizarCategoria(int id)
        {
            var respuestaModelo = _categoriaModel.ConsultarUnaCategoria(id);
            return View(respuestaModelo?.Dato);
        }

        // Método para actualizar una categoría
        [HttpPost]
        public IActionResult ActualizarCategoria(CategoriaEnt entidad)
        {
            var respuestaModelo = _categoriaModel.ActualizarCategoria(entidad);

            if (respuestaModelo?.Codigo == "1")
                return RedirectToAction("ConsultarCategorias", "Categoria");
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return View(entidad);
            }
        }

        // Método para eliminar una categoría
        [HttpPost]
        public IActionResult EliminarCategoria(int id)
        {
            var respuestaModelo = _categoriaModel.EliminarCategoria(id);

            if (respuestaModelo?.Codigo == "1")
                return RedirectToAction("ConsultarCategorias", "Categoria");
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return RedirectToAction("ConsultarCategorias", "Categoria");
            }
        }
    }
}
