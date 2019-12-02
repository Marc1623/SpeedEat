using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Microsoft.Extensions.Configuration;
using DataTransferObject;

namespace BLL
{
    public class OrdersManager
    {

        public IOrdersDB OrdersDB { get; }

        public OrdersManager(IConfiguration configuration)
        {
            OrdersDB = new OrdersDB(configuration);
        }

        public List<Orders> GetAllOrders()
        {
            return OrdersDB.GetAllOrder();
        }

        public Orders GetOrders(int id)
        {
            return OrdersDB.GetOrders(id);
        }

        public Orders AddOrders(Orders orders)
        {
            return OrdersDB.AddOrders(orders);
        }

        public Orders UpdateOrders(Orders orders)
        {
            return OrdersDB.UpdateOrders(orders);
        }

        public int DeleteOrders(int id)
        {
            return OrdersDB.DeleteOrders(id);
        }
    }
}

