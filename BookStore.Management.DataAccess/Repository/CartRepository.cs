using BookStore.Management.DataAccess.Data;
using BookStore.Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Management.DataAccess.Repository
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async Task SaveAsync(Cart order)
        {
            if (order.Id == 0)
            {
                await CreateAsync(order);
            }
            else
            {
                Update(order);
            }
        }
    }
}
