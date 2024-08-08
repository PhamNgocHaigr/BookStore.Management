using AutoMapper;
using BookStore.Management.Application.Abstracts;
using BookStore.Management.Application.DTOs.User;
using BookStore.Management.DataAccess.Abstract;
using BookStore.Management.Domain.Entities;


namespace BookStore.Management.Application.Services
{
    public class UserAddressService : IUserAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserAddressService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserAddressDTO>> GetUserAddressListForSiteAsync(string userId)
        {
            var address = await _unitOfWork.UserAddressRepository.GetAllAddressByUserAsync(userId);

            var result = _mapper.Map<IEnumerable<UserAddressDTO>>(address);

            return result;
        }

        public async Task<int> SaveAsync(UserAddressDTO userAddressDTO)
        {
            try
            {
                var address = _mapper.Map<UserAddress>(userAddressDTO);

                await _unitOfWork.UserAddressRepository.SaveAsync(address);

                await _unitOfWork.SaveChangeAsync();

                return address.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
