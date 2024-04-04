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
    public class ThietBisController : Controller
    {
        private TTMaiEntities db = new TTMaiEntities();

        // GET: ThietBis
        public ActionResult Index()
        {
            return View(db.ThietBis.ToList());
        }

        // GET: ThietBis/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThietBi thietBi = db.ThietBis.Find(id);
            if (thietBi == null)
            {
                return HttpNotFound();
            }
            return View(thietBi);
        }

        // GET: ThietBis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThietBis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTB,TenTB,TinhTrang,NgaySuDung,SoLanBaoTri")] ThietBi thietBi)
        {
            if (ModelState.IsValid)
            {
                db.ThietBis.Add(thietBi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thietBi);
        }

        // GET: ThietBis/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThietBi thietBi = db.ThietBis.Find(id);
            if (thietBi == null)
            {
                return HttpNotFound();
            }
            return View(thietBi);
        }

        // POST: ThietBis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTB,TenTB,TinhTrang,NgaySuDung,SoLanBaoTri")] ThietBi thietBi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thietBi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thietBi);
        }

        // GET: ThietBis/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThietBi thietBi = db.ThietBis.Find(id);
            if (thietBi == null)
            {
                return HttpNotFound();
            }
            return View(thietBi);
        }

        // POST: ThietBis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ThietBi thietBi = db.ThietBis.Find(id);
            db.ThietBis.Remove(thietBi);
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
