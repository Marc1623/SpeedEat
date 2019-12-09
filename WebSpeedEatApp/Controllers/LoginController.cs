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
        private ILoginManager LoginManager { get; }
        public LoginController(ILoginManager loginManager)
        {
            LoginManager = loginManager;
        }

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
                return RedirectToAction("GetCities", "City", new { isValid = isValid, user = "Antoine" });
            }
            else
            {
                return View();
            }
        }
    }
}