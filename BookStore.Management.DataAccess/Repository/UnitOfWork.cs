using BookStore.Management.DataAccess.Data;
using BookStore.Management.Domain.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;


namespace BookStore.Management.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _applicationDbContext;

        private readonly ISQLQueryHandler _sqlQueryHandler;
        
        private IBookRepository? _bookRepository;
        private IGenreRepository? _genreRepository;
        private bool disposedValue;

        public UnitOfWork(ApplicationDbContext applicationDbContext, ISQLQueryHandler sqLQueryHandler)
        {
            _applicationDbContext = applicationDbContext;
            _sqlQueryHandler = sqLQueryHandler;
        }

        public DbSet<T> Table<T>() where T : class => _applicationDbContext.Set<T>();

        public IBookRepository BookRepository => _bookRepository ??= new BookRepository(_applicationDbContext, _sqlQueryHandler);
        public IGenreRepository GenreRepository => _genreRepository ??= new GenreRepository(_applicationDbContext);

        
        
        

        public async Task SaveChangesAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if(!disposedValue)
            {
                if (disposing)
                {
                    _applicationDbContext.Dispose();
                }
                disposedValue = true;
            }  
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
