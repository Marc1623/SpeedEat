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

        /*
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Login l)
        {
            bool isValid = LoginManager.IsUserValid(l);
            if (isValid)
            {
                HttpContext.Session.SetString("Username", l.Username);
                return RedirectToAction("GetAllCities", "City");
            }
            else
            {
                return View();
            }
        }
        */

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

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
    }
}