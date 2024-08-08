using BookStore.Management.Application.DTOs.Book;
using BookStore.Management.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Management.Application.DTOs.Order
{
    public  class OrderRequestDTO
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public DateTime CreatedOn { get; set; }
        public double TotalAmount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string UserId { get; set; }
        public int AddressId { get; set; }
        public List<BookCartDTO> Books { get; set; }
        public StatusProcessing Status { get; set; }
    }
}
