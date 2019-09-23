using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Spreadsheet;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace WorkbookTest.Controllers
{
  [Route("api/[controller]")]
  public class ExcelController : Controller
  {
    public ExcelController(IHostingEnvironment environment)
    {
      _env = environment;
    }

    private readonly IHostingEnvironment _env;

		[HttpGet]
		public int Get()
		{
			string path = Path.Combine(_env.ContentRootPath, "Data");
			string filename = $"{path}/planilha.xlsx";

      Workbook wb = new Workbook();
      wb.Options.Import.ThrowExceptionOnInvalidDocument = true;
      using (FileStream stream = new FileStream(filename, FileMode.Open))
      {
        wb.LoadDocument(stream, DocumentFormat.Xlsx);
      }

      return wb.Worksheets.Count;

      //using (Workbook wb = new Workbook())
      //{
      //  wb.Options.Import.ThrowExceptionOnInvalidDocument = true;
      //  wb.LoadDocument(filename, DocumentFormat.Xlsx);
      //  return wb.Worksheets.Count;
      //}
    }

		[HttpGet("EPPlus")]
		public int Get1()
		{
			string path = Path.Combine(_env.ContentRootPath, "Data");
			string filename = $"{path}/planilha.xlsx";

			ExcelPackage wb = new ExcelPackage();
			using (FileStream stream = new FileStream(filename, FileMode.Open))
			{
				wb.Load(stream);
			}

			return wb.Workbook.Worksheets.Count;
		}
	}
}
