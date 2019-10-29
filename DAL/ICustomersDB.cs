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
        List<Deliverer> GetAllCustomers();
        Deliverer GetCustomers(int id);
        Deliverer AddCustomers(Deliverer customers);
        Deliverer UpdateCustomers(Deliverer customers);
        int DeleteCustomers(int id);
    }

}