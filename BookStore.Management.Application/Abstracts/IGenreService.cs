using BookStore.Management.Application.DTOs;
using BookStore.Management.Application.DTOs.ViewModels;

namespace BookStore.Management.Application.Abstracts
{
    public interface IGenreService
    {
        Task<bool> DeleteAsync(int id);
        Task<GenreViewModel> GetById(int id);
        Task<ResponseDatatable<GenreDTO>> GetGenreByPagination(RequestDatatable request);
        Task<ResponseModel> SaveAsync(GenreViewModel genreVM);
    }
}