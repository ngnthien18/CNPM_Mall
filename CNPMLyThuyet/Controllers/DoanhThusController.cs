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
    public class DoanhThusController : Controller
    {
        private TTMaiEntities db = new TTMaiEntities();

        // GET: DoanhThus
        public ActionResult Index()
        {
            var doanhThus = db.DoanhThus.Include(d => d.MatBang);
            return View(doanhThus.ToList());
        }

        // GET: DoanhThus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoanhThu doanhThu = db.DoanhThus.Find(id);
            if (doanhThu == null)
            {
                return HttpNotFound();
            }
            return View(doanhThu);
        }

        // GET: DoanhThus/Create
        public ActionResult Create()
        {
            ViewBag.MaMB = new SelectList(db.MatBangs, "MaMB", "TenMB");
            return View();
        }

        // POST: DoanhThus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDT,Thang,Nam,TongTien,MaMB")] DoanhThu doanhThu)
        {
            if (ModelState.IsValid)
            {
                db.DoanhThus.Add(doanhThu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaMB = new SelectList(db.MatBangs, "MaMB", "TenMB", doanhThu.MaMB);
            return View(doanhThu);
        }

        // GET: DoanhThus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoanhThu doanhThu = db.DoanhThus.Find(id);
            if (doanhThu == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMB = new SelectList(db.MatBangs, "MaMB", "TenMB", doanhThu.MaMB);
            return View(doanhThu);
        }

        // POST: DoanhThus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDT,Thang,Nam,TongTien,MaMB")] DoanhThu doanhThu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doanhThu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaMB = new SelectList(db.MatBangs, "MaMB", "TenMB", doanhThu.MaMB);
            return View(doanhThu);
        }

        // GET: DoanhThus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoanhThu doanhThu = db.DoanhThus.Find(id);
            if (doanhThu == null)
            {
                return HttpNotFound();
            }
            return View(doanhThu);
        }

        // POST: DoanhThus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoanhThu doanhThu = db.DoanhThus.Find(id);
            db.DoanhThus.Remove(doanhThu);
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
