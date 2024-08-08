using BookStore.Management.Application.Abstracts;
using BookStore.Management.Domain.Entities;
using BookStore.Management.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Management.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginController(IAuthenticationService authenticationService, SignInManager<ApplicationUser> signInManager)
        {
            _authenticationService = authenticationService;
            _signInManager = signInManager;
        }

        public IActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
 
        [HttpPost]
        
        public async Task<IActionResult> Index(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _authenticationService.CheckLogin(loginModel.Username, loginModel.Password, hasRemember: false);
                if (result.Status)
                {
                    string returnUrl = loginModel.ReturnUrl;
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1
                        && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//")
                        && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("", "Home");
                }
                else
                {
                    ModelState.AddModelError("error", "Username or password is incorrect");
                }
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
