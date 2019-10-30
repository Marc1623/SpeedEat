using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Dishes
    {
        public int IdDishes { get; set; }

        public string DishesName { get; set; }

        public string DishesDescription { get; set; }

        public float DishesPrice { get; set; }

        public int DishesStatus { get; set; }

        public string DishesCreated_At { get; set; }

        public int DishesFk_Id_Restaurants { get; set; }


        public override string ToString()
        {
            return $"{IdDishes}|{DishesName}|{DishesDescription}|{DishesPrice}|{DishesStatus}|{DishesCreated_At}|{DishesFk_Id_Restaurants}";
        }
    }
}
