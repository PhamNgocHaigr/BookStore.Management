using BookStore.Management.Domain.Abstract;
using BookStore.Management.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Management.DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        IGenreRepository GenreRepository { get; }
        IUserAddressRepository UserAddressRepository { get; }
        IOrderRepository OrderRepository { get; }
        ICartRepository CartRepository { get; }

        Task BeginTransaction();
        Task CommitTransactionAsync();
        void Dispose();
        Task RollbackTransactionAsync();
        Task SaveChangeAsync();
        DbSet<T> Table<T>() where T : class;
        
    }
}