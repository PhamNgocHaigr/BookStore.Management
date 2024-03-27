using BookStore.Management.DataAccess.Data;
using BookStore.Management.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Management.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _applicationDbContext;

        private IBookRepository? _bookRepository;
        private IGenreRepository? _genreRepository;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IBookRepository BookRepository => _bookRepository ??= new BookRepository(_applicationDbContext);
        public IGenreRepository GenreRepository => _genreRepository ??= new GenreRepository(_applicationDbContext);

       

        public async Task SaveChangesAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            if(_applicationDbContext != null)
            {
                _applicationDbContext.Dispose();
            }
        }
    }
}
