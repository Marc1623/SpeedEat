using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Microsoft.Extensions.Configuration;

using DTO;

namespace BLL
{
    public class DishesManager
    {

        public IDishesDB DishesDB { get; }

        public DishesManager(IConfiguration configuration)
        {
            DishesDB = new DishesDB(configuration);
        }

        public List<Dishes> GetAllDishes()
        {
            return DishesDB.GetAllDishes();
        }

        public Dishes GetDishes(int id)
        {
            return DishesDB.GetDishes(id);
        }

        public Dishes AddDishes(Dishes dishes)
        {
            return DishesDB.AddDishes(dishes);
        }

        public Dishes UpdateDishes(Dishes dishes)
        {
            return DishesDB.UpdateDishes(dishes);
        }

        public int DeleteDishes(int id)
        {
            return DishesDB.DeleteDishes(id);
        }
    }
}
