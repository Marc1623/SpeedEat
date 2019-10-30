﻿using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace DAL
{
    public class CustomersDB : ICustomersDB
    {
        public IConfiguration Configuration { get; }
        public CustomersDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Customers> GetAllCustomers()
        {
            List<Customers> results = null;
            string ConnectionStrings = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionStrings))
                {
                    string query = "SELECT * from Customers";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Customers>();

                            Customers customers = new Customers();

                            customers.IdCustomers = (int)dr["IdCustomers"];
                            customers.CustomerstName = (String)dr["CustomerstName"];
                            customers.CustomersLastName = (String)dr["CustomersLastName"];
                            customers.CustomersPhone = (String)dr["CustomersPhone"];
                            customers.CustomersAddress = (String)dr["CustomersAddress"];
                            customers.CustomersLogin = (String)dr["CustomersLogin"];
                            customers.CustomersPassword = (String)dr["CustomersPassword"];
                            customers.CustomersCreated_At = (String)dr["CustomersCreated_At"];
                            customers.CustomersFk_Id_Cities = (int)dr["CustomersFk_Id_Cities"];

                            results.Add(customers);
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

        public Customers GetCustomers(int id)
        {
            Customers customers = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Customers where IdCustomers = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            customers = new Customers();

                            if (dr["IdHotel"] != null)
                                customers.IdCustomers = (int)dr["IdCustomers"];

                            if (dr["Name"] != null)
                                customers.CustomerstName = (string)dr["CustomersName"];

                            if (dr["LastName"] != null)
                                customers.CustomersLastName = (string)dr["LastName"];

                            if (dr["Phone_Number"] != null)
                                customers.CustomersPhone = (string)dr["Phone_Number"];

                            if (dr["Address"] != null)
                                customers.CustomersAddress = (string)dr["Address"];

                            if (dr["Login"] != null)
                                customers.CustomersLogin = (string)dr["Login"];

                            if (dr["Password"] != null)
                                customers.CustomersPassword = (string)dr["Password"];

                            if (dr["Created_At"] != null)
                                customers.CustomersCreated_At = (string)dr["Created_At"];

                            if (dr["Fk_Id_Cities"] != null)
                                customers.CustomersFk_Id_Cities = (int)dr["Fk_Id_Cities"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return customers;
        }

        public Customers AddCustomers(Customers customers)
        {


            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Customers(CustomersName, CustomersLastName, CustomersPhone, CustomersAddress, CustomersLogin, CustomersPassword, CustomersCreated_At, CustomersFk_Id_Cities) values(@CustomersName, @CustomersLastName, @CustomersPhone, @CustomersAddress, @CustomersLogin, @CustomersPassword, @CustomersCreated_At, @CustomersFk_Id_Cities); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@CustomersName", customers.CustomerstName);
                    cmd.Parameters.AddWithValue("@CustomersLastName", customers.CustomersLastName);
                    cmd.Parameters.AddWithValue("@CustomersPhone", customers.CustomersPhone);
                    cmd.Parameters.AddWithValue("@CustomersAddress", customers.CustomersAddress);
                    cmd.Parameters.AddWithValue("@CustomersLogin", customers.CustomersLogin);
                    cmd.Parameters.AddWithValue("@CustomersPassword", customers.CustomersPassword);
                    cmd.Parameters.AddWithValue("@CustomersCreated_At", customers.CustomersCreated_At);
                    cmd.Parameters.AddWithValue("@CustomersFk_Id_Cities", customers.CustomersFk_Id_Cities);

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

        public Customers UpdateCustomers(Customers customers)
        {
            int result = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Customers SET CustomersName = @CustomersName, CustomersLastName = @CustomersLastName, CustomersPhone = @CustomersPhone, CustomersAddress = @CustomersAddress, CustomersLogin = @CustomersLogin, CustomersPassword = @CustomersPassword, CustomersCreated_At = @CustomersCreated_At, CustomersFk_Id_Cities = @CustomersFk_Id_Cities WHERE IdCustomers = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@CustomersName", customers.CustomerstName);
                    cmd.Parameters.AddWithValue("@CustomersLastName", customers.CustomersLastName);
                    cmd.Parameters.AddWithValue("@CustomersPhone", customers.CustomersPhone);
                    cmd.Parameters.AddWithValue("@CustomersAddress", customers.CustomersAddress);
                    cmd.Parameters.AddWithValue("@CustomersLogin", customers.CustomersLogin);
                    cmd.Parameters.AddWithValue("@CustomersPassword", customers.CustomersPassword);
                    cmd.Parameters.AddWithValue("@CustomersCreated_At", customers.CustomersCreated_At);
                    cmd.Parameters.AddWithValue("@CustomersFk_Id_Cities", customers.CustomersFk_Id_Cities);

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