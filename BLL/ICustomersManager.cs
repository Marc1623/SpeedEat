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

        List<Customers> GetAllCustomers();

        Customers GetCustomers(int id);

        Customers AddCustomers(Customers customers);

        Customers UpdateCustomers(Customers customers);

        int DeleteCustomers(int id);

        bool IsUserValid(Customers l);
    }

}
