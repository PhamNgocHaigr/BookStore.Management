using AutoMapper;
using BookStore.Management.Application.DTOs.Book;
using BookStore.Management.Application.DTOs.Genre;
using BookStore.Management.Application.DTOs.User;
using BookStore.Management.Application.DTOs.ViewModels;
using BookStore.Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Management.Application.Configuration
{
    public class AutomapConfig : Profile
    {
        public AutomapConfig() 
        {
            CreateMap<ApplicationUser, AccountDTO>()
                .ForMember(dest => dest.Phone, source => source.MapFrom(src => src.PhoneNumber))
                .ReverseMap();
            CreateMap<Genre, GenreDTO>().ReverseMap();
            CreateMap<Genre, GenreViewModel>().ReverseMap();
            CreateMap<Book, BookViewModel>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Book, BookCartDTO>()
                .ForMember(dest => dest.Price, source => source.MapFrom(src => src.Cost))
                .ReverseMap();
        }
    }
}
