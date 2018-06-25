using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace AssetManagement.EntityFramework.Repositories
{
    public abstract class AssetManagementRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<AssetManagementDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected AssetManagementRepositoryBase(IDbContextProvider<AssetManagementDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class AssetManagementRepositoryBase<TEntity> : AssetManagementRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected AssetManagementRepositoryBase(IDbContextProvider<AssetManagementDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
