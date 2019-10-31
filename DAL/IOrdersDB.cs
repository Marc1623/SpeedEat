using DataTransferObject;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL
{
    public interface IOrdersDB
    {
        IConfiguration Configuration { get; }
        List<Orders> GetAllOrder();
        Orders GetOrders(int id);
        Orders AddOrders(Orders orders);
        Orders UpdateOrders(Orders orders);
        int DeleteOrders(int id);
    }

}
