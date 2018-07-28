using MVCProject.Service.CustomerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerServices _customerServices;

        public HomeController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        public ActionResult Index()
        {
            ViewBag.GetAll = _customerServices.GetAll();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}