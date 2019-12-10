﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;

namespace WebSpeedEatApp.Controllers
{
    public class RestaurantsController : Controller
    {private IRestaurantsManager RestaurantsManager { get; }
        public RestaurantsController (IRestaurantsManager restaurantsManager)
        {
            RestaurantsManager = restaurantsManager;
        }
        // GET: Restaurants
        public ActionResult Index()
        {
            return View();
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult GetAllRestaurants(int id)
        {
            var restaurants = RestaurantsManager.GetAllRestaurants(id);
            return View(restaurants);
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Restaurants/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Restaurants/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Dishes(int id)
        {

            return RedirectToAction("GetAllDishes", "Dishes");
        }
    }
}