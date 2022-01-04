﻿using Mc2.CrudTest.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Data
{
    public interface IRepository<TEntity> where TEntity : Entity
    {

        TEntity GetById(params object[] ids);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        IQueryable<TEntity> Table { get; }

        IQueryable<TEntity> TableNoTracking { get; }

        TEntity GetByIdAsNoTracking(params object[] ids);
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task InsertAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(params object[] ids);
        Task<TEntity> GetByIdAsNoTrackingAsync(params object[] ids);
        List<T> RunFunctionDb<T>(string functionName, List<DbParamter> paramters) where T : new();
    }

}
