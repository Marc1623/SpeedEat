﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Deliverer
    {
        public int IdDeliverer { get; set; }

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
            return $"{IdDeliverer}|{FirstName}|{LastName}|{Phone_Number}|{Address}|{Login}|{Password}|{Created_At}|{Fk_Id_Cities}";
        }
    }
}