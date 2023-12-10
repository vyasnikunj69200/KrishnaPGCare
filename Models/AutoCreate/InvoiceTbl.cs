using System;
using System.Collections.Generic;

#nullable disable

namespace KrishnaPGCare.Models.AutoCreate
{
    public partial class InvoiceTbl
    {
        public int InvoiceId { get; set; }
        public int? TenantId { get; set; }
        public int? PropertyId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public bool? InvoiceStatus { get; set; }
        public DateTime? PaymentDate { get; set; }

        public virtual PropertyTbl Property { get; set; }
        public virtual TenantTbl Tenant { get; set; }
    }
}
