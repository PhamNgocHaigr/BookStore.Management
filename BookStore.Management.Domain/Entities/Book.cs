using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Management.Domain.Entities
{
    public class Book : BaseEntity
    {
        [Required]
        [StringLength(500)]
        public string Title { get; set; }
        [Required]
        [StringLength(500)]
        public string Author { get; set; }
        [StringLength(500)]
        public string Publisher { get; set; }
        [Required]
        public int Avaiable { get; set; }
        public double Price { get; set; }
        public DateTime CreateOn { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int GenreId { get; set; }
        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; }

    }
}
