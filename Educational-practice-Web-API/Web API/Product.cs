//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_API
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.IncomeInvoiceDetail = new HashSet<IncomeInvoiceDetail>();
            this.OutcomeInvoiceDetail = new HashSet<OutcomeInvoiceDetail>();
            this.WarehouseStock = new HashSet<WarehouseStock>();
        }
    
        public int Product_ID { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public string Barcode { get; set; }
        public string Category { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Serial_Number { get; set; }
        public Nullable<int> Min_Stock { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IncomeInvoiceDetail> IncomeInvoiceDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OutcomeInvoiceDetail> OutcomeInvoiceDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarehouseStock> WarehouseStock { get; set; }
    }
}
