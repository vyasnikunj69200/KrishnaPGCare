using System;
using System.Collections.Generic;

#nullable disable

namespace KrishnaPGCare.Models.AutoCreate
{
    public partial class FacilityTbl
    {
        public int FacilityId { get; set; }
        public int? PropertyId { get; set; }
        public int? RoomId { get; set; }
        public string FacilityName { get; set; }
        public decimal? PricePerMonth { get; set; }
        public bool? FacilityStatus { get; set; }

        public virtual PropertyTbl Property { get; set; }
        public virtual RoomTbl Room { get; set; }
    }
}
