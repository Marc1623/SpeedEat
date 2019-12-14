using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Microsoft.Extensions.Configuration;
using DTO;

namespace BLL
{
    public class DelivererManager : IDelivererManager
    {

        public IDelivererDB DelivererDB { get; }

        public DelivererManager(IConfiguration configuration)
        {
            DelivererDB = new DelivererDB(configuration);
        }

        public List<Deliverer> GetAllDeliverer()
        {
            return DelivererDB.GetAllDeliverer();
        }
        public int GetIdDeliverer(string login)
        {
            return DelivererDB.GetIdDeliverer(login);
        }

        public string GetPassDeliverer(int id, string login)
        {
            return DelivererDB.GetPassDeliverer(id, login);
        }

        public Deliverer GetDeliverer(int id)
        {
            return DelivererDB.GetDeliverer(id);
        }

        public Deliverer AddDeliverer(Deliverer deliverer)
        {
            return DelivererDB.AddDeliverer(deliverer);
        }

        public Deliverer UpdateDeliverer(Deliverer deliverer)
        {
            return DelivererDB.UpdateDeliverer(deliverer);
        }

        public int DeleteDeliverer(int id)
        {
            return DelivererDB.DeleteDeliverer(id);
        }
    }
}
