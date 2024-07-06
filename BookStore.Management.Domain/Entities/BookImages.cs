using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Management.Domain.Entities
{
    public class BookImages : BaseEntity
    {

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
        public Book Book { get; set; }

        [NotMapped]
        public bool IsActive { get; set; }
    }
}
