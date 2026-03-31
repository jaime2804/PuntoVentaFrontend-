using PuntoVentaWeb.Entities;
using PuntoVentaWeb.Services;
using static PuntoVentaWeb.Entities.InventarioEnt;

namespace PuntoVentaWeb.Models
{
    public class InventarioModel(HttpClient _http, IConfiguration _configuration) : IInventarioModel
    {


        public InventarioRespuesta? ConsultarInventario()
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Inventario/ConsultarInventario";
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<InventarioRespuesta>().Result;

            return null;
        }

    }
}