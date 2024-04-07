using BookStore.Management.UI.Ultility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Management.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DashboardController : Controller
    {
        [BreadScrum("Dashboard", "")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
