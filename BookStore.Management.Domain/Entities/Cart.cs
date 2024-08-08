using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Management.Domain.Entities
{
    public class Cart : BaseEntity
    {
        [Required]
        [StringLength(20)]
        public string Code { get; set; }
        [StringLength(1000)]
        public string? Note { get; set; }
        public DateTime CreatedOn { get; set; }
        public short Status { get; set; }

    }
}
