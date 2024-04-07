using BookStore.Management.Application.DTOs;

namespace BookStore.Management.Application.Abstracts
{
    public interface IAuthenticationService
    {
        Task<ResponseModel> CheckLogin(string username, string password, bool hasRemember);
    }
}