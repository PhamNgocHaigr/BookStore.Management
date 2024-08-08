using BookStore.Management.Application.DTOs.Cart;

namespace BookStore.Management.Application.Abstracts
{
    public interface ICartService
    {
        Task<bool> SaveAsync(CartRequestDTO bookCartDTOs);
    }
}