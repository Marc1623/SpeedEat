using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Microsoft.Extensions.Configuration;
using DTO;


namespace BLL
{
    public class RestaurantsManager : IRestaurantsManager
    {

        public IRestaurantsDB RestaurantsDB { get; }

        public RestaurantsManager(IConfiguration configuration)
        {
            RestaurantsDB = new RestaurantsDB(configuration);
        }

        public List<Restaurants> GetAllRestaurants(int id)
        {
            return RestaurantsDB.GetAllRestaurants(id);
        }

        public Restaurants GetRestaurants(int id)
        {
            return RestaurantsDB.GetRestaurants(id);
        }

       /* public Restaurants AddRestaurants(Restaurants restaurants)
        {
            return RestaurantsDB.AddRestaurants(restaurants);
        }

        public Restaurants UpdateRestaurants(Restaurants restaurants)
        {
            return RestaurantsDB.UpdateRestaurants(restaurants);
        }

        public int DeleteRestaurants(int id)
        {
            return RestaurantsDB.DeleteRestaurants(id);
        }*/
    }
}