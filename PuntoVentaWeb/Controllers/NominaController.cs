using Microsoft.AspNetCore.Mvc;
using PuntoVentaWeb.Entities;
using PuntoVentaWeb.Models;
using PuntoVentaWeb.Services;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.ComponentModel;

namespace PuntoVentaWeb.Controllers
{
	[FiltroSesiones]
	public class NominaController : Controller
    {
        private readonly INominaModel _iNominaModel;

        public NominaController(INominaModel iNominaModel)
        {
            _iNominaModel = iNominaModel;
        }

        [HttpGet]
        public IActionResult CrearNomina(int Cedula)
        {
            var respuestaModelo = _iNominaModel.ObtenerEmpleadoPorId(Cedula);
            return View(respuestaModelo?.Dato);
        }

        [HttpPost]
        public IActionResult CrearNomina(NominaEnt nomina)
        {
            var respuestaApi = _iNominaModel.CrearNomina(nomina);

            if (respuestaApi?.Codigo == "1")
                return RedirectToAction("ConsultarEmpleados", "Empleado");
            else
            {
                return RedirectToAction("ConsultarEmpleados", "Empleado");
            }
        }

        [HttpGet]
        public IActionResult ExportarNominas()
        {
          ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            var nominas = _iNominaModel.ObtenerNominas();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Nominas");

                // Agregar encabezados
                worksheet.Cells[1, 1].Value = "ID Nómina";
                worksheet.Cells[1, 2].Value = "Cedula";
                worksheet.Cells[1, 3].Value = "Nombre";
                worksheet.Cells[1, 4].Value = "Apellido";
                worksheet.Cells[1, 5].Value = "Vacaciones";
                worksheet.Cells[1, 6].Value = "Horas";
                worksheet.Cells[1, 7].Value = "Salario Ajustado";

                // Aplicar estilo a los encabezados
                using (var range = worksheet.Cells[1, 1, 1, 7])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                // Agregar datos
                for (int i = 0; i < nominas.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = nominas[i].IdNomina;
                    worksheet.Cells[i + 2, 2].Value = nominas[i].Cedula;
                    worksheet.Cells[i + 2, 3].Value = nominas[i].Nombre;
                    worksheet.Cells[i + 2, 4].Value = nominas[i].Apellido;
                    worksheet.Cells[i + 2, 5].Value = nominas[i].Vacaciones;
                    worksheet.Cells[i + 2, 6].Value = nominas[i].Horas;
                    worksheet.Cells[i + 2, 7].Value = nominas[i].SalarioAjustado;
                }

                // Ajustar el ancho de las columnas
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var fileName = "Nominas.xlsx";
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                return File(stream, contentType, fileName);
            }
        }
    }
}
