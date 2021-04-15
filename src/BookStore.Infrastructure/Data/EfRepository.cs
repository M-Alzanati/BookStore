using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.SharedKernel;
using BookStore.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace BookStore.Infrastructure.Data
{
    public class EfRepository : IRepository
    {
        private readonly AppDbContext _dbContext;

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById<T>(string id) where T : BaseEntity
        {
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public Task<T> GetByIdAsync<T>(string id) where T : BaseEntity
        {
            return _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public Task<T> GetByIdAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            return _dbContext.Set<T>().SingleOrDefaultAsync(predicate);
        }

        public Task<T> GetByIdAsync<T>(Expression<Func<T, IEnumerable<BaseEntity>>> include, Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            return _dbContext.Set<T>().Include(include).SingleOrDefaultAsync(predicate);
        }

        public Task<List<T>> ListAsync<T>() where T : BaseEntity
        {
            return _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync<T>(T entity) where T : BaseEntity
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public Task UpdateAsync<T>(T entity) where T : BaseEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task<List<T>> ListAsync<T>(Func<T, bool> predicate) where T : BaseEntity
        {
            return Task.FromResult(_dbContext.Set<T>().Where(predicate).ToList());
        }
    }
}