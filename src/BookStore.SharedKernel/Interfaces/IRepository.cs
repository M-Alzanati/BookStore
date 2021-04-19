using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BookStore.SharedKernel.Interfaces
{
    /// <summary>
    /// This is a generic repository interface should be implemented by concrete classes
    /// to interact with database.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Get Entity by it's id synchros
        /// and throw exception if there is more than one item  is matching the condition
        /// </summary>
        /// <typeparam name="T">string</typeparam>
        /// <param name="id">unique identifier</param>
        /// <returns>Single entity</returns>
        T GetById<T>(string id) where T : BaseEntity;

        /// <summary>
        /// Get Entity by it's id asynchrons
        /// and throw exception if there is more than one item  is matching the condition
        /// </summary>
        /// <typeparam name="T">string</typeparam>
        /// <param name="id">unique identifier</param>
        /// <returns>Single entity</returns>
        Task<T> GetByIdAsync<T>(string id) where T : BaseEntity;

        /// <summary>
        /// Get Entity by it's id asynchrons and filter by a predicate, 
        /// and throw exception if there is more than one item  is matching the condition
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="predicate">Filter function</param>
        /// <returns>Single entity</returns>
        Task<T> GetByIdAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;

        /// <summary>
        /// Get Entity by it's id asynchrons with including other entities and filter by a predicate
        /// and throw exception if there is more than one item  is matching the condition
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="include">include function that contains required sub-entities</param>
        /// <param name="predicate">Filter function</param>
        /// <returns>Single entity</returns>
        Task<T> GetByIdAsync<T>(Expression<Func<T, IEnumerable<BaseEntity>>> include, Expression<Func<T, bool>> predicate) where T : BaseEntity;

        /// <summary>
        /// Get all entities asynchrons
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <returns>List of entities</returns>
        Task<List<T>> ListAsync<T>() where T : BaseEntity;

        /// <summary>
        /// Get all entities asynchrons, and filter by a predicate
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="predicate">Filter function</param>
        /// <returns>List of entities</returns>
        Task<List<T>> ListAsync<T>(Func<T, bool> predicate) where T : BaseEntity;

        /// <summary>
        /// Get all entities asynchrons, and filter by a predicate
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="predicate">Filter function</param>
        /// <returns>List of entities</returns>
        Task<List<T>> ListAsync<T>(Expression<Func<T, IEnumerable<BaseEntity>>> include) where T : BaseEntity;


        /// <summary>
        /// Add new entity async
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="entity">New Entity with tenant id</param>
        /// <returns>Added entity with it's id</returns>
        Task<T> AddAsync<T>(T entity) where T : BaseEntity;

        /// <summary>
        /// Update existing entity async
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="entity">Entity with tenant id</param>
        /// <returns>Updated entity with it's id</returns>
        Task UpdateAsync<T>(T entity) where T : BaseEntity;

        /// <summary>
        /// Delete entity async
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns>Number of state entries written to the database.</returns>
        Task DeleteAsync<T>(T entity) where T : BaseEntity;
    }
}