using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;

namespace BLL
{
    public interface IOrdersManager
    {

        IOrdersDB OrdersDB { get; }

        List<Orders> GetAllOrders();

        Orders GetOrders(int id);

        Orders AddOrders(Orders orders);

        Orders UpdateOrders(Orders orders);

        int DeleteOrders(int id);
    }

}
