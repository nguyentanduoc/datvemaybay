using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatVeMayBay.EntityViews
{
    public class UserSession
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public int MaTK { get; set; }
        public bool? isAdmin { get; set; }
    }
}