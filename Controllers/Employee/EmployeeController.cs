using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RazorMVCDotNetApp.Commons;
using RazorMVCDotNetApp.Dao.Department;
using RazorMVCDotNetApp.Dto;
using RazorMVCDotNetApp.Dto.Department;
using RazorMVCDotNetApp.Dto.Employee;
using RazorMVCDotNetApp.Employee.Services;
using RazorMVCDotNetApp.Interfaces.Employee;
using RazorMVCDotNetApp.Models;

namespace RazorMVCDotNetApp.Controllers.Employee
{
    public class EmployeeController: Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IEmployeeService iEmployeeService;
        private DepartmentDao departmentDao;
        private EmployeeDto employeeDto;
        private CryptoEngine cryptoEngine;

        public EmployeeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Add()
        {
            //Populate ViewBag with Departments Data
            departmentDao = new DepartmentDao();
            ViewData["Departments"] = departmentDao.FindAll();

            //Pass the EmployeeDto to the View
            return View(new EmployeeDto());
        }
        
        public IActionResult Edit(string id)
        {
            //Populate ViewBag with Departments Data
            var departments = new List<DepartmentModel>();
            var departmentDtos = new List<DepartmentDto>();
            departmentDao = new DepartmentDao();
            departments = departmentDao.FindAll();

            foreach (var item in departments)
            {
                DeptModelToDto(item, departmentDtos);
            }

            ViewData["Departments"] = departmentDtos;
            //View with Employee details
            iEmployeeService = new AddEmployeeService();
            employeeDto = new EmployeeDto();
            List<EmployeeModel> employees = iEmployeeService.GetEmployee(id);
            
            EmpModelToDto(id, employees);
            
            ViewData["Employee"] = employeeDto;
            return View(new EmployeeDto());
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeDto employeeDto)
        {
            //Declare the response object
            Dictionary<String,Object> response = new Dictionary<string, object>();
            //Check if the model is valid and proceed with saving the data
            //otherwise return the model to Index view
            if (ModelState.IsValid)
            {
                var employee = new EmployeeModel();
                try
                {
                    iEmployeeService = new AddEmployeeService();
                    employee = iEmployeeService.AddEmployee(employeeDto);
                    if (employee == null)
                    {
                        response.Add("status","error");
                        response.Add("message","Failed to save the data due to an error in Service.");
                        return Json(response);
                    }
                    response.Add("status","success");
                    response.Add("message","Employee Saved Successfully");
                    return Json(response);
                }
                catch(Exception ex)
                {
                    response.Add("status","error");
                    response.Add("message","Failed to save the data due to an error In Controller.");
                    response.Add("errorMessage", ex.InnerException!=null?ex.InnerException.Message:ex.Message);
                    return Json(response);
                }
            }

            response.Add("status","error");
            response.Add("message","Invalid Inputs " + ModelState.Values);
            return Json(response);
        }
        
        [HttpPost]
        public IActionResult EditEmployee(EmployeeDto employeeDto)
        {
            //Declare the response object
            var response = new Dictionary<string, object>();
            //Check if the model is valid and proceed with saving the data
            //otherwise return the model to Index view
            if (ModelState.IsValid)
            {
                try
                {
                    iEmployeeService = new AddEmployeeService();
                    var employee = iEmployeeService.EditEmployee(employeeDto);
                    if (employee.Id == 0)
                    {
                        response.Add("status","error");
                        response.Add("message","Failed to Edit the data due to an error in Service.");
                        return Json(response);
                    }
                    response.Add("status","success");
                    response.Add("message","Department Saved Successfully");
                    return Json(response);
                }
                catch(Exception ex)
                {
                    response.Add("status","error");
                    response.Add("message","Failed to save the data due to an error In Controller.");
                    response.Add("errorMessage", ex.InnerException!=null?ex.InnerException.Message:ex.Message);
                    return Json(response);
                }
            }

            response.Add("status","error");
            response.Add("message","Invalid Inputs " + ModelState.Values);
            return Json(response);
        }

        [HttpPost]
        public IActionResult GetTopHundred(SearchDto searchDto)
        {
            var response = new Dictionary<string, object>();

            iEmployeeService = new AddEmployeeService();
            var employees = iEmployeeService.GetEmployees(searchDto);
            
            response.Add("data", employees);
            response.Add("recordsTotal", employees.Count);
            response.Add("recordsFiltered", employees.Count);
            response.Add("draw", searchDto.draw);
            
            return Json(response);
        }
        
        private void EmpModelToDto(string id, List<EmployeeModel> employees)
        {
            employeeDto.IdEncryption = id;
            employeeDto.FirstName = employees[0].FirstName;
            employeeDto.LastName = employees[0].LastName;
            employeeDto.DepartmentId = employees[0].DepartmentId;
            var deptIdStr = cryptoEngine.Encrypt(employees[0].DepartmentId.ToString(), "qwer-3qa8-asdf21");
            employeeDto.DeptIdEncryption = deptIdStr;
        }

        private void DeptModelToDto(DepartmentModel item, List<DepartmentDto> departmentDtos)
        {
            var departmentDto = new DepartmentDto();

            cryptoEngine = new CryptoEngine();
            departmentDto.IdEncryption = cryptoEngine.Encrypt(item.Id.ToString(), "qwer-3qa8-asdf21");
            departmentDto.Name = item.Name;
            departmentDto.Id = item.Id;

            departmentDtos.Add(departmentDto);
        }

        public IActionResult Delete(string id)
        {
            var response = new Dictionary<string, object>();
            //Editing IService Function Called here
            //Check if the model is valid and proceed with saving the data
            //otherwise return the model to Index view
            if (ModelState.IsValid)
            {
                try
                {
                    iEmployeeService = new AddEmployeeService();
                    var employee = iEmployeeService.DeleteEmployee(id);
                    if (employee.Id == 0)
                    {
                        response.Add("status", "error");
                        response.Add("message", "Failed to Delete the data due to an error in Service.");
                        return Json(response);
                    }

                    response.Add("status", "success");
                    response.Add("message", "Employee Deleted Successfully");
                    return Json(response);
                }
                catch (Exception ex)
                {
                    response.Add("status", "error");
                    response.Add("message", "Failed to Delete the data due to an error In Controller.");
                    response.Add("errorMessage", ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                    return Json(response);
                }
            }
            response.Add("status", "error");
            response.Add("message", "Invalid Inputs " + ModelState.Values);
            return Json(response);
        }
        
    }
}