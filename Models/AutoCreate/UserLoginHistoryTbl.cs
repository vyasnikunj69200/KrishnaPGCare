using System;
using System.Collections.Generic;

#nullable disable

namespace KrishnaPGCare.Models.AutoCreate
{
    public partial class UserLoginHistoryTbl
    {
        public int LogId { get; set; }
        public DateTime? LoginDateTime { get; set; }
        public string Ipaddress { get; set; }
        public string UserAgent { get; set; }
        public bool? Status { get; set; }
        public string FailureReason { get; set; }
        public int? UserId { get; set; }
    }
}
