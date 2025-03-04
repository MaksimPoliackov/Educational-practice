using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Web_API.Models;

namespace Web_API.Controllers
{
    public class ProductsController : Controller
    {
        private readonly Warehouse_accountingEntities db = new Warehouse_accountingEntities();

        // GET: Products
        public async Task<ActionResult> Index()
        {
            // Асинхронно получаем список всех продуктов из базы данных
            var products = await db.Product.ToListAsync();
            return View(products);
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Асинхронно находим продукт по ID
            var product = await db.Product.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Product_ID,Name,Article,Barcode,Category,Unit,Price,Serial_Number,Min_Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                // Добавляем новый продукт в базу данных
                db.Product.Add(product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            // Если данные невалидны, возвращаем представление с ошибками
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Асинхронно находим продукт по ID
            var product = await db.Product.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Product_ID,Name,Article,Barcode,Category,Unit,Price,Serial_Number,Min_Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                // Обновляем продукт в базе данных
                db.Entry(product).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            // Если данные невалидны, возвращаем представление с ошибками
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Асинхронно находим продукт по ID
            var product = await db.Product.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            // Асинхронно находим продукт по ID и удаляем его
            var product = await db.Product.FindAsync(id);
            if (product != null)
            {
                db.Product.Remove(product);
                await db.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Освобождаем ресурсы контекста базы данных
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}