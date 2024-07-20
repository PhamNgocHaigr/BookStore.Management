using BookStore.Management.Application.DTOs;
using BookStore.Management.Application.DTOs.User;
using System.Threading.Tasks;

namespace BookStore.Management.Application.Abstracts
{
    public interface IUserService
    { 
        Task<ResponseDatatable<UserModel>> GetAllUserByPagination(RequestDatatable request);
        Task<ResponseModel> Save(AccountDTO accountDTO);
        Task<AccountDTO> GetUserById(string id);
        Task<bool> DeleteAsync(string id);
    }
}