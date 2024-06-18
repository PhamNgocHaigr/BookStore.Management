using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Management.Application.DTOs.ViewModels
{
    public class GenreViewModel
    {
        public int? Id { get; set; } = 0;
        [Required(ErrorMessage = "Genre name must not empty")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
