using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebSpeedEatApp.Models;

namespace WebSpeedEatApp.Models
{
    public class Orders_Dishes
    {
        [Required]
        public int IdOders_Dishes { get; set; }
        [Required]
        public int Oders_DishesQuantity { get; set; }
        [Required]
        public string Oders_DishesCreated_At { get; set; }
        [Required]
        public int Oders_DishesFk_Id_Orders { get; set; }
        [Required]
        public int Oders_DishesFk_Id_Dishes { get; set; }
    }
}
