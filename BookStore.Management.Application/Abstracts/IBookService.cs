using BookStore.Management.Application.DTOs;
using BookStore.Management.Application.DTOs.Book;
using BookStore.Management.Application.DTOs.ViewModels;

namespace BookStore.Management.Application.Abstracts
{
    public interface IBookService
    {
        Task DeleteAsync(int id);
        Task<string> GenerateCodeAsync(int number = 10);
        Task<BookViewModel> GetBooksByIdAsync(int id);
        Task<IEnumerable<BookCartDTO>> GetBooksByListCodeAsync(string[] codes);
        Task<ResponseDatatable<BookDTO>> GetBooksByPaginationAsyns(RequestDatatable request);
        Task<BookForSiteDTO> GetBooksForSiteAsync(int genreId, int pageIndex, int pageSize = 10);
        Task<ResponseModel> SaveAsync(BookViewModel bookVM);
    }
}