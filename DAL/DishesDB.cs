using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace DAL
{
    public class DishesDB : IDishesDB
    {
        public IConfiguration Configuration { get; }
        public DishesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Dishes> GetAllDishes(int id)
        {
            List<Dishes> results = null;
            string ConnectionStrings = Configuration.GetConnectionString("DefaultConnection");
            //test
            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionStrings))
                {
                    string query = "SELECT * from Dishes WHERE DishesFk_Id_Restaurants = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@id", id);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Dishes>();

                            Dishes dishes = new Dishes();

                            dishes.IdDishes = (int)dr["IdDishes"];
                            dishes.DishesName = (string)dr["DishesName"];
                            dishes.DishesDescription = (string)dr["DishesDescription"];
                            dishes.DishesPrice = (double)dr["DishesPrice"];
                            dishes.DishesStatus = (int)dr["DishesStatus"];
                            dishes.DishesCreated_At = (DateTime)dr["DishesCreated_At"];
                            dishes.DishesFk_Id_Restaurants = (int)dr["DishesFk_Id_Restaurants"];

                            results.Add(dishes);
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

        public Dishes GetDishes(int id)
        {
            Dishes dishes = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Dishes where IdDishes = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            dishes = new Dishes();

                            if (dr["IdDishes"] != null)
                                dishes.IdDishes = (int)dr["IdDishes"];

                            if (dr["DishesName"] != null)
                                dishes.DishesName = (string)dr["DishesName"];

                            if (dr["DishesDescription"] != null)
                                dishes.DishesDescription = (string)dr["DishesDescription"];

                            if (dr["DishesPrice"] != null)
                                dishes.DishesPrice = (double)dr["DishesPrice"];

                            if (dr["DishesStatus"] != null)
                                dishes.DishesStatus = (int)dr["DishesStatus"];

                            if (dr["DishesCreated_At"] != null)
                                dishes.DishesCreated_At = (DateTime)dr["DishesCreated_At"];

                            if (dr["DishesFk_Id_Restaurants"] != null)
                                dishes.DishesFk_Id_Restaurants = (int)dr["DishesFk_Id_Restaurants"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dishes;
        }

        public Dishes AddDishes(Dishes dishes)
        {


            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Dishes(DishesName, DishesDescription, DishesPrice, DishesStatus, DishesCreated_At, DishesFk_Id_Restaurants) values(@DishesName, @DishesDescription, @DishesPrice, @DishesStatus, @DishesCreated_At, @DishesFk_Id_Restaurants); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@DishesName", dishes.DishesName);
                    cmd.Parameters.AddWithValue("@DishesDescription", dishes.DishesDescription);
                    cmd.Parameters.AddWithValue("@DishesPrice", dishes.DishesPrice);
                    cmd.Parameters.AddWithValue("@DishesStatus", dishes.DishesStatus);
                    cmd.Parameters.AddWithValue("@DishesCreated_At", dishes.DishesCreated_At);
                    cmd.Parameters.AddWithValue("@DishesFk_Id_Restaurants", dishes.DishesFk_Id_Restaurants);

                    cn.Open();

                    dishes.IdDishes = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dishes;
        }

        public Dishes UpdateDishes(Dishes dishes)
        {
            int result = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Dishes SET DishesName = @DishesName, DishesDescription = @DishesDescription, DishesPrice = @DishesPrice, DishesStatus = @DishesStatus, DishesCreated_At = @DishesCreated_At, DishesFk_Id_Restaurants = @DishesFk_Id_Restaurants WHERE IdDishes = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@DishesName", dishes.DishesName);
                    cmd.Parameters.AddWithValue("@DishesDescription", dishes.DishesDescription);
                    cmd.Parameters.AddWithValue("@DishesPrice", dishes.DishesPrice);
                    cmd.Parameters.AddWithValue("@DishesStatus", dishes.DishesStatus);
                    cmd.Parameters.AddWithValue("@DishesCreated_At", dishes.DishesCreated_At);
                    cmd.Parameters.AddWithValue("@DishesFk_Id_Restaurants", dishes.DishesFk_Id_Restaurants);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dishes;
        }

        public int DeleteDishes(int id)
        {
            int result = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE from Dishes where IdDishes = @id";
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
        }
    }

}
