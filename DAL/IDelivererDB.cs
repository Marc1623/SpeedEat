using DTO;
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
        Deliverer AddDeliverer(Deliverer deliverer);
        Deliverer UpdateDeliverer(Deliverer deliverer);
        int DeleteDeliverer(int id);
    }

}