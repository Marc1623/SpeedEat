using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;

namespace WebSpeedEatApp.Controllers
{
    public class DishesController : Controller
    {

        private IDishesManager DishesManager { get; }

        public DishesController (IDishesManager dishesManager)
        {
            DishesManager = dishesManager;
        }
        // GET: Dishes
        public ActionResult Index()
        {
            return View();
        }

        // GET: Dishes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        //show all dishes where the id is the same as the fk id for restaurants
        public ActionResult GetAllDishes(int id)
        {
            var dishes = DishesManager.GetAllDishes(id);
            return View(dishes);
        }

     
    }
}