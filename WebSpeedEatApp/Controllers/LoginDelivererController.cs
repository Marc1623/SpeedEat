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
    public class LoginDelivererController : Controller
    {
        private ILoginManager LoginDelivererManager { get; }
        public LoginDelivererController(ILoginManager loginManager)
        {
            LoginDelivererManager = loginManager;
        }
        // GET: LoginDeliverer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Login l)
        {
            bool isValid = LoginDelivererManager.IsUserValid(l);
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
    }
}