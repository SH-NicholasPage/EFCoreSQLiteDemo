using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SQLiteEFDemo.Pages
{
    public class IndexModel : PageModel
    {
        public DBContext db = new DBContext();
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Console.WriteLine(db);
        }
    }
}