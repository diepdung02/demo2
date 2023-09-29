using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopTheThao.Models
{
    public class GioHang1
    {

        ShopTheThaoEntities8 db = new ShopTheThaoEntities8();
        public  int  iMaSanPham { get; set; }
        public string sTenSanPham { get; set; }

        public string sHinhChinh { get; set; }
        public double dGiaBan { get; set; }
        public int iSoLuong { get; set; }
        public double dThanhTien
        {
            get
            { return iSoLuong * dGiaBan; }
        }

        public GioHang1(int ms)
        {
            iMaSanPham = ms;
            SanPham s = db.SanPham.Single(n => n.MaSanPham == iMaSanPham);
            sTenSanPham = s.TenSanPham;
            sHinhChinh = s.HinhChinh;
            dGiaBan = double.Parse(s.GiaBan.ToString());
            iSoLuong = 1;
        }




    }
}