using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSpeedEatApp.Models
{

    //same information as in the DTO
    public partial class Dishe
    {
     

        public int IdDishes { get; set; }
        public string DishesName { get; set; }
        public string DishesDescription { get; set; }
        public int DishesPrice { get; set; }
        public string status { get; set; }
        public int DishesFk_Id_Restaurants { get; set; }


        
    }
}