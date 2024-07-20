using BookStore.Management.Application.DTOs;
using BookStore.Management.Application.DTOs.Genre;
using BookStore.Management.Application.DTOs.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Management.Application.Abstracts
{
    public interface IGenreService
    {
        Task<bool> DeleteAsync(int id);
        Task<GenreViewModel> GetById(int id);
        Task<ResponseDatatable<GenreDTO>> GetGenreByPagination(RequestDatatable request);
        Task<IEnumerable<SelectListItem>> GetGenresForDropdownlistAsync();
        IEnumerable<GenreSiteDTO> GetGenresListForSite();
        Task<ResponseModel> SaveAsync(GenreViewModel genreVM);
    }
}