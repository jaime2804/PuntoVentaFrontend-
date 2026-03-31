
using PuntoVentaWeb.Services;
using static PuntoVentaWeb.Entities.VerFacturasEnt;
using static System.Net.WebRequestMethods;

namespace PuntoVentaWeb.Models
{
    
    public class VerFacturasModel(HttpClient httpClient, IConfiguration iConfiguration) : IVerFacturasModel
    {


        public VerFacturasRespuesta ConsultarFacturas(DateTime fechaInicio, DateTime fechaFin)
        {
            string url = iConfiguration.GetSection("settings:UrlApi").Value +
                         $"api/VerFacturas/ConsultarFacturas?fechaInicio={fechaInicio:yyyy-MM-dd}&fechaFin={fechaFin:yyyy-MM-dd}";
            var resp = httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<VerFacturasRespuesta>().Result;

            return null;
        }


    }
}
