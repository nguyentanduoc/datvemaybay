using DatVeMayBay.EntityViews;
using ModelPlain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatVeMayBay.Controllers
{
    public class KhachHangController : Controller
    {
        DatVeMayBayDBEntities db = new DatVeMayBayDBEntities();
        // GET: KhachHang
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VeDaDat()
        {
            var sess = (UserSession)Session[Common.Constant.USER_SESSION];
            if (sess != null)
            {
                List<danhsachvekhachhang_Result> dsve = db.danhsachvekhachhang(sess.MaKH).ToList();
                return View(dsve);
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
          
        }
        public ActionResult ThemKhachHang()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemKhachHang(KHACHHANG kHACHHANG,string MatKhau)
        {
            if (ModelState.IsValid)
            {
                int ve = 0;
                HttpCookie appCookie = Request.Cookies["VE"];
                if (appCookie != null)
                {
                    ve = int.Parse(appCookie.Value);
                }              
               
                UserSession user = new UserSession();                             
                //them khach hang
                kHACHHANG.TINHTRANG_KHACHHANG = true;
                db.KHACHHANGs.Add(kHACHHANG);
                db.SaveChanges();
                //them tai khoa
                TAIKHOAN tk = new TAIKHOAN();
                tk.EMAIL_TAIKHOAN = kHACHHANG.EMAIL_KHACHHANG;
                tk.MATKHAU_TAIKHOAN = MatKhau;
                tk.TINHTRANG_TAIKHOAN = true;
                tk.MA_KHACHHANG = kHACHHANG.MA_KHACHHANG;
                db.TAIKHOANs.Add(tk);
                db.SaveChanges();

                //add khach hang vao session
                user.isAdmin = false;
                user.MaKH = kHACHHANG.MA_KHACHHANG;
                user.MaTK = tk.MA_TAIKHOAN;
                user.TenKH = kHACHHANG.TEN_KHACHHANG;
                Session.Add(Common.Constant.USER_SESSION, user);
                if(ve > 0)
                {
                    CHITIETDATVE cHITIETDATVE = new CHITIETDATVE();
                    cHITIETDATVE.MAVE = ve;
                    cHITIETDATVE.MA_KHACHHANG = kHACHHANG.MA_KHACHHANG;
                    cHITIETDATVE.NGAYDAT = DateTime.Now;
                    db.CHITIETDATVEs.Add(cHITIETDATVE);
                    db.SaveChanges();
                    return RedirectToAction("VeDaDat", "KhachHang");
                }             
            }
            return View();
        }

        public ActionResult TTKH()
        {
            var sess = (UserSession)Session[Common.Constant.USER_SESSION];
            return View(db.KHACHHANGs.Find(sess.MaKH));
        }
    }
}