
using PuntoVentaWeb.Entities;
using PuntoVentaWeb.Services;

using static PuntoVentaWeb.Entities.FacturaEnt;

namespace PuntoVentaWeb.Models
{
    public class FacturaModel(HttpClient _http, IConfiguration _configuration) : IFacturaModel
    {

        public FacturaRespuesta? RegistrarFactura(FacturaEnt entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Factura/RegistrarFactura";

            JsonContent body = JsonContent.Create(entidad);
            var RespuestaApi = _http.PostAsync(url, body).Result;
            if (RespuestaApi.IsSuccessStatusCode)
                return RespuestaApi.Content.ReadFromJsonAsync<FacturaRespuesta>().Result;
            return null;
        }

        public FacturaRespuesta? ConsultarFactura()
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Factura/ConsultarFactura";
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<FacturaRespuesta>().Result;

            return null;
        }

        public FacturaRespuesta? ConsultarUltimaFactura()
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Factura/ConsultarUltimaFactura";
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<FacturaRespuesta>().Result;

            return null;
        }


        public FacturaRespuesta? ConsultarUnaFactura(int IdFactura)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Factura/ConsultarUnaFactura?IdFactura=" + IdFactura;
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<FacturaRespuesta>().Result;

            return null;

        }
    }

       
}