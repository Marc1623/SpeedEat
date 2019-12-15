using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace DAL
{
    public class DelivererDB : IDelivererDB
    {
        public IConfiguration Configuration { get; }
        public DelivererDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Deliverer> GetAllDeliverer()
        {
            List<Deliverer> results = null;
            string ConnectionStrings = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionStrings))
                {
                    string query = "SELECT * from Deliverer";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Deliverer>();

                            Deliverer deliverer = new Deliverer();

                            deliverer.IdDeliverer = (int)dr["IdDeliverer"];
                            deliverer.FirstName = (String)dr["FirstName"];
                            deliverer.LastName = (String)dr["LastName"];
                            deliverer.Phone_Number = (String)dr["Phone_Number"];
                            deliverer.Address = (String)dr["Address"];
                            deliverer.Login = (String)dr["Login"];
                            deliverer.Password = (String)dr["Password"];
                            deliverer.DelivererCreated_At = (String)dr["Created_At"];
                            deliverer.Fk_Id_Cities = (int)dr["Fk_Id_Cities"];

                            results.Add(deliverer);
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
        public int GetIdDeliverer(string login)
        {
            int idCustomer = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select IdDeliverer from Deliverer where Login = @login";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("login", login);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            idCustomer = (int)dr["IdDeliverer"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return idCustomer;
        }

        public string GetPassDeliverer(int id, string login)
        {
            string password = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select Password from Deliverer where IdDeliverer = @id and Login = @pass";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@pass", login);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            password = (string)dr["Password"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return password;
        }

        public Deliverer GetDeliverer(int id)
        {
            Deliverer deliverer = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Deliverer where IdDeliverer = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            deliverer = new Deliverer();

                            if (dr["IdDeliverer"] != null)
                                deliverer.IdDeliverer = (int)dr["IdDeliverer"];

                            if (dr["FirstName"] != null)
                                deliverer.FirstName = (string)dr["FirstName"];

                            if (dr["LastName"] != null)
                                deliverer.LastName = (string)dr["LastName"];

                            if (dr["Phone_Number"] != null)
                                deliverer.Phone_Number = (string)dr["Phone_Number"];

                            if (dr["Address"] != null)
                                deliverer.Address = (string)dr["Address"];

                            if (dr["Login"] != null)
                                deliverer.Login = (string)dr["Login"];

                            if (dr["Password"] != null)
                                deliverer.Password = (string)dr["Password"];

                            if (dr["DelivererCreated_At"] != null)
                                deliverer.DelivererCreated_At = (string)dr["DelivererCreated_At"];

                            if (dr["Fk_Id_Cities"] != null)
                                deliverer.Fk_Id_Cities = (int)dr["Fk_Id_Cities"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return deliverer;
        }

        /*public Deliverer AddDeliverer(Deliverer deliverer)
        {


            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Deliverer(FirstName, LastName, Phone_Number, Address, Login, Password, Created_At, Fk_Id_Cities) values(@FirstName, @LastName, @Phone_Number, @Address, @Login, @Password, @Created_At, @Fk_Id_Cities); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@FirstName", deliverer.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", deliverer.LastName);
                    cmd.Parameters.AddWithValue("@Phone_Number", deliverer.Phone_Number);
                    cmd.Parameters.AddWithValue("@Address", deliverer.Address);
                    cmd.Parameters.AddWithValue("@Login", deliverer.Login);
                    cmd.Parameters.AddWithValue("@Password", deliverer.Password);
                    cmd.Parameters.AddWithValue("@Created_At", deliverer.DelivererCreated_At);
                    cmd.Parameters.AddWithValue("@Fk_Id_Cities", deliverer.Fk_Id_Cities);

                    cn.Open();

                    deliverer.IdDeliverer = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return deliverer;
        }

        public Deliverer UpdateDeliverer(Deliverer deliverer)
        {
            int result = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Deliverer SET FirstName = @FirstName, LastName = @LastName, Phone_Number = @Phone_Number, Address = @Address, Login = @Login, Password = @Password, Created_At = @Created_At, Fk_Id_Cities = @Fk_Id_Cities WHERE IdDeliverer = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@FirstName", deliverer.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", deliverer.LastName);
                    cmd.Parameters.AddWithValue("@Phone_Number", deliverer.Phone_Number);
                    cmd.Parameters.AddWithValue("@Address", deliverer.Address);
                    cmd.Parameters.AddWithValue("@Login", deliverer.Login);
                    cmd.Parameters.AddWithValue("@Password", deliverer.Password);
                    cmd.Parameters.AddWithValue("@Created_At", deliverer.DelivererCreated_At);
                    cmd.Parameters.AddWithValue("@Fk_Id_Cities", deliverer.Fk_Id_Cities);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return deliverer;
        }

        public int DeleteDeliverer(int id)
        {
            int result = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE from Deliverer where IdDeliverer = @id";
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
        }*/
    }

}
