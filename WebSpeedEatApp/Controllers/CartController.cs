using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebSpeedEatApp.Helpers;
using WebSpeedEatApp.Models;



namespace WebSpeedEatApp.Controllers
{

    public class CartController : Controller
    {
        private IConfiguration Configuration { get; }
        public CartController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // GET: Cart

        public ActionResult Index()
        {
            var cart = SessionHelper.GetObjectAsJason<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(i => i.Dishe.DishesPrice * i.Quantity);

            return View(cart);
        }

        public ActionResult buy(int id)
        {

            DishesManager dishesManager = new DishesManager(Configuration);
            var cart = new List<Item>();
            if (SessionHelper.GetObjectAsJason<List<Item>>(HttpContext.Session, "cart") == null)
            {

                cart.Add(new Item() { Dishe = dishesManager.GetDishes(id), Quantity = 1 });
                SessionHelper.SetObjectAsJason(HttpContext.Session, "cart", cart);
            }
            else
            {
                cart = SessionHelper.GetObjectAsJason<List<Item>>(HttpContext.Session, "cart");
                int index = Exists(cart, id);
                if (index == -1)
                {
                    cart.Add(new Item() { Dishe = dishesManager.GetDishes(id), Quantity = 1 });
                }
                else
                {
                    cart[index].Quantity++;
                }
                SessionHelper.SetObjectAsJason(HttpContext.Session, "cart", cart);
            }

            return RedirectToAction("Index", "Cart");
        }

        private int Exists(List<Item> cart, int id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Dishe.IdDishes == id)
                {
                    return i;
                }

            }
            return -1;

        }

        public IActionResult Remove(int id)
        {
            List<Item> cart = SessionHelper.GetObjectAsJason<List<Item>>(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJason(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");

        }

        public ActionResult Order()

        {
            Delivery_TimeManager delivery_TimeManager = new Delivery_TimeManager(Configuration);
            return View(delivery_TimeManager.GetAllTime());
        }

        public ActionResult Validate()
        {
            return View();
        }


    }
}