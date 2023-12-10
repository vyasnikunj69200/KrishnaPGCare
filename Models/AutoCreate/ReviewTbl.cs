using System;
using System.Collections.Generic;

#nullable disable

namespace KrishnaPGCare.Models.AutoCreate
{
    public partial class ReviewTbl
    {
        public int ReviewId { get; set; }
        public int? TenantId { get; set; }
        public int? PropertyId { get; set; }
        public DateTime? ReviewDate { get; set; }
        public decimal? Rating { get; set; }
        public string ReviewText { get; set; }

        public virtual PropertyTbl Property { get; set; }
        public virtual TenantTbl Tenant { get; set; }
    }
}
