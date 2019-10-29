using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface ICustomersManager
    {

        ICustomersDB CustomersDB { get; }

        List<Deliverer> GetAllCustomers();

        Deliverer GetCustomers(int id);

        Deliverer AddCustomers(Deliverer customers);

        Deliverer UpdateCustomers(Deliverer customers);

        int DeleteCustomers(int id);
    }

}
