using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KrishnaPGCare.Models
{
    public class BookingRequestModel
    {
        public int RequestId { get; set; }
        public int? TenantId { get; set; }
        public int? PropertyId { get; set; }
        public DateTime? Rquestdatetime { get; set; }
        public bool? AcceptByOwner { get; set; }
        public int? RoomType { get; set; }
        public string TenantName { get; set; }
        public string PropertyName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
