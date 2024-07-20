using BookStore.Management.Application.Abstracts;
using BookStore.Management.Application.DTOs;
using BookStore.Management.Application.DTOs.User;
using BookStore.Management.UI.Ultility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Management.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public AccountController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
  
        }
        [BreadScrum("Account List", "Application")] 
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetAccountPagination(RequestDatatable requestDatatable)
        {
            var data = await _userService.GetAllUserByPagination(requestDatatable);

            return Json(data);
        }
        [HttpGet]
        [BreadScrum("Account Form", "Application")] 
        public async Task<IActionResult> SaveData(string id)
        {
            AccountDTO accountDto = !string.IsNullOrEmpty(id) ? await _userService.GetUserById(id) : new();

            ViewBag.Roles = await _roleService.GetRoleForDropdownlist();

            return View(accountDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [BreadScrum("Account Form", "Application")]
        public async Task<IActionResult> SaveData(AccountDTO accountDTO)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Roles = await _roleService.GetRoleForDropdownlist();
                ModelState.AddModelError("errorsModel", "Invalid Model");

                return View(accountDTO);
            }
            var result = await _userService.Save(accountDTO);
            if(result.Status)
            {
                return RedirectToAction("","Account");
            }

            ModelState.AddModelError("errorsModel", result.Message);
            ViewBag.Roles = await _roleService.GetRoleForDropdownlist();

            return View(accountDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            return Json(await _userService.DeleteAsync(id));
        }
    }
}
