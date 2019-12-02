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

        Cities GetCities(int id);

        int DeleteCities(int id);
    }

}
