using System;
using System.Collections.Generic;

#nullable disable

namespace KrishnaPGCare.Models.AutoCreate
{
    public partial class EmailNotificationsLogTbl
    {
        public int NotificationId { get; set; }
        public int? RecipientUserId { get; set; }
        public bool? NotificationType { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime? SentDateTime { get; set; }
        public bool? Status { get; set; }

        public virtual UserTbl RecipientUser { get; set; }
    }
}
