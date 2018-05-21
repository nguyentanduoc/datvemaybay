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
    public class LoaiKhachHangController : Controller
    {
        private DatVeMayBayDBEntities db = new DatVeMayBayDBEntities();

        // GET: Admin/LoaiKhachHang
        public ActionResult Index()
        {
            ViewBag.loaikhachhang = db.LOAIKHACHes.ToList();
            return View();
        }

        // GET: Admin/LoaiKhachHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIKHACH lOAIKHACH = db.LOAIKHACHes.Find(id);
            if (lOAIKHACH == null)
            {
                return HttpNotFound();
            }
            return View(lOAIKHACH);
        }

        // GET: Admin/LoaiKhachHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiKhachHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_LOAIKHACH,TEN_LOAIKHACH,PHANTRAMGIA_LOAIKHACH,TINHTRANG_LOAIKHACH")] LOAIKHACH lOAIKHACH)
        {
            if (ModelState.IsValid)
            {
                db.LOAIKHACHes.Add(lOAIKHACH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAIKHACH);
        }

        // GET: Admin/LoaiKhachHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIKHACH lOAIKHACH = db.LOAIKHACHes.Find(id);
            if (lOAIKHACH == null)
            {
                return HttpNotFound();
            }
            return View(lOAIKHACH);
        }

        // POST: Admin/LoaiKhachHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_LOAIKHACH,TEN_LOAIKHACH,PHANTRAMGIA_LOAIKHACH,TINHTRANG_LOAIKHACH")] LOAIKHACH lOAIKHACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAIKHACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAIKHACH);
        }

        // GET: Admin/LoaiKhachHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIKHACH lOAIKHACH = db.LOAIKHACHes.Find(id);
            if (lOAIKHACH == null)
            {
                return HttpNotFound();
            }
            return View(lOAIKHACH);
        }

        // POST: Admin/LoaiKhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOAIKHACH lOAIKHACH = db.LOAIKHACHes.Find(id);
            db.LOAIKHACHes.Remove(lOAIKHACH);
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
