using System;
using System.Collections.Generic;

#nullable disable

namespace KrishnaPGCare.Models.AutoCreate
{
    public partial class MaintenanceRequestTbl
    {
        public int RequestId { get; set; }
        public int? TenantId { get; set; }
        public int? PropertyId { get; set; }
        public DateTime? RequestDate { get; set; }
        public string Description { get; set; }
        public bool? UrgencyLevel { get; set; }
        public bool? Status { get; set; }

        public virtual PropertyTbl Property { get; set; }
        public virtual TenantTbl Tenant { get; set; }
    }
}
