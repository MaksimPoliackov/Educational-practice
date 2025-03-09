namespace WarehouseLibrary
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public string Barcode { get; set; }
        public string Category { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public string SerialNumber { get; set; }
        public int MinStock { get; set; }
    }

    public class Warehouse
    {
        public int WarehouseID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
    }

    public class WarehouseStock
    {
        public int WarehouseStockID { get; set; }
        public int WarehouseID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}