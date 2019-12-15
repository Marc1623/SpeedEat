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
    public class RestaurantsController : Controller
    {

        private IConfiguration Configuration { get; }
        public RestaurantsController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // GET: Restaurants
        public ActionResult Index()
        {
            return View();
        }

        
        //show a list of restaurants 
        public ActionResult GetAllRestaurants(int id)
        {
            RestaurantsManager restaurantsManager = new RestaurantsManager(Configuration);
            return View(restaurantsManager.GetAllRestaurants(id));
            
        }

        

    }
}