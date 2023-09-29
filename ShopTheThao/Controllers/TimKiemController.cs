using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopTheThao.Models;
using PagedList;

namespace ShopTheThao.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        ShopTheThaoEntities8 db = new ShopTheThaoEntities8();

        [HttpGet]

        public ActionResult KQTimKiem(string sTuKhoa,int? page)
        {
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var lstSP = db.SanPham.Where(n => n.TenSanPham.Contains(sTuKhoa));
            ViewBag.TuKhoa = sTuKhoa;
            return View(lstSP.OrderBy(n => n.TenSanPham).ToPagedList(pageNumber,pageSize));
        }

        [HttpPost]
        public ActionResult KQTimKiem(string sTuKhoa, int? page,FormCollection  f)
        {
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var lstSP = db.SanPham.Where(n => n.TenSanPham.Contains(sTuKhoa));
            ViewBag.TuKhoa = sTuKhoa;
            return View(lstSP.OrderBy(n => n.TenSanPham).ToPagedList(pageNumber, pageSize));
        }


    }
}