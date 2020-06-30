using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Assignment.Core.Repositories
{
    /**
     * Base interface specifying the contract method Repository signatures.
     */
    public interface IRepository<TEntity> where TEntity : class
    {
        // Methods used to find objects
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();

        // Methods used to adding new objects
        void Add(TEntity entity); // Wanted to unit test in HomeControllerTest
        void AddRange(IEnumerable<TEntity> entities);  // Wanted to unit test in HomeControllerTest

        // Methods used to removing existing objects
        void Remove(TEntity entity); // Wanted to unit test in HomeControllerTest
        void RemoveRange(IEnumerable<TEntity> entities); // Wanted to unit test in HomeControllerTest
    }
}
