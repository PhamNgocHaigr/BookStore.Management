using BookStore.Management.Application.DTOs;

namespace BookStore.Management.Application.Abstracts
{
    public interface IGenreService
    {
        Task<ResponseDatatable<GenreDTO>> GetGenreByPagination(RequestDatatable request);
    }
}