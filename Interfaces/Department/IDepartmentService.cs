using RazorMVCDotNetApp.Models;

namespace RazorMVCDotNetApp.Interfaces.Department
{
    public interface IDepartmentService
    {
        public DepartmentModel AddDepartment(string name);
    }
}