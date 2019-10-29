using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Delivery
    {
        public int IdDelivery { get; set; }

        public string Start_Time { get; set; }

        public string End_Time { get; set; }

        public string Created_At { get; set; }

        public int Fk_Id_Deliverer { get; set; }

        public override string ToString()
        {
            return $"{IdDelivery}|{Start_Time}|{End_Time}|{Created_At}|{Fk_Id_Deliverer}";
        }
    }
}