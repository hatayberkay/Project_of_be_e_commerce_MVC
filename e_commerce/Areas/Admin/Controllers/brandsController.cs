using BL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace e_commerce.Areas.Admin.Controllers
{
    public class brandsController : Controller
    {

        brandsManager manager = new brandsManager();

       
        public ActionResult Index()
        {
            return View(manager.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(brands brands) // class name ve itemi
        {
            if (ModelState.IsValid)
            {
                try
                {
                    brands.upload_time = DateTime.Now;
                    var sonuc = manager.Add(brands);
                    if (sonuc > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else ModelState.AddModelError("", "Kayıt Eklenemedi!");
                }
                catch (Exception hata) //buradaki hata nesnesinden hata detaylarına ulaşabiliriz
                {
                    ModelState.AddModelError("", "Hata Oluştu! Kayıt Eklenemedi!");
                }
            }
            return View();
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            brands brands = manager.Get(id.Value);

            if (brands == null)
            {
                return HttpNotFound();
            }
            return View(brands);
        }

        
        [HttpPost]
        public ActionResult Edit(brands brands)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    manager.Update(brands);

                    return RedirectToAction("Index");
                }
                return View(brands);
            }
            catch
            {
                return View();
            }
        }



      
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            brands brands = manager.Get(id.Value);

            if (brands == null)
            {
                return HttpNotFound();
            }
            return View(brands);
        }

      
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                manager.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}