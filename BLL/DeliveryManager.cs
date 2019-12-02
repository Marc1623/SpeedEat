using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Microsoft.Extensions.Configuration;
using DTO;

namespace BLL
{
    public class DeliveryManager
    {

        public IDeliveryDB DeliveryDB { get; }

        public DeliveryManager(IConfiguration configuration)
        {
            DeliveryDB = new DeliveryDB(configuration);
        }

        public List<Delivery> GetAllDelivery()
        {
            return DeliveryDB.GetAllDelivery();
        }

        public Delivery GetDelivery(int id)
        {
            return DeliveryDB.GetDelivery(id);
        }

        public Delivery AddDelivery(Delivery delivery)
        {
            return DeliveryDB.AddDelivery(delivery);
        }

        public Delivery UpdateDelivery(Delivery delivery)
        {
            return DeliveryDB.UpdateDelivery(delivery);
        }

        public int DeleteDelivery(int id)
        {
            return DeliveryDB.DeleteDelivery(id);
        }
    }
}