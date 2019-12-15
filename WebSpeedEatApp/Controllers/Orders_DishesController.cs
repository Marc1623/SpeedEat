using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSpeedEatApp.Models;

namespace WebSpeedEatApp.Controllers
{
    public class Orders_DishesController : Controller
    {
        AddDishes addDishes = new AddDishes();

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //should save the Orders in the orders dishes tab 
        [HttpPost]
        public IActionResult Create([Bind] Orders_Dishes orders_Dishes)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resp = addDishes.AddDishesRecord(orders_Dishes);
                    TempData["msg"] = resp;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }
    }
}
