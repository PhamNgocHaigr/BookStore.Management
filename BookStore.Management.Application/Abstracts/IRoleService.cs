using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Management.Application.Abstracts
{
    public interface IRoleService
    {
        Task<IEnumerable<SelectListItem>> GetRoleForDropdownlist();
    }
}