using MetanitGuidModded.Models;
using MetanitGuidModded.Models.BookStore;
using MetanitGuidModded.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MetanitGuidModded.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();
        public ViewResult Index()
        {
            var books = db.Books;
            ViewBag.Books = books;

            ViewData["Head"] = "Hello world!";
            //== ViewBag.Head = "Hello world"; and initialize in Index.cshtml using @ViewBag.Head

            ViewBag.Fruit = new List<string>
            {
                "apples", "oranges", "bananas"
            };
            return View();
        }
        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            // Add purchase info into DB
            db.Purchases.Add(purchase);
            // Save changes in DB
            db.SaveChanges();
            return purchase.Person + ", thanks for your purchase!";
        }

        public string Square()
        {
            int a = Int32.Parse(Request.Params["a"]);
            int h = Int32.Parse(Request.Params["h"]);

            double s = a * h / 2.0;
            return "<h2>Площадь треугольника с основанием " + a +
                    " и высотой " + h + " равна " + s + "</h2>";
        }
        [HttpGet]
        public ActionResult GetBook()
        {
            return View();
        }
        [HttpPost]
        public ContentResult PostBook(string title, string author)
        {
            return Content("Book \"" + title + "\" writen by " + author);
        }
        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Hello World!</h2>");
        }
        public ActionResult GetImage()
        {
            string path = "../Content/Images/pizza.png";
            return new ImageResult(path);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult GetVoid(int id)
        {
            if(id>5)
            {
                return Redirect("/Home/Contact");
            }
            return View("About");
            
        }
    }
}