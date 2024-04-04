using CNPMLyThuyet.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CNPMLyThuyet.Controllers
{
    public class AccountController : Controller
    {

        TTMaiEntities db = new TTMaiEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var users = db.Users.Where(k => k.NameID == user.NameID && k.Pass == user.Pass).FirstOrDefault();
            if (users != null)
            {
                var nhanvien = db.NhanViens.Where(k=>k.IDUSER==users.IDUSER).FirstOrDefault();
                if (nhanvien!= null)
                {
                    Session["TaiKhoan"] = nhanvien;
                    ViewBag.ThongBao = "Đăng nhập thành công ";
                    if (nhanvien.MaPB == "PNKD")
                    {
                        return RedirectToAction("KinhDoanh", "Home");
                    }
                    if (nhanvien.MaPB == "PNNS")
                    {
                        return RedirectToAction("NhanSu", "Home");
                    }
                    if (nhanvien.MaPB == "PNTC")
                    {
                        return RedirectToAction("TaiChinh", "Home");
                    }
                    if (nhanvien.MaPB == "PNKT")
                    {
                        return RedirectToAction("KyThuat", "Home");
                    }

                }
                else
                {
                   
                    var khachhang = db.KhachHangs.Where(k=>k.IDUSER ==users.IDUSER).FirstOrDefault();
                    Session["TaiKhoan"] = khachhang;
                    return RedirectToAction("Index", "Home");
                }
                

            }

            else ViewBag.ThongBao = "Tên đăng nhập hoặc tài khoản không đúng ";
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

    }
}