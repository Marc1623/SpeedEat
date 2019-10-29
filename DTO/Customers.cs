﻿using System;

namespace DTO
{
    public class Customers

    {
        public int IdCustomers { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone_Number { get; set; }

        public string Address { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Created_At { get; set; }

        public int Fk_Id_Cities { get; set; }

        public override string ToString()
        {
            return $"{IdCustomers}|{FirstName}|{LastName}|{Phone_Number}|{Address}|{Login}|{Password}|{Created_At}|{Fk_Id_Cities}";
        }
    }
}