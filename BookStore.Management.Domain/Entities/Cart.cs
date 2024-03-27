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
        [StringLength(200)]
        public string Code { get; set; }
        [StringLength(1000)]
        public string Note { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Status { get; set; }
        public bool IsActive { get; set; }
        [StringLength(450)]
        public string? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser ApplicationUser { get; set; }

    }
}
