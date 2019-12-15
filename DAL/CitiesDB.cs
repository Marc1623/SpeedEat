using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace DAL
{
    public class CitiesDB : ICitiesDB
    {
        public IConfiguration Configuration { get; }
        public CitiesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //get all the city to show for the customers
        public List<Cities> GetAllCities()
        {
            List<Cities> results = null;
            string ConnectionStrings = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionStrings))
                {
                    string query = "SELECT * from Cities";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Cities>();

                            Cities cities = new Cities();

                            cities.IdCity = (int)dr["IdCity"];
                            cities.Name = (String)dr["Name"];
                            cities.Zip_Code = (int)dr["Zip_Code"];
                            cities.Country = (String)dr["Country"];
                            cities.Created_At = (String)dr["Created_At"]; 

                            results.Add(cities);
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

        //get all the city to show for the deliverer
        public List<Cities> GetAllCitiesDeliverer()
        {
            List<Cities> results = null;
            string ConnectionStrings = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionStrings))
                {
                    string query = "SELECT * from Cities";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Cities>();

                            Cities cities = new Cities();

                            cities.IdCity = (int)dr["IdCity"];
                            cities.Name = (String)dr["Name"];
                            cities.Zip_Code = (int)dr["Zip_Code"];
                            cities.Country = (String)dr["Country"];
                            cities.Created_At = (String)dr["Created_At"];

                            results.Add(cities);
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

    }

}

