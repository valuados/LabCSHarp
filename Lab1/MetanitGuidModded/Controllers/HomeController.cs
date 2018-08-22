using MetanitGuidModded.Models;
using MetanitGuidModded.Models.BookStore;
using MetanitGuidModded.Util;
using System;
using System.Collections.Generic;
using System.IO;
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
            Session["name"] = "Tom";
            HttpContext.Response.Cookies["id"].Value = "ca-4353w";
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
            if (id > 5)
            {
                //return RedirectToRoute(new { controller = "Home", action = "Contact"});
                //return RedirectToAction("Square", "Home", new { a = 10, h = 12 });
                return new HttpStatusCodeResult(404); //return HttpNotFound();
                //return new HttpUnauthorizedResult();

            }
            return View("About");

        }
        // Отправка массива байтов
        public FilePathResult GetFile()
        {
            // Путь к файлу
            string file_path = Server.MapPath("~/Files/Apps.txt");
            //string file_path2 = "C://files//custom.txt
            // Тип файла - content-type
            string file_type = "application/octet-stream";//Universal file type
            // Имя файла - необязательно
            string file_name = "Apps.txt";
            return File(file_path, file_type, file_name);
        }
        // Отправка массива байтов
        public FileResult GetBytes()
        {
            string path = Server.MapPath("~/Files/Apps.txt");
            byte[] mas = System.IO.File.ReadAllBytes(path);
            string file_type = "application/octet-stream";
            string file_name = "Apps.txt";
            return File(mas, file_type, file_name);
        }
        // Отправка потока
        public FileResult GetStream()
        {
            string path = Server.MapPath("~/Files/Apps.txt");
            // Объект Stream
            FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "application/octet-stream";
            string file_name = "Apps.txt";
            return File(fs, file_type, file_name);
        }
        public void GetContext()
        {
            HttpContext.Response.Write("This is Response Text");
            string browser = HttpContext.Request.Browser.Browser;
            string user_agent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            string referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
            HttpContext.Response.Write("<p>Browser: " + browser + "</p><p>User-Agent: " + user_agent + "</p><p>Request URL: " + url +
                "</p><p>Referrer: " + referrer + "</p><p>IP-address: " + ip + "</p>");
        }
        public string GetCookieAndSessionData()
        {
            string id = HttpContext.Request.Cookies["id"].Value;
            return id.ToString() + " " + Session["name"];
        }
    }
}