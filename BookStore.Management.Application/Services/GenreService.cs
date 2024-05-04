using AutoMapper;
using BookStore.Management.Application.Abstracts;
using BookStore.Management.Application.DTOs;
using BookStore.Management.DataAccess.Repository;


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

        public async Task<ResponseDatatable<GenreDTO>> GetGenreByPagination(RequestDatatable request)
        {
            var genres = await _unitOfWork.GenreRepository.GetAllGenre();

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

    }
}
