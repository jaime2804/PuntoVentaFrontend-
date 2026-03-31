using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PuntoVentaWeb.Entities;
using PuntoVentaWeb.Models;
using PuntoVentaWeb.Services;
using System;

namespace PuntoVentaWeb.Controllers
{
	[FiltroSesiones]
	public class FacturaController(IFacturaModel _FacturaModel) : Controller
    {
        //Abre la vista:
        [HttpGet]
        public IActionResult RegistrarFactura()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarFactura(FacturaEnt entidad)
        {
            var RespuestaApi = _FacturaModel.RegistrarFactura(entidad);

            if (RespuestaApi?.Codigo == "1")
                return RedirectToAction("Carrito", "Carrito");
            else
            {
                return RedirectToAction("Carrito", "Carrito");
            }
        }

        [HttpPost]
        public IActionResult TerminarVenta(string documentoCliente, string itemsJson)
        {

            var items = JsonConvert.DeserializeObject<List<ItemModel>>(itemsJson);
            int cont = 0;
            var nuevaFact = 0;


            foreach (var item in items)
            {
                FacturaEnt entidad = new FacturaEnt();

                cont++;
                var productoId = item.ProductoId;
                var cantidad = item.Cantidad;
                var precio = item.Precio;
                var descuento = item.Descuento;
                var tipoPago = item.TipoPago;
                var pago = item.Pago;
                var idEmpleado = HttpContext.Session.GetInt32("IdUsuario");

                if (cont == 1)
                {
                    nuevaFact = 1;
                }
                entidad.NuevaFactura = nuevaFact;
                entidad.Cantidad = cantidad;
                entidad.IdProducto = productoId;
                entidad.Descuento = Decimal.ToInt32(descuento);
                entidad.TipoPago = tipoPago;
                entidad.Pago = pago;
                entidad.IdCajero = idEmpleado.Value;
                nuevaFact = 0;
                RegistrarFactura(entidad);


            }


            return RedirectToAction("ConsultarUltimaFactura", "Factura");
        }

        [HttpGet]
        public IActionResult ConsultarFactura()
        {
            var respuestaModelo = _FacturaModel.ConsultarFactura();

            if (respuestaModelo?.Codigo == "1")
                return View(respuestaModelo?.Datos);
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return View(new List<FacturaEnt>());
            }
        }

        [HttpGet]
        public IActionResult ConsultarUltimaFactura()
        {
            var respuestaModelo = _FacturaModel.ConsultarUltimaFactura();

            if (respuestaModelo?.Codigo == "1")
            {
                var factura = respuestaModelo?.Dato;

                return RedirectToAction("ConsultarUnaFactura", "Factura", new
                {
                    factura.IdFactura

                });

            }
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return View(new List<FacturaEnt>());
            }



        }

        [HttpGet]
        public IActionResult ConsultarUnaFactura(int IdFactura)
        {
            var respuestaModelo = _FacturaModel.ConsultarUnaFactura(IdFactura);

            if (respuestaModelo?.Codigo == "1")
            {
                TempData["DatosFactura"] = JsonConvert.SerializeObject(respuestaModelo.Datos);
                return RedirectToAction("Imprimir", "Impresion");
            }
            else
            {
                ViewBag.MsjPantalla = respuestaModelo?.Mensaje;
                return View(new List<FacturaEnt>());
            }

        }



        public class ItemModel
        {
            public string ProductoId { get; set; }
            public string NombreProducto { get; set; }
            public int Cantidad { get; set; }
            public decimal Precio { get; set; }
            public decimal Descuento { get; set; }
            public decimal Pago { get; set; }
            public string? TipoPago { get; set; }
        }


    }
}

