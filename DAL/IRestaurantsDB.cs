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
        List<Restaurants> GetAllRestaurants(int id);
        Restaurants GetRestaurants(int id);


    }
}

