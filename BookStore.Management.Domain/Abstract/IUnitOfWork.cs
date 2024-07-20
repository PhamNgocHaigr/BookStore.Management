using BookStore.Management.Domain.Abstract;
using BookStore.Management.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Management.DataAccess.Repository
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        IGenreRepository GenreRepository { get; }
        
        Task SaveChangesAsync();
        DbSet<T> Table<T>() where T : class;
        
    }
}