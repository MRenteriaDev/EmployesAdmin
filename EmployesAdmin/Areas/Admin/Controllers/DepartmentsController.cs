using EmployesAdmin.Data;
using EmployesAdmin.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployesAdmin.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentsController : Controller
    {
        private readonly DataContext _context;
        public DepartmentsController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var depts = _context.Departments.ToList();
            return View(depts);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                TempData["success"] = $"{department.Name} Se creó exitosamente";
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            var dept = _context.Departments.Find(id);
            return View(dept);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Update(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        public IActionResult Delete(int id)
        {
            var dep = _context.Departments.Find(id);
            return View(dep);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(Department department)
        {
            if (department.Id != 0)
            {
                _context.Departments.Remove(department);
                TempData["success"] = $"{department.Name} se eliminó exitosamente";
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department);
        }
    }
}
