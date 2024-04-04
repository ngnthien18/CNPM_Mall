using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CNPMLyThuyet.Model;

namespace CNPMLyThuyet.Controllers
{
    public class KinhDoanhMBController : Controller
    {
        private TTMaiEntities db = new TTMaiEntities();

        // GET: MatBangs/
        public ActionResult Index(string searchby, bool? dathue)
        {

            if (searchby == "Tầng 1")
            {
                if (dathue == true)
                {
                    return View(db.MatBangs.Where(p => p.Tang.TenTang.Contains("Tầng 1") && p.TinhTrang.Contains("Chưa thuê")));
                }
                else
                {
                    return View(db.MatBangs.Where(p => p.Tang.TenTang.Contains("Tầng 1")));
                }
            }
            if (searchby == "Tầng 2")
            {
                if (dathue == true)
                {
                    return View(db.MatBangs.Where(p => p.Tang.TenTang.Contains("Tầng 2") && p.TinhTrang.Contains("Đã thuê")));
                }
                if (dathue == false)
                {
                    return View(db.MatBangs.Where(p => p.Tang.TenTang.Contains("Tầng 2") && p.TinhTrang.Contains("Chưa thuê")));
                }
                else
                {
                    return View(db.MatBangs.Where(p => p.Tang.TenTang.Contains("Tầng 2")));
                }
            }
            if (searchby == "Tầng 3")
            {
                if (dathue == true)
                {
                    return View(db.MatBangs.Where(p => p.Tang.TenTang.Contains("Tầng 3") && p.TinhTrang.Contains("Đã thuê")));
                }
                if (dathue == false)
                {
                    return View(db.MatBangs.Where(p => p.Tang.TenTang.Contains("Tầng 3") && p.TinhTrang.Contains("Chưa thuê")));
                }
                else
                {
                    return View(db.MatBangs.Where(p => p.Tang.TenTang.Contains("Tầng 3")));
                }
            }
            else
            {
                var matBangs = db.MatBangs.Include(m => m.KhachHang).Include(m => m.Tang);
                return View(matBangs.ToList());
            }


        }

        // GET: MatBangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatBang matBang = db.MatBangs.Find(id);
            if (matBang == null)
            {
                return HttpNotFound();
            }
            return View(matBang);
        }

        // GET: MatBangs/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoVaTen");
            ViewBag.MaTang = new SelectList(db.Tangs, "MaTang", "TenTang");
            return View();
        }

        // POST: MatBangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMB,TenMB,TinhTrang,GiaTien,MaTang,MaKH,ImagePath")] MatBang matBang, HttpPostedFileBase ImagePath)
        {
            if (ModelState.IsValid)
            {

                if (ImagePath != null)
                {
                    //Lấy tên file của hình được up lên
                    var fileName = Path.GetFileName(ImagePath.FileName);
                    //Tạo đường dẫn tới file
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    //Lưu tên
                    matBang.ImagePath = fileName;
                    //Save vào Images Folder
                    ImagePath.SaveAs(path);
                }
                db.MatBangs.Add(matBang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoVaTen", matBang.MaKH);
            ViewBag.MaTang = new SelectList(db.Tangs, "MaTang", "TenTang", matBang.MaTang);
            return View(matBang);
        }

        // GET: MatBangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatBang matBang = db.MatBangs.Find(id);
            if (matBang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoVaTen", matBang.MaKH);
            ViewBag.MaTang = new SelectList(db.Tangs, "MaTang", "TenTang", matBang.MaTang);
            return View(matBang);
        }

        // POST: MatBangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMB,TenMB,TinhTrang,GiaTien,MaTang,MaKH,ImagePath")] MatBang matBang, HttpPostedFileBase ImagePath)
        {
            if (ModelState.IsValid)
            {
                var matbangDB = db.MatBangs.FirstOrDefault(p => p.MaMB == matBang.MaMB);
                if (matbangDB != null)
                {
                    matbangDB.TenMB = matBang.TenMB;
                    matbangDB.TinhTrang = matBang.TinhTrang;
                    matbangDB.GiaTien = matBang.GiaTien;
                    if (ImagePath != null)
                    {
                        //Lấy tên file của hình được up lên
                        var fileName = Path.GetFileName(ImagePath.FileName);
                        //Tạo đường dẫn tới file
                        var path = Path.Combine(Server.MapPath("~/Images"),
                       fileName);
                        //Lưu tên
                        matbangDB.ImagePath = fileName;
                        //Save vào Images Folder
                        ImagePath.SaveAs(path);
                    }
                    matbangDB.MaKH = matBang.MaKH;
                    matbangDB.MaTang = matBang.MaTang;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoVaTen", matBang.MaKH);
            ViewBag.MaTang = new SelectList(db.Tangs, "MaTang", "TenTang", matBang.MaTang);
            return View(matBang);
        }

        // GET: MatBangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatBang matBang = db.MatBangs.Find(id);
            if (matBang == null)
            {
                return HttpNotFound();
            }
            return View(matBang);
        }

        // POST: MatBangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MatBang matBang = db.MatBangs.Find(id);
            db.MatBangs.Remove(matBang);
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
