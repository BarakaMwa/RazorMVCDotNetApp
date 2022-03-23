using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorMVCDotNetApp.Models
{
    [Table("employee")]
    public class EmployeeModel
    {
        [Key] [Column("ID")] public int Id { get; set; }
        
        [Column("FIRST_NAME")] public string FirstName { get; set; }
        
        [Column("LAST_NAME")] public string LastName { get; set; }
        
        [Column("DEPARTMENT_ID")] public int DepartmentId { get; set; }
    }
}