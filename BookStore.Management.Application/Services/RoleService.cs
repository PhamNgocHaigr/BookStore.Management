using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookStore.Management.Application.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Management.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<SelectListItem>> GetRoleForDropdownlist()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return roles.Select(x => new SelectListItem
            {
                Value = x.Name,
                Text = x.Name
            });
        }
    }
}
