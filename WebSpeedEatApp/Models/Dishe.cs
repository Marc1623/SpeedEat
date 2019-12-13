using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSpeedEatApp.Models
{


    public partial class Dishe
    {
        /*public Dishes()
        {
            this.Dishes_Order = new HashSet<Dishes_Order>();
        }*/

        public int IdDishes { get; set; }
        public string DishesName { get; set; }
        public string DishesDescription { get; set; }
        public int DishesPrice { get; set; }
        public string status { get; set; }
        public int DishesFk_Id_Restaurants { get; set; }


        // public virtual ICollection<dishes_order> dishes_order { get; set; }
        //  public virtual restaurants restaurants { get; set; }
    }
}