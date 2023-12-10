using KrishnaPGCare.Models.AutoCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KrishnaPGCare.Models
{
    public class TenantHomePageViewModel
    {
        public string WelcomeMessage { get; set; }
        public List<PropertyTbl> Properties { get; set; }
        public List<BookingRequestTbl> BookingRequests { get; set; }
    }
}
