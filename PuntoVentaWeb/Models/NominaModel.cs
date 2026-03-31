using PuntoVentaWeb.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using PuntoVentaWeb.Services;
using static PuntoVentaWeb.Entities.NominaEnt;
using static PuntoVentaWeb.Entities.EmpleadoEnt;

namespace PuntoVentaWeb.Models
{
    public class NominaModel : INominaModel
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public NominaModel(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }

        public NominaRespuesta? CrearNomina(NominaEnt nomina)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Nomina/CrearNomina";

            JsonContent body = JsonContent.Create(nomina);
            var RespuestaApi = _http.PostAsync(url, body).Result;
            if (RespuestaApi.IsSuccessStatusCode)
                return RespuestaApi.Content.ReadFromJsonAsync<NominaRespuesta>().Result;
            return null;
        }
        public NominaRespuesta? ObtenerEmpleadoPorId(int Cedula)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Empleado/ObtenerEmpleadoPorCedula?Cedula=" + Cedula;
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<NominaRespuesta>().Result;

            return null;
        }

        public List<NominaEnt> ObtenerNominas()
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Nomina/ObtenerNominas";
            var RespuestaApi = _http.GetAsync(url).Result;
            if (RespuestaApi.IsSuccessStatusCode)
                return RespuestaApi.Content.ReadFromJsonAsync<List<NominaEnt>>().Result!;
            return new List<NominaEnt>();
        }
    }
}
