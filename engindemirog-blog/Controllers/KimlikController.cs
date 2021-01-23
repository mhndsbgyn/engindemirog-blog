using engindemirog_blog.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace engindemirog_blog.Controllers
{
    public class KimlikController : Controller
    {
        // GET: Kimlik
        EnginDBEntities db = new EnginDBEntities();

        public ActionResult Index()
        {
            return View(db.Kimlik.ToList());
        }

   
        public ActionResult Edit(int id)
        {
            var kimlik = db.Kimlik.Where(x => x.KimlikId == id).SingleOrDefault();
            return View(kimlik);
        }

        // POST: Kimlik/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Kimlik kimlik, HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                var k = db.Kimlik.Where(x => x.KimlikId == id).SingleOrDefault();
                if(ResimURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(kimlik.ResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(kimlik.ResimURL));
                    }
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);

                    string logoname = ResimURL.FileName + imginfo.Extension;
                    img.Resize(200, 150);
                    img.Save("~/Uploads/Kimlik/" + logoname);


                    k.ResimURL = "/Uploads/Kimlik/" + logoname;

                }   
                    k.Title = kimlik.Title;
                    k.Keywords = kimlik.Keywords;
                    k.Decription = kimlik.Decription;
                    k.Unvan = kimlik.Unvan;
                    db.SaveChanges();
                    return RedirectToAction("Index");
               
            } 
            return View(kimlik);
        }

 
    }
}
