using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Npgsql;
using System.Data;

namespace StorageCompany1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            var claim_password = HttpContext.User.Claims.First(c => c.Type == "password");
            var password = claim_password.Value;
            var claim_login = HttpContext.User.Claims.First(c => c.Type == "login");
            var login = claim_login.Value;
            using (NpgsqlConnection connection = new NpgsqlConnection($"Server=127.0.0.1;User Id={login};Password={password};Database=StorageCompany;"))
            {

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand($"SELECT * FROM clientscontentview", connection);
                cmd.CommandType = CommandType.Text;
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                adapter.Fill(ds);
                dt = ds.Tables[0];


                var wb = new XLWorkbook();
                wb.Worksheets.Add(dt);

                string fileName = "Количество_товара_на_складах.xlsx";

                string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                await using (var stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, contentType, fileName);
                }

            }
        }
    }
}