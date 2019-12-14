using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Delivery_Time
    {
        public int Id { get; set; }
        public string Time_Zone { get; set; }
        public string Created_At { get; set; }

        public override string ToString()
        {
            return $"{Id}|{Time_Zone}|{Created_At}";
        }
    }
}
