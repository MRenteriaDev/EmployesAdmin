using EmployesAdmin.Data;
using Microsoft.AspNetCore.Mvc;

namespace EmployesAdmin.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly DataContext _context;
        public DashboardController(DataContext context) 
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
