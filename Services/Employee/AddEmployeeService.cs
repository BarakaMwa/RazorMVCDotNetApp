using System;
using System.Collections.Generic;
using RazorMVCDotNetApp.Dao.Employee;
using RazorMVCDotNetApp.Dto.Employee;
using RazorMVCDotNetApp.Interfaces.Employee;
using RazorMVCDotNetApp.Models;

namespace RazorMVCDotNetApp.Employee.Services
{
    public class AddEmployeeService: IEmployeeService
    {
        private EmployeeDao employeeDao;
        
        public AddEmployeeService(){}

        public EmployeeModel AddEmployee(EmployeeDto employeeDto)
        {
            var employee = new EmployeeModel();

            try
            {
                employee.DepartmentId = employeeDto.DepartmentId;
                employee.FirstName = employeeDto.FirstName;
                employee.LastName = employeeDto.LastName;

                employeeDao = new EmployeeDao();
                return employeeDao.Save(employee);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot Add Employee");
                Console.WriteLine(ex);
                return employee;
            }
            
        }

        public EmployeeModel EditEmployee(EmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }

        public EmployeeModel FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeModel> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}