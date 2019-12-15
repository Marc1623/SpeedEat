using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebSpeedEatApp.Models;

namespace WebSpeedEatApp.Models
{
    public class AddDishes
    {

        SqlConnection con = new SqlConnection("Server=153.109.124.35;Database=Kohl_Vial_Projet;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=true");
        public string AddDishesRecord(Orders_Dishes orders_Dishes)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Orders_Add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdOders_Dishes", orders_Dishes.IdOders_Dishes);
                cmd.Parameters.AddWithValue("@Oders_DishesQuantity", orders_Dishes.Oders_DishesQuantity);
                cmd.Parameters.AddWithValue("@Oders_DishesCreated_At", orders_Dishes.Oders_DishesCreated_At);
                cmd.Parameters.AddWithValue("@Oders_DishesFk_Id_Orders", orders_Dishes.Oders_DishesFk_Id_Orders);
                cmd.Parameters.AddWithValue("@Oders_DishesFk_Id_Dishes", orders_Dishes.Oders_DishesFk_Id_Dishes);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }
    }
}
