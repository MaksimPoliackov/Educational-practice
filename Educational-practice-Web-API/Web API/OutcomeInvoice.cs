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
    
    public partial class OutcomeInvoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OutcomeInvoice()
        {
            this.OutcomeInvoiceDetail = new HashSet<OutcomeInvoiceDetail>();
        }
    
        public int Outcome_Invoice_ID { get; set; }
        public string Invoice_Number { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> Customer_ID { get; set; }
        public Nullable<decimal> Total_Amount { get; set; }
    
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OutcomeInvoiceDetail> OutcomeInvoiceDetail { get; set; }
    }
}
