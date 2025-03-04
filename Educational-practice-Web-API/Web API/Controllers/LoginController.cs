using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WerehouseManagement.Models;

namespace WerehouseManagement.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Index(User loginModel, string returnUrl)
        {
            if (IsUserValid(loginModel))
            {
                // Аутентификация пользователя
                FormsAuthentication.SetAuthCookie(loginModel.Username, createPersistentCookie: false);
                Session["Username"] = loginModel.Username;

                // Перенаправление на URL, с которого пользователь пришел, или на главную страницу
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                // Если данные неверны, возвращаем представление с ошибкой
                ModelState.AddModelError("", "Неверный логин или пароль.");
                return View(loginModel);
            }
        }

        // Проверка валидности пользователя
        private bool IsUserValid(User model)
        {
            using (var db = new Warehouse_accountingEntities())
            {
                // Поиск пользователя в базе данных
                var user = db.Users
                    .FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

                return user != null; // Возвращает true, если пользователь найден
            }
        }

        // POST: LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            // Выход из системы
            FormsAuthentication.SignOut();
            Session.Clear(); // Очистка сессии
            return RedirectToAction("Index", "Home");
        }
    }
}