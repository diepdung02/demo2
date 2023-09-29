using ShopTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ShopTheThao.Controllers
{
    public class GioHang11Controller : Controller
    {
        
        ShopTheThaoEntities8 db = new ShopTheThaoEntities8();
        // GET: GioHang11
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CapNhatGioHang1(int iMaSanPham, FormCollection f)
        {
            List<GioHang1> lstGioHang1 = LayGioHang1();
            GioHang1 sp = lstGioHang1.SingleOrDefault(n => n.iMaSanPham == iMaSanPham);
            if (sp != null)
            {
                sp.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang1");
        }
        [HttpGet]
        public ActionResult DatHang()
        {
            if (Session["User"] == null || Session["User"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "User");
            }
            if (Session["GioHang1"] == null)
            {
                return RedirectToAction("DanhSachSanPham", "SanPham");
            }
            List<GioHang1> lstGioHang1 = LayGioHang1();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(lstGioHang1);
        }

        [HttpPost]
        public ActionResult DatHang(FormCollection f )
        {
            DonDatHang ddh = new DonDatHang();
            User kh = (User)Session["User"];
            List<GioHang1> lstGioHang11 = LayGioHang1();
            int id_ddh = db.DonDatHang.Count() + 1;
            ddh.MaDonHang = id_ddh;
            ddh.DaThanhToan = false;
            ddh.TinhTrangGiaoHang = true;
            ddh.NgayDat = DateTime.Now;
            var Giao = DateTime.Now.AddDays(7).ToString();
            var NgayGiao = string.Format("{0:MM/dd/yyyy}", Giao);
            ddh.NgayGiao = DateTime.Parse(NgayGiao);
            ddh.MaKH = kh.ID;
            db.DonDatHang.Add(ddh);
            db.SaveChanges();
            // them chi tiet don hang
            foreach (var item in lstGioHang11)
            {
                ChiTietDatHang ctdh = new ChiTietDatHang();
                ctdh.MaDonHang = ddh.MaDonHang;
                ctdh.MaSP = item.iMaSanPham;
                ctdh.SoLuong = item.iSoLuong;
                ctdh.Gia = (decimal)item.dGiaBan;
                db.ChiTietDatHang.Add(ctdh);
            }
            db.SaveChanges();
            Session["GioHang1"] = null;
            return RedirectToAction("XacNhanDonHang", "GioHang1");
        }


        public ActionResult GioHang1()
        {
            if (Session["User"] == null || Session["User"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "User");
            }
            List<GioHang1> lstGioHang1 = LayGioHang1();
            ViewBag.Count = lstGioHang1.Count;
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(lstGioHang1);

        }
        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }

        public List<GioHang1> LayGioHang1()
        {
            List<GioHang1> lstGioHang1 = Session["GioHang1"] as List<GioHang1>;
            if (lstGioHang1 == null)
            {
                lstGioHang1 = new List<GioHang1>();
                Session["GioHang1"] = lstGioHang1;
            }
            return lstGioHang1;
        }
        public ActionResult XacNhanDonHang()
        {
            return View();
        }

        public ActionResult XoaSPKhoiGioHang(int id_MaSanPham)
        {
            List<GioHang1> lstGioHang1 = LayGioHang1();
            GioHang1 sp = lstGioHang1.SingleOrDefault(n => n.iMaSanPham == id_MaSanPham);
            if (sp != null)
            {
                lstGioHang1.RemoveAll(n => n.iMaSanPham == id_MaSanPham);
                if (lstGioHang1.Count == 0)
                {
                    return RedirectToAction("DanhSachSanPham", "SanPham");
                }
            }
            return RedirectToAction("GioHang1");
        }

        public ActionResult XoaGioHang1()
        {
            List<GioHang1> lst = LayGioHang1();
            lst.Clear();
            return RedirectToAction("GioHang1");
        }
        public ActionResult ThemGioHang(int iMaSanPham, string url)
        {
            
            List<GioHang1> lstGioHang1 = LayGioHang1();
            GioHang1 sp = lstGioHang1.Find(n => n.iMaSanPham == iMaSanPham);
            if (sp == null)
            {
                sp = new GioHang1(iMaSanPham);
                lstGioHang1.Add(sp);
            }
            else
            {
                sp.iSoLuong++;
            }

            return Redirect(url);
        }

        public int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang1> lstGioHang1 = Session["GioHang1"] as List<GioHang1>;
            if (lstGioHang1 != null)
            {
                iTongSoLuong = (int)lstGioHang1.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        public double TongTien()
        {
            double dTongTien = 0;
            List<GioHang1> lstGioHang1 = Session["GioHang1"] as List<GioHang1>;
            if (lstGioHang1 != null)
            {
                dTongTien = (double)lstGioHang1.Sum(n => n.dThanhTien);
            }
            return dTongTien;
        }
    }
}