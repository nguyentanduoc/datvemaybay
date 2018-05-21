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
    public class MayBayAdminController : Controller
    {
        private DatVeMayBayDBEntities db = new DatVeMayBayDBEntities();

        // GET: Admin/MayBayAdmin
        public ActionResult Index()
        {
            ViewBag.maybay = db.MAYBAYs.ToList();
            return View();
        }

        // GET: Admin/MayBayAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAYBAY mAYBAY = db.MAYBAYs.Find(id);
            if (mAYBAY == null)
            {
                return HttpNotFound();
            }
            return View(mAYBAY);
        }

        // GET: Admin/MayBayAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MayBayAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_MAYBAY,SOHIEU_MAYBAY,TINHTRANG_MAYBAY")] MAYBAY mAYBAY)
        {
            if (ModelState.IsValid)
            {
                db.MAYBAYs.Add(mAYBAY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mAYBAY);
        }

        // GET: Admin/MayBayAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAYBAY mAYBAY = db.MAYBAYs.Find(id);
            if (mAYBAY == null)
            {
                return HttpNotFound();
            }
            return View(mAYBAY);
        }

        // POST: Admin/MayBayAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_MAYBAY,SOHIEU_MAYBAY,TINHTRANG_MAYBAY")] MAYBAY mAYBAY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mAYBAY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mAYBAY);
        }

        // GET: Admin/MayBayAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAYBAY mAYBAY = db.MAYBAYs.Find(id);
            if (mAYBAY == null)
            {
                return HttpNotFound();
            }
            return View(mAYBAY);
        }

        // POST: Admin/MayBayAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MAYBAY mAYBAY = db.MAYBAYs.Find(id);
            db.MAYBAYs.Remove(mAYBAY);
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
