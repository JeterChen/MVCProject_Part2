using MVCProject.Data.Entity;
using MVCProject.Infrastructure;
using MVCProject.Service.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.Service.Repository
{
    public class NewRepository<TEntity> : INewRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public IUnitOfWork CurrentUnitOfWork
        {
            get { return this.Context as IUnitOfWork; }
        }

        public NewRepository(IUnitOfWork unitOfwork)
        {
            Context = unitOfwork as DbContext;

        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public bool Update(TEntity entity)
        {
            bool result;

            if (entity == null)
                result = false;
            else
                result = true;

            Context.Entry(entity).State = EntityState.Modified;

            return result;
        }

        public bool Update(IEnumerable<TEntity> entities)
        {
            bool result;

            if (entities == null)
                result = false;
            else
                result = true;

            Context.Entry(entities).State = EntityState.Modified;

            return result;
        }
    }
}
