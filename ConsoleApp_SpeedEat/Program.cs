using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using BLL;
using DTO;

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

            var delivererManager = new DelivererManager(Configuration);
            var customersManager = new CustomersManager(Configuration);

            int id;
            int reponse;
            var dishesManager = new DishesManager(Configuration);

            //Get Deliverer *****************************************************************************************************************
            Console.WriteLine("Avez-vous déjà un compte");
            Console.WriteLine("entrer 1 pour oui ou 2 pour non");
            reponse = Convert.ToInt32(Console.ReadLine());
            if(reponse==1)
            {
                Console.WriteLine("Connectez-vous");
            }
            else
            {
                Console.WriteLine("Créer un compte");

                Console.WriteLine("Nom : ");
                string LastNameNewCustomer = Console.ReadLine();
                Console.WriteLine("Prénom : ");
                string FirsttNameNewCustomer = Console.ReadLine();
                Console.WriteLine("Téléphone : ");
                string PhoneNewCustomer = Console.ReadLine();
                Console.WriteLine("Address : ");
                string AddressNewCustomer = Console.ReadLine();
                Console.WriteLine("Username : ");
                string UsernameNewCustomer = Console.ReadLine();
                Console.WriteLine("Password : ");
                string PasswordNewCustomer = Console.ReadLine();
               
                customersManager.AddCustomers(new Customers { CustomersLastName = LastNameNewCustomer, CustomerstName = FirsttNameNewCustomer, CustomersPhone = PhoneNewCustomer, CustomersAddress = AddressNewCustomer, CustomersLogin = UsernameNewCustomer, CustomersPassword = PasswordNewCustomer, CustomersCreated_At = "", CustomersFk_Id_Cities = });
                Console.WriteLine("Bienvenue sur SPEEDEAT !");
            }
            var deliverer2 = delivererManager.GetDeliverer(1);
            Console.WriteLine(deliverer2.ToString());


            

            //Login or Create an account*****************************************************************************************************************





        }

    }
}
