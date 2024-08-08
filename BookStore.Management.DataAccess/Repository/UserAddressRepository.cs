using BookStore.Management.DataAccess.Data;
using BookStore.Management.Domain.Entities;

namespace BookStore.Management.DataAccess.Repository
{
    public class UserAddressRepository : GenericRepository<UserAddress>, IUserAddressRepository
    {
        public UserAddressRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async Task<IEnumerable<UserAddress>> GetAllAddressByUserAsync(string id)
        {
            return await GetAllAsync(x => x.UserId == id && x.IsActive);
        }
        public async Task SaveAsync(UserAddress userAddress)
        {
            if (userAddress.Id == 0)
            {
                await CreateAsync(userAddress);
            }
            else
            {
                Update(userAddress);
            }
        }
    }
}
