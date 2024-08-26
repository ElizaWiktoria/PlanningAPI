using Microsoft.EntityFrameworkCore;
using PlanningAPI.DataContext;
using System.Linq.Expressions;

namespace PlanningAPI.Repositories
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
            => _dbSet;

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _dbSet.ToListAsync(cancellationToken);

        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancelationToken = default)
            => await _dbSet.FirstOrDefaultAsync(expression, cancellationToken: cancelationToken);

        public IEnumerable<T> GetFiltered(Expression<Func<T, bool>> expression)
            => _dbSet.Where(expression);

        public void Remove(T entity)
            => _dbSet.Remove(entity);

        public bool SaveChanges()
            => _dbContext.SaveChanges() > 0;
    }
}
