using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL
{
    public interface IDeliveryDB
    {
        IConfiguration Configuration { get; }
        List<Deliverer> GetAllDelivery();
        Deliverer GetDelivery(int id);
        Deliverer AddDelivery(Deliverer delivery);
        Deliverer UpdateDelivery(Deliverer delivery);
        int DeleteDelivery(int id);
    }

}