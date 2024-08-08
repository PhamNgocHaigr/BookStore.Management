using BookStore.Management.DataAccess.Abstract;
using BookStore.Management.DataAccess.Data;
using BookStore.Management.Domain.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;


namespace BookStore.Management.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ISQLQueryHandler _sqlQueryHandler;

        ApplicationDbContext _applicationDbContext;
        IBookRepository _bookRepository;
        IGenreRepository _genreRepository;
        IUserAddressRepository _addressRepository;
        IOrderRepository _orderRepository;
        ICartRepository _cartRepository;
        IDbContextTransaction _dbContextTransaction;

        private bool disposedValue;

        public UnitOfWork(ApplicationDbContext applicationDbContext, ISQLQueryHandler sqLQueryHandler)
        {
            _applicationDbContext = applicationDbContext;
            _sqlQueryHandler = sqLQueryHandler;
        }

        public DbSet<T> Table<T>() where T : class => _applicationDbContext.Set<T>();

        public IBookRepository BookRepository => _bookRepository ??= new BookRepository(_applicationDbContext, _sqlQueryHandler);
        public IGenreRepository GenreRepository => _genreRepository ??= new GenreRepository(_applicationDbContext);
        public IUserAddressRepository UserAddressRepository => _addressRepository ??= new UserAddressRepository(_applicationDbContext);
        public IOrderRepository OrderRepository => _orderRepository ??= new OrderRepository(_applicationDbContext, _sqlQueryHandler);
        public ICartRepository CartRepository => _cartRepository ??= new CartRepository(_applicationDbContext);


        public async Task BeginTransaction()
        {
            _dbContextTransaction = await _applicationDbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _dbContextTransaction.CommitAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            if (_dbContextTransaction != null)
            {
                try
                {
                    await _dbContextTransaction.RollbackAsync();
                }
                catch (Exception ex)
                {
                    // Ghi lại lỗi hoặc xử lý ngoại lệ
                    throw new InvalidOperationException("Error occurred during transaction rollback.", ex);
                }
            }
            else
            {
                // Ghi lại thông tin hoặc xử lý trường hợp _dbContextTransaction là null
                throw new InvalidOperationException("No transaction to roll back.");
            }

           // await _dbContextTransaction.RollbackAsync();
        }


        public async Task SaveChangeAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _applicationDbContext.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
