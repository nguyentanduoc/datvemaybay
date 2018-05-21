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
    public class LoaiGheAdminController : Controller
    {
        private DatVeMayBayDBEntities db = new DatVeMayBayDBEntities();

        // GET: Admin/LoaiGheAdmin
        public ActionResult Index()
        {
            ViewBag.loaighe = db.LOAIGHEs.ToList();
            return View();
        }

        // GET: Admin/LoaiGheAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIGHE lOAIGHE = db.LOAIGHEs.Find(id);
            if (lOAIGHE == null)
            {
                return HttpNotFound();
            }
            return View(lOAIGHE);
        }

        // GET: Admin/LoaiGheAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiGheAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_LOAIGHE,TEN_LOAIGHE,PHANTRAMGIA_LOAIGHE,TINHTRANG_LOAIGHE")] LOAIGHE lOAIGHE)
        {
            if (ModelState.IsValid)
            {
                db.LOAIGHEs.Add(lOAIGHE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAIGHE);
        }

        // GET: Admin/LoaiGheAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIGHE lOAIGHE = db.LOAIGHEs.Find(id);
            if (lOAIGHE == null)
            {
                return HttpNotFound();
            }
            return View(lOAIGHE);
        }

        // POST: Admin/LoaiGheAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_LOAIGHE,TEN_LOAIGHE,PHANTRAMGIA_LOAIGHE,TINHTRANG_LOAIGHE")] LOAIGHE lOAIGHE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAIGHE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAIGHE);
        }

        // GET: Admin/LoaiGheAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIGHE lOAIGHE = db.LOAIGHEs.Find(id);
            if (lOAIGHE == null)
            {
                return HttpNotFound();
            }
            return View(lOAIGHE);
        }

        // POST: Admin/LoaiGheAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOAIGHE lOAIGHE = db.LOAIGHEs.Find(id);
            db.LOAIGHEs.Remove(lOAIGHE);
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
