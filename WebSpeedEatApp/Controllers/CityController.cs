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

        //Get all the cities if the user is valid 
        public ActionResult GetAllCities([FromQuery(Name = "isValid")] string Valid, [FromQuery(Name = "user")] string user)
        {
            CitiesManager citiesM = new CitiesManager(Configuration);
            
            var cities = citiesM.GetAllCities();
            ViewBag.isValid = Valid;
            ViewBag.user = user;
            return View(cities);
        }
        //Get all the cities for deliverer if the Deliverer is valid 
        public ActionResult GetAllCitiesDeliverer([FromQuery(Name = "isValid")] string Valid, [FromQuery(Name = "user")] string user)
        {
            CitiesManager citiesM = new CitiesManager(Configuration);

            var cities = citiesM.GetAllCitiesDeliverer();
            ViewBag.isValid = Valid;
            ViewBag.user = user;
            return View(cities);
        }
        //Get all restaurant when you clic on Select
        public ActionResult Select(int id)
        {
            RestaurantsManager restaurantsManager = new RestaurantsManager(Configuration); 
            return View(restaurantsManager.GetAllRestaurants(id));
        }
        //Get all Dishes when you clic on Choose
        public ActionResult Choose(int id)

        {
            DishesManager dishesManager = new DishesManager(Configuration);
            return View(dishesManager.GetAllDishes(id));
        }
        //Get all Orders_Dishes when you clic on Take
        public ActionResult Take(int id)
        {
            Orders_DishesManager orders_DishesManager = new Orders_DishesManager(Configuration);
            return View(orders_DishesManager.GetAllOrders_Dishes(id));
        }
        //Get all customer when you clic on Go to show the customer infos for Deliverer
        public ActionResult GO(int id)
        {
            CustomersManager customersManager = new CustomersManager(Configuration);
            return View(customersManager.GetAllCustomers(id));
        }

    }
}