using System;
using System.Collections.Generic;

#nullable disable

namespace KrishnaPGCare.Models.AutoCreate
{
    public partial class BookingTbl
    {
        public BookingTbl()
        {
            PaymentTbls = new HashSet<PaymentTbl>();
        }

        public int BookingId { get; set; }
        public int? TenantId { get; set; }
        public int? PropertyId { get; set; }
        public int? RoomId { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public bool? BookingStatus { get; set; }
        public decimal? TotalAmount { get; set; }
        public bool? PaymentStatus { get; set; }
        public DateTime? BookingDate { get; set; }
        public string SpecialRequests { get; set; }

        public virtual PropertyTbl Property { get; set; }
        public virtual RoomTbl Room { get; set; }
        public virtual TenantTbl Tenant { get; set; }
        public virtual ICollection<PaymentTbl> PaymentTbls { get; set; }
    }
}
