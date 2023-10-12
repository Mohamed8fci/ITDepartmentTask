using ITDepartmentTask.Dal.Models;
using ITDepartmentTask.pl.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ITDepartmentTask.pl.Controllers
{
    public class DeviceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var devices = _context.Devices.Include(d => d.DeviceCategory).ToList();
            return View(devices);
        }

        public IActionResult Create()
        {
            var deviceCategories = _context.DeviceCategories.ToList();
            var propertyItems = _context.PropertyItems.ToList();
            var viewModel = new DeviceFormViewModel
            {
                DeviceCategories = deviceCategories,
                PropertyItems = propertyItems
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DeviceFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.DeviceCategories = _context.DeviceCategories.ToList();
                viewModel.PropertyItems = _context.PropertyItems.ToList();
                return View(viewModel);
            }

            var device = new Device
            {
                DeviceName = viewModel.DeviceName,
                DeviceCategoryId = viewModel.DeviceCategoryId,
                DeviceCategory = await _context.DeviceCategories.SingleOrDefaultAsync(c => c.ID == viewModel.DeviceCategoryId),
                AcquisitionDate = viewModel.AcquisitionDate,
                Memo = viewModel.Memo,
                PropertyValues = new List<PropertyValue>()
            };

            var selectedDeviceCategory = device.DeviceCategory;

            if (selectedDeviceCategory == null)
            {
                ModelState.AddModelError("DeviceCategoryId", "Invalid Device Category selection.");
                viewModel.DeviceCategories = _context.DeviceCategories.ToList();
                viewModel.PropertyItems = _context.PropertyItems.ToList();
                return View(viewModel);
            }

            if (selectedDeviceCategory.PropertyItems != null)
            {
                for (var i = 0; i < selectedDeviceCategory.PropertyItems.Count; i++)
                {
                    var propertyValue = new PropertyValue
                    {
                        PropertyItem = selectedDeviceCategory.PropertyItems[i],
                        Value = viewModel.PropertyValues[i]
                    };
                    device.PropertyValues.Add(propertyValue);
                }
            }

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _context.Devices.Add(device);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


    }
}