using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IOrders_DishesManager
    {

        IOrders_DishesDB Orders_DishesDB { get; }

        List<Orders_Dishes> GetAllOrders_Dishes();

        Orders_Dishes GetOrders_Dishes(int id);
        Orders_Dishes GetOrders_DishesQuantity(int id);

        Orders_Dishes AddOrders_Dishes(Orders_Dishes orders_Dishes);

        Orders_Dishes UpdateOrders_Dishes(Orders_Dishes Orders_Dishes);

        int DeleteOrders_Dishes(int id);
    }

}
