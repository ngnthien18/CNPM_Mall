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
    public class ChiTietBaoTrisController : Controller
    {
        private TTMaiEntities db = new TTMaiEntities();

        // GET: ChiTietBaoTris
        public ActionResult Index()
        {
            var chiTietBaoTris = db.ChiTietBaoTris.Include(c => c.NhanVien).Include(c => c.ThietBi);
            return View(chiTietBaoTris.ToList());
        }

        // GET: ChiTietBaoTris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietBaoTri chiTietBaoTri = db.ChiTietBaoTris.Find(id);
            if (chiTietBaoTri == null)
            {
                return HttpNotFound();
            }
            return View(chiTietBaoTri);
        }

        // GET: ChiTietBaoTris/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "MaNV");
            ViewBag.MaTB = new SelectList(db.ThietBis, "MaTB", "MaTB");
            return View();
        }

        // POST: ChiTietBaoTris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STT,MaNV,MaTB,NgayBaoTri,ChiPhi")] ChiTietBaoTri chiTietBaoTri)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietBaoTris.Add(chiTietBaoTri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "MaNV", chiTietBaoTri.MaNV);
            ViewBag.MaTB = new SelectList(db.ThietBis, "MaTB", "MaTB", chiTietBaoTri.MaTB);
            return View(chiTietBaoTri);
        }

        // GET: ChiTietBaoTris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietBaoTri chiTietBaoTri = db.ChiTietBaoTris.Find(id);
            if (chiTietBaoTri == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "MaNV", chiTietBaoTri.MaNV);
            ViewBag.MaTB = new SelectList(db.ThietBis, "MaTB", "MaTB", chiTietBaoTri.MaTB);
            return View(chiTietBaoTri);
        }

        // POST: ChiTietBaoTris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STT,MaNV,MaTB,NgayBaoTri,ChiPhi")] ChiTietBaoTri chiTietBaoTri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietBaoTri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "MaNV", chiTietBaoTri.MaNV);
            ViewBag.MaTB = new SelectList(db.ThietBis, "MaTB", "MaTB", chiTietBaoTri.MaTB);
            return View(chiTietBaoTri);
        }

        // GET: ChiTietBaoTris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietBaoTri chiTietBaoTri = db.ChiTietBaoTris.Find(id);
            if (chiTietBaoTri == null)
            {
                return HttpNotFound();
            }
            return View(chiTietBaoTri);
        }

        // POST: ChiTietBaoTris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietBaoTri chiTietBaoTri = db.ChiTietBaoTris.Find(id);
            db.ChiTietBaoTris.Remove(chiTietBaoTri);
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
