using System;
using System.Collections.Generic;

#nullable disable

namespace KrishnaPGCare.Models.AutoCreate
{
    public partial class BillTbl
    {
        public int BillId { get; set; }
        public int? TenantId { get; set; }
        public int? PropertyId { get; set; }
        public DateTime? BillDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? BillAmount { get; set; }
        public bool? BillStatus { get; set; }

        public virtual PropertyTbl Property { get; set; }
        public virtual TenantTbl Tenant { get; set; }
    }
}
