using BookStore.Management.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Management.DataAccess.Repository
{
    public class GenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GenericRepository(ApplicationDbContext applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;
        }
        
        //list.Where(x => x.name == "name").Tolist()

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            if(expression is null)
            {
                return await _applicationDbContext.Set<T>().ToListAsync();
            }   
            return await _applicationDbContext.Set<T>().Where(expression).ToListAsync();
        }
        
        public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> expression = null)
        {
            return await _applicationDbContext.Set<T>().SingleOrDefaultAsync(expression);
        }

        public async Task CreateAsync(T entity)
        {
            await _applicationDbContext.AddAsync(entity);
        }

        public async Task Update(T entity)
        {
            _applicationDbContext.Set<T>().Attach(entity);
            _applicationDbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(T entity)
        {
            _applicationDbContext.Set<T>().Attach(entity);
            _applicationDbContext.Entry(entity).State = EntityState.Deleted;
        }

        public async Task SaveChange()
        {
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
