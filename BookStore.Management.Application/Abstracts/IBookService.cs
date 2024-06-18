using BookStore.Management.Application.DTOs;

namespace BookStore.Management.Application.Abstracts
{
    public interface IBookService
    {
        Task<ResponseDatatable<BookDTO>> GetBooksByPaginationAsyns(RequestDatatable request);
    }
}