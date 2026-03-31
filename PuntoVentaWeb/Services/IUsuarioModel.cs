using PuntoVentaWeb.Entities;
using static PuntoVentaWeb.Entities.UsuarioEnt;

namespace PuntoVentaWeb.Services
{
    public interface IUsuarioModel
    {
        Task<UsuarioRespuesta?> RegistrarUsuarioAsync(UsuarioEnt entidad);
        Task<UsuarioRespuesta?> LoginUsuarioAsync(UsuarioEnt entidad);
        Task<UsuarioRespuesta?> ConsultarUsuariosAsync();
        Task<UsuarioRespuesta?> ConsultarUnUsuarioAsync(int IdUsuario);
        Task<UsuarioRespuesta?> ActualizarUsuarioAsync(UsuarioEnt entidad);
        Task<UsuarioRespuesta?> EliminarUsuarioAsync(int IdUsuario);

	}
}