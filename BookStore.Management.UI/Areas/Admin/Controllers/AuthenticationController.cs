using BookStore.Management.Application.Services;
using BookStore.Management.Domain.Entities;
using BookStore.Management.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Management.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticationController(IUserService userService, SignInManager<ApplicationUser> signInManager)
        {
            _userService = userService;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            var mdLogin = new LoginModel();
            return View(mdLogin);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if(ModelState.IsValid)
            {
                var result = await _userService.CheckLogin(loginModel.Username, loginModel.Password,loginModel.HasRememberMe);
                if(!result.Status)
                {
                    TempData["errer"] = result.Message;
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }    
            }
            else
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors)
                                                    .Select(x => x.ErrorMessage).ToList();
                TempData["errer"] = string.Join("<br/>", errors);
            }
            
            
            return View(loginModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return View("Login");
        }
    }
}
