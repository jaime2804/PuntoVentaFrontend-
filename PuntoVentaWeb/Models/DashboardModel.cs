using PuntoVentaWeb.Services;
using static PuntoVentaWeb.Entities.DashboardEnt;

namespace PuntoVentaWeb.Models
{
    public class DashboardModel(HttpClient _http, IConfiguration _configuration) : IDashboardModel
    {


        public DashboardRespuesta? ObtenerDashboard()
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Dashboard/ObtenerDashboard";
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<DashboardRespuesta>().Result;

            return null;
        }
    }
}