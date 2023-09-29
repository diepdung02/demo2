using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopTheThao.Models;

namespace ShopTheThao.Controllers
{
    public class ShopTheThaoController : Controller
    {
        // GET: ShopTheThao
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MainMenu()
        {
            return PartialView();
        }
    }
}