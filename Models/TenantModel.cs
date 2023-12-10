using KrishnaPGCare.Models.AutoCreate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KrishnaPGCare.Models
{
    public class TenantModel
    {
        public int TenantId { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, ErrorMessage = "First Name should be at most 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, ErrorMessage = "Last Name should be at most 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password should be at least 6 characters.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Contact Phone is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact Phone should be exactly 10 digits.")]
        [Display(Name = "Contact Phone")]
        public string ContactPhone { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100, ErrorMessage = "Address should be at most 100 characters.")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "City should be at most 50 characters.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [StringLength(50, ErrorMessage = "State should be at most 50 characters.")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Postal Code is required.")]
        [StringLength(10, ErrorMessage = "Postal Code should be at most 10 characters.")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(50, ErrorMessage = "Country should be at most 50 characters.")]
        [Display(Name = "Country")]
        public string Country { get; set; }
        
        [Display(Name = "Move-In Date")]
        public DateTime? MoveInDate { get; set; }
        
        [Display(Name = "Monthly Rent")]
        public decimal? MonthlyRent { get; set; }

        [Display(Name = "Room Number")]
        public int? RoomNumber { get; set; }

        [Display(Name = "Lease Start Date")]
        public DateTime? LeaseStartDate { get; set; }

        [Display(Name = "Lease End Date")]
        public DateTime? LeaseEndDate { get; set; }

        [StringLength(20, ErrorMessage = "Lease Term should be at most 20 characters.")]
        [Display(Name = "Lease Term")]
        public string LeaseTerm { get; set; }

        [Display(Name = "Security Deposit")]
        public decimal? SecurityDeposit { get; set; }

        [Display(Name = "Lease Status")]
        public bool? LeaseStatus { get; set; }
    }
}


