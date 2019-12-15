using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;

namespace BLL
{
    public class Orders_DishesManager 
    {

        public IOrders_DishesDB Orders_DishesDB { get; }

        public Orders_DishesManager(IConfiguration configuration)
        {
            Orders_DishesDB = new Orders_DishesDB(configuration);
        }

        public List<Orders_Dishes> GetAllOrders_Dishes(int id)
        {
            return Orders_DishesDB.GetAllOrders_Dishes(id);
        }

        public Orders_Dishes GetOrders_Dishes(int id)
        {
            return Orders_DishesDB.GetOrders_Dishes(id);
        }

        public Orders_Dishes AddOrders_Dishes(Orders_Dishes orders_Dishes)
        {
            return Orders_DishesDB.AddOrders_Dishes(orders_Dishes);
        }

       

      
    }
}
