using BookStore.Management.Application.DTOs;
using BookStore.Management.Application.DTOs.ViewModels;

namespace BookStore.Management.Application.Abstracts
{
    public interface IBookService
    {
        Task<string> GenerateCodeAsync(int number = 10);
        Task<BookViewModel> GetBooksByIdAsync(int id);
        Task<ResponseDatatable<BookDTO>> GetBooksByPaginationAsyns(RequestDatatable request);
        Task<ResponseModel> SaveAsync(BookViewModel bookVM);
    }
}