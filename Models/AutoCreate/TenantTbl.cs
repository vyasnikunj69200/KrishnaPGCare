using System;
using System.Collections.Generic;

#nullable disable

namespace KrishnaPGCare.Models.AutoCreate
{
    public partial class TenantTbl
    {
        public TenantTbl()
        {
            BillTbls = new HashSet<BillTbl>();
            BookingTbls = new HashSet<BookingTbl>();
            InvoiceTbls = new HashSet<InvoiceTbl>();
            MaintenanceRequestTbls = new HashSet<MaintenanceRequestTbl>();
            PaymentTbls = new HashSet<PaymentTbl>();
            ReviewTbls = new HashSet<ReviewTbl>();
        }

        public int TenantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ContactPhone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public DateTime? MoveInDate { get; set; }
        public decimal? MonthlyRent { get; set; }
        public int? RoomNumber { get; set; }
        public DateTime? LeaseStartDate { get; set; }
        public DateTime? LeaseEndDate { get; set; }
        public string LeaseTerm { get; set; }
        public decimal? SecurityDeposit { get; set; }
        public bool? LeaseStatus { get; set; }

        public virtual ICollection<BillTbl> BillTbls { get; set; }
        public virtual ICollection<BookingTbl> BookingTbls { get; set; }
        public virtual ICollection<InvoiceTbl> InvoiceTbls { get; set; }
        public virtual ICollection<MaintenanceRequestTbl> MaintenanceRequestTbls { get; set; }
        public virtual ICollection<PaymentTbl> PaymentTbls { get; set; }
        public virtual ICollection<ReviewTbl> ReviewTbls { get; set; }
    }
}
