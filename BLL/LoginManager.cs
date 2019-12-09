using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL;

namespace BLL
{
    public class LoginManager : ILoginManager
    {
        public ILoginDB LoginDbObject { get; }

        public LoginManager(ILoginDB loginDB)
        {
            LoginDbObject = loginDB;
        }

        public bool IsUserValid(Login l)
        {
            return LoginDbObject.IsUserValid(l);
        }
    }
}
