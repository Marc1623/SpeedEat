using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL
{
    public interface ICustomersDB
    {
        IConfiguration Configuration { get; }
        List<Customers> GetAllCustomers();
        Customers GetCustomers(int id);
        Customers AddCustomers(Customers customers);
        Customers UpdateCustomers(Customers customers);
        bool IsUserValid(Customers l);
        int DeleteCustomers(int id);
    }

}