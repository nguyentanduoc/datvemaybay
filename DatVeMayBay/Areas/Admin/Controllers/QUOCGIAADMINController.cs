using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelPlain.DAO;
using ModelPlain.EF;

namespace DatVeMayBay.Areas.Admin.Controllers
{
    public class QUOCGIAADMINController : Controller
    {
        QuocGiaDAO quocgia = null;

        // GET: Admin/QUOCGIAADMIN
        public ActionResult Index()
        {
            quocgia = new QuocGiaDAO();
            ViewBag.quocgia = quocgia.getList();
            return View();
        }

        // GET: Admin/QUOCGIAADMIN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quocgia = new QuocGiaDAO();
            QUOCGIA qUOCGIA = quocgia.getByID(id);
            if (qUOCGIA == null)
            {
                return HttpNotFound();
            }
            return View(qUOCGIA);
        }

        // GET: Admin/QUOCGIAADMIN/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/QUOCGIAADMIN/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_QUOCGIA,TEN_QUOCGIA,TINHTRANG_QUOCGIA")] QUOCGIA qUOCGIA)
        {
            if (ModelState.IsValid)
            {
                var rs = new QuocGiaDAO().Create(qUOCGIA);
                if (rs.MA_QUOCGIA > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                }             
            }
            return View(qUOCGIA);
        }

        // GET: Admin/QUOCGIAADMIN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quocgia = new QuocGiaDAO();
            QUOCGIA qUOCGIA = quocgia.getByID(id);
            if (qUOCGIA == null)
            {
                return HttpNotFound();
            }
            return View(qUOCGIA);
        }

        // POST: Admin/QUOCGIAADMIN/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_QUOCGIA,TEN_QUOCGIA,TINHTRANG_QUOCGIA")] QUOCGIA qUOCGIA)
        {
            if (ModelState.IsValid)
            {
                quocgia = new QuocGiaDAO();
                quocgia.Edit(qUOCGIA);               
                return RedirectToAction("Index");
            }
            return View(qUOCGIA);
        }
        // GET: Admin/QUOCGIAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quocgia = new QuocGiaDAO();
            QUOCGIA qUOCGIA = quocgia.getByID(id);
            if (qUOCGIA == null)
            {
                return HttpNotFound();
            }
            return View(qUOCGIA);
        }

        // POST: Admin/QUOCGIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            quocgia = new QuocGiaDAO();
            quocgia.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
