using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BookStore.SharedKernel.Interfaces
{
    public interface IRepository
    {
        T GetById<T>(string id) where T : BaseEntity;

        Task<T> GetByIdAsync<T>(string id) where T : BaseEntity;

        Task<T> GetByIdAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;

        Task<List<T>> ListAsync<T>() where T : BaseEntity;

        Task<List<T>> ListAsync<T>(Func<T, bool> predicate) where T : BaseEntity;

        Task<T> AddAsync<T>(T entity) where T : BaseEntity;

        Task UpdateAsync<T>(T entity) where T : BaseEntity;

        Task DeleteAsync<T>(T entity) where T : BaseEntity;
    }
}