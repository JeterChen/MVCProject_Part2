using MVCProject.Data.Entity;
using MVCProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.Service.CustomerService
{
    public interface ICustomerServices
    {
        int Count();

        CustomerVO FindbyId(string CustomerID);


        IEnumerable<CustomerVO> GetAll();


        //void Save();

        int AddNew(CustomerVO vo);

        void Delete(string CustomerId);

        bool CheckCustomerId(string CustomerId);
    }
}
