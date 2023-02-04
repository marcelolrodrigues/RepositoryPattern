﻿using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T> CreateAsync(T entity);

        Task<T?> GetByIdAsync<TId>(TId entityId) where TId : notnull;
        Task<List<T>> FindWithSpecification(BaseSpecification<T> specification);

        Task<List<T>> ListAsync();

        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(T entity);
    }
}
