using System;

namespace WarehouseManagement.Models
{
    public class Warehouse
    {
        public int Id { get; set; } // Идентификатор склада
        public string Name { get; set; } // Название склада
        public string Address { get; set; } // Адрес склада
        public string Type { get; set; } // Тип склада
        public string StorageZone { get; set; } // Зона хранения
    }
}