using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RazorMVCDotNetApp.Dao.Department;
using RazorMVCDotNetApp.Dto;
using RazorMVCDotNetApp.Dto.Department;
using RazorMVCDotNetApp.Interfaces.Department;
using RazorMVCDotNetApp.Models;
using RazorMVCDotNetApp.Services.Department;

namespace RazorMVCDotNetApp.Controllers.Department
{
    public class DepartmentController: Controller
    {
        private IDepartmentService iDepartmentService;
        private DepartmentDao departmentDao;
        private readonly ILogger<HomeController> _logger;

        public DepartmentController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Add()
        {
            return View(new DepartmentDto());
        }
        
        public IActionResult Edit(string id)
        {
            iDepartmentService = new AddDepartmentService();
            List <DepartmentModel> department = iDepartmentService.GetDepartment(id);
            ViewData["Department"] = department[0];
            return View(new DepartmentDto());
        }
        
        [HttpPost]
        public IActionResult EditDepartment(DepartmentDto departmentDto)
        {
            var response = new Dictionary<string, object>();
            
            //Editing IService Function Called here
            
            return Json(response);
        }

        [HttpPost]
        public IActionResult AddDepartment(DepartmentDto departmentDto)
        {
            //Declare the response object
            Dictionary<String,Object> response = new Dictionary<string, object>();
            //Check if the model is valid and proceed with saving the data
            //otherwise return the model to Index view
            if (ModelState.IsValid)
            {
                var department = new DepartmentModel();
                try
                {
                    iDepartmentService = new AddDepartmentService();
                    department = iDepartmentService.AddDepartment(departmentDto);
                    if (department.Name == null)
                    {
                        response.Add("status","error");
                        response.Add("message","Failed to save the data due to an error in Service.");
                        return Json(response);
                    }
                    response.Add("status","success");
                    response.Add("message","Department Saved Successfully");
                    return Json(response);
                }
                catch (Exception ex)
                {
                    response.Add("status","error");
                    response.Add("message","Failed to save the data due to an error In Controller.");
                    response.Add("errorMessage", ex.InnerException!=null?ex.InnerException.Message:ex.Message);
                    return Json(response);
                }
            }
                // ViewData["Departments"] = DepartmentDao.FindAll();
                // return View("Add",departmentDto);
                response.Add("status","error");
                response.Add("message","Invalid Inputs " + ModelState.Values);
                return Json(response);
         
        }

        [HttpPost]
        public IActionResult GetTopHundred(SearchDto searchDto)
        {
            var response = new Dictionary<string, object?>();

            iDepartmentService = new AddDepartmentService();
            var departments = iDepartmentService.GetDepartments(searchDto);

            response.Add("data",departments);
            response.Add("recordsTotal",departments.Count);
            response.Add("recordsFiltered",departments.Count);
            response.Add("draw",searchDto.draw);

            return Json(response);
        }

    }
}