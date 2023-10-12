using ITDepartmentTask.Dal.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITDepartmentTask.pl.Controllers
{
    public class PropertyItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PropertyItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var propertyItems = _context.PropertyItems.ToList();
            return View(propertyItems);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PropertyItem propertyItem)
        {
            if (!ModelState.IsValid)
            {
                return View(propertyItem);
            }

            _context.PropertyItems.Add(propertyItem);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}
