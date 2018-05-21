using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatVeMayBay.EntityViews;
using ModelPlain.EF;

namespace DatVeMayBay.Areas.Admin.Controllers
{
    public class TaoVeAdminController : Controller
    {
        DatVeMayBayDBEntities db = new DatVeMayBayDBEntities();
        // GET: Admin/TaoVeAdmin
        public ActionResult Index()
        {
            List<TUYENBAY> DanhSachTuyen = db.TUYENBAYs.ToList();
            ViewBag.DanhSachTuyen = new SelectList(DanhSachTuyen, "MA_TUYENBAY", "TEN_TUYENBAY");
            return View();
        }

        public JsonResult LayChuyen(int idTuyen)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<CHUYENBAY> ChuyenBay = db.CHUYENBAYs.Where(x => x.MA_TUYENBAY == idTuyen).ToList();
            return Json(ChuyenBay, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult laySanBay(int idTuyen)
        {
            string sqlQuery;
            SqlParameter[] sqlParams;
            db.Configuration.ProxyCreationEnabled = false;
            try
            {
                sqlQuery = "getSanBay @idTuyen";
                sqlParams = new SqlParameter[]
                {
                    new SqlParameter{ParameterName="@idTuyen",Value=idTuyen,Direction = System.Data.ParameterDirection.Input}
                };
                QuocGiaEV rs = db.Database.SqlQuery<QuocGiaEV>(sqlQuery, sqlParams).SingleOrDefault();

                return Json(new { result = "oke", noidi = rs.SAN_BAI_DI, noiden = rs.SAN_BAY_DEN });
            }
            catch (Exception)
            {
                return Json(new { result = "false"});
            }
        }
        [HttpPost]
        public JsonResult LayVeTheoChuyenBay(int MaChuyen)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                //Where(x => x.MA_CHUYENBAY == MaChuyen).ToList();
                List<VE> ve = db.VEs.Include(c =>c.MA_CHUYENBAY).Include(g=>g.MA_GHE).Where(x => x.MA_CHUYENBAY == MaChuyen).ToList();
                return Json(ve, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { result = e });
            }
        }
        [HttpPost]
        public JsonResult TaoVe(int MaChuyen)
        {
            string sqlQuery;
            SqlParameter[] sqlParams;
            db.Configuration.ProxyCreationEnabled = false;
            try
            {
                sqlQuery = "sp_taove @machuyen";
                sqlParams = new SqlParameter[]
                {
                    new SqlParameter{ParameterName="@machuyen",Value=MaChuyen,Direction = System.Data.ParameterDirection.Input}
                };
                var rowsAffected = db.Database.ExecuteSqlCommand(sqlQuery, sqlParams);
                if(rowsAffected > 0)
                {
                    return LayVeTheoChuyenBay(MaChuyen);
                }
                else
                {
                    return Json(new { result = "failed"});
                }
               
            }
            catch (Exception)
            {
                return Json(new { result = "failed" });
            }           
        }
    }
}