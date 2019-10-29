using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using DTO;

namespace BLL
{
    public class CustomersManager
    {

        public ICustomersDB CustomersDB { get; }

        public CustomersManager(IConfiguration configuration)
        {
            CustomersDB = new CustomersDB(configuration);
        }

        public List<Deliverer> GetAllCustomers()
        {
            return CustomersDB.GetAllCustomers();
        }

        public Deliverer GetCustomers(int id)
        {
            return CustomersDB.GetCustomers(id);
        }

        public Deliverer AddCustomers(Deliverer customers)
        {
            return CustomersDB.AddCustomers(customers);
        }

        public Deliverer UpdateCustomers(Deliverer customers)
        {
            return CustomersDB.UpdateCustomers(customers);
        }

        public int DeleteCustomers(int id)
        {
            return CustomersDB.DeleteCustomers(id);
        }
    }
}
