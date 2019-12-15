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

        List<Deliverer> GetAllDeliverer();

        int GetIdDeliverer(string login);
        string GetPassDeliverer(int id, string login);
        Deliverer GetDeliverer(int id);

      
    }

}
