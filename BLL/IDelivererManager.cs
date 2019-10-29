using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IDelivererManager
    {

        IDelivererDB DelivererDB { get; }

        List<Deliverer> GetAllDeliverers();

        Deliverer GetDeliverer(int id);

        Deliverer AddDeliverer(Deliverer deliverer);

        Deliverer UpdateDeliverer(Deliverer deliverer);

        int DeleteDeliverer(int id);
    }

}
