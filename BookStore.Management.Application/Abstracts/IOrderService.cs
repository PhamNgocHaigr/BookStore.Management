using BookStore.Management.Application.DTOs;
using BookStore.Management.Application.DTOs.Order;

namespace BookStore.Management.Application.Abstracts
{
    public interface IOrderService
    {
        Task<ResponseDatatable<object>> GetByPaginationAsync(RequestDatatable request);
        Task<bool> SaveAsync(OrderRequestDTO orderDTO);
    }
}