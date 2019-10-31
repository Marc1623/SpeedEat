using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObject
{
    public class Orders
    {
        public int IdOrders { get; set; }

        public int OrdersStatus { get; set; }

        public string OrdersCreated_At { get; set; }

        public int OrdersFk_Id_Delivery { get; set; }


        public override string ToString()
        {
            return $"{IdOrders}|{OrdersStatus}|{OrdersCreated_At}|{OrdersFk_Id_Delivery}";
        }
    }
}
