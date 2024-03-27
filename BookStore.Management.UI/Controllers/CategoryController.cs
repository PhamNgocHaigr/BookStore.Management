using Microsoft.AspNetCore.Mvc;

namespace BookStore.Management.UI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
