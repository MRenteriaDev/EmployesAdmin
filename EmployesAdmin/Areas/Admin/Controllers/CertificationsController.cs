using EmployesAdmin.Data;
using EmployesAdmin.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployesAdmin.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CertificationsController : Controller
    {
        private readonly DataContext _context;
        public CertificationsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public Certification Create(Certification certification)
        {
            _context.Certifications.Add(certification);
            _context.SaveChanges();
            return certification;
        }
    }
}
