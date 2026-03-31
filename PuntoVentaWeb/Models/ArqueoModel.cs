using PuntoVentaWeb.Entities;
using PuntoVentaWeb.Services;


namespace PuntoVentaWeb.Models
{
    public class ArqueoModel(HttpClient _http, IConfiguration _configuration) : IArqueoModel
    {

        //------------------------------------------------------------------------------------------Caja---------------------------------------------------------------------------------------- //


        public CajaRespuesta? CrearCaja(CajaEnt entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Arqueo/CrearCaja";

            JsonContent body = JsonContent.Create(entidad);
            var RespuestaApi = _http.PostAsync(url, body).Result;
            if (RespuestaApi.IsSuccessStatusCode)
                return RespuestaApi.Content.ReadFromJsonAsync<CajaRespuesta>().Result;
            return null;
        }

        public ArqueoRespuesta? ObtenerCajaPorArqueoId(int IdCaja)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Arqueo/ObtenerCajaPorId?IdCaja=" + IdCaja;
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ArqueoRespuesta>().Result;

            return null;
        }

        public MovimientoRespuesta? ObtenerCajaPorMovimientoId(int IdCaja)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Arqueo/ObtenerCajaPorId?IdCaja=" + IdCaja;
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<MovimientoRespuesta>().Result;

            return null;
        }

        public CierreSemanalRespuesta? CalcularCierreSemanal()
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Arqueo/CalcularCierreSemanal";
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<CierreSemanalRespuesta>().Result;

            return null;
        }

        //------------------------------------------------------------------------------------------Arqueos---------------------------------------------------------------------------------------- //

        public CajaRespuesta? ObtenerTodosArqueos()
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Arqueo/ObtenerTodosArqueos";
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<CajaRespuesta>().Result;

            return null;
        }


        public ArqueoRespuesta? RegistrarArqueo(ArqueoEnt entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Arqueo/RegistrarArqueo";

            JsonContent body = JsonContent.Create(entidad);
            var RespuestaApi = _http.PostAsync(url, body).Result;
            if (RespuestaApi.IsSuccessStatusCode)
                return RespuestaApi.Content.ReadFromJsonAsync<ArqueoRespuesta>().Result;
            return null;
        }
        public ArqueoRespuesta? CalcularTotalesArqueo(int idArqueo)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Arqueo/CalcularTotalesArqueo?IdCaja=" + idArqueo;
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ArqueoRespuesta>().Result;

            return null;
        }

        //------------------------------------------------------------------------------------------Movimientos---------------------------------------------------------------------------------------- //

        public MovimientoRespuesta? ObtenerMovimientos()
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Arqueo/ObtenerMovimientos";
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<MovimientoRespuesta>().Result;

            return null;
        }

        public MovimientoRespuesta? ConsultarUnMovimiento(int IdCaja)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Arqueo/ConsultarUnMovimiento?IdCaja=" + IdCaja;
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<MovimientoRespuesta>().Result;

            return null;
        }

        public MovimientoRespuesta? RegistrarMovimiento(MovimientoEnt entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Arqueo/RegistrarMovimiento";

            JsonContent body = JsonContent.Create(entidad);
            var RespuestaApi = _http.PostAsync(url, body).Result;
            if (RespuestaApi.IsSuccessStatusCode)
                return RespuestaApi.Content.ReadFromJsonAsync<MovimientoRespuesta>().Result;
            return null;
        }

        public CajaRespuesta? EliminarCaja(int idCaja)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Arqueo/EliminarCaja?idCaja=" + idCaja;
            var resp = _http.DeleteAsync(url).Result;
            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<CajaRespuesta>().Result;

            return null;
        }



    }


}


