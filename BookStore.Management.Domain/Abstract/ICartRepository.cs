using BookStore.Management.Domain.Entities;

namespace BookStore.Management.DataAccess.Repository
{
    public interface ICartRepository
    {
        Task SaveAsync(Cart order);
    }
}