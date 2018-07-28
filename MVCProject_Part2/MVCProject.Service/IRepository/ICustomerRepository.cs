using MVCProject.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.Service.IRepository
{
    public interface ICustomerRepository : INewRepository<Customers>
    {
        IEnumerable<Customers> GetCustomerWithOrders(int pageIndex, int pageSize);
    }
}
