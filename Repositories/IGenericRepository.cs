﻿using System.Linq.Expressions;

namespace PlanningAPI.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancelationToken = default);
        T? Get(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        void Add(T entity);
        bool SaveChanges();
        void Remove(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetFiltered(Expression<Func<T, bool>> expression);
    }
}