using System;
using System.Collections.Generic;
using System.Linq;

namespace WarehouseManagement.Models
{
    public class WarehouseAnalysisCalculator
    {
        private readonly Warehouse_accountingEntities _dbContext;
        private readonly LibWarehouse.WarehouseAnalyzer _analyzer;

        public WarehouseAnalysisCalculator(Warehouse_accountingEntities dbContext, LibWarehouse.WarehouseAnalyzer analyzer)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _analyzer = analyzer ?? throw new ArgumentNullException(nameof(analyzer));
        }

        public int CalculateTotalQuantity()
        {
            var stockBalances = _dbContext.StockBalances.ToList();
            return _analyzer.CalculateTotalQuantity(TransformBalances(stockBalances));
        }

        public decimal CalculateTotalSum()
        {
            var stockBalances = _dbContext.StockBalances.ToList();
            var products = _dbContext.Products.ToList();
            return _analyzer.CalculateTotalSum(TransformBalances(stockBalances), TransformProducts(products));
        }

        public Dictionary<string, int> CalculateCategories()
        {
            var stockBalances = _dbContext.StockBalances.ToList();
            var products = _dbContext.Products.ToList();
            return _analyzer.CalculateCategories(TransformBalances(stockBalances), TransformProducts(products));
        }

        private List<LibWarehouse.StockBalance> TransformBalances(IEnumerable<StockBalance> balances)
        {
            return balances.Select(b => new LibWarehouse.StockBalance
            {
                BalanceId = b.BalanceId,
                ProductId = b.ProductId,
                WarehouseId = b.WarehouseId,
                CurrentQuantity = b.CurrentQuantity
            }).ToList();
        }

        private List<LibWarehouse.Product> TransformProducts(IEnumerable<Product> products)
        {
            return products.Select(p => new LibWarehouse.Product
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Article = p.Article,
                Barcode = p.Barcode,
                Category = p.Category,
                UnitOfMeasure = p.UnitOfMeasure,
                PricePerUnit = p.PricePerUnit,
                SerialNumber = p.SerialNumber,
                MinimumStock = p.MinimumStock
            }).ToList();
        }
    }
}