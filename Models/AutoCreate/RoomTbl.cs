using System;
using System.Collections.Generic;

#nullable disable

namespace KrishnaPGCare.Models.AutoCreate
{
    public partial class RoomTbl
    {
        public RoomTbl()
        {
            BookingTbls = new HashSet<BookingTbl>();
            FacilityTbls = new HashSet<FacilityTbl>();
        }

        public int RoomId { get; set; }
        public int? PropertyId { get; set; }
        public int? RoomNumber { get; set; }
        public bool? RoomType { get; set; }
        public bool? RoomStatus { get; set; }
        public decimal? MonthlyRent { get; set; }
        public string RoomDescription { get; set; }
        public string Amenities { get; set; }

        public virtual PropertyTbl Property { get; set; }
        public virtual ICollection<BookingTbl> BookingTbls { get; set; }
        public virtual ICollection<FacilityTbl> FacilityTbls { get; set; }
    }
}
