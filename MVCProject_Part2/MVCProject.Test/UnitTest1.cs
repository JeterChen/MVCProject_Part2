using System;
using System.Collections.Generic;
using Autofac;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCProject.Model;
using MVCProject.Service.CustomerService;

namespace MVCProject.Test
{
    [TestClass]
    public class UnitTest1 : BaseTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var lifeScope = TesterContainer.GetContainer.BeginLifetimeScope())
            {
                var srv = lifeScope.Resolve<ICustomerServices>();
                //List<CustomersA> list = new List<CustomersA>();

                var result = srv.GetAll();

                var list = Mapper.Map<IEnumerable<CustomerVO>>(result);

                //foreach (var a in result)
                //{
                //    list.Add(new CustomersA()
                //    {
                //        CName = a.CompanyName,
                //        CustomerID = a.CustomerID
                //    });
                //}

                Assert.IsNotNull(list);
            }
        }

        [TestMethod]
        public void TestAdd()
        {
            using(var lifeScope = TesterContainer.GetContainer.BeginLifetimeScope())
            {
                var srv = lifeScope.Resolve<ICustomerServices>();
                //CustomerVO NewVo = new CustomerVO
                //{
                //    CustomerID = "AF123",
                //    CompanyName = "WWW.MyBaseBallTeam.com",
                //    Phone = "213456789",
                //    City = "taipei"
                //};
                //srv.AddNew(NewVo);
                string customerId = "AF123";

                var  qvo = srv.FindbyId(customerId);

                Assert.IsNotNull(qvo);
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            using(var lifeScope = TesterContainer.GetContainer.BeginLifetimeScope())
            {
                string id = "ALFKI";

                string expected = "Alfreds Futterkiste";
                string actual = string.Empty;

                var srv = lifeScope.Resolve<ICustomerServices>();

                var data = srv.FindbyId(id);

                actual = data.CompanyName;

                Assert.AreEqual(expected, actual);
            }
        }

        //[TestMethod]
        //public void TestMethod3()
        //{
        //    //Arrange(傳入參數)
        //        string id = "ALFKI";
        //        string actual = string.Empty;
        //    var actual = new Customers() { id=2};

        //    //Act(要測試的函式)
        //    ICustomerServices srv =  Mock<CustomerServices>();
             
        //        var data = srv.FindbyId(id)
        //                      .return(actual);

        //    //Assert(預期的結果)
        //        string expected = new CustomersA { CustomerID=1 };
        //    expected.toEqual(actual)
      
          
        //}
    }

   
}
