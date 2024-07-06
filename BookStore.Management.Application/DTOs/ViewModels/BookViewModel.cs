using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Management.Application.DTOs.ViewModels
{
    public class BookViewModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Genre must be not empty")]
        [DisplayName("Genre Name")]
        public int GenreId { get; set; }
        [Required(ErrorMessage = "Title must be not empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Code must be not empty")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Available must be not empty")]   
        public int Available { get; set; }
        [Required(ErrorMessage = "Cost must be not empty")]
        public double Cost { get; set; }
        [Required(ErrorMessage = "Description must be not empty")]
        public string Description { get; set; }
        public string? Publisher { get; set; }
        [Required(ErrorMessage = "Author must be not empty")]
        public string Author { get; set; }
        public bool IsActive { get; set; }
        public IFormFile? Image { get; set; }
    }
}
