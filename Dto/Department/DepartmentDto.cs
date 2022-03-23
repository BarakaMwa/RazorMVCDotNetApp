using System.ComponentModel.DataAnnotations;

namespace RazorMVCDotNetApp.Dto.Department
{
    public class DepartmentDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50)]
        public string Name { get; set; }

        public string? IdEncryption  { get; set; }
        
    }
}