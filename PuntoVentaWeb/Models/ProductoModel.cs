using PuntoVentaWeb.Entities;
using PuntoVentaWeb.Services;
using static PuntoVentaWeb.Entities.ProductoEnt;

namespace PuntoVentaWeb.Models
{
    public class ProductoModel(HttpClient _http, IConfiguration _configuration) : IProductoModel
    {

        public ProductoRespuesta? RegistrarProducto(ProductoEnt entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Producto/RegistrarProducto";

            JsonContent body = JsonContent.Create(entidad);
            var RespuestaApi = _http.PostAsync(url, body).Result;
            if (RespuestaApi.IsSuccessStatusCode)
                return RespuestaApi.Content.ReadFromJsonAsync<ProductoRespuesta>().Result;
            return null;
        }

        public ProductoRespuesta? ConsultarProductos()
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Producto/ConsultarProductos";
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ProductoRespuesta>().Result;

            return null;
        }

        public ProductoRespuesta? ConsultarUnProducto(string IdProducto)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Producto/ConsultarUnProducto?IdProducto=" + IdProducto;
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ProductoRespuesta>().Result;

            return null;
        }

        public ProductoRespuesta? ActualizarProducto(ProductoEnt entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Producto/ActualizarProducto";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _http.PutAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ProductoRespuesta>().Result;

            return null;
        }


        public ProductoRespuesta? EliminarProducto(string IdProducto)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Producto/EliminarProducto?IdProducto=" + IdProducto;
            var resp = _http.DeleteAsync(url).Result;
            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ProductoRespuesta>().Result;

            return null;
        }
    }
}