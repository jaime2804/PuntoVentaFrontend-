using PuntoVentaWeb.Entities;
using static PuntoVentaWeb.Entities.EmpleadoEnt;


namespace PuntoVentaWeb.Services
{
    public interface IEmpleadoModel
    {
        EmpleadoRespuesta? ConsultarEmpleados();

        EmpleadoRespuesta? ObtenerEmpleadoPorId(int Cedula);

        EmpleadoRespuesta? RegistrarEmpleado(EmpleadoEnt entidad);
        EmpleadoRespuesta? ActualizarEmpleado(EmpleadoEnt entidad);

        EmpleadoRespuesta? EliminarEmpleado(int Cedula);
    }
}
