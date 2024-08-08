using BookStore.Management.Application.DTOs.Book;
using BookStore.Management.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Management.Application.DTOs.Cart
{
    public class CartRequestDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string? Note { get; set; }
        public DateTime CreatedOn { get; set; }
        public StatusProcessing Status { get; set; }

        public List<BookCartDTO> Books { get; set; }
    }
}
