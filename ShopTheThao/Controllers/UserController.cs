using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ShopTheThao.Models;

namespace ShopTheThao.Controllers
{
    public class UserController : Controller
    {
        ShopTheThaoEntities8 db = new ShopTheThaoEntities8();
        // GET: User

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(User user)
        {
            if (ModelState.IsValid)
            {
                var check = db.User.FirstOrDefault(s => s.Email == user.Email);
                var ktra = db.User.SingleOrDefault(s => s.UserName == user.UserName);
                if (check == null)
                {
                    
                    user.Password = GetMD5(user.Password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.User.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("DangNhap");
                }
                else
                {
                    ViewBag.error = "Email đã tồn tại! Xin vui lòng sử dụng email khác";
                    return View();
                }
            }
            return View();
        }
        //Đăng nhập
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(User user)
        {
            var check = db.User.Where(s => s.UserName.Equals(user.UserName)
            && s.Password.Equals(user.Password)).FirstOrDefault();
            if (check == null)
            {
                user.LoginErrorMessage = "Tên đăng nhập và mật khẩu không đúng!";
                return View("DangNhap", user);
            }    
            else
            {
                Session["ID"] = user.ID;
                Session["UserName"] = user.UserName;
                return RedirectToAction("Index", "ShopTheThao");
            }    
        }
        public ActionResult DangXuat()
        {
            Session.Abandon();
            return RedirectToAction("DangNhap", "User");
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2string = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2string += targetData[i].ToString("x2");
            }
            return byte2string;
        }

    }

}
       