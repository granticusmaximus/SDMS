using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SDMS.App.Entities
{
    public class Client
    {
        [Key]
        public int CID { get; set; }

        [Required]
        [Display(Name = "POC Name")]
        public string POCName { get; set; }

        [Required]
        [Display(Name = "POC Phone")]
        public string POCPhone { get; set; }

        [Required]
        [Display(Name = "POC Email")]
        [EmailAddress]
        public string POCEmail { get; set; }

        [Required]
        [Display(Name = "Business Name")]
        public string BName { get; set; }

        [Required]
        [Display(Name = "Business Phone")]
        public string BPhone { get; set; }
    }
}