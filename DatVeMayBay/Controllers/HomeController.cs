using DatVeMayBay.EntityViews;
using ModelPlain.DAO;
using ModelPlain.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatVeMayBay.Controllers
{
    public class HomeController : Controller
    {
        DatVeMayBayDBEntities db = new DatVeMayBayDBEntities();
        public void getSelectList()
        {
            ViewBag.maybay = new SanBayDAO().getList();         
        }

        public ActionResult Index()
        {
            getSelectList();
            return View();
        }

        [HttpGet]       
        public ActionResult Search(SearchEVTicket  searchEVTicket)
        {
            return View(db.search(searchEVTicket.NGAY_DI, searchEVTicket.MA_SAN_BAY_DEN, searchEVTicket.MA_SAN_BAY_DI).ToList());
        }

        public ActionResult DanhSachVE(int MaLG,int MCB)
        {
            return View(db.danhSachVe(MCB,MaLG));
        }

        public ActionResult DatVe(int MAVE)
        {
            var sess = (UserSession)Session[Common.Constant.USER_SESSION];
            if (sess != null)
            {
                CHITIETDATVE ctv = new CHITIETDATVE();
                ctv.MA_KHACHHANG = sess.MaKH;
                ctv.MAVE = MAVE;
                ctv.NGAYDAT = DateTime.Today;
                db.CHITIETDATVEs.Add(ctv);
                db.SaveChanges();
                return RedirectToAction("VeDaDat", "KhachHang");
            }
            else
            {
                //lưu lại vé khách hàng chọn
                HttpCookie cookie = new HttpCookie("VE", MAVE.ToString());
                cookie.Expires.AddHours(1);
                HttpContext.Response.SetCookie(cookie);                
                return RedirectToAction("ThemKhachHang","KhachHang");
            }
        }
    }
}