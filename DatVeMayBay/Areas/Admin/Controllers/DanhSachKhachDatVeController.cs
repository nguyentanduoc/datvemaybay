using ModelPlain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatVeMayBay.Areas.Admin.Controllers
{
    public class DanhSachKhachDatVeController : Controller
    {
        private DatVeMayBayDBEntities db = new DatVeMayBayDBEntities();

        public ActionResult Index()
        {
            List<CHITIETDATVE> ctv = db.CHITIETDATVEs.OrderBy(x=>x.NGAYDAT).ToList();  
            return View(ctv);
        }
        public ActionResult TTK(int id)
        {
            KHACHHANG kh = db.KHACHHANGs.Find(id);
            return View(kh);
        }
    }
}