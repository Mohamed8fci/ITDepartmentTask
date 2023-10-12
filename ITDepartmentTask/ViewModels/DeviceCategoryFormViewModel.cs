using ITDepartmentTask.Dal.Models;
using System.ComponentModel.DataAnnotations;

namespace ITDepartmentTask.pl.ViewModels
{
    public class DeviceCategoryFormViewModel
    {
        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        public List<PropertyItem> PropertyItems { get; set; }
    }
}
