
using BookStore.Management.Application.DTOs;
using System.Threading.Tasks;

namespace BookStore.Management.Application.Services
{
    public interface IUserService
    {
        Task<ResponseModel> CheckLogin(string username, string password, bool hasRemember);
    }
}