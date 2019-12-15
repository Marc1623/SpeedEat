using System;

namespace DTO
{
    public class Customers

    {
        public int IdCustomers { get; set; }

        public string CustomersName { get; set; }

        public string CustomersLastName { get; set; }

        public string CustomersPhone { get; set; }

        public string CustomersAddress { get; set; }
        public string CustomersCity { get; set; }
        public string CustomersZip { get; set; }

        public string CustomersLogin { get; set; }

        public string CustomersPassword { get; set; }

        public string CustomersCreated_At { get; set; }

        public int CustomersFk_Id_Cities { get; set; }

        public int Fk_Id_Oders_Dishes { get; set; }

        public override string ToString()
        {
            return $"{IdCustomers}|{CustomersName}|{CustomersLastName}|{CustomersPhone}|{CustomersAddress}|{CustomersCity}|{CustomersZip}|{CustomersLogin}|{CustomersPassword}|{CustomersCreated_At}|{CustomersFk_Id_Cities}|{Fk_Id_Oders_Dishes}";
        }
    }
}