using System;
using System.Collections.Generic;

#nullable disable

namespace KrishnaPGCare.Models.AutoCreate
{
    public partial class UserTbl
    {
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
    }
}
