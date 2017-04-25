using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Logix_Guru.Models
{
    public class Health
    {
     
        public int HealthID { get; set; }

        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }

        [DisplayName("Email")]
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please Enter Correct Email Address")]
        public string Email { get; set; }

        [DisplayName("Phone Number")]
        [Required]
        [MaxLength(10)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public decimal PhoneNumber { get; set; }

        [DisplayName("Status")]
        [Required]
        public string Status { get; set; }
        public List<SelectListItem> StatusList { get; set; }

        //public Health()
        //{
        //    StatusList = new List<SelectListItem> { new SelectListItem { Value = "Inactive", Text = "Inactive" }, new SelectListItem { Value = "Active", Text = "Active" } };

        //}
    }
}