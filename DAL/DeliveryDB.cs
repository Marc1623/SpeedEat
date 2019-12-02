using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace DAL
{
    public class DeliveryDB : IDeliveryDB
    {
        public IConfiguration Configuration { get; }
        public DeliveryDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Delivery> GetAllDelivery()
        {
            List<Delivery> results = null;
            string ConnectionStrings = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionStrings))
                {
                    string query = "SELECT * from Delivery";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Delivery>();

                            Delivery deliverey = new Delivery();

                            deliverey.IdDelivery = (int)dr["IdCustomers"];
                            deliverey.Start_Time = (String)dr["Start_Time"];
                            deliverey.End_Time = (String)dr["End_Time"];
                            deliverey.Created_At = (String)dr["Created_At"];
                            deliverey.Fk_Id_Deliverer = (int)dr["Fk_Id_Dliverer"];

                            results.Add(deliverey);
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

        public Delivery GetDelivery(int id)
        {
            Delivery deliverey = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Delivery where IdDelivery = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            deliverey = new Delivery();

                            if (dr["IdDelivery"] != null)
                                deliverey.IdDelivery = (int)dr["IdDelivery"];

                            if (dr["Start_Time"] != null)
                                deliverey.Start_Time = (string)dr["Start_Time"];

                            if (dr["End_Time"] != null)
                                deliverey.End_Time = (string)dr["End_Time"];

                            if (dr["Created_At"] != null)
                                deliverey.Created_At = (string)dr["Created_At"];

                            if (dr["Fk_Id_Delivery"] != null)
                                deliverey.Fk_Id_Deliverer = (int)dr["Fk_Id_Delivery"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return deliverey;
        }

        public Delivery AddDelivery(Delivery delivery)
        {


            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Delivery(Start_Time, End_Time, Created_At, Fk_Id_Deliverer) values(@Start_Time, @End_Time, @Created_At, @Fk_Id_Deliverer); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@FirstName", delivery.Start_Time);
                    cmd.Parameters.AddWithValue("@LastName", delivery.End_Time);
                    cmd.Parameters.AddWithValue("@Phone_Number", delivery.Created_At);
                    cmd.Parameters.AddWithValue("@Address", delivery.Fk_Id_Deliverer);
                    

                    cn.Open();

                    delivery.IdDelivery = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return delivery;
        }

        public Delivery UpdateDelivery(Delivery delivery)
        {
            int result = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Delivery SET Start_Time = @Start_Time, End_Time = @End_Time, Created_At = @Created_At, Fk_Id_Deliverer = @Fk_Id_Deliverer WHERE IdDelivery = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Start_Time", delivery.Start_Time);
                    cmd.Parameters.AddWithValue("@End_Time", delivery.End_Time);
                    cmd.Parameters.AddWithValue("@Created_At", delivery.Created_At);
                    cmd.Parameters.AddWithValue("@Fk_Id_Deliverer", delivery.Fk_Id_Deliverer);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return delivery;
        }

        public int DeleteDelivery(int id)
        {
            int result = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE from Delivery where IdDelivery = @id";
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
