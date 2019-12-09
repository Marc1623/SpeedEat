using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace BLL
{
    public interface ILoginManager
    {
        bool IsUserValid(Login l);
    }
}
