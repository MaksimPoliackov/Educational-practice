using System;

namespace WarehouseManagement.Models
{
    public class Product
    {
        public int ProductId { get; set; } // Идентификатор товара
        public string Name { get; set; } // Название товара
        public string Article { get; set; } // Артикул товара
        public string Barcode { get; set; } // Штрихкод товара
        public string Category { get; set; } // Категория товара
        public string UnitOfMeasure { get; set; } // Единица измерения
        public decimal PricePerUnit { get; set; } // Цена за единицу
        public string SerialNumber { get; set; } // Серийный номер
        public int MinimumStock { get; set; } // Минимальный остаток

        public Product(Products products)
        {
            ProductId = products.ProductId;
            Name = products.Name;
            Article = products.Article;
            Barcode = products.Barcode;
            Category = products.Category;
            UnitOfMeasure = products.UnitOfMeasure;
            PricePerUnit = products.PricePerUnit;
            SerialNumber = products.SerialNumber;
            MinimumStock = products.MinimumStock;
        }
    }
}