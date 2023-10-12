using ITDepartmentTask.Dal.Models;
using System.ComponentModel.DataAnnotations;

namespace ITDepartmentTask.pl.ViewModels
{
    public class DeviceFormViewModel
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Device Name")]
        public string? DeviceName { get; set; }

        [Required]
        [Display(Name = "Device Category")]
        public int DeviceCategoryId { get; set; }

        [Required]
        [Display(Name = "Acquisition Date")]
        public DateTime AcquisitionDate { get; set; }

        [Display(Name = "Memo")]
        public string? Memo { get; set; }

        public List<DeviceCategory>? DeviceCategories { get; set; }
        public List<string>? PropertyValues { get; set; }
        public List<PropertyItem>? PropertyItems { get; set; } // Define PropertyItems
    }

}
