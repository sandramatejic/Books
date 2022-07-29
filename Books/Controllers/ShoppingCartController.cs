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
            var model = DataOrders.cart;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddToCart(int idAdd)
        {
            if(ModelState.IsValid)
            {
                var model = DataBooks.Get(idAdd);
                DataOrders.cart.Add(model);
                var available = DataBooks.Get(idAdd);
                available.Availability = "Sold";
                return RedirectToAction("AddToCart");
            }
            return HttpNotFound();
        }
        public ActionResult RemoveFromCart(int id)
        {
            DataOrders.RemoveCart(id);
            return RedirectToAction("AddToCart");
        }
        [HttpGet]
        public ActionResult Order()
        {
            if (Session["FullName"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "User");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order(Order order)
        {
            if(ModelState.IsValid)
            {
                order.OrderList = DataOrders.cart;
                DataOrders.AddOrder(order);
                var deleted = DataOrders.GetCarts();
                foreach (var book in deleted)
                {
                    DataBooks.Remove(book.ID);
                }
                DataOrders.cart.Clear();
                return RedirectToAction("Index", "Book");
            }
            return HttpNotFound();
        }
    }
}