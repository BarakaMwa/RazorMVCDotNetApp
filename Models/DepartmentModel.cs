﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorMVCDotNetApp.Models
{
    [Table("department")]
    public class DepartmentModel
    {
        [Key] [Column("id")] public int Id {get; set;}
        [Column("name")] public string Name {get; set;}
    }
}