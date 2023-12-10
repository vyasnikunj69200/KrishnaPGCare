using System;
using System.Collections.Generic;

#nullable disable

namespace KrishnaPGCare.Models.AutoCreate
{
    public partial class UserTbl
    {
        public UserTbl()
        {
            EmailNotificationsLogTbls = new HashSet<EmailNotificationsLogTbl>();
            FeedBackTbls = new HashSet<FeedBackTbl>();
            PropertyTbls = new HashSet<PropertyTbl>();
            UserLoginHistoryTbls = new HashSet<UserLoginHistoryTbl>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string ContactPhone { get; set; }
        public string Addresss { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public bool UserType { get; set; }

        public virtual ICollection<EmailNotificationsLogTbl> EmailNotificationsLogTbls { get; set; }
        public virtual ICollection<FeedBackTbl> FeedBackTbls { get; set; }
        public virtual ICollection<PropertyTbl> PropertyTbls { get; set; }
        public virtual ICollection<UserLoginHistoryTbl> UserLoginHistoryTbls { get; set; }
    }
}
