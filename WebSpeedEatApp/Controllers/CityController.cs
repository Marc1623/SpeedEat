using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using Microsoft.Extensions.Configuration;

namespace WebSpeedEatApp.Controllers
{
    public class CityController : Controller
    {
       
        //private ICitiesManager CitiesManager { get; }
        private IConfiguration Configuration { get; }
        public CityController (IConfiguration configuration)
        {
            Configuration = configuration;
        }



        // GET: City
        public ActionResult index()
        {
            return View();
        }

        public ActionResult GetAllCities([FromQuery(Name = "isValid")] string Valid, [FromQuery(Name = "user")] string user)
        {
            CitiesManager citiesM = new CitiesManager(Configuration);
            
            var cities = citiesM.GetAllCities();
            ViewBag.isValid = Valid;
            ViewBag.user = user;
            return View(cities);
        }

        // GET: City/Details/5

        public ActionResult Select(int id)
        {
            RestaurantsManager restaurantsManager = new RestaurantsManager(Configuration); 
            return View(restaurantsManager.GetAllRestaurants(id));
        }

        public ActionResult Choose(int id)

        {
            DishesManager dishesManager = new DishesManager(Configuration);
            return View(dishesManager.GetAllDishes(id));
        }
        
        /*public ActionResult GetAllDelivery(int id)
        {
            DeliveryManager deliveryManager = new DeliveryManager(Configuration);
            return View(deliveryManager.GetAllDelivery(id));
        }
        */

       
    }
}