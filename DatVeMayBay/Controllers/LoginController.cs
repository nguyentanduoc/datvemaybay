using DatVeMayBay.EntityViews;
using ModelPlain.DAO;
using ModelPlain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatVeMayBay.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginEV loginEV)
        {
            if (ModelState.IsValid)
            {
                var dao = new TAIKHOANDAO();
                var result = dao.Login(loginEV.UserName, loginEV.PassWord);
                if (result == 1)
                {
                    var account = dao.getByUserName(loginEV.UserName);
                    var kh = new KHACHHANGDAO().getByID(account.MA_KHACHHANG);
                    UserSession userSession = new UserSession
                    {
                        isAdmin = account.ISADMIN,
                        TenKH = kh.TEN_KHACHHANG,
                        MaKH = kh.MA_KHACHHANG,
                        MaTK = account.MA_TAIKHOAN
                    };                   
                    Session.Add(Common.Constant.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại");
                }
            }
            return View("Index");
        }
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(RegisterEV registerEV)
        {
            if (ModelState.IsValid)
            {
                var dao = new KHACHHANGDAO();
                var rs = dao.Regiter(registerEV.FullName, registerEV.User, registerEV.PassWord);
                if(rs > 0)
                {
                    var kh = new KHACHHANGDAO().getByID(rs);
                    var idTK = new TAIKHOANDAO().getByIDKH(kh.MA_KHACHHANG);
                    UserSession userSession = new UserSession
                    {
                        isAdmin = false,
                        TenKH = kh.TEN_KHACHHANG,
                        MaKH = kh.MA_KHACHHANG,
                        MaTK = idTK.MA_TAIKHOAN
                    };
                    Session.Add(Common.Constant.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if(rs == -3)
                    ModelState.AddModelError("","Tài khoản tồn tại");
                }                
            }
            return  View();
        }
        public ActionResult Logout()
        {
            var userSession = new UserSession();
            userSession = null;
            Session.Add(Common.Constant.USER_SESSION, userSession);
            return RedirectToAction("Index", "Home");
        }        
    }
}