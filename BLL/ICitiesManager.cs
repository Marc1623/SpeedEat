using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface ICitiesManager
    {

        ICitiesDB CitiesDB { get; }

        List<Cities> GetAllCities();

        List<Cities> GetAllCitiesDeliverer();

      //  Cities GetCities(int id);

       // int DeleteCities(int id);
    }

}
