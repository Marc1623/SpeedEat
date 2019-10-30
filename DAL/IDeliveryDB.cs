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
        List<Deliverey> GetAllDelivery();
        Deliverey GetDelivery(int id);
        Deliverey AddDelivery(Deliverey delivery);
        Deliverey UpdateDelivery(Deliverey delivery);
        int DeleteDelivery(int id);
    }

}