using System.Collections.Generic;
using RazorMVCDotNetApp.Dto;
using RazorMVCDotNetApp.Dto.Department;
using RazorMVCDotNetApp.Models;

namespace RazorMVCDotNetApp.Interfaces.Department
{
    public interface IDepartmentService
    {
        DepartmentModel AddDepartment(DepartmentDto departmentDto);
        
        DepartmentModel EditDepartment(DepartmentDto departmentDto);
        
        List<DepartmentModel> FindAll();
        
        List<DepartmentModel>? GetDepartments(SearchDto searchDto);
    }
}