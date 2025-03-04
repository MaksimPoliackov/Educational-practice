using System;
using System.Net;
using System.Web.Http;
using WerehouseManagement.Models;
using LibWarehouse;

namespace WerehouseManagement.Controllers
{
    [RoutePrefix("api/WarehouseAnalysis")]
    public class WarehouseAnalysisController : ApiController
    {
        private readonly Warehouse_accountingEntities _context;
        private readonly WarehouseAnalyzer _warehouseAnalyzer;

        public WarehouseAnalysisController()
        {
            _context = new Warehouse_accountingEntities(); // Инициализация контекста базы данных
            _warehouseAnalyzer = new WarehouseAnalyzer(_context);
        }

        // GET api/WarehouseAnalysis/TotalProducts/Warehouse/{warehouseId}
        [HttpGet]
        [Route("TotalProducts/Warehouse/{warehouseId}")]
        public IHttpActionResult GetTotalProductsInWarehouse(int warehouseId)
        {
            try
            {
                int count = _warehouseAnalyzer.CountTotalProductsInWarehouse(warehouseId);
                return Ok(count);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                return Content(HttpStatusCode.InternalServerError, $"Ошибка: {ex.Message}");
            }
        }

        // GET api/WarehouseAnalysis/TotalProducts/Overall
        [HttpGet]
        [Route("TotalProducts/Overall")]
        public IHttpActionResult GetTotalProductsOverall()
        {
            try
            {
                int count = _warehouseAnalyzer.CountTotalProductsOverall();
                return Ok(count);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                return Content(HttpStatusCode.InternalServerError, $"Ошибка: {ex.Message}");
            }
        }

        // GET api/WarehouseAnalysis/TotalValue/Warehouse/{warehouseId}
        [HttpGet]
        [Route("TotalValue/Warehouse/{warehouseId}")]
        public IHttpActionResult GetTotalValueInWarehouse(int warehouseId)
        {
            try
            {
                decimal value = _warehouseAnalyzer.CalculateTotalValueInWarehouse(warehouseId);
                return Ok(value);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                return Content(HttpStatusCode.InternalServerError, $"Ошибка: {ex.Message}");
            }
        }

        // GET api/WarehouseAnalysis/TotalValue/Overall
        [HttpGet]
        [Route("TotalValue/Overall")]
        public IHttpActionResult GetTotalValueOverall()
        {
            try
            {
                decimal value = _warehouseAnalyzer.CalculateTotalValueOverall();
                return Ok(value);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                return Content(HttpStatusCode.InternalServerError, $"Ошибка: {ex.Message}");
            }
        }

        // GET api/WarehouseAnalysis/Category/Warehouse/{warehouseId}/{category}
        [HttpGet]
        [Route("Category/Warehouse/{warehouseId}/{category}")]
        public IHttpActionResult GetProductsByCategoryInWarehouse(int warehouseId, string category)
        {
            try
            {
                int count = _warehouseAnalyzer.CountProductsByCategoryInWarehouse(warehouseId, category);
                return Ok(count);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                return Content(HttpStatusCode.InternalServerError, $"Ошибка: {ex.Message}");
            }
        }

        // GET api/WarehouseAnalysis/Category/Overall/{category}
        [HttpGet]
        [Route("Category/Overall/{category}")]
        public IHttpActionResult GetProductsByCategoryOverall(string category)
        {
            try
            {
                int count = _warehouseAnalyzer.CountProductsByCategoryOverall(category);
                return Ok(count);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                return Content(HttpStatusCode.InternalServerError, $"Ошибка: {ex.Message}");
            }
        }

        // GET api/WarehouseAnalysis/AverageValue/Warehouse/{warehouseId}
        [HttpGet]
        [Route("AverageValue/Warehouse/{warehouseId}")]
        public IHttpActionResult GetAverageProductValueInWarehouse(int warehouseId)
        {
            try
            {
                decimal averageValue = _warehouseAnalyzer.CalculateAverageProductValueInWarehouse(warehouseId);
                return Ok(averageValue);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                return Content(HttpStatusCode.InternalServerError, $"Ошибка: {ex.Message}");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose(); // Освобождение ресурсов контекста базы данных
            }
            base.Dispose(disposing);
        }
    }
}