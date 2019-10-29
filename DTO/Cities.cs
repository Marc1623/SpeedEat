using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Cities
    { 
    public int IdCity { get; set; }

    public string Name { get; set; }

    public int Zip_Code { get; set; }

    public string Country { get; set; }

    public string Created_At { get; set; }

    public override string ToString()
        {
            return $"{IdCity}|{Name}|{Zip_Code}|{Country}|{Created_At}";
        }
    }
}
