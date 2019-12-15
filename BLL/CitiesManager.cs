using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Microsoft.Extensions.Configuration;

using DTO;

namespace BLL
{
    public class CitiesManager : ICitiesManager
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

        public List<Cities> GetAllCitiesDeliverer()
        {
            return CitiesDB.GetAllCitiesDeliverer();
        }

       
    }
}