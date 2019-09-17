using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Spreadsheet;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

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
      using (FileStream stream = new FileStream(filename, FileMode.Open))
      {
        wb.LoadDocument(stream, DocumentFormat.Xlsx);
      }

      return wb.Worksheets.Count;
    }
  }
}
