using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KrishnaPGCare.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(15, ErrorMessage = "First Name should be at most 15 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(15, ErrorMessage = "Last Name should be at most 15 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password should be at least 6 characters.")]
        [Display(Name = "Password")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Contact Phone is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact Phone should be exactly 10 digits.")]
        [Display(Name = "Contact Phone")]
        public string ContactPhone { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100, ErrorMessage = "Address should be at most 100 characters.")]
        [Display(Name = "Address")]
        public string Addresss { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(20, ErrorMessage = "City should be at most 20 characters.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [StringLength(20, ErrorMessage = "State should be at most 20 characters.")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Postal Code is required.")]
        [StringLength(8, ErrorMessage = "Postal Code should be at most 8 characters.")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(20, ErrorMessage = "Country should be at most 20 characters.")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "User Type is required.")]
        [Display(Name = "User Type")]
        public bool UserType { get; set; }
    }


}
