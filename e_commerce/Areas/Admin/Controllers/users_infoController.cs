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
    public class users_infoController : Controller
    {
        // GET: Admin/users_info

        usersinfoManager manager = new usersinfoManager();
        public ActionResult Index()
        {
            return View(manager.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(users_info users_info) // class name ve itemi
        {
            if (ModelState.IsValid)
            {

                manager.Add(users_info); // managerdan itemi ekliyoruz.

                return RedirectToAction("Index");
            }

            return View(users_info);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


           
            users_info users_info_id = manager.Get(id.Value);
           
            if (users_info_id == null)
            {
                return HttpNotFound();
            }
            return View(users_info_id);
        }

        // POST: Admin/Kullanici/Edit/5
        [HttpPost]
        public ActionResult Edit(users_info users_info)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    manager.Update(users_info);

                    return RedirectToAction("Index");
                }
                return View(users_info);
            }
            catch
            {
                return View();
            }
        }



        // GET: Admin/Kullanici/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users_info users_info = manager.Get(id.Value);

            if (users_info == null)
            {
                return HttpNotFound();
            }
            return View(users_info);
        }

        // POST: Admin/Kullanici/Delete/5
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