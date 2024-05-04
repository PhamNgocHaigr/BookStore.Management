using BookStore.Management.DataAccess.Data;
using BookStore.Management.Domain.Abstract;
using BookStore.Management.Domain.Entities;


namespace BookStore.Management.DataAccess.Repository
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }  

        public async Task<IEnumerable<Genre>> GetAllGenre()
        {
            return await GetAllAsync();
        }
    }
}
