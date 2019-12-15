using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;

namespace WebSpeedEatApp.Models
{
    // model use to show all the dishes and the quantity
    public class Item
    {
        public Dishes Dishe { get; set; }

        public int Quantity { get; set; }
    }

}
