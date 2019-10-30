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

        public List<Deliverer> GetAllDelivery()
        {
            List<Deliverer> results = null;
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
                                results = new List<Deliverer>();

                            Deliverer delivery = new Deliverer();

                            delivery.IdDelivery = (int)dr["IdCustomers"];
                            delivery.Start_Time = (String)dr["Start_Time"];
                            delivery.End_Time = (String)dr["End_Time"];
                            delivery.Created_At = (String)dr["Created_At"];
                            delivery.Fk_Id_Dliverer = (int)dr["Fk_Id_Dliverer"];

                            results.Add(delivery);
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

        public Deliverer GetDelivery(int id)
        {
            Deliverer delivery = null;
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
                            delivery = new Deliverer();

                            if (dr["IdHotel"] != null)
                                delivery.IdDelivery = (int)dr["IdDelivery"];

                            if (dr["Name"] != null)
                                delivery.Start_Time = (string)dr["Start_Time"];

                            if (dr["LastName"] != null)
                                delivery.End_Time = (string)dr["End_Time"];

                            if (dr["Created_At"] != null)
                                delivery.Created_At = (string)dr["Created_At"];

                            if (dr["Fk_Id_Cities"] != null)
                                delivery.Fk_Id_Dliverer = (int)dr["Fk_Id_Dliverer"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return delivery;
        }

        public Deliverer AddCustomers(Deliverer customers)
        {


            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Customers(FirstName, LastName, Phone_Number, Address, Login, Password, Created_At, Fk_Id_Cities) values(@FirstName, @LastName, @Phone_Number, @Address, @Login, @Password, @Created_At, @Fk_Id_Cities); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@FirstName", customers.Start_Time);
                    cmd.Parameters.AddWithValue("@LastName", customers.End_Time);
                    cmd.Parameters.AddWithValue("@Phone_Number", customers.Phone_Number);
                    cmd.Parameters.AddWithValue("@Address", customers.Address);
                    cmd.Parameters.AddWithValue("@Login", customers.Login);
                    cmd.Parameters.AddWithValue("@Password", customers.Password);
                    cmd.Parameters.AddWithValue("@Created_At", customers.Created_At);
                    cmd.Parameters.AddWithValue("@Fk_Id_Cities", customers.Fk_Id_Cities);

                    cn.Open();

                    customers.IdCustomers = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return customers;
        }

        public Deliverer UpdateCustomers(Deliverer customers)
        {
            int result = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, Phone_Number = @Phone_Number, Address = @Address, Login = @Login, Password = @Password, Created_At = @Created_At, Fk_Id_Cities = @Fk_Id_Cities WHERE IdCustomers = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@FirstName", customers.Start_Time);
                    cmd.Parameters.AddWithValue("@LastName", customers.End_Time);
                    cmd.Parameters.AddWithValue("@Phone_Number", customers.Phone_Number);
                    cmd.Parameters.AddWithValue("@Address", customers.Address);
                    cmd.Parameters.AddWithValue("@Login", customers.Login);
                    cmd.Parameters.AddWithValue("@Password", customers.Password);
                    cmd.Parameters.AddWithValue("@Created_At", customers.Created_At);
                    cmd.Parameters.AddWithValue("@Fk_Id_Cities", customers.Fk_Id_Cities);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return customers;
        }

        public int DeleteCustomers(int id)
        {
            int result = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE from Customers where IdCustomers = @id";
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
