using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ShopTheThao.Models;

namespace ShopTheThao.Controllers
{
    public class SanPhamController : Controller
    {
            ShopTheThaoEntities8 db = new ShopTheThaoEntities8();


        public ActionResult DanhMuc()
        {
           List<DanhMucSP> ketQua = db.DanhMucSP.ToList();
            return PartialView(ketQua);
        }



        // GET: DanhMucSanPham
        public ActionResult DanhSachSanPham(int? page)
        {
            if (page == null) page = 1;

            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo LinkID mới có thể phân trang.
            var lst = db.SanPham.OrderBy(x => x.MaSanPham);

            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 6;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return View(lst.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult ChiTietSanPham(int id)
        {
            //Tim ra doi tuong trong csdl

            SanPham ketQua = db.SanPham.Find(id);
            return View(ketQua);
        }
        public ActionResult DanhMucSanPham(string danhMuc, int id, int?page)
        {
            List<SanPham> ketQua = db.SanPham.Where(s => s.IDDanhMuc == id).ToList();
            ViewBag.DanhMuc = danhMuc;
            ViewBag.page = page ?? 1;
            return View(ketQua);
        }

        public ActionResult ThemMoi()
        {
            return View(new SanPham());
        }
        [HttpPost]
        public ActionResult ThemMoi(SanPham model)
        {
            // Lưu dữ liệu db
            if(string.IsNullOrEmpty (model.TenSanPham) == true)
            {
                ModelState.AddModelError("", "Tên sản phẩm không được để trống");
                return View(model);
            }    
            if(model.GiaBan <=0)
            {
                ModelState.AddModelError("", "Giá bán phải lớn hơn 0");
                return View(model);
            }

            // Lưu
            ShopTheThaoEntities8 db = new ShopTheThaoEntities8();
            // Hàm thêm mới
            db.SanPham.Add(model);
            // Hàm lưu dữ liệu
            db.SaveChanges();
            if(model.MaSanPham > 0)
            {
                return RedirectToAction("DanhSachSanPham");
            }    
            else
            {
                ModelState.AddModelError("", "Không lưu được vào cơ sở dữ liệu");
                return View(model);
            }

        }

        public ActionResult SanPhamNoiBat()
        {
            List<SanPham> ketQua = db.SanPham.OrderByDescending(m => m.MaSanPham).Take(6).ToList();
            return PartialView(ketQua);
        }

        public ActionResult SanPhamBanChay()
        {
            List<SanPham> ketQua = db.SanPham.OrderByDescending(m => m.GiaBan).Take(6).ToList();
            return PartialView(ketQua);
        }

    }
}