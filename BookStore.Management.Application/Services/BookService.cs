using AutoMapper;
using BookStore.Management.Application.Abstracts;
using BookStore.Management.Application.DTOs;
using BookStore.Management.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Management.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        IUnitOfWork _unitOfWork;

        public BookService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseDatatable<BookDTO>> GetBooksByPaginationAsyns(RequestDatatable request)
        {
            int totalRecords = 0;
            IEnumerable<BookDTO> books; 

             (books, totalRecords) = await _unitOfWork.BookRepository.GetBooksByPaginationAsync<BookDTO>(request.SkipItems, request.PageSize, request.Keyword);
            return new ResponseDatatable<BookDTO>
            {
                Draw = request.Draw,
                RecordsTotal = totalRecords,
                RecordsFiltered = totalRecords,
                Data = books.ToList()
            };
        }
    }
}
