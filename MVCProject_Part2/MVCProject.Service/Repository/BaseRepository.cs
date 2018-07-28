using MVCProject.Data.Entity;
using MVCProject.Service.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace MVCProject.Service.Repository
{
    
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        internal NORTHWNDEntities Context;
        internal DbSet<T> Table;

        public BaseRepository(NORTHWNDEntities context)
        {
            this.Context = context;
            this.Table = context.Set<T>();
        }

        public virtual long Count(Expression<Func<T, bool>> expression)
        {
            return Table.LongCount(expression);
        }

        public virtual int CountInt(Expression<Func<T, bool>> expression)
        {
            return Table.Count(expression);
        }

        public virtual bool Delete(object id)
        {
            bool result;

            var o = Table.Find(id);
            Table.Remove(o);
            result = true;


            return result;
        }

        public virtual bool Delete(T entity)
        {
            bool result;

            if (entity == null)
                result = false;
            else
                result = true;

            Table.Remove(entity);
            
            return result;
        }

        public virtual bool Delete(IEnumerable<T> entities)
        {
            bool result;

            if (entities == null)
                result = false;
            else
                result = true;

            Table.RemoveRange(entities);

            return result;
        }

        public virtual T Get(Expression<Func<T, bool>> expression)
        {
            return Table.FirstOrDefault(expression);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Table;
        }

        public virtual T GetById(object id)
        {
            return Table.Find(id);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> expression)
        {
            return Table.Where(expression);
        }

        public virtual bool Insert(T entity)
        {
            bool result;
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Table.Add(entity);
                Context.SaveChanges();
                result = true;
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}";

                var fail = new Exception(msg, dbEx);
                    //throw fail;
                result = false;
            }

            return result;
        }

        public virtual bool Insert(IEnumerable<T> entities)
        {
            bool result;

            if (Table.AddRange(entities).Count() == 0)
                result = false;
            else
                result = true;

            return result;
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }

        public virtual bool Update(T entity)
        {
            bool result;

            if (entity == null)
                result = false;
            else
                result = true;

            Context.Entry(entity).State = EntityState.Modified;

            return result;
        }

        public bool Update(IEnumerable<T> entities)
        {
            bool result;

            if (entities == null)
                result = false;
            else
                result = true;

            Context.Entry(entities).State = EntityState.Modified;

            return result;
        }

        //public bool UpdateNotSave(T entity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
