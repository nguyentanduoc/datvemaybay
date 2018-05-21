using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DatVeMayBay.EntityViews
{
    public class RegisterEV
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Enter Full Name")]
        public string FullName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Enter Your Email")]
        public string User { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Enter Your PassWord")]
        public string PassWord { get; set; }
    }
}