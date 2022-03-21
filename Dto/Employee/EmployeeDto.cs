using System.ComponentModel.DataAnnotations;

namespace RazorMVCDotNetApp.Dto.Employee
{
    public class EmployeeDto
    {
        
        public int Id{set; get;}
        
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(50)]
        public string FistName{set; get;}
        
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(50)]
        public string LastName{set; get;}

        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(15)]
        public int DepartmentId{set; get;}
        
    }
}