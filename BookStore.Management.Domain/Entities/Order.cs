using BookStore.Management.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Management.Domain.Entities
{
    public class Order : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Code { get; set; }
        public DateTime CreatedOn { get; set; }
        public double TotalAmount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public StatusProcessing Status { get; set; }
        public int AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public UserAddress UserAddress { get; set; }
        public ICollection<OrderDetail> Details { get; set; }
    }
}
