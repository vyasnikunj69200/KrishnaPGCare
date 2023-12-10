using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KrishnaPGCare.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserLoginHistoryModel
    {
        public int LogId { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        [Display(Name = "User ID")]
        public int? UserId { get; set; }

        [Required(ErrorMessage = "Login Date and Time is required.")]
        [Display(Name = "Login Date and Time")]
        public DateTime? LoginDateTime { get; set; }

        [Required(ErrorMessage = "IP Address is required.")]
        [Display(Name = "IP Address")]
        public string IpAddress { get; set; }

        [Required(ErrorMessage = "User Agent is required.")]
        [Display(Name = "User Agent")]
        public string UserAgent { get; set; }

        [Display(Name = "Status")]
        public bool? Status { get; set; }

        [Display(Name = "Failure Reason")]
        public string FailureReason { get; set; }
    }
}
