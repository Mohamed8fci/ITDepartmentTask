using ITDepartmentTask.Dal.Models;
using ITDepartmentTask.pl.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITDepartmentTask.pl.Controllers
{
    public class DeviceCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var deviceCategories = _context.DeviceCategories.Include(c => c.PropertyItems).ToList();
            return View(deviceCategories);
        }

        public IActionResult Create()
        {
            var viewModel = new DeviceCategoryFormViewModel
            {
                PropertyItems = _context.PropertyItems.ToList()
            };
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Create(DeviceCategory deviceCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(deviceCategory);
            }

            _context.DeviceCategories.Add(deviceCategory);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}
