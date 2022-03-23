using System.ComponentModel.DataAnnotations;

namespace RazorMVCDotNetApp.Dto.Employee
{
    public class EmployeeDto
    {
        
        public int Id{set; get;}
        
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(50)]
        public string FirstName{set; get;}
        
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(50)]
        public string LastName{set; get;}

        [Required(ErrorMessage = "{0} is Required")]
        public int DepartmentId{set; get;}

        public string? DeptIdEncryption{set; get;}
        
        public string? DepartmentName{set; get;}
        
        public string IdEncryption { get; set; }
    }
}