using DTO;
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

        public List<Deliverer> GetAllCustomers()
        {
            List<Deliverer> results = null;
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
                                results = new List<Deliverer>();

                            Deliverer customers = new Deliverer();

                            customers.IdCustomers = (int)dr["IdCustomers"];
                            customers.FirstName = (String)dr["FirstName"];
                            customers.LastName = (String)dr["LastName"];
                            customers.Phone_Number = (String)dr["Phone_Number"];
                            customers.Address = (String)dr["Address"];
                            customers.Login = (String)dr["Login"];
                            customers.Password = (String)dr["Password"];
                            customers.Created_At = (String)dr["Created_At"];
                            customers.Fk_Id_Cities = (int)dr["Fk_Id_Cities"];

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

        public Deliverer GetCustomers(int id)
        {
            Deliverer customers = null;
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
                            customers = new Deliverer();

                            if (dr["IdHotel"] != null)
                                customers.IdCustomers = (int)dr["IdCustomers"];

                            if (dr["Name"] != null)
                                customers.FirstName = (string)dr["Name"];

                            if (dr["LastName"] != null)
                                customers.LastName = (string)dr["LastName"];

                            if (dr["Phone_Number"] != null)
                                customers.Phone_Number = (string)dr["Phone_Number"];

                            if (dr["Address"] != null)
                                customers.Address = (string)dr["Address"];

                            if (dr["Login"] != null)
                                customers.Login = (string)dr["Login"];

                            if (dr["Password"] != null)
                                customers.Password = (string)dr["Password"];

                            if (dr["Created_At"] != null)
                                customers.Created_At = (string)dr["Created_At"];

                            if (dr["Fk_Id_Cities"] != null)
                                customers.Fk_Id_Cities = (int)dr["Fk_Id_Cities"];

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

        public Deliverer AddCustomers(Deliverer customers)
        {


            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Customers(FirstName, LastName, Phone_Number, Address, Login, Password, Created_At, Fk_Id_Cities) values(@FirstName, @LastName, @Phone_Number, @Address, @Login, @Password, @Created_At, @Fk_Id_Cities); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@FirstName", customers.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", customers.LastName);
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
                    cmd.Parameters.AddWithValue("@FirstName", customers.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", customers.LastName);
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
