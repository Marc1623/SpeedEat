﻿using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL
{
    public interface IDeliveryDB
    {
        IConfiguration Configuration { get; }
        List<Delivery> GetAllDelivery();
        Delivery GetDelivery(int id);
        Delivery AddDelivery(Delivery delivery);
        Delivery UpdateDelivery(Delivery delivery);
        int DeleteDelivery(int id);
    }

}