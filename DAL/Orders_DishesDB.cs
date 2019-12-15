using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class Orders_DishesDB : IOrders_DishesDB
    {
        public IConfiguration Configuration { get; }
        public Orders_DishesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Orders_Dishes> GetAllOrders_Dishes(int id)
        {
            List<Orders_Dishes> results = null;
            string ConnectionStrings = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionStrings))
                {
                    string query = "SELECT * from Orders_Dishes WHERE Fk_Id_Cities = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Orders_Dishes>();

                            Orders_Dishes orders_Dishes = new Orders_Dishes();

                            orders_Dishes.IdOders_Dishes = (int)dr["IdOders_Dishes"];
                            orders_Dishes.Oders_DishesQuantity = (int)dr["Oders_DishesQuantity"];
                            orders_Dishes.Oders_DishesCreated_At = (String)dr["Oders_DishesCreated_At"];
                            orders_Dishes.Oders_DishesFk_Id_Orders = (int)dr["Oders_DishesFk_Id_Orders"];
                            orders_Dishes.Oders_DishesFk_Id_Dishes = (int)dr["Oders_DishesFk_Id_Dishes"];
                            orders_Dishes.Fk_Id_Cities = (int)dr["Fk_Id_Cities"];
                            orders_Dishes.Fk_Id_Customers = (int)dr["Fk_Id_Customers"];


                            results.Add(orders_Dishes);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return results;
        }

        public Orders_Dishes GetOrders_Dishes(int id)
        {
            Orders_Dishes orders_Dishes = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Orders_Dishes where IdOders_Dishes = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            orders_Dishes = new Orders_Dishes();

                            if (dr["IdOders_Dishes"] != null)
                                orders_Dishes.IdOders_Dishes = (int)dr["IdOders_Dishes"];

                            if (dr["Oders_DishesQuantity"] != null)
                                orders_Dishes.Oders_DishesQuantity = (int)dr["Oders_DishesQuantity"];

                            if (dr["Oders_DishesCreated_At"] != null)
                                orders_Dishes.Oders_DishesCreated_At = (string)dr["Oders_DishesCreated_At"];

                            if (dr["Oders_DishesFk_Id_Orders"] != null)
                                orders_Dishes.Oders_DishesFk_Id_Orders = (int)dr["Oders_DishesFk_Id_Orders"];

                            if (dr["Oders_DishesFk_Id_Dishes"] != null)
                                orders_Dishes.Oders_DishesFk_Id_Dishes = (int)dr["Oders_DishesFk_Id_Dishes"];



                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return orders_Dishes;
        }

        public Orders_Dishes AddOrders_Dishes(Orders_Dishes orders_Dishes)
        {


            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Orders_Dishes( Oders_DishesQuantity, Oders_DishesCreated_At, Oders_DishesFk_Id_Orders, Oders_DishesFk_Id_Dishes, Fk_Id_Cities) values(@Oders_DishesQuantity, @Oders_DishesCreated_At, @Oders_DishesFk_Id_Orders, @Oders_DishesFk_Id_Dishes); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@Oders_DishesQuantity", orders_Dishes.Oders_DishesQuantity);
                    cmd.Parameters.AddWithValue("@Oders_DishesCreated_At", orders_Dishes.Oders_DishesCreated_At);
                    cmd.Parameters.AddWithValue("@Oders_DishesFk_Id_Orders", orders_Dishes.Oders_DishesFk_Id_Orders);
                    cmd.Parameters.AddWithValue("@Oders_DishesFk_Id_Dishes", orders_Dishes.Oders_DishesFk_Id_Dishes);
                   


                    cn.Open();

                    orders_Dishes.IdOders_Dishes = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return orders_Dishes;
        }

        /*public Orders_Dishes UpdateOrders_Dishes(Orders_Dishes orders_Dishes)
        {

            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Orders_Dishes SET Oders_DishesQuantity = @Oders_DishesQuantity, Oders_DishesCreated_At = @Oders_DishesCreated_At, Oders_DishesFk_Id_Orders = @Oders_DishesFk_Id_Orders, Oders_DishesFk_Id_Dishes = @Oders_DishesFk_Id_Dishes WHERE IdOders_Dishes = @IdOders_Dishes";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdOders_Dishes", orders_Dishes.IdOders_Dishes);
                    cmd.Parameters.AddWithValue("@Oders_DishesQuantity", orders_Dishes.Oders_DishesQuantity);
                    cmd.Parameters.AddWithValue("@Oders_DishesCreated_At", orders_Dishes.Oders_DishesCreated_At);
                    cmd.Parameters.AddWithValue("@Oders_DishesFk_Id_Orders", orders_Dishes.Oders_DishesFk_Id_Orders);
                    cmd.Parameters.AddWithValue("@Oders_DishesFk_Id_Dishes", orders_Dishes.Oders_DishesFk_Id_Dishes);


                    cn.Open();

                    result = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return orders_Dishes;
        }


        public int DeleteOrders_Dishes(int id)
        {
            int result = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE from Orders_Dishes where IdOders_Dishes = @IdOders_Dishes";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);


                    cn.Open();

                    result = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }*/

        


    }
}

