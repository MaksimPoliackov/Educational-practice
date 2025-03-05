-- Товары
CREATE TABLE Product (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Article NVARCHAR(50) NOT NULL,
    Barcode NVARCHAR(50),
    Category NVARCHAR(50),
    Unit NVARCHAR(20),
    Price DECIMAL(18, 2),
    SerialNumber NVARCHAR(50),
    MinStock INT
);

-- Склады
CREATE TABLE Warehouse (
    WarehouseID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200),
    Type NVARCHAR(50)
);

-- Поставщики
CREATE TABLE Supplier (
    SupplierID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    INN NVARCHAR(20),
    ContactInfo NVARCHAR(200),
    Address NVARCHAR(200)
);

-- Клиенты
CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    ContactInfo NVARCHAR(200),
    Address NVARCHAR(200)
);

-- Приходные накладные
CREATE TABLE IncomeInvoice (
    IncomeInvoiceID INT PRIMARY KEY IDENTITY(1,1),
    InvoiceNumber NVARCHAR(50) NOT NULL,
    Date DATETIME NOT NULL,
    SupplierID INT FOREIGN KEY REFERENCES Supplier(SupplierID),
    TotalAmount DECIMAL(18, 2)
);

-- Расходные накладные
CREATE TABLE OutcomeInvoice (
    OutcomeInvoiceID INT PRIMARY KEY IDENTITY(1,1),
    InvoiceNumber NVARCHAR(50) NOT NULL,
    Date DATETIME NOT NULL,
    CustomerID INT FOREIGN KEY REFERENCES Customer(CustomerID),
    TotalAmount DECIMAL(18, 2)
);

-- Инвентаризация
CREATE TABLE Inventory (
    InventoryID INT PRIMARY KEY IDENTITY(1,1),
    Date DATETIME NOT NULL,
    Responsible NVARCHAR(100),
    Results NVARCHAR(MAX),
    WarehouseID INT FOREIGN KEY REFERENCES Warehouse(WarehouseID)
);

-- Промежуточная таблица для связи IncomeInvoice и Product
CREATE TABLE IncomeInvoiceDetail (
    IncomeInvoiceDetailID INT PRIMARY KEY IDENTITY(1,1),
    IncomeInvoiceID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (IncomeInvoiceID) REFERENCES IncomeInvoice(IncomeInvoiceID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

-- Промежуточная таблица для связи OutcomeInvoice и Product
CREATE TABLE OutcomeInvoiceDetail (
    OutcomeInvoiceDetailID INT PRIMARY KEY IDENTITY(1,1),
    OutcomeInvoiceID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (OutcomeInvoiceID) REFERENCES OutcomeInvoice(OutcomeInvoiceID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

-- Таблица для связи Product и Warehouse
CREATE TABLE WarehouseStock (
    WarehouseStockID INT PRIMARY KEY IDENTITY(1,1),
    WarehouseID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    FOREIGN KEY (WarehouseID) REFERENCES Warehouse(WarehouseID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);