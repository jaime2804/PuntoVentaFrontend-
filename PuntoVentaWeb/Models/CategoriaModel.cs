using PuntoVentaWeb.Entities;
using PuntoVentaWeb.Services;
using System.Net.Http.Json;

namespace PuntoVentaWeb.Models
{
    public class CategoriaModel : ICategoriaModel
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public CategoriaModel(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }

        public CategoriaRespuesta? RegistrarCategoria(CategoriaEnt entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Categoria/RegistrarCategoria";

            JsonContent body = JsonContent.Create(entidad);
            var RespuestaApi = _http.PostAsync(url, body).Result;
            if (RespuestaApi.IsSuccessStatusCode)
                return RespuestaApi.Content.ReadFromJsonAsync<CategoriaRespuesta>().Result;
            return null;
        }

        public CategoriaRespuesta? ConsultarCategorias()
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Categoria/ConsultarCategorias";
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<CategoriaRespuesta>().Result;

            return null;
        }

        public CategoriaRespuesta? ConsultarUnaCategoria(int id)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Categoria/ConsultarUnaCategoria?id=" + id;
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<CategoriaRespuesta>().Result;

            return null;
        }

        public CategoriaRespuesta? ActualizarCategoria(CategoriaEnt entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Categoria/ActualizarCategoria";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _http.PutAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<CategoriaRespuesta>().Result;

            return null;
        }

        public CategoriaRespuesta? EliminarCategoria(int id)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Categoria/EliminarCategoria?id=" + id;
            var resp = _http.DeleteAsync(url).Result;
            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<CategoriaRespuesta>().Result;

            return null;
        }
    }
}
