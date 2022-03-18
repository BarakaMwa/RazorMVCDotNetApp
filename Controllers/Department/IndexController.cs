using Microsoft.AspNetCore.Mvc;

namespace RazorMVCDotNetApp.Controllers.Department
{
    public class IndexController: Controller
    {
        
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