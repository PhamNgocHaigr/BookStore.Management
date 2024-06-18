using BookStore.Management.Application.Abstracts;
using BookStore.Management.Domain.Entities;
using BookStore.Management.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Management.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous] 
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticationController(IAuthenticationService authenticationService, SignInManager<ApplicationUser> signInManager)
        {
            _authenticationService = authenticationService;
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
                var result = await _authenticationService.CheckLogin(loginModel.Username, loginModel.Password,loginModel.HasRememberMe);
                if(!result.Status)
                {
                    TempData["errer"] = result.Message;
                }
                else
                {
                    return RedirectToAction("Index", "Dashboard");
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
