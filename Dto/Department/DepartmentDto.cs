using System.ComponentModel.DataAnnotations;

namespace RazorMVCDotNetApp.Dto.Department
{
    public class DepartmentDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(15)]
        public string Name { get; set; }
    }
}