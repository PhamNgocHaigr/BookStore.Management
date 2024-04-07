using Microsoft.AspNetCore.Mvc;

namespace BookStore.Management.UI.Areas.Admin.Controllers
{
    public class GenreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
