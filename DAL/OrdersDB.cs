using DataTransferObject;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace DAL
{
    public class OrdersDB : IOrdersDB
    {
        public IConfiguration Configuration { get; }
        public OrdersDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Orders> GetAllOrder()
        {
            List<Orders> results = null;
            string ConnectionStrings = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionStrings))
                {
                    string query = "SELECT * from Orders";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Orders>();

                            Orders orders = new Orders();

                            orders.IdOrders = (int)dr["IdOrders"];
                            orders.OrdersStatus = (int)dr["OrdersStatus"];
                            orders.OrdersCreated_At = (String)dr["OrdersCreated_At"];
                            orders.OrdersFk_Id_Delivery = (int)dr["OrdersFk_Id_Delivery"];

                            results.Add(orders);
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

        public Orders GetOrders(int id)
        {
            Orders orders = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Orders where IdOrders = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            orders = new Orders();

                            if (dr["IdHotel"] != null)
                                orders.IdOrders = (int)dr["IdOrders"];

                            if (dr["Name"] != null)
                                orders.OrdersStatus = (int)dr["OrdersStatus"];

                            if (dr["Description"] != null)
                                orders.OrdersCreated_At = (string)dr["OrdersCreated_At"];

                            if (dr["Location"] != null)
                                orders.OrdersFk_Id_Delivery = (int)dr["OrdersFk_Id_Delivery"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return orders;
        }

        public Orders AddOrders(Orders orders)
        {


            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Orders(OrdersStatus, OrdersCreated_At, OrdersFk_Id_Delivery) values(@OrdersStatus, @OrdersCreated_At, @OrdersFk_Id_Delivery); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Name", orders.OrdersStatus);
                    cmd.Parameters.AddWithValue("@Description", orders.OrdersCreated_At);
                    cmd.Parameters.AddWithValue("@Location", orders.OrdersFk_Id_Delivery);
               

                    cn.Open();

                    orders.IdOrders = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return orders;
        }

        public Orders UpdateOrders(Orders orders)
        {
            int result = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Hotels SET OrdersStatus = @OrdersStatus, OrdersCreated_At = @OrdersCreated_At, OrdersFk_Id_Delivery = @OrdersFk_Id_Delivery WHERE IdHotel = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Id", orders.IdOrders);
                    cmd.Parameters.AddWithValue("@OrdersStatus", orders.OrdersStatus);
                    cmd.Parameters.AddWithValue("@OrdersCreated_At", orders.OrdersCreated_At);
                    cmd.Parameters.AddWithValue("@OrdersFk_Id_Delivery", orders.OrdersFk_Id_Delivery);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return orders;
        }

        public int DeleteOrders(int id)
        {
            int result = 0;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE from Orders where IdOrders = @id";
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
