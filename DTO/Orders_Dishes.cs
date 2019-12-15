using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Orders_Dishes
    {
        public int IdOders_Dishes { get; set; }

        public int Oders_DishesQuantity { get; set; }

        public string Oders_DishesCreated_At { get; set; }

        public int Oders_DishesFk_Id_Orders { get; set; }

        public int Oders_DishesFk_Id_Dishes { get; set; }

        public int Fk_Id_Cities { get; set; }
        public int Fk_Id_Customers { get; set; }

        public override string ToString()
        {
            return $"{IdOders_Dishes}|{Oders_DishesQuantity}|{Oders_DishesCreated_At}|{Oders_DishesFk_Id_Orders}|{Oders_DishesFk_Id_Dishes}|{Fk_Id_Cities}||{Fk_Id_Customers}";
        }
    }
}
