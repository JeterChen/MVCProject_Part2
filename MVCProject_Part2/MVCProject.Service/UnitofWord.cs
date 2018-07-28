using MVCProject.Data.Entity;
using MVCProject.Service.IRepository;
using MVCProject.Service.Repository;
using System;

namespace MVCProject.Service
{
    public class UnitofWord : IDisposable
    {
        #region Fields
        public readonly NORTHWNDEntities Context = new NORTHWNDEntities();
        private IBaseRepository<Customers> _customerRepository;//BaseRepository<Customers> _customerRepository;
        #endregion

        #region Constructors and Destructors

        public IBaseRepository<Customers> CustomersRepository
        {
            get
            {
                if (this._customerRepository == null)
                    this._customerRepository = new BaseRepository<Customers>(Context);
                return _customerRepository;
            }
        }

        #endregion

        #region Public Methods and Operators

        public void Save()
        {
            Context.SaveChanges();
        }

        #endregion

        #region Dispose

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
