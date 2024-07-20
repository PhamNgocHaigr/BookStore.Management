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

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await GetAllAsync(x => x.IsActive);
        }

        public async Task<Genre> GetById(int id)
        {
            return await GetSingleAsync(x => x.Id == id);
        }

        public async Task<bool> Save(Genre genre)
        {
            try
            {
                if (genre.Id == 0)
                {
                    await base.CreateAsync(genre);
                }
                else
                {
                     base.Update(genre);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }   
    }
}
