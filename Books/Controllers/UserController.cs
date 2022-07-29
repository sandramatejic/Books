using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using Books.DataBase;
using Books.Models;

namespace Books.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                var check = DataUsers.users.FirstOrDefault(u => u.Email == user.Email);
                if (check != null)
                {
                    ModelState.AddModelError(nameof(user.Email), "Email already exists");
                }
                else
                {
                    DataUsers.AddUser(user);
                    Session["FullName"] = user.FirstName + " " + user.LastName;
                    return RedirectToAction("Index", "Book");
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var data = DataUsers.users.Where(u => u.Email.Equals(email) && u.Password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    return RedirectToAction("Index", "Book");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect email or password");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}