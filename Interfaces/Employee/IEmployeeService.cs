using System;
using System.Collections.Generic;
using RazorMVCDotNetApp.Dto;
using RazorMVCDotNetApp.Dto.Employee;
using RazorMVCDotNetApp.Models;

namespace RazorMVCDotNetApp.Interfaces.Employee
{
    public interface IEmployeeService
    {
        EmployeeModel AddEmployee(EmployeeDto employeeDto);
        
        EmployeeModel EditEmployee(EmployeeDto employeeDto);
        
        List<EmployeeModel> FindAll();

        List<EmployeeModel>  GetEmployee(string id);
        
        List<Object> GetEmployees(SearchDto searchDto);
        
        EmployeeModel DeleteEmployee(string id);

        List<EmployeeModel> GetEmployeeByDeptId(DepartmentModel department);

    }
}