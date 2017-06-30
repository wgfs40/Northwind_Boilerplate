using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Wind.Northwind.EntityFramework.Repositories
{
    public abstract class NorthwindRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<NorthwindDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected NorthwindRepositoryBase(IDbContextProvider<NorthwindDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class NorthwindRepositoryBase<TEntity> : NorthwindRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected NorthwindRepositoryBase(IDbContextProvider<NorthwindDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
