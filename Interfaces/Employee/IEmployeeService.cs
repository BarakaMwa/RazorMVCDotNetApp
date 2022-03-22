using System.Collections.Generic;
using RazorMVCDotNetApp.Dto.Employee;
using RazorMVCDotNetApp.Models;

namespace RazorMVCDotNetApp.Interfaces.Employee
{
    public interface IEmployeeService
    {
        EmployeeModel AddEmployee(EmployeeDto employeeDto);
        
        EmployeeModel EditEmployee(EmployeeDto employeeDto);

        EmployeeModel FindById(int id);
        
        List<EmployeeModel> FindAll();
        
    }
}