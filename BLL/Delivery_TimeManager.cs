using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Microsoft.Extensions.Configuration;
using DTO;


namespace BLL
{
    public class Delivery_TimeManager : IDelivery_TimeManager
    {
        public IDelivery_TimeDB Delivery_TimeDB { get; }

        public Delivery_TimeManager(IConfiguration configuration)
        {
            Delivery_TimeDB = new Delivery_TimeDB(configuration);
        }

        public List<Delivery_Time> GetAllTime()
        {
            return Delivery_TimeDB.GetAllTime();
        }
    }
}
