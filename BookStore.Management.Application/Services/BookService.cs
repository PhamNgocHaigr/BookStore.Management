using AutoMapper;
using BookStore.Management.Application.Abstracts;
using BookStore.Management.Application.DTOs;
using BookStore.Management.Application.DTOs.ViewModels;
using BookStore.Management.DataAccess.Repository;
using BookStore.Management.Domain.Entities;
using BookStore.Management.Domain.Enums;
using BookStore.Management.Infrastructure.Image;
using Microsoft.AspNetCore.Http;
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
        private readonly ICommonService _commonService;
        private readonly IImageService _imageService;

        public BookService(IMapper mapper, IUnitOfWork unitOfWork, ICommonService commonService, IImageService imageService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _commonService = commonService;
            _imageService = imageService;
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
        public async Task<BookViewModel> GetBooksByIdAsync(int id)
        {
            var book = await _unitOfWork.BookRepository.GetBooksByIdAsync(id);
            return _mapper.Map<BookViewModel>(book);
        }

        public async Task<ResponseModel> SaveAsync(BookViewModel bookVM)
        {
            var book = new Book();

            if ((bookVM.Id ?? 0) == 0)
            {
                book = _mapper.Map<Book>(bookVM);
                book.CreatedOn = DateTime.Now;
                book.Code = bookVM.Code;
            }
            else
            {
                book = await _unitOfWork.BookRepository.GetBooksByIdAsync(bookVM.Id ?? 0);

                book.Title = bookVM.Title;
                book.Description = bookVM.Description;
                book.Author = bookVM.Author;
                book.Available = bookVM.Available;
                book.GenreId = bookVM.GenreId;
                book.Cost = bookVM.Cost;
                book.Publisher = bookVM.Publisher;
                book.IsActive = bookVM.IsActive;
            }

            var result = await _unitOfWork.BookRepository.SaveAsync(book);
            await _unitOfWork.SaveChangesAsync();

            if (result)
            {
                await _imageService.SaveImage(new List<IFormFile> { bookVM.Image }, "images/book", $"{book.Id}.png");
            }

            var actionType = bookVM.Id == 0 ? ActionType.Insert : ActionType.Update;
            var successMessage = $"{(bookVM.Id == 0 ? "Insert" : "Update")} successful.";
            var failureMessage = $"{(bookVM.Id == 0 ? "Insert" : "Update")} failed.";

            return new ResponseModel
            {
                Action = actionType,
                Message = result ? successMessage : failureMessage,
                Status = result,
            };
        }

        public async Task<string> GenerateCodeAsync(int number = 10)
        {
            string newCode = string.Empty;  

            while (true)
            {
                newCode = _commonService.GenerateRandomCode(number);

                var bookCode = await _unitOfWork.BookRepository.GetBooksByCodeAsync(newCode);

                if (bookCode is null)
                {
                    break;
                }

            }
            return newCode;
        }

        
    }
}
