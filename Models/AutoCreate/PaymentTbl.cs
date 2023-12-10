using System;
using System.Collections.Generic;

#nullable disable

namespace KrishnaPGCare.Models.AutoCreate
{
    public partial class PaymentTbl
    {
        public int PaymentId { get; set; }
        public int? TenantId { get; set; }
        public int? BookingId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? AmountPaid { get; set; }
        public bool? PaymentMethod { get; set; }
        public bool? PaymentStatus { get; set; }
        public string PaymentReference { get; set; }
        public string PaymentNotes { get; set; }

        public virtual BookingTbl Booking { get; set; }
        public virtual TenantTbl Tenant { get; set; }
    }
}
