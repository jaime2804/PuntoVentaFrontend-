using PuntoVentaWeb.Entities;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using PuntoVentaWeb.Services;

namespace PuntoVentaWeb.Models
{
    public class CarritoModel : ICarritoModel
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public CarritoModel(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }

        public Carrito GetCarrito()
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Carrito/GetCarrito";
            var carrito = _http.GetFromJsonAsync<Carrito>(url).Result;
            return carrito ?? new Carrito();
        }

        public void AgregarProducto(string productoId, int cantidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + $"api/Carrito/AgregarProducto/{productoId}";
            var content = JsonContent.Create(cantidad);
            var response = _http.PostAsync(url, content).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new System.Exception("No se pudo agregar el producto al carrito");
            }
        }
        public void AgregarProductoPorId(string productoId)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + $"api/Carrito/AgregarProducto/{productoId}";
            var content = JsonContent.Create(1); // Asume que la cantidad es 1 al escanear el IdProducto
            var response = _http.PostAsync(url, content).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new System.Exception("No se pudo agregar el producto al carrito");
            }
        }


        public void EliminarProducto(string productoId)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + $"api/Carrito/EliminarProducto/{productoId}";
            var response = _http.DeleteAsync(url).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new System.Exception("No se pudo eliminar el producto del carrito");
            }
        }

        public void VaciarCarrito()
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Carrito/VaciarCarrito";
            var response = _http.PostAsync(url, null).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new System.Exception("No se pudo vaciar el carrito");
            }
        }

    }
}
