using BookStore.Management.Application.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Management.UI.ViewComponents
{
    [ViewComponent(Name = "GenreList")]
    public class GenreList : ViewComponent
    {
        private readonly IGenreService _genreService;

        public GenreList(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool isActive)
        {
            var genres = _genreService.GetGenresListForSite();

            return View(genres);
        }
    }
}
