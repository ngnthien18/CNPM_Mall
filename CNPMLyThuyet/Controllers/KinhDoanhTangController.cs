using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CNPMLyThuyet.Model;

namespace CNPMLyThuyet.Controllers
{
    public class KinhDoanhTangController : Controller
    {
        private TTMaiEntities db = new TTMaiEntities();

        // GET: KinhDoanhTang
        public ActionResult Index()
        {
            return View(db.Tangs.ToList());
        }

        // GET: KinhDoanhTang/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tang tang = db.Tangs.Find(id);
            if (tang == null)
            {
                return HttpNotFound();
            }
            return View(tang);
        }

        // GET: KinhDoanhTang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KinhDoanhTang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTang,TenTang")] Tang tang)
        {
            if (ModelState.IsValid)
            {
                db.Tangs.Add(tang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tang);
        }

        // GET: KinhDoanhTang/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tang tang = db.Tangs.Find(id);
            if (tang == null)
            {
                return HttpNotFound();
            }
            return View(tang);
        }

        // POST: KinhDoanhTang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTang,TenTang")] Tang tang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tang);
        }

        // GET: KinhDoanhTang/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tang tang = db.Tangs.Find(id);
            if (tang == null)
            {
                return HttpNotFound();
            }
            return View(tang);
        }

        // POST: KinhDoanhTang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Tang tang = db.Tangs.Find(id);
            db.Tangs.Remove(tang);
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
