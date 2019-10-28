using DataTransferObject;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL
{
    public interface ICitiesDB
    {
        IConfiguration Configuration { get; }
        List<C> GetAllHotels();
        CitiesDB GetHotel(int id);
        CitiesDB AddHotel(CitiesDB cities );
        CitiesDB UpdateHotel(CitiesDB cities);
        int DeleteHotel(int id);
    }

}