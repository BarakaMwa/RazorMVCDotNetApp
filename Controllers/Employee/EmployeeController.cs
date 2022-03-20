using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RazorMVCDotNetApp.Controllers.Employee
{
    public class EmployeeController: Controller
    {
        private readonly ILogger<HomeController> _logger;
        
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
    }
}