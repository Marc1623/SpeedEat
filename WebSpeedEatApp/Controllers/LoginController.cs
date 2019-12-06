using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO;
using BLL;

namespace WebSpeedEatApp.Controllers
{
   public class LoginController : Controller
    {
        private ICustomersManager CustomersManager { get; }
        public LoginController(ICustomersManager customersManager)
        {
            CustomersManager = customersManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Customers l)
        {
            bool isValid = CustomersManager.IsUserValid(l);
            if (isValid)
            {
                HttpContext.Session.SetString("Username", l.CustomersLogin);
                return RedirectToAction("GetCities", "Cities", new { isValid = isValid, user = "Antoine" });
            }
            else
            {
                return View();
            }
        }
    }
}