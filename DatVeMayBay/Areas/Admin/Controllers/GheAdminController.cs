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
    public class GheAdminController : Controller
    {
        private DatVeMayBayDBEntities db = new DatVeMayBayDBEntities();

        // GET: Admin/GheAdmin
        public ActionResult Index()
        {
            var gHEs = db.GHEs.Include(g => g.LOAIGHE).Include(g => g.MAYBAY);
            ViewBag.ghe = gHEs.ToList();
            ViewBag.MA_LOAIGHE = new SelectList(db.LOAIGHEs, "MA_LOAIGHE", "TEN_LOAIGHE");
            ViewBag.MA_MAYBAY = new SelectList(db.MAYBAYs, "MA_MAYBAY", "SOHIEU_MAYBAY");
            return View();
        }

        // GET: Admin/GheAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GHE gHE = db.GHEs.Find(id);
            if (gHE == null)
            {
                return HttpNotFound();
            }
            return View(gHE);
        }

        // GET: Admin/GheAdmin/Create
        public ActionResult Create()
        {
            ViewBag.MA_LOAIGHE = new SelectList(db.LOAIGHEs, "MA_LOAIGHE", "TEN_LOAIGHE");
            ViewBag.MA_MAYBAY = new SelectList(db.MAYBAYs, "MA_MAYBAY", "SOHIEU_MAYBAY");
            return View();
        }

        // POST: Admin/GheAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_GHE,MA_LOAIGHE,MA_MAYBAY,SOHIEU_GHE,TINHTRANG_GHE")] GHE gHE)
        {
            if (ModelState.IsValid)
            {
                db.GHEs.Add(gHE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MA_LOAIGHE = new SelectList(db.LOAIGHEs, "MA_LOAIGHE", "TEN_LOAIGHE", gHE.MA_LOAIGHE);
            ViewBag.MA_MAYBAY = new SelectList(db.MAYBAYs, "MA_MAYBAY", "SOHIEU_MAYBAY", gHE.MA_MAYBAY);
            return View(gHE);
        }

        // GET: Admin/GheAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GHE gHE = db.GHEs.Find(id);
            if (gHE == null)
            {
                return HttpNotFound();
            }
            ViewBag.MA_LOAIGHE = new SelectList(db.LOAIGHEs, "MA_LOAIGHE", "TEN_LOAIGHE", gHE.MA_LOAIGHE);
            ViewBag.MA_MAYBAY = new SelectList(db.MAYBAYs, "MA_MAYBAY", "SOHIEU_MAYBAY", gHE.MA_MAYBAY);
            return View(gHE);
        }

        // POST: Admin/GheAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_GHE,MA_LOAIGHE,MA_MAYBAY,SOHIEU_GHE,TINHTRANG_GHE")] GHE gHE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gHE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MA_LOAIGHE = new SelectList(db.LOAIGHEs, "MA_LOAIGHE", "TEN_LOAIGHE", gHE.MA_LOAIGHE);
            ViewBag.MA_MAYBAY = new SelectList(db.MAYBAYs, "MA_MAYBAY", "SOHIEU_MAYBAY", gHE.MA_MAYBAY);
            return View(gHE);
        }

        // GET: Admin/GheAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GHE gHE = db.GHEs.Find(id);
            if (gHE == null)
            {
                return HttpNotFound();
            }
            return View(gHE);
        }

        // POST: Admin/GheAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GHE gHE = db.GHEs.Find(id);
            db.GHEs.Remove(gHE);
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
