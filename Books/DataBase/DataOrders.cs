using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.DataBase
{
    public static class DataOrders
    {
        public static List<Book> cart = new List<Book>();

        public static IEnumerable<Book> GetCarts()
        {
            return cart;
        }
        public static Book GetCart(int id)
        {
            return cart.FirstOrDefault(r => r.ID == id);
        }
        public static void RemoveCart(int id)
        {
            var b = GetCart(id);
            if (b != null)
            {
                var a = DataBooks.Get(b.ID);
                a.Availability = "Available";
                cart.Remove(b);
            }
        }

        public static List<Order> orders = new List<Order>();

        public static void AddOrder(Order order)
        {
            orders.Add(order);
        }
    }
}