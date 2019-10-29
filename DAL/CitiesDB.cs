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

        public Cities GetCities(int id)
        {
            Cities cities = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Cities where IdCities = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            cities = new Cities();

                            if (dr["IdCities"] != null)
                                cities.IdCity = (int)dr["IdCities"];

                            if (dr["Name"] != null)
                                cities.Name = (string)dr["Name"];

                            if (dr["Zip_Code"] != null)
                                cities.Zip_Code = (int)dr["Zip_Code"];

                            if (dr["Country"] != null)
                                cities.Country = (string)dr["Country"];

                            if (dr["Created_At"] != null)
                                cities.Created_At = (string)dr["Created_At"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return cities;
        }

        public Cities AddCities(Cities cities)
        {


            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Cities(Name, Zip_Code, Country, Created_At) values(@Name, @Zip_Code, @Country, @Created_At); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Name", cities.Name);
                    cmd.Parameters.AddWithValue("@Zip_Code", cities.Zip_Code);
                    cmd.Parameters.AddWithValue("@Country", cities.Country);
                    cmd.Parameters.AddWithValue("@Created_At", cities.Created_At);

                    cn.Open();

                    cities.IdCity = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return cities;
        }


        public int DeleteCities(int id)
        {
            int result = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE from Cities where IdCities = @id";
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

