using System;
using System.Collections.Generic;

#nullable disable

namespace KrishnaPGCare.Models.AutoCreate
{
    public partial class BookingRequest
    {
        public int RequestId { get; set; }
        public int? TenantId { get; set; }
        public int? PropertyId { get; set; }
        public DateTime? Rquestdatetime { get; set; }
        public bool? AcceptByOwner { get; set; }
        public int? RoomType { get; set; }
    }
}
