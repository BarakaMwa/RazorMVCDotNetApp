using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RazorMVCDotNetApp.Interfaces.Department;
using RazorMVCDotNetApp.Models;

namespace RazorMVCDotNetApp.Controllers.Department
{
    public class DepartmentController: Controller
    {
        private readonly IDepartmentService IDepartmentService;
        private readonly ILogger<HomeController> _logger;

        public DepartmentController(IDepartmentService IDepartmentService, ILogger<HomeController> _logger)
        {
            this.IDepartmentService = IDepartmentService;
            this._logger = _logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Add()
        {
            return View();
        }
        
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDepartment(DepartmentModel department)
        {
            //Declare the response object
            Dictionary<String,Object> response = new Dictionary<string, object>();
            //Check if the model is valid and proceed with saving the data
            //otherwise return the model to Index view
            if (ModelState.IsValid)
            {
                try
                {
                    department = IDepartmentService.AddDepartment(department.Name);
                    if (department == null)
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
                return View("Index",department);
         
        }

    }
}