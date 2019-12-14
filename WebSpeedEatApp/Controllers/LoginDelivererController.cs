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
        public IActionResult Index2(Deliverer deliverer)
        {
            DelivererManager delivererManager = new DelivererManager(Configuration);
            int IdCustomers = delivererManager.GetIdDeliverer(deliverer.Login);
            string PassCustomers = delivererManager.GetPassDeliverer(IdCustomers, deliverer.Login);
            if (deliverer.Password == PassCustomers)
            {
                HttpContext.Session.SetInt32("IdCustomer", IdCustomers);
                return RedirectToAction("GetAllCitiesDeliverer", "City");
            }
            else
            {
                return View();
            }
        }
    }
}