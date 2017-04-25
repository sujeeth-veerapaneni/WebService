using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthAPI.Models
{
    public class Health
    {
        public int HealthID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public decimal PhoneNumber { get; set; }

        public string Status { get; set; }
        public List<SelectListItem> StatusList { get; set; }

        public Health()
        {
            StatusList = new List<SelectListItem> { new SelectListItem { Value = "Inactive", Text = "Inactive" }, new SelectListItem { Value = "Active", Text = "Active" } };

        }
    }
}