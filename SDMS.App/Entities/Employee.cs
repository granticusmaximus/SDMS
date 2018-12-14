using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SDMS.App.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        [Display(Name = "Address")]
        public string Addres { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }
    }
}