﻿using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL
{
    public interface IDishesDB
    {
        IConfiguration Configuration { get; }
        List<Dishes> GetAllDishes(int id);
        Dishes GetDishes(int id);
        Dishes AddDishes(Dishes dishes);
     
    }

}
