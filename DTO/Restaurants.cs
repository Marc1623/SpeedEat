using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Restaurants
    {
        public int IdRestaurant { get; set; }

        public string Restaurant_Name { get; set; }

        public string Adress { get; set; }

        public string Phone { get; set; }

        public string Created_At { get; set; }

        public int Fk_Id_Cities { get; set; }



        public override string ToString()
        {
            return $"{IdRestaurant}|{Restaurant_Name}|{Adress}|{Phone}|{Created_At}|{Fk_Id_Cities}";
        }
    }
}
