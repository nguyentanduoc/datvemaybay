using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatVeMayBay.Common

{
    [Serializable]
    public class UserLogin
    {
        public int MaTaiKhoan { get; set; }
        public string TenTaiKhoan { get; set; }
    }
}