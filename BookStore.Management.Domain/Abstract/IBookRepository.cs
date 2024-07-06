using BookStore.Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Management.Domain.Abstract
{
    public interface IBookRepository
    {
        Task<Book?> GetBooksByCodeAsync(string code);
        Task<Book?> GetBooksByIdAsync(int id);
        Task<(IEnumerable<T>, int)> GetBooksByPaginationAsync<T>(int pageIndex, int pageSize, string keyword);
        Task<(IEnumerable<Book>, int)> GetBooksForSiteAsync(int genreId, int pageIndex, int pageSize = 10);
        Task<bool> SaveAsync(Book book);
    }
}
