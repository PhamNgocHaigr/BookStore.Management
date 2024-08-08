using BookStore.Management.Domain.Entities;

namespace BookStore.Management.DataAccess.Repository
{
    public interface IUserAddressRepository
    {
        Task<IEnumerable<UserAddress>> GetAllAddressByUserAsync(string id);
        Task SaveAsync(UserAddress userAddress);
    }
}