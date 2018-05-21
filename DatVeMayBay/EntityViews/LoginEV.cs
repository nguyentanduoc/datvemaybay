using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DatVeMayBay.EntityViews
{
    public partial class LoginEV
    {
        [StringLength(50)]
        [Display(Name = "Enter Your Email")]
        public string UserName { get; set; }

        [StringLength(15)]
        [Display(Name = "Enter PassWord")]
        public string PassWord { get; set; }

        public bool ReMemberMe { get; set; }
    }
}