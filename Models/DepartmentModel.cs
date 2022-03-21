using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorMVCDotNetApp.Models
{
    [Table("department")]
    public class DepartmentModel
    {
        [Key] [Column("ID")] public int Id {get; set;}
        [Column("NAME")] public string Name {get; set;}
    }
}