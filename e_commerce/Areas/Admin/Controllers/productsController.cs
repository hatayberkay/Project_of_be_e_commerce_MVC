using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using BL;
using Entities;
using System.IO;

namespace e_commerce.Areas.Admin.Controllers
{
    public class productsController : Controller
    {

      
        productsManager manager = new productsManager();
        categoriesManager categoriesManager = new categoriesManager();
        brandsManager brandsManager = new brandsManager();

       
        public ActionResult Index()
        {
            return View(manager.GetAll());
        }

        public ActionResult Create()
        {

            ViewBag.categories_id = new SelectList(categoriesManager.GetAll(), "Id", "category_name");
            ViewBag.brands_id = new SelectList(brandsManager.GetAll(), "Id", "brand_name");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(products products, HttpPostedFileBase photo) // class name ve itemi
        {
            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                    string directory = Server.MapPath("~/Img/");
                    var fileName = Path.GetFileName(photo.FileName);
                    photo.SaveAs(Path.Combine(directory, fileName));
                    products.photo = photo.FileName;
                }
                products.upload_time = System.DateTime.Now;
             

                manager.Add(products);

                return RedirectToAction("Index");
            }

            ViewBag.categories_id = new SelectList(categoriesManager.GetAll(), "Id", "categories_id", products.categories_id);
            ViewBag.brands_id = new SelectList(brandsManager.GetAll(), "Id", "categories_id", products.brands_id);
            return View(products);
        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            products products = manager.Get(id.Value);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(categoriesManager.GetAll(), "Id", "KategoriAdi", products.categories_id);
            ViewBag.MarkaId = new SelectList(brandsManager.GetAll(), "Id", "MarkaAdi", products.brands_id);
            return View(products);
        }

        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(products products , HttpPostedFileBase photo , bool cbPhotoSil)
        {

            try
            {
              


                if (ModelState.IsValid)
                {

                    if (cbPhotoSil == true)
                    {
                     products.photo = string.Empty;
                    }

                    if (photo != null)
                    {
                        string directory = Server.MapPath("~/Img/");
                        var fileName = Path.GetFileName(photo.FileName);
                        photo.SaveAs(Path.Combine(directory, fileName));
                        products.photo = photo.FileName;
                    }
                    products.upload_time = DateTime.Now;

                    manager.Update(products);

                    return RedirectToAction("Index");
                }
                ViewBag.KategoriId = new SelectList(categoriesManager.GetAll(), "Id", "KategoriAdi", products.categories_id);
                ViewBag.MarkaId = new SelectList(brandsManager.GetAll(), "Id", "MarkaAdi", products.brands_id);
                return View(products);

            }
            catch (Exception)
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
            products products = manager.Get(id.Value);

            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
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