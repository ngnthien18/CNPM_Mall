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
    public class KinhDoanhKHController : Controller
    {
        private TTMaiEntities db = new TTMaiEntities();

        // GET: KinhDoanhKH
        public ActionResult Index()
        {
            var khachHangs = db.KhachHangs.Include(k => k.User);
            return View(khachHangs.ToList());
        }

        // GET: KinhDoanhKH/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // GET: KinhDoanhKH/Create
        public ActionResult Create()
        {
            ViewBag.IDUSER = new SelectList(db.Users, "IDUSER", "NameID");
            return View();
        }

        // POST: KinhDoanhKH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,HoVaTen,DiaCHi,NgaySinh,NgayGiaNhap,SDT,Email,IDUSER")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDUSER = new SelectList(db.Users, "IDUSER", "NameID", khachHang.IDUSER);
            return View(khachHang);
        }

        // GET: KinhDoanhKH/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDUSER = new SelectList(db.Users, "IDUSER", "NameID", khachHang.IDUSER);
            return View(khachHang);
        }

        // POST: KinhDoanhKH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,HoVaTen,DiaCHi,NgaySinh,NgayGiaNhap,SDT,Email,IDUSER")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDUSER = new SelectList(db.Users, "IDUSER", "NameID", khachHang.IDUSER);
            return View(khachHang);
        }

        // GET: KinhDoanhKH/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: KinhDoanhKH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KhachHang khachHang = db.KhachHangs.Find(id);
            db.KhachHangs.Remove(khachHang);
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
