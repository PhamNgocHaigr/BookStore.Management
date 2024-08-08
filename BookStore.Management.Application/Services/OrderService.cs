using AutoMapper;
using BookStore.Management.Application.Abstracts;
using BookStore.Management.Application.DTOs;
using BookStore.Management.Application.DTOs.Order;
using BookStore.Management.DataAccess.Abstract;
using BookStore.Management.DataAccess.Repository;
using BookStore.Management.Domain.Entities;
using BookStore.Management.Domain.Enums;


namespace BookStore.Management.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDatatable<object>> GetByPaginationAsync(RequestDatatable request)
        {
            var (orders, totalRecords) = await _unitOfWork.OrderRepository.GetByPaginationAsync<OrderResponseDTO>(request.SkipItems,
                                                                                                    request.PageSize,
                                                                                                    request.Keyword);

            return new ResponseDatatable<object>
            {
                Draw = request.Draw,
                RecordsTotal = totalRecords,
                RecordsFiltered = totalRecords,
                Data = orders.Select(x => new
                {
                    x.Id,
                    x.Code,
                    x.CreatedOn,
                    x.Fullname,
                    x.TotalPrice,
                    Status = Enum.GetName(typeof(StatusProcessing), x.Status),
                    PaymentMethod = Enum.GetName(typeof(PaymentMethod), x.PaymentMethod),
                }).ToList()
            };
        }

        public async Task<bool> SaveAsync(OrderRequestDTO orderDTO)
        {
            try
            {
                var order = _mapper.Map<Order>(orderDTO);

                await _unitOfWork.BeginTransaction();

                await _unitOfWork.OrderRepository.SaveAsync(order);

                await _unitOfWork.SaveChangeAsync();

                if (orderDTO.Books.Any())
                {
                    foreach (var book in orderDTO.Books)
                    {
                        var orderDetail = new OrderDetail
                        {
                            IsActive = true,
                            OrderId = order.Id,
                            ProductId = book.Id,
                            Quantity = book.Quantity,
                            UnitPrice = book.Price,
                        };

                        await _unitOfWork.Table<OrderDetail>().AddAsync(orderDetail);
                    }

                    await _unitOfWork.SaveChangeAsync();
                }

                await _unitOfWork.CommitTransactionAsync();

            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();

                return false;
            }

            return true;
        }

    }
}
