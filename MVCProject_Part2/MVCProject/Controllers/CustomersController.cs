using MVCProject.Model;
using MVCProject.Service.CustomerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerServices _customerServices;

        public CustomersController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Addnew(CustomerVO vo)
        {
            return Json(_customerServices.AddNew(vo), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllCustomers()
        {
            return Json(_customerServices.GetAll(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(string CustomerId)
        {
            _customerServices.Delete(CustomerId);
            return Json("true", JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckCustomerId(string CustomerId)
        {
            return Json(_customerServices.CheckCustomerId(CustomerId), JsonRequestBehavior.AllowGet);
        }
    }
}