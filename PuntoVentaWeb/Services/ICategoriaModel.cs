using PuntoVentaWeb.Entities;

namespace PuntoVentaWeb.Services
{
    public interface ICategoriaModel
    {
        CategoriaRespuesta? ConsultarCategorias();
        CategoriaRespuesta? ConsultarUnaCategoria(int id);

        CategoriaRespuesta? RegistrarCategoria(CategoriaEnt entidad);
        CategoriaRespuesta? ActualizarCategoria(CategoriaEnt entidad);

        CategoriaRespuesta? EliminarCategoria(int id);
    }
}
