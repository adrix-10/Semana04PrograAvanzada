using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Semana04.Models;

namespace Semana04.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        //Por defecto todos los metodos se solicitan con una peticion GET, al igual que todas la anclas

        private VentasEntities1 db = new VentasEntities1();
        public ActionResult Index()
        {
            List<Product> productos = db.Products.ToList();//Recupera todos los datos de la tabla
            return View(productos);
        }
        public ActionResult Create() 
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Product product) 
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else 
            {
                return View(product);
            }
        }
        public ActionResult Edit(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null) 
            {
                return HttpNotFound();
            }

            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product) 
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else 
            {
                return View(product);
            }
        }
        public ActionResult Details(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }
        [HttpPost,ActionName("ConfirmDelete")]
        public ActionResult Eliminar(int id) 
        {
            Product product = db.Products.Find(id);
            if (product == null) 
            {
                return HttpNotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}