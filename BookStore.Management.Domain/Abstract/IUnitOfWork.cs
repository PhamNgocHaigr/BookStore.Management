using BookStore.Management.Domain.Abstract;

namespace BookStore.Management.DataAccess.Repository
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        IGenreRepository GenreRepository { get; }

        Task SaveChangesAsync();
    }
}