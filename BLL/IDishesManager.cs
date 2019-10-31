using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IDishesManager
    {

        IDishesDB DishesDB { get; }

        List<Dishes> GetAllDishes();

        Dishes GetDishes(int id);

        Dishes AddDishes(Dishes dishes);

        Dishes UpdateDishes(Dishes dishes);

        int DeleteDishes(int id);
    }

}

