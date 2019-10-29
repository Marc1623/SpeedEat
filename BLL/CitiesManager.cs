using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using DTO;

namespace BLL
{
    public class CitiesManager
    {

        public ICitiesDB CitiesDB { get; }

        public CitiesManager(IConfiguration configuration)
        {
            CitiesDB = new CitiesDB(configuration);
        }

        public List<Cities> GetAllCities()
        {
            return CitiesDB.GetAllCities();
        }

        public Cities GetCities(int id)
        {
            return CitiesDB.GetCities(id);
        }
        public int DeleteCities(int id)
        {
            return CitiesDB.DeleteCities(id);
        }
    }
}