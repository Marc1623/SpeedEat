﻿using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL
{
    public interface IDelivererDB
    {
        IConfiguration Configuration { get; }
        List<Deliverer> GetAllDeliverer();
        Deliverer GetDeliverer(int id);
    
        int GetIdDeliverer(string login);
        string GetPassDeliverer(int id, string login);
       
    }

}