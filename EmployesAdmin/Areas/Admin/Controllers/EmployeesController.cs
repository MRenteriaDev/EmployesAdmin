using EmployesAdmin.Data;
using EmployesAdmin.Interfaces;
using EmployesAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployesAdmin.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeesController : Controller
    {
        private readonly DataContext _context;
        private readonly IPhotoService _photoService;
        public EmployeesController(DataContext context, IPhotoService photoService)
        {
            _context = context;
            _photoService = photoService;
        }

        public ActionResult Index()
        {
            var employees = _context.Employes.ToList();
            return View(employees);
        }

        public IActionResult Edit(int id)
        {
            var employee = _context.Employes.Find(id);

            IEnumerable<SelectListItem> DepartmentsLists = _context.Departments.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });

            ViewBag.DepartmentsList = DepartmentsLists;

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employe employe)
        {
            if (ModelState.IsValid)
            {
                _context.Employes.Update(employe);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employe);
        }

        public ActionResult Detail(int id)
        {
            var employee = _context.Employes
                .Where(x => x.Id == id)
                .Include(x => x.Department)
                .Include(x => x.Positions)
                .Include(x => x.Documents)
                .Include(x => x.Certifications)
                .FirstOrDefault();

            return View(employee);
        }

        public ActionResult Create()
        {
            List<Department> departments = _context.Departments.ToList();

            IEnumerable<SelectListItem> DepartmentsLists = departments.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });

            ViewBag.DepartmentsList = DepartmentsLists;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Employe employe)
        {
            if (employe == null) return RedirectToAction("Index");
            if (!ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(employe?.Image);
                employe.ImageUrl = result.SecureUrl.AbsoluteUri;
                employe.ImagePublicId = result.PublicId;
                await _context.Employes.AddAsync(employe);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employe);
        }

        public ActionResult Delete(int id)
        {
            var employee = _context.Employes.Find(id);

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(Employe employe)
        {
            if (employe.Id != 0)
            {
                _context.Employes.Remove(employe);
                TempData["success"] = $"{employe.Name} se eliminó exitosamente";
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employe);
        }
    }
}
