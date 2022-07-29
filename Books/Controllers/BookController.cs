using Books.DataBase;
using Books.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Books.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            var model = DataBooks.GetBooks();
            return View(model);

        }
        [HttpGet]
        public ActionResult Create()
        {
            if(Session["FullName"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "User");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {

                if (book.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(book.ImageFile.FileName);
                    string extension = Path.GetExtension(book.ImageFile.FileName).ToLower();

                    if (extension == ".jpg" || extension == ".png")
                    {
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        book.ImagePath = "~/Images/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                        book.ImageFile.SaveAs(fileName);

                        book.Availability = "Available";
                        DataBooks.Add(book);
                        return RedirectToAction("Index");
                    }
                }
            }
            return HttpNotFound();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = DataBooks.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection fc)
        {
            DataBooks.Remove(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model= DataBooks.Get(id);
            if(model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = DataBooks.Get(id);
            if(model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection form, Book book)
        {
            if (ModelState.IsValid)
            {
                DataBooks.Update(book);
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
    }
}