using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Data
{
    public interface IApplcationDbContext
    {

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry Entry(object entity);
        List<T> RunSp<T>(string storeName, List<DbParamter> listParamert) where T : new();
    }

}
