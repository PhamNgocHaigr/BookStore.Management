using BookStore.Management.DataAccess.Data;
using BookStore.Management.Domain.Abstract;
using BookStore.Management.Domain.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Management.DataAccess.Repository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly ISQLQueryHandler _sqLQueryHandler;

        public BookRepository(ApplicationDbContext applicationDbContext, ISQLQueryHandler sqLQueryHandler) : base(applicationDbContext)
        {
            _sqLQueryHandler = sqLQueryHandler;
        }

        public async Task<(IEnumerable<T>, int)> GetBooksByPaginationAsync<T>(int pageIndex, int pageSize, string keyword)
        {
            DynamicParameters parammeters = new DynamicParameters();

            parammeters.Add("keyword", keyword, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parammeters.Add("pageIndex", pageIndex, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parammeters.Add("pageSize", pageSize, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parammeters.Add("totalRecords", 0, System.Data.DbType.Int32, System.Data.ParameterDirection.Output);

            var result = await _sqLQueryHandler.ExecuteStoreProdecureReturnListAsync<T>("spGetALLBooksByPagination", parammeters); 


            var totalRecords = parammeters.Get<int>("totalRecords");

            return (result, totalRecords);
        }




    }
}
