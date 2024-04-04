using CNPMLyThuyet.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CNPMLyThuyet.Controllers
{
    public class HomeController : Controller
    {
        TTMaiEntities db = new TTMaiEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult DanhSachMatBangs(string searchby, bool? dathue, bool? chuathue)
        {
            if (searchby == "Tầng 1")
            {
                if (dathue == true)
                {
                    return View(db.MatBangs.Where(p => p.Tang.TenTang.Contains("Tầng 1") && p.TinhTrang.Contains("Đã thuê")));
                }
                if (chuathue == true)
                {
                    return View(db.MatBangs.Where(p => p.Tang.TenTang.Contains("Tầng 1") && p.TinhTrang.Contains("Chưa thuê")));
                }

                else
                {
                    return View(db.MatBangs.Where(p => p.Tang.TenTang.Contains("Tầng 1")));
                }
            }
            if (searchby == "Tầng trệt")
            {
                if (dathue == true)
                {
                    return View(db.MatBangs.Where(p => p.Tang.TenTang.Contains("Tầng trệt") && p.TinhTrang.Contains("Đã thuê")));
                }
                if (chuathue == true)
                {
                    return View(db.MatBangs.Where(p => p.Tang.TenTang.Contains("Tầng trệt") && p.TinhTrang.Contains("Chưa thuê")));
                }

                else
                {
                    return View(db.MatBangs.Where(p => p.Tang.TenTang.Contains("Tầng trệt")));
                }
            }
            if (searchby == "Tầng 2")
            {
                if (dathue == true)
                {
                    return View(db.MatBangs.Where(p => p.Tang.TenTang.Contains("Tầng 2") && p.TinhTrang.Contains("Đã thuê")));
                }
                if (chuathue == true)
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
                if (chuathue == true)
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
                var matbangs = db.MatBangs.ToList();
                return View(matbangs.ToList());
            }

        }
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
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(KhachHang cust)
        {
            if (ModelState.IsValid)
            {
                var check = db.KhachHangs.Where(c => c.MaKH == cust.MaKH).FirstOrDefault();
                if (check == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.KhachHangs.Add(cust);
                    db.SaveChanges();

                    return RedirectToAction("ThongBao");
                }
                else
                {
                    ViewBag.ErrorRegister = "Mã của bạn đã được đăng ký";
                    return View();
                }
            }

            return View();
        }
        public ActionResult ThongBao()
        {
            return View();
        }
        public ActionResult KinhDoanh()
        {
            return View();
        }
        public ActionResult TaiChinh()
        {
            return View();
        }
        public ActionResult BaoCaoDoanhthu()
        {
            return View();
        }
        public List<sp_getyear2_Result> GetReportByYear(int year)
        {
             using(var db = new TTMaiEntities())
            {
                var lsData = db.sp_getyear2(year).ToList();
                return lsData;
            }
        }
        public ActionResult GetBaoCao(int year)
        {
            var lsData = GetReportByYear(year);
            return Json(lsData,JsonRequestBehavior.AllowGet);
        }
        public ActionResult NhanSu()
        {
            return View();
        }
        public ActionResult KyThuat()
        {
            return View();
        }
        public ActionResult NhapDoanhThu()
        {
            KhachHang khachhang = (KhachHang)Session["TaiKhoan"];
            var matbangs = db.MatBangs.Where(m => m.MaKH == khachhang.MaKH).FirstOrDefault();
            ViewBag.Khachhang = matbangs.MaMB;
            ViewBag.MaMB = new SelectList(db.MatBangs, "MaMB", "MaMB");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NhapDoanhThu([Bind(Include = "MaDT,Thang,Nam,TongTien,MaMB")] DoanhThu doanhThu)
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


    }
}