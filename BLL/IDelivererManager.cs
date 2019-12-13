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

        int GetIdDeliverer(string login);
        string GetPassDeliverer(int id, string login);
        Deliverer GetDeliverer(int id);

        Deliverer AddDeliverer(Deliverer deliverer);

        Deliverer UpdateDeliverer(Deliverer deliverer);

        int DeleteDeliverer(int id);
    }

}
