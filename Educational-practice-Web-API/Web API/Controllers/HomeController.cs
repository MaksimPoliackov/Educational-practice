using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_API.Models;

namespace Web_API.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Index
        [Authorize] // Доступ только для авторизованных пользователей
        public ActionResult Index()
        {
            using (var db = new Warehouse_accountingEntities())
            {
                // Получаем список всех пользователей из базы данных
                List<User> users = db.Users.ToList();
                return View(users); // Передаем список пользователей в представление
            }
        }

        // GET: Home/About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        // GET: Home/Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}