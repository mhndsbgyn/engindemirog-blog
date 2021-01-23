using engindemirog_blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace engindemirog_blog.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        EnginDBEntities db = new EnginDBEntities();
        public ActionResult Index()
        {
            var sorgu = db.Kategori.ToList();
            return View(sorgu);
        }
    }
}