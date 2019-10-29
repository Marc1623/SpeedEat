using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ConsoleApp_SpeedEat
{
    class Program
    {

            public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .Build();

        static void Main(string[] args)
        {
            Console.WriteLine("nike ta mere!");
        }
    } // DROP TABLE Customers2
}
