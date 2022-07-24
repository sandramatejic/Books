using Books.DataBase;
using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddToCart()
        {
            var model = DataBooks.cart;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddToCart(int idAdd)
        {
            if(ModelState.IsValid)
            {
                var model = DataBooks.Get(idAdd);
                DataBooks.cart.Add(model);
                var available = DataBooks.Get(idAdd);
                available.Availability = "Sold";
                return RedirectToAction("AddToCart");
            }
            return HttpNotFound();
        }
        public ActionResult RemoveFromCart(int id)
        {
            DataBooks.RemoveCart(id);
            return RedirectToAction("AddToCart");
        }
        [HttpGet]
        public ActionResult Order()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Order(Order order)
        {
            return RedirectToAction("Index", "Book");
        }
    }
}