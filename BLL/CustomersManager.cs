using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Microsoft.Extensions.Configuration;
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

        public List<Customers> GetAllCustomers()
        {
            return CustomersDB.GetAllCustomers();
        }

        public int GetIdCustomers(string login)
        {
            return CustomersDB.GetIdCustomers(login);
        }

        public string GetPassCustomers(int id, string login)
        {
            return CustomersDB.GetPassCustomers(id,login);
        }

        public Customers GetCustomers(int id)
        {
            return CustomersDB.GetCustomers(id);
        }

        public Customers AddCustomers(Customers customers)
        {
            return CustomersDB.AddCustomers(customers);
        }

        public Customers UpdateCustomers(Customers customers)
        {
            return CustomersDB.UpdateCustomers(customers);
        }

        public int DeleteCustomers(int id)
        {
            return CustomersDB.DeleteCustomers(id);
        }

        public ICustomersDB LoginDbObject { get; }


        public CustomersManager(ICustomersDB customersDB)
        {
            LoginDbObject = customersDB;
        }

        public bool IsUserValid(Customers l)
        {
            return LoginDbObject.IsUserValid(l);
        }
    }
}
