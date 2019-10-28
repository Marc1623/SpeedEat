using DataTransferObject;
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

        public List<Cities> GetAllHotels()
        {
            List<Cities> results = null;
            string ConnectionStrings = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionStrings))
                {
                    string query = "SELECT * from Hotels";
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
                            cities.Zip_Code = (int)dr["Description"];
                            cities.Country = (String)dr["Location"];
                            cities.Created_at = (String)dr["Category"]; 

                            results.Add(hotel);
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

                            if (dr["IdHotel"] != null)
                                cities.IdCities = (int)dr["IdCities"];

                            if (dr["Name"] != null)
                                hotel.Name = (string)dr["Name"];

                            if (dr["Description"] != null)
                                hotel.Description = (string)dr["Description"];

                            if (dr["Location"] != null)
                                hotel.Location = (string)dr["Location"];

                            if (dr["Category"] != null)
                                hotel.Category = (int)dr["Category"];

                            if (dr["HasWifi"] != null)
                                hotel.HasWifi = (bool)dr["HasWifi"];

                            if (dr["HasParking"] != null)
                                hotel.HasParking = (bool)dr["HasParking"];

                            if (dr["Phone"] != null)
                                hotel.Phone = (string)dr["Phone"];

                            if (dr["Email"] != null)
                                hotel.Email = (string)dr["Email"];

                            if (dr["Website"] != null)
                                hotel.Website = (string)dr["Website"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return hotel;
        }

        public Hotel AddHotel(Hotel hotel)
        {


            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Hotels(Name, Description, Location, Category, HasWifi, HasParking, Phone, Email, Website) values(@Name, @Description, @Location, @Category, @HasWifi, @HasParking, @Phone, @Email, @Website); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Name", hotel.Name);
                    cmd.Parameters.AddWithValue("@Description", hotel.Description);
                    cmd.Parameters.AddWithValue("@Location", hotel.Location);
                    cmd.Parameters.AddWithValue("@Category", hotel.Category);
                    cmd.Parameters.AddWithValue("@HasWifi", hotel.HasWifi);
                    cmd.Parameters.AddWithValue("@HasParking", hotel.HasParking);
                    cmd.Parameters.AddWithValue("@Phone", hotel.Phone);
                    cmd.Parameters.AddWithValue("@Email", hotel.Email);
                    cmd.Parameters.AddWithValue("@Website", hotel.Website);

                    cn.Open();

                    hotel.IdHotel = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return hotel;
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            int result = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Hotels SET Name = @Name, Description = @Description, Location = @Location, Category = @Category, HasWifi = @HasWifi, HasParking = @HasParking, Phone = @Phone, Email = @Email, Website = @Website WHERE IdHotel = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", hotel.IdHotel);
                    cmd.Parameters.AddWithValue("@Name", hotel.Name);
                    cmd.Parameters.AddWithValue("@Description", hotel.Description);
                    cmd.Parameters.AddWithValue("@Location", hotel.Location);
                    cmd.Parameters.AddWithValue("@Category", hotel.Category);
                    cmd.Parameters.AddWithValue("@HasWifi", hotel.HasWifi);
                    cmd.Parameters.AddWithValue("@HasParking", hotel.HasParking);
                    cmd.Parameters.AddWithValue("@Phone", hotel.Phone);
                    cmd.Parameters.AddWithValue("@Email", hotel.Email);
                    cmd.Parameters.AddWithValue("@Website", hotel.Website);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return hotel;
        }

        public int DeleteHotel(int id)
        {
            int result = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE from Hotels where IdHotel = @id";
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

