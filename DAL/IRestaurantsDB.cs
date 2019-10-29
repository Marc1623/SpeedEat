using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL
{
    public interface IRestaurantsDB
    {

        IConfiguration Configuration { get; }
        List<Restaurants> GetAllRestaurants();
        Restaurants GetRestaurants(int id);
        Restaurants AddRestaurants(Restaurants restaurants);
        Restaurants UpdateHotel(Restaurants restaurants);
        int DeleteRestaurants(int id);

    }
}

