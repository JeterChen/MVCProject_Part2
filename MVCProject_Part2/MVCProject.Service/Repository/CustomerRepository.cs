using MVCProject.Data.Entity;
using MVCProject.Infrastructure;
using MVCProject.Service.IRepository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MVCProject.Service.Repository
{
    public class CustomerRepository : NewRepository<Customers>, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork uok)
         : base(uok) { }

        public IEnumerable<Customers> GetCustomerWithOrders(int pageIndex, int pageSize)
        {
            return NORTHWNDContext.Customers
                .Include(c => c.Orders)
                .OrderBy(c => c.CompanyName)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public NORTHWNDEntities NORTHWNDContext
        {
            get { return Context as NORTHWNDEntities; }
        }
    }
}
