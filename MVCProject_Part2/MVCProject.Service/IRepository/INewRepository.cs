using MVCProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.Service.IRepository
{
    public interface INewRepository<TEntity> where TEntity : class
    {
        IUnitOfWork CurrentUnitOfWork { get; }

        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);


        bool Update(TEntity entity);

        bool Update(IEnumerable<TEntity> entities);
    }
}
