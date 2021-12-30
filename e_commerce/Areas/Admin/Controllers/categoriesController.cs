using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BL;
using Entities;

namespace e_commerce.Areas.Admin.Controllers
{
    public class categoriesController : Controller
    {

        categoriesManager manager = new categoriesManager();

      
        public ActionResult Index()
        {
            return View(manager.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(categories categories)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    categories.upload_time = DateTime.Now;
                    var sonuc = manager.Add(categories);
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
            categories categories = manager.Get(id.Value);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }
        [HttpPost]
        public ActionResult Edit(categories categories)
        {
            if (ModelState.IsValid)
            {
                manager.Update(categories);

                return RedirectToAction("Index");
            }
            return View(categories);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categories categories = manager.Get(id.Value);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                categories categories = manager.Get(id.Value);
                manager.Delete(categories.Id);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Hata oluştu!");
            }
            return RedirectToAction("Index");
        }

    }
}