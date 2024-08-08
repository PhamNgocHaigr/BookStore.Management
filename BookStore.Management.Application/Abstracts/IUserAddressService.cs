using BookStore.Management.Application.DTOs.User;

namespace BookStore.Management.Application.Abstracts
{
    public interface IUserAddressService
    {
        Task<IEnumerable<UserAddressDTO>> GetUserAddressListForSiteAsync(string userId);
        Task<int> SaveAsync(UserAddressDTO userAddressDTO);
    }
}