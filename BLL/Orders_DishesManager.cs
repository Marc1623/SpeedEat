using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Microsoft.Extensions.Configuration;
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

        public List<Orders_DishesDB> GetAllOrders_Dishes()
        {
            return Orders_DishesDB.GetAllOrders_Dishes();
        }

        public Orders_DishesDB GetOrders_Dishes(int id)
        {
            return Orders_DishesDB.GetOrders_Dishes(id);
        }

        public Orders_DishesDB AddOrders_Dishes(Orders_DishesDB orders_Dishes)
        {
            return Orders_DishesDB.AddOrders_Dishes(orders_Dishes);
        }

        public Orders_DishesDB UpdateOrders_Dishes(Orders_DishesDB orders_Dishes)
        {
            return Orders_DishesDB.UpdateOrders_Dishes(orders_Dishes);
        }

        public int DeleteOrders_Dishes(int id)
        {
            return Orders_DishesDB.DeleteOrders_Dishes(id);
        }
    }
}
