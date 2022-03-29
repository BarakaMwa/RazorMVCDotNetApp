using System;
using System.Collections.Generic;
using RazorMVCDotNetApp.Commons;
using RazorMVCDotNetApp.Dao.Employee;
using RazorMVCDotNetApp.Dto;
using RazorMVCDotNetApp.Dto.Employee;
using RazorMVCDotNetApp.Interfaces.Department;
using RazorMVCDotNetApp.Interfaces.Employee;
using RazorMVCDotNetApp.Models;
using RazorMVCDotNetApp.Services.Department;

namespace RazorMVCDotNetApp.Employee.Services
{
    public class AddEmployeeService : IEmployeeService
    {
        private EmployeeDao employeeDao;
        private CryptoEngine cryptoEngine;
        private IDepartmentService iDepartmentService;

        public AddEmployeeService()
        {
        }

        public EmployeeModel AddEmployee(EmployeeDto employeeDto)
        {
            var employee = new EmployeeModel();

            try
            {
                employee.DepartmentId = employeeDto.DepartmentId;
                employee.FirstName = employeeDto.FirstName;
                employee.LastName = employeeDto.LastName;
                employee.Gender = employeeDto.Gender;

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
            var employee = new EmployeeModel();
            var employees = new List<EmployeeModel>();
            try
            {
                employees = GetEmployee(employeeDto.IdEncryption);
                //Assign values to Employee oBject
                employees[0].FirstName = employeeDto.FirstName;
                employees[0].LastName = employeeDto.LastName;
                employees[0].Gender = employeeDto.Gender;
                
                var decrypt = cryptoEngine.Decrypt(employeeDto.DeptIdEncryption, "qwer-3qa8-asdf21");
                var idInt = Convert.ToInt32(decrypt);
                employees[0].DepartmentId = idInt;
                
                employeeDao = new EmployeeDao();
                employee = employeeDao.Update(employees[0]);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot Get Employee for editing");
                Console.WriteLine("Error");
                Console.WriteLine(ex);
                employee = null;
            }

            return employee;
        }

        public List<EmployeeModel> GetEmployee(string id)
        {
            var employees = new List<EmployeeModel>();
            cryptoEngine = new CryptoEngine();
            try
            {
                id = cryptoEngine.Decrypt(id, "qwer-3qa8-asdf21");
                int idInt = Convert.ToInt32(id);
                employeeDao = new EmployeeDao();
                employees = employeeDao.FindById(idInt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to get Employee");
                Console.WriteLine("Error");
                Console.WriteLine(ex);
            }

            return employees;
        }

        public List<EmployeeModel> FindAll()
        {
            var employees = new List<EmployeeModel>();
            employeeDao = new EmployeeDao();
            try
            {
                employees = employeeDao.FindAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to get Employee");
                Console.WriteLine("Error");
                Console.WriteLine(ex);
            }
            return employees;
        }

        public List<Object> GetEmployees(SearchDto searchDto)
        {
            var employeeList = new List<Object>();
            employeeDao = new EmployeeDao();
            var search = searchDto.search["value"];

            var employees = employeeDao.FindContaining(search);
            try
            {
                if (employees.Count == 0)
                {
                    employees = employeeDao.FindTopHundred();
                }

                foreach (var item in employees)
                {
                    var empItem = new Dictionary<string, string>();
                    cryptoEngine = new CryptoEngine();
                    string idStr = cryptoEngine.Encrypt(item.Id.ToString(), "qwer-3qa8-asdf21");
                    empItem.Add("firstName", item.FirstName);
                    empItem.Add("lastName", item.LastName);
                    empItem.Add("gender", item.Gender);
                    empItem.Add("id", idStr);
                    //getting the Department Name
                    string deptIdStr = cryptoEngine.Encrypt(item.DepartmentId.ToString(), "qwer-3qa8-asdf21");
                    iDepartmentService = new AddDepartmentService();
                    var departments = iDepartmentService.GetDepartment(deptIdStr);
                    empItem.Add("departmentName", departments[0].Name);

                    employeeList.Add(empItem);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured!! ");
                Console.WriteLine("Error Details : ");
                Console.WriteLine(ex);
                employeeList.Clear();
            }

            return employeeList;
        }

        public EmployeeModel DeleteEmployee(string id)
        {
            var employee = new EmployeeModel();
            var employees = new List<EmployeeModel>();

            try
            {
                employees = GetEmployee(id);
                employeeDao = new EmployeeDao();
                employee = employeeDao.Delete(employees[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot Get Employee for deleting");
                Console.WriteLine("Error");
                Console.WriteLine(ex);
                employees.Clear();
            }

            return employee;
        }

        public List<EmployeeModel> GetEmployeeByDeptId(DepartmentModel department)
        {
            var employees = new List<EmployeeModel>();
            employeeDao = new EmployeeDao();
            try
            {
                employees = employeeDao.GetEmployeeByDeptId(department);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to get Employee");
                Console.WriteLine("Error");
                Console.WriteLine(ex);
            }
            return employees;
        }
    }
}