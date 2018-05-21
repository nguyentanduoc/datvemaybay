using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelPlain.EF;

namespace DatVeMayBay.Areas.Admin.Controllers
{
    public class TuyenBayAdminController : Controller
    {
        private DatVeMayBayDBEntities db = new DatVeMayBayDBEntities();

        // GET: Admin/TuyenBayAdmin
        public ActionResult Index()
        {
            var tUYENBAYs = db.TUYENBAYs.Include(t => t.SANBAY).Include(t => t.SANBAY1);
            return View(tUYENBAYs.ToList());
        }

        // GET: Admin/TuyenBayAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TUYENBAY tUYENBAY = db.TUYENBAYs.Find(id);
            if (tUYENBAY == null)
            {
                return HttpNotFound();
            }
            return View(tUYENBAY);
        }

    
        public ActionResult Create()
        {
            ViewBag.MA_SANBAY_DI = new SelectList(db.SANBAYs, "MA_SANBAY", "TEN_SANBAY");
            ViewBag.MA_SANBAY_DEN = new SelectList(db.SANBAYs, "MA_SANBAY", "TEN_SANBAY");
            return View();
        }
            
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TUYENBAY tUYENBAY, HttpPostedFileBase file)
        {

            var f = Request.Files["Upload"];
            if (f != null && f.ContentLength > 0 && ModelState.IsValid)
            {
                if(tUYENBAY.MA_SANBAY_DEN == tUYENBAY.MA_SANBAY_DI)
                {
                    ModelState.AddModelError("", "Không thể tạo điểm đến và điểm đi trùng nhau");
                    ViewBag.MA_SANBAY_DI = new SelectList(db.SANBAYs, "MA_SANBAY", "TEN_SANBAY", tUYENBAY.MA_SANBAY_DI);
                    ViewBag.MA_SANBAY_DEN = new SelectList(db.SANBAYs, "MA_SANBAY", "TEN_SANBAY", tUYENBAY.MA_SANBAY_DEN);
                    return View();
                }
                else
                {
                    var path = Path.Combine(Server.MapPath("~/Content/images/"), Path.GetFileName(f.FileName));
                    f.SaveAs(path);

                    tUYENBAY.HINHANH_TUYENBAY = "images/" + Path.GetFileName(f.FileName);
                    db.TUYENBAYs.Add(tUYENBAY);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }               

            }
            ViewBag.MA_SANBAY_DI = new SelectList(db.SANBAYs, "MA_SANBAY", "TEN_SANBAY", tUYENBAY.MA_SANBAY_DI);
            ViewBag.MA_SANBAY_DEN = new SelectList(db.SANBAYs, "MA_SANBAY", "TEN_SANBAY", tUYENBAY.MA_SANBAY_DEN);
            return View(tUYENBAY);
        }

        // GET: Admin/TuyenBayAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TUYENBAY tUYENBAY = db.TUYENBAYs.Find(id);
            if (tUYENBAY == null)
            {
                return HttpNotFound();
            }
            ViewBag.MA_SANBAY_DI = new SelectList(db.SANBAYs, "MA_SANBAY", "TEN_SANBAY", tUYENBAY.MA_SANBAY_DI);
            ViewBag.MA_SANBAY_DEN = new SelectList(db.SANBAYs, "MA_SANBAY", "TEN_SANBAY", tUYENBAY.MA_SANBAY_DEN);
            return View(tUYENBAY);
        }

        // POST: Admin/TuyenBayAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TUYENBAY tUYENBAY, HttpPostedFileBase file)
        {
            var f = Request.Files["Upload"];
            if (ModelState.IsValid)
            {
                if (f != null && f.ContentLength > 0)
                {
                    string filename = "~/Content/images/" + f.FileName;                   
                    var path = Path.Combine(Server.MapPath("~/Content/images/"), Path.GetFileName(f.FileName));
                    f.SaveAs(path);
                    tUYENBAY.HINHANH_TUYENBAY = "images/" + Path.GetFileName(f.FileName);                                    
                }
                db.Entry(tUYENBAY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MA_SANBAY_DI = new SelectList(db.SANBAYs, "MA_SANBAY", "TEN_SANBAY", tUYENBAY.MA_SANBAY_DI);
            ViewBag.MA_SANBAY_DEN = new SelectList(db.SANBAYs, "MA_SANBAY", "TEN_SANBAY", tUYENBAY.MA_SANBAY_DEN);
            return View(tUYENBAY);
        }

        // GET: Admin/TuyenBayAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TUYENBAY tUYENBAY = db.TUYENBAYs.Find(id);
            if (tUYENBAY == null)
            {
                return HttpNotFound();
            }
            return View(tUYENBAY);
        }

        // POST: Admin/TuyenBayAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TUYENBAY tUYENBAY = db.TUYENBAYs.Find(id);
            db.TUYENBAYs.Remove(tUYENBAY);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
