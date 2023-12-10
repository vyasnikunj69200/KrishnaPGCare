using System;
using System.Collections.Generic;

#nullable disable

namespace KrishnaPGCare.Models.AutoCreate
{
    public partial class PropertyTbl
    {
        public PropertyTbl()
        {
            BillTbls = new HashSet<BillTbl>();
            BookingTbls = new HashSet<BookingTbl>();
            FacilityTbls = new HashSet<FacilityTbl>();
            FeedBackTbls = new HashSet<FeedBackTbl>();
            InvoiceTbls = new HashSet<InvoiceTbl>();
            MaintenanceRequestTbls = new HashSet<MaintenanceRequestTbl>();
            ReviewTbls = new HashSet<ReviewTbl>();
            RoomTbls = new HashSet<RoomTbl>();
        }

        public int PropertyId { get; set; }
        public int? OwnerId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyDescription { get; set; }
        public int? PropertyType { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public int? TotalRooms { get; set; }
        public int? AvailableRooms { get; set; }
        public decimal? PricePerRoom { get; set; }
        public string Amenities { get; set; }
        public bool PropertyStatus { get; set; }

        public virtual UserTbl Owner { get; set; }
        public virtual ICollection<BillTbl> BillTbls { get; set; }
        public virtual ICollection<BookingTbl> BookingTbls { get; set; }
        public virtual ICollection<FacilityTbl> FacilityTbls { get; set; }
        public virtual ICollection<FeedBackTbl> FeedBackTbls { get; set; }
        public virtual ICollection<InvoiceTbl> InvoiceTbls { get; set; }
        public virtual ICollection<MaintenanceRequestTbl> MaintenanceRequestTbls { get; set; }
        public virtual ICollection<ReviewTbl> ReviewTbls { get; set; }
        public virtual ICollection<RoomTbl> RoomTbls { get; set; }
    }
}
