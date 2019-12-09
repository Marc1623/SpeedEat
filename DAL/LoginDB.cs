using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public class LoginDB : ILoginDB
    {


        public LoginDB()
        {

        }
        public bool IsUserValid(Login l)
        {
            // add sql statement to get user data from DB
            return true;
        }
    }
}
