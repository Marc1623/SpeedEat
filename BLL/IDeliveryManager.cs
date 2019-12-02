using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using DataTransferObject;

namespace BLL
{
    public interface IDeliveryManager
    {

        IDeliveryDB DeliveryDB { get; }

        List<Delivery> GetAllDelivery();

        Delivery GetDelivery(int id);

        Delivery AddDelivery(Delivery delivery);

        Delivery UpdateDelivery(Delivery delivery);

        int DeleteDelivery(int id);
    }
}