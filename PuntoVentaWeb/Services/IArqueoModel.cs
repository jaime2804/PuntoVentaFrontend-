using PuntoVentaWeb.Entities;
using System.Collections.Generic;

namespace PuntoVentaWeb.Services
{
    public interface IArqueoModel

    {

        //Caja//
        CajaRespuesta? CrearCaja(CajaEnt entidad);
        CajaRespuesta? EliminarCaja(int IdCaja);
        CierreSemanalRespuesta? CalcularCierreSemanal();


        //Arqueos//
        ArqueoRespuesta? ObtenerCajaPorArqueoId(int IdCaja);
		CajaRespuesta? ObtenerTodosArqueos();
        ArqueoRespuesta? RegistrarArqueo(ArqueoEnt entidad);

        ArqueoRespuesta? CalcularTotalesArqueo(int idArqueo);

		//Movimiento//
		MovimientoRespuesta? ObtenerCajaPorMovimientoId(int IdCaja);
		MovimientoRespuesta? ObtenerMovimientos();
        MovimientoRespuesta? ConsultarUnMovimiento(int IdCaja);
        MovimientoRespuesta? RegistrarMovimiento(MovimientoEnt entidad);








    }
}
