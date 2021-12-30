using System.Net;
using System.Web;
using System.Web.Mvc;
using BL;
using Entities;


namespace e_commerce.Controllers
{
    public class HomeController : Controller
    {
        productsManager manager = new productsManager();
        categoriesManager manager_categori = new categoriesManager();
        brandsManager manager_brands = new brandsManager();
     

        public ActionResult Index()
        {
            var sayfaModeli = new Models.AnasayfaVM
            {
                products = manager.GetAll(),
                categories = manager_categori.GetAll(),
                brands = manager_brands.GetAll()
            };

            return View(sayfaModeli);
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is only e-commerce web site.";
         

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
         
            return View();
        }

        public ActionResult product_detail(int? id)
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

        public ActionResult categories() 
        {
   
            return View(manager.GetAll());
        }

       

    }
}