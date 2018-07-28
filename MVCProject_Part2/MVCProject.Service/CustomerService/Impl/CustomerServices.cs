using MVCProject.Data.Entity;
using MVCProject.Infrastructure;
using MVCProject.Model;
using MVCProject.Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.Service.CustomerService
{

    public class CustomerServices : BaseDomainService, ICustomerServices
    {
        //Old Code
        //private UnitofWord _unitOfWork;

        private ICustomerRepository customerRepository;

        public CustomerServices(IUnitOfWork uok, 
            ICustomerRepository _customerRepository)
            :base(uok)
        {
            this.customerRepository = _customerRepository;
        }

        public int AddNew(CustomerVO vo)
        {
            Customers customers = customerRepository.Find(c => c.CustomerID == vo.CustomerID)
                    .FirstOrDefault();

            if (customers == null) // add new
            {
                Customers add = AutoMapper.Mapper.Map<Customers>(vo);
                customerRepository.Add(add);
                uok.Commit();

                return 1;
            }
            else //edit
            {

                AutoMapper.Mapper.Map(vo, customers);

                customerRepository.Update(customers);

                uok.Commit();

                return 2;
            }
        }

        public bool CheckCustomerId(string CustomerId)
        {
            var check = customerRepository.Find(c => c.CustomerID.Equals(CustomerId)).FirstOrDefault();
            if (check != null)
                return true;
            return false;
        }

        //Old Code
        //public CustomerServices(UnitofWord unitOfWork)
        //{
        //    this._unitOfWork = unitOfWork;
        //}

        public int Count()
        {
            return customerRepository.Find(c => c.CustomerID == "1").Count();

            //Old Code
            //return _unitOfWork.CustomersRepository.CountInt(c => c.CustomerID == "1");
        }

        public void Delete(string CustomerId)
        {
            var delobj = customerRepository.Find(c => c.CustomerID == CustomerId).FirstOrDefault();
            customerRepository.Remove(delobj);
            uok.Commit();

        }

        public CustomerVO FindbyId(string CustomerID)
        {
            CustomerVO vo = new CustomerVO();

            var result = customerRepository.Find(c => c.CustomerID == CustomerID).FirstOrDefault();

            //Old Code
            //var result = _unitOfWork.CustomersRepository.Get(c => c.CustomerID == CustomerID);

            //var  vo = AutoMapper.Mapper.Map<CustomerVO>(result);

            vo.CustomerID = result.CustomerID;
            vo.Country = result.Country;
            vo.ContactTitle = result.ContactTitle;
            vo.ContactName = result.ContactName;
            vo.CompanyName = result.CompanyName;
            vo.Phone = result.Phone;
            vo.PostalCode = result.PostalCode;
            vo.Region = result.Region;
            vo.Fax = result.Fax;
            vo.Address = result.Address;
            vo.City = result.City;

            return vo;
        }

        public IEnumerable<CustomerVO> GetAll()
        {
            //List<CustomerVO> list = new List<CustomerVO>();

            //var result = customerRepository.GetCustomerWithOrders(1, 4);

            //Old Code 
            //var result = _unitOfWork.CustomersRepository.GetAll();

            IEnumerable<Customers> result = customerRepository.GetAll();
            
            //foreach (var c in result)
            //{
            //    list.Add(new CustomerVO()
            //    {
            //        CustomerID = c.CustomerID,
            //        Country = c.Country,
            //        ContactTitle = c.ContactTitle,
            //        ContactName = c.ContactName,
            //        CompanyName = c.CompanyName,
            //        Phone = c.Phone,
            //        PostalCode = c.PostalCode,
            //        Region = c.Region,
            //        Fax = c.Fax,
            //        Address = c.Address,
            //        City = c.City,
            //    });
            //}

            var list = AutoMapper.Mapper.Map<IEnumerable<CustomerVO>>(result);

            return list;
        }

        //public void Save()
        //{
        //    uok.Commit();
        //}
    }
}
