using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IOrders_DishesDB
    {
        IConfiguration Configuration { get; }
        List<Orders_Dishes> GetAllOrders_Dishes();
        Orders_Dishes GetOrders_Dishes(int id);
        Orders_Dishes AddOrders_Dishes(Orders_Dishes orders_Dishes);
        Orders_Dishes UpdateOrders_Dishes(Orders_Dishes orders_Dishes);
        int DeleteOrders_Dishes(int id);
    }
}
