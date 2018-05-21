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
    public class SanBayAdminController : Controller
    {
        private DatVeMayBayDBEntities db = new DatVeMayBayDBEntities();

        // GET: Admin/SanBayAdmin
        public ActionResult Index()
        {
            var sANBAYs = db.SANBAYs.Include(s => s.QUOCGIA);
            return View(sANBAYs.ToList());
        }

        // GET: Admin/SanBayAdmin/Create
        public ActionResult Create()
        {
            ViewBag.MA_QUOCGIA = new SelectList(db.QUOCGIAs, "MA_QUOCGIA", "TEN_QUOCGIA");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_SANBAY,MA_QUOCGIA,TEN_SANBAY,TINHTRANG_SANBAY,DIACHI_SANBAY")] SANBAY sANBAY)
        {
            if (ModelState.IsValid)
            {
                db.SANBAYs.Add(sANBAY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MA_QUOCGIA = new SelectList(db.QUOCGIAs, "MA_QUOCGIA", "TEN_QUOCGIA", sANBAY.MA_QUOCGIA);
            return View(sANBAY);
        }

        // GET: Admin/SanBayAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANBAY sANBAY = db.SANBAYs.Find(id);
            if (sANBAY == null)
            {
                return HttpNotFound();
            }
            ViewBag.MA_QUOCGIA = new SelectList(db.QUOCGIAs, "MA_QUOCGIA", "TEN_QUOCGIA", sANBAY.MA_QUOCGIA);
            return View(sANBAY);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_SANBAY,MA_QUOCGIA,TEN_SANBAY,TINHTRANG_SANBAY,DIACHI_SANBAY")] SANBAY sANBAY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sANBAY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MA_QUOCGIA = new SelectList(db.QUOCGIAs, "MA_QUOCGIA", "TEN_QUOCGIA", sANBAY.MA_QUOCGIA);
            return View(sANBAY);
        }

        // GET: Admin/SanBayAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANBAY sANBAY = db.SANBAYs.Find(id);
            if (sANBAY == null)
            {
                return HttpNotFound();
            }
            return View(sANBAY);
        }

        // POST: Admin/SanBayAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SANBAY sANBAY = db.SANBAYs.Find(id);
            db.SANBAYs.Remove(sANBAY);
            db.SaveChanges();
            return RedirectToAction("Index");
        }       
    }
}
