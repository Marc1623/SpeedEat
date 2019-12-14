using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IDelivery_TimeManager
    {
        IDelivery_TimeDB Delivery_TimeDB { get; }

        List<Delivery_Time> GetAllTime(int id);

    }
}
