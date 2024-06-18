using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Management.Domain.Abstract
{
    public interface IBookRepository
    {
        Task<(IEnumerable<T>, int)> GetBooksByPaginationAsync<T>(int pageIndex, int pageSize, string keyword);
    }
}
