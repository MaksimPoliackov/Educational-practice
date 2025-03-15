using System.Collections.Generic;
using System.Linq;

namespace WarehouseLibrary
{
    public class WarehouseCalculator
    {
        // Метод для подсчета общего количества товаров на всех складах
        public int CalculateTotalQuantity(List<WarehouseStock> stocks, int productId)
        {
            return stocks.Where(s => s.ProductID == productId).Sum(s => s.Quantity);
        }

        // Перегрузка метода для подсчета количества товаров на конкретном складе
        public int CalculateTotalQuantity(List<WarehouseStock> stocks, int productId, int warehouseId)
        {
            return stocks.Where(s => s.ProductID == productId && s.WarehouseID == warehouseId).Sum(s => s.Quantity);
        }

        // Метод для подсчета общей стоимости товаров на всех складах
        public decimal CalculateTotalAmount(List<WarehouseStock> stocks, List<Product> products, int productId)
        {
            var product = products.FirstOrDefault(p => p.ProductID == productId);
            if (product == null) return 0;

            return stocks.Where(s => s.ProductID == productId).Sum(s => s.Quantity * product.Price);
        }

        // Перегрузка метода для подсчета стоимости товаров на конкретном складе
        public decimal CalculateTotalAmount(List<WarehouseStock> stocks, List<Product> products, int productId, int warehouseId)
        {
            var product = products.FirstOrDefault(p => p.ProductID == productId);
            if (product == null) return 0;

            return stocks.Where(s => s.ProductID == productId && s.WarehouseID == warehouseId).Sum(s => s.Quantity * product.Price);
        }

        // Метод для подсчета количества товаров по категориям на всех складах
        public Dictionary<string, int> CalculateQuantityByCategory(List<WarehouseStock> stocks, List<Product> products)
        {
            return stocks
                .Join(products, s => s.ProductID, p => p.ProductID, (s, p) => new { s.Quantity, p.Category })
                .GroupBy(x => x.Category)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Quantity));
        }

        // Перегрузка метода для подсчета количества товаров по категориям на конкретном складе
        public Dictionary<string, int> CalculateQuantityByCategory(List<WarehouseStock> stocks, List<Product> products, int warehouseId)
        {
            return stocks
                .Where(s => s.WarehouseID == warehouseId)
                .Join(products, s => s.ProductID, p => p.ProductID, (s, p) => new { s.Quantity, p.Category })
                .GroupBy(x => x.Category)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Quantity));
        }
    }
}