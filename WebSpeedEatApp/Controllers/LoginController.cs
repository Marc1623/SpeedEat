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
    public class LoginController : Controller
    {
        private IConfiguration Configuration { get; }
        public LoginController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

      
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //test if the username is correct and the password is the same in the DB
        // if yes it show a list of city
        [HttpPost]
        public IActionResult Index(Customers customers)
        {
            CustomersManager customersManager = new CustomersManager(Configuration);
            int IdCustomers = customersManager.GetIdCustomers(customers.CustomersLogin);
            string PassCustomers = customersManager.GetPassCustomers(IdCustomers, customers.CustomersLogin);
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

        // show the same login but for the Deliverer
        public ActionResult Index2()
        {
            return RedirectToAction("Index2", "LoginDeliverer");
        }
    }
}