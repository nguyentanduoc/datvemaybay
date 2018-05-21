using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelPlain.EF;

namespace DatVeMayBay.Areas.Admin.Controllers
{
    public class ChuyenBayAdminController : Controller
    {
        private DatVeMayBayDBEntities db = new DatVeMayBayDBEntities();

        // GET: Admin/ChuyenBayAdmin
        public ActionResult Index()
        {
            var cHUYENBAYs = db.CHUYENBAYs.Include(c => c.MAYBAY).Include(c => c.TUYENBAY);
            return View(cHUYENBAYs.ToList());
        }

        // GET: Admin/ChuyenBayAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUYENBAY cHUYENBAY = db.CHUYENBAYs.Find(id);
            if (cHUYENBAY == null)
            {
                return HttpNotFound();
            }
            return View(cHUYENBAY);
        }

        // GET: Admin/ChuyenBayAdmin/Create
        public ActionResult Create()
        {
            ViewBag.MA_MAYBAY = new SelectList(db.MAYBAYs, "MA_MAYBAY", "SOHIEU_MAYBAY");
            ViewBag.MA_TUYENBAY = new SelectList(db.TUYENBAYs, "MA_TUYENBAY", "GIOITHIEU_TUYENBAY");
            return View();
        }

        // POST: Admin/ChuyenBayAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_CHUYENBAY,MA_TUYENBAY,MA_MAYBAY,TEN_CHUYENBAY,NGAYBAY_CHUYENBAY,GIOBAY_CHUYENBAY")] CHUYENBAY cHUYENBAY)
        {
            if (ModelState.IsValid)
            {
                
                db.CHUYENBAYs.Add(cHUYENBAY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MA_MAYBAY = new SelectList(db.MAYBAYs, "MA_MAYBAY", "SOHIEU_MAYBAY", cHUYENBAY.MA_MAYBAY);
            ViewBag.MA_TUYENBAY = new SelectList(db.TUYENBAYs, "MA_TUYENBAY", "GIOITHIEU_TUYENBAY", cHUYENBAY.MA_TUYENBAY);
            return View(cHUYENBAY);
        }

        // GET: Admin/ChuyenBayAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUYENBAY cHUYENBAY = db.CHUYENBAYs.Find(id);
            if (cHUYENBAY == null)
            {
                return HttpNotFound();
            }
            ViewBag.MA_MAYBAY = new SelectList(db.MAYBAYs, "MA_MAYBAY", "SOHIEU_MAYBAY", cHUYENBAY.MA_MAYBAY);
            ViewBag.MA_TUYENBAY = new SelectList(db.TUYENBAYs, "MA_TUYENBAY", "GIOITHIEU_TUYENBAY", cHUYENBAY.MA_TUYENBAY);
            return View(cHUYENBAY);
        }

        // POST: Admin/ChuyenBayAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_CHUYENBAY,MA_TUYENBAY,MA_MAYBAY,TEN_CHUYENBAY,NGAYBAY_CHUYENBAY,GIOBAY_CHUYENBAY")] CHUYENBAY cHUYENBAY)
        {
            if (ModelState.IsValid)
            {

                db.Entry(cHUYENBAY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MA_MAYBAY = new SelectList(db.MAYBAYs, "MA_MAYBAY", "SOHIEU_MAYBAY", cHUYENBAY.MA_MAYBAY);
            ViewBag.MA_TUYENBAY = new SelectList(db.TUYENBAYs, "MA_TUYENBAY", "GIOITHIEU_TUYENBAY", cHUYENBAY.MA_TUYENBAY);
            return View(cHUYENBAY);
        }

        // GET: Admin/ChuyenBayAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUYENBAY cHUYENBAY = db.CHUYENBAYs.Find(id);
            if (cHUYENBAY == null)
            {
                return HttpNotFound();
            }
            return View(cHUYENBAY);
        }

        // POST: Admin/ChuyenBayAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHUYENBAY cHUYENBAY = db.CHUYENBAYs.Find(id);
            db.CHUYENBAYs.Remove(cHUYENBAY);
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
