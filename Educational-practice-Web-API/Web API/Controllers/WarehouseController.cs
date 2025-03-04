using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WerehouseManagement.Models;

namespace WerehouseManagement.Controllers
{
    [RoutePrefix("api/Warehouses")]
    public class WarehousesController : ApiController
    {
        private readonly WarehouseAccountingEntities db = new WarehouseAccountingEntities();

        // GET: api/Warehouses
        [HttpGet]
        public async Task<IHttpActionResult> GetWarehouses()
        {
            // Асинхронно получаем список всех складов
            var warehouses = await db.Warehouses.ToListAsync();
            return Ok(warehouses);
        }

        // GET: api/Warehouses/5
        [HttpGet]
        [ResponseType(typeof(Warehouse))]
        public async Task<IHttpActionResult> GetWarehouse(int id)
        {
            // Асинхронно находим склад по ID
            Warehouse warehouse = await db.Warehouses.FindAsync(id);
            if (warehouse == null)
            {
                return NotFound();
            }

            return Ok(warehouse);
        }

        // PUT: api/Warehouses/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWarehouse(int id, Warehouse warehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != warehouse.WarehouseID)
            {
                return BadRequest("ID в запросе не совпадает с ID склада.");
            }

            db.Entry(warehouse).State = EntityState.Modified;

            try
            {
                // Асинхронно сохраняем изменения
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarehouseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Warehouses
        [HttpPost]
        [ResponseType(typeof(Warehouse))]
        public async Task<IHttpActionResult> PostWarehouse(Warehouse warehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Добавляем новый склад в базу данных
            db.Warehouses.Add(warehouse);
            await db.SaveChangesAsync();

            // Возвращаем статус 201 (Created) и URI нового ресурса
            return CreatedAtRoute("DefaultApi", new { id = warehouse.WarehouseID }, warehouse);
        }

        // DELETE: api/Warehouses/5
        [HttpDelete]
        [ResponseType(typeof(Warehouse))]
        public async Task<IHttpActionResult> DeleteWarehouse(int id)
        {
            // Асинхронно находим склад по ID
            Warehouse warehouse = await db.Warehouses.FindAsync(id);
            if (warehouse == null)
            {
                return NotFound();
            }

            // Удаляем склад из базы данных
            db.Warehouses.Remove(warehouse);
            await db.SaveChangesAsync();

            return Ok(warehouse);
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

        private bool WarehouseExists(int id)
        {
            // Проверяем, существует ли склад с указанным ID
            return db.Warehouses.Any(e => e.WarehouseID == id);
        }
    }
}