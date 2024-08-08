using BookStore.Management.Domain.Entities;

namespace BookStore.Management.DataAccess.Repository
{
    public interface IOrderRepository
    {
        Task<(IEnumerable<T>, int)> GetByPaginationAsync<T>(int pageIndex, int pageSize, string keyword);
        Task SaveAsync(Order order);
    }
}