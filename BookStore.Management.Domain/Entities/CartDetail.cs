using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Management.Domain.Entities
{
    public class CartDetail : BaseEntity
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        [StringLength(1000)]
        public string? Description { get; set; }
        public int Discount { get; set; }
        public int BookId { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }

        public int CartId { get; set; }
        [ForeignKey(nameof(CartId))]
        public Cart cart { get; set; }

    }
}
