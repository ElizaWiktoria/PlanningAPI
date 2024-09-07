using Microsoft.EntityFrameworkCore;
using Planning.Domain.Interfaces.Repository;
using Planning.Infrastructure.AutoMappers.DataContext;
using System.Linq.Expressions;

namespace Planning.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        protected DataContextEF _dbContext { get; set; }
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DataContextEF dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
            => _dbSet.Add(entity);

        public T? Get(Expression<Func<T, bool>> expression)
            => _dbSet.FirstOrDefault(expression);

        public IEnumerable<T> GetAll()
            => _dbSet.ToList();

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _dbSet.ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _dbSet.ToListAsync(cancellationToken);

        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancelationToken = default)
            => await _dbSet.FirstOrDefaultAsync(expression, cancellationToken: cancelationToken);

        public IEnumerable<T> GetFiltered(Expression<Func<T, bool>> expression)
            => _dbSet.Where(expression);

        public async Task<IEnumerable<T>> GetFilteredAsync(Expression<Func<T, bool>> expression)
            => await _dbSet.Where(expression).ToListAsync();

        public void Remove(T entity)
            => _dbSet.Remove(entity);

        public bool SaveChanges()
            => _dbContext.SaveChanges() > 0;

        public async Task<bool> SaveChangesAsync()
            => await _dbContext.SaveChangesAsync() > 0;

        public async Task AddAsync(T entity)
            => await _dbSet.AddAsync(entity);
    }
}
