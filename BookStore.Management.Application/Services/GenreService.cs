using AutoMapper;
using BookStore.Management.Application.Abstracts;
using BookStore.Management.Application.DTOs;
using BookStore.Management.Application.DTOs.Genre;
using BookStore.Management.Application.DTOs.ViewModels;
using BookStore.Management.DataAccess.Repository;
using BookStore.Management.Domain.Entities;
using BookStore.Management.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace BookStore.Management.Application
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GenreViewModel> GetById(int id)
        {
            var genre = await _unitOfWork.GenreRepository.GetById(id);

            return _mapper.Map<GenreViewModel>(genre);     
        }

        public async Task<ResponseDatatable<GenreDTO>> GetGenreByPagination(RequestDatatable request)
        {
            var genres = await _unitOfWork.GenreRepository.GetAllAsync();

            var genresDTO = _mapper.Map<IEnumerable<GenreDTO>>(genres);

            int totalRecords = genresDTO.Count();

            var result = genresDTO.Skip(request.SkipItems).Take(request.PageSize).ToList();

            return new ResponseDatatable<GenreDTO>
            {
                Draw = request.Draw,
                RecordsTotal = totalRecords,
                RecordsFiltered = totalRecords,
                Data = result
            };
        }

        public async Task<IEnumerable<SelectListItem>> GetGenresForDropdownlistAsync()
        {
            var genres = await _unitOfWork.GenreRepository.GetAllAsync();

            var result = genres.Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Name
            });

            return result;
        }


        public async Task<ResponseModel> SaveAsync(GenreViewModel genreVM)
        {
            var genre = _mapper.Map<Genre>(genreVM);
            
            if(genreVM.Id == 0)
            {
               genre.CreateOn = DateTime.Now;
               genre.IsActive = true;
            }

            var result = await _unitOfWork.GenreRepository.Save(genre);

            await _unitOfWork.SaveChangesAsync();

            var actionType = genreVM.Id == 0 ? ActionType.Insert : ActionType.Update;
            var successMessage = $"{(genreVM.Id == 0 ? "Insert" : "Update")} successful.";
            var failedMessage = $"{(genreVM.Id == 0 ? "Insert" : "Update")} failed.";

            return new ResponseModel
            {
               Action = actionType,
               Message = successMessage,    
               Status = result,
            }; 
        }

        public IEnumerable<GenreSiteDTO> GetGenresListForSite()
        {
            var result = _unitOfWork.Table<Genre>().Select(x => new GenreSiteDTO
            {
                Id = x.Id,
                Name = x.Name,
                TotalBooks = x.Books.Count
            }).AsNoTracking();

            return result;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var genre = await _unitOfWork.GenreRepository.GetById(id);

            if (genre is not null)
            {
                genre.IsActive = false;
                await _unitOfWork.GenreRepository.Save(genre);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
