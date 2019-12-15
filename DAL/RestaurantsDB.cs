using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class RestaurantsDB : IRestaurantsDB
    {
        public IConfiguration Configuration { get; }
        public RestaurantsDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //list every restaurants from every city
        public List<Restaurants> GetAllRestaurants(int id)
        {
            List<Restaurants> results = null;
            string ConnectionStrings = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionStrings))
                {
                    string query = "SELECT * FROM Restaurants WHERE Fk_Id_Cities = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Restaurants>();

                            Restaurants restaurants = new Restaurants();

                            restaurants.IdRestaurant = (int)dr["IdRestaurant"];
                            restaurants.Restaurant_Name = (string)dr["Restaurant_Name"];
                            restaurants.Adress = (string)dr["Adress"];
                            restaurants.Phone = (string)dr["Phone"];
                            restaurants.Created_At = (string)dr["Created_At"];
                            restaurants.Fk_Id_Cities = (int)dr["Fk_Id_Cities"];

                            results.Add(restaurants);
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

        public Restaurants GetRestaurants(int id)
        {
            Restaurants restaurants = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Restaurants where IdRestaurant = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            restaurants = new Restaurants();

                            if (dr["IdRestaurant"] != null)
                                restaurants.IdRestaurant = (int)dr["IdRestaurant"];

                            if (dr["Restaurant_Name"] != null)
                                restaurants.Restaurant_Name = (string)dr["Restaurant_Name"];

                            if (dr["Adress"] != null)
                                restaurants.Adress = (string)dr["Adress"];

                            if (dr["Phone"] != null)
                                restaurants.Phone = (string)dr["Phone"];

                            if (dr["Created_At"] != null)
                                restaurants.Created_At = (string)dr["Created_At"];

                            if (dr["Fk_Id_Cities"] != null)
                                restaurants.Fk_Id_Cities = (int)dr["Fk_Id_Cities"];


                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restaurants;
        }


    }
}