using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatVeMayBay.EntityViews
{
    public class ListVeEV
    {
        public int SL { get; set; }
        public int MA_LOAIGHE {get;set;}
        public string TEN_LOAIGHE { get; set; }
        public float GIAVE { get; set; }
        public DateTime NGAYBAY_CHUYENBAY { get; set; }
        public TimeSpan GIOBAY_CHUYENBAY { get; set; }
        public string HINHANH_TUYENBAY { get; set; }
    }
}