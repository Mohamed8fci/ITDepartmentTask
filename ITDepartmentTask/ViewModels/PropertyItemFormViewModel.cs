using System.ComponentModel.DataAnnotations;

namespace ITDepartmentTask.pl.ViewModels
{
    public class PropertyItemFormViewModel
    {
        [Required]
        [Display(Name = "Property Description")]
        public string PropertyDescription { get; set; }
    }
}
