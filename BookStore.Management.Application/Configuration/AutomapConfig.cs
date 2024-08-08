using AutoMapper;
using BookStore.Management.Application.DTOs.Book;
using BookStore.Management.Application.DTOs.Cart;
using BookStore.Management.Application.DTOs.Genre;
using BookStore.Management.Application.DTOs.Order;
using BookStore.Management.Application.DTOs.Report;
using BookStore.Management.Application.DTOs.User;
using BookStore.Management.Application.DTOs.ViewModels;
using BookStore.Management.Domain.Entities;

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

            CreateMap<UserAddress, UserAddressDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<CartRequestDTO, Cart>()
                .ForMember(dest => dest.Status, source => source.MapFrom(src => Convert.ToInt16(src.Status)))
                .ReverseMap();
            CreateMap<Order, OrderRequestDTO>().ReverseMap();

            CreateMap<UserAddress, OrderAddressDTO>()
                .ForMember(dest => dest.Phone, source => source.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Name, source => source.MapFrom(src => src.Fullname))
                .ReverseMap();

        }
    }
}
