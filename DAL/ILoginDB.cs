using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface ILoginDB
    {
        bool IsUserValid(Login l);
    }
}
