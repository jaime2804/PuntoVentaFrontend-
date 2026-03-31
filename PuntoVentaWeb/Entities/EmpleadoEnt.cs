using System.ComponentModel;

namespace PuntoVentaWeb.Entities
{
    public class EmpleadoEnt
    {

        [DisplayName("Cedula")]
        public int Cedula { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        [DisplayName("Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }

        [DisplayName("Horas Trabajadas")]
        public int HorasTrabajadas { get; set; }

        [DisplayName("Horas Rebajadas")]
        public int HorasRebajadas { get; set; }

        [DisplayName("Valor por Hora")]
        public int ValorPorHora { get; set; }

        [DisplayName("Salario Ajustado")]
        public int SalarioAjustado { get; set; }



        public class EmpleadoRespuesta
        {
            public EmpleadoRespuesta()
            {
                Codigo = "1";
                Mensaje = string.Empty;
                Dato = null;
                Datos = null;
            }

            public string Codigo { get; set; }
            public string Mensaje { get; set; }
            public EmpleadoEnt? Dato { get; set; }
            public List<EmpleadoEnt>? Datos { get; set; }
        }
    }
}
