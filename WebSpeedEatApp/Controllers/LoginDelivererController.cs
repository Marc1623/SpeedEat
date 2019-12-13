using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO;
using BLL;
using Microsoft.Extensions.Configuration;

namespace WebSpeedEatApp.Controllers
{
    public class LoginDelivererController : Controller
    {
        private IConfiguration Configuration { get; }
        public LoginDelivererController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // GET: LoginDeliverer
        [HttpGet]
        public IActionResult Index2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index2(Customers customers)
        {
            DelivererManager delivererManager = new DelivererManager(Configuration);
            int IdCustomers = delivererManager.GetIdDeliverer(customers.CustomersLogin);
            string PassCustomers = delivererManager.GetPassDeliverer(IdCustomers, customers.CustomersLogin);
            if (customers.CustomersPassword == PassCustomers)
            {
                HttpContext.Session.SetInt32("IdCustomer", IdCustomers);
                return RedirectToAction("GetAllCities", "City");
            }
            else
            {
                return View();
            }
        }
    }
}