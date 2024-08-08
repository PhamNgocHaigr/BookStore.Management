using AutoMapper;
using BookStore.Management.Application.Abstracts;
using BookStore.Management.Application.DTOs.Cart;
using BookStore.Management.DataAccess.Abstract;
using BookStore.Management.DataAccess.Repository;
using BookStore.Management.Domain.Entities;


namespace BookStore.Management.Application.Services
{
    public class CartService : ICartService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CartService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> SaveAsync(CartRequestDTO bookCartDTOs)
        {
            try
            {
                var cart = _mapper.Map<Cart>(bookCartDTOs);

                await _unitOfWork.BeginTransaction();

                await _unitOfWork.CartRepository.SaveAsync(cart);
                await _unitOfWork.SaveChangeAsync();

                if (bookCartDTOs.Books.Any())
                {
                    foreach (var book in bookCartDTOs.Books)
                    {
                        var cartDetail = new CartDetail
                        {
                            CartId = cart.Id,
                            BookId = book.Id,
                            Quantity = book.Quantity,
                            Price = book.Price,
                            IsActive = true
                        };

                        await _unitOfWork.Table<CartDetail>().AddAsync(cartDetail);
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
