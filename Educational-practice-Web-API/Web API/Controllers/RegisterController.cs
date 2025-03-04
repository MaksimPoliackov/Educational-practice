using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WerehouseManagement.Models;

namespace WerehouseManagement.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        public ActionResult Index(User model)
        {
            if (!ModelState.IsValid)
            {
                // Если модель невалидна, возвращаем представление с ошибками валидации
                return View(model);
            }

            using (var db = new Warehouse_accountingEntities())
            {
                // Проверяем, существует ли пользователь с таким же логином в базе данных
                if (db.Users.Any(u => u.Username == model.Username))
                {
                    ModelState.AddModelError("Username", "Логин уже занят.");
                    return View(model);
                }

                // Добавляем нового пользователя в базу данных
                db.Users.Add(model);
                db.SaveChanges();

                // Аутентифицируем пользователя и создаем сессию
                FormsAuthentication.SetAuthCookie(model.Username, createPersistentCookie: false);
                Session["Username"] = model.Username;

                // Перенаправляем на главную страницу после успешной регистрации
                return RedirectToAction("Index", "Home");
            }
        }
    }
}