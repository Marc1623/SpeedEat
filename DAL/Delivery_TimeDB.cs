using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
        public class Delivery_TimeDB : IDelivery_TimeDB
        {
            public IConfiguration Configuration { get; }
            public Delivery_TimeDB(IConfiguration configuration)
            {
                Configuration = configuration;
            }

        public List<Delivery_Time> GetAllTime()
        {
            List<Delivery_Time> results = null;
            string ConnectionStrings = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionStrings))
                {
                    string query = "SELECT * from Delivery_Time";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Delivery_Time>();

                            Delivery_Time delivery_Time = new Delivery_Time();

                            delivery_Time.Id = (int)dr["Id"];
                            delivery_Time.Time_Zone = (string)dr["Time_Zone"];
                            delivery_Time.Created_At = (string)dr["Created_At"];
                      

                            results.Add(delivery_Time);
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
