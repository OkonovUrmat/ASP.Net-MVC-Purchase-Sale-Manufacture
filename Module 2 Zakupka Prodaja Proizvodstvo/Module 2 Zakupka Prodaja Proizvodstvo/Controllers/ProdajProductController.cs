using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Module_2_Zakupka_Prodaja_Proizvodstvo.Models;
namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Controllers
{
    public class ProdajProductController : Controller
    {
        ProdajProductContext db = new ProdajProductContext();
        // GET: ProdajProduct

        public ActionResult Index(int? product, int? sotrudnik)
        {
            bool da = true;
            IQueryable<Prodaj_Product> proizvodstvos = db.Prodaj_Products.Include(p => p.Sotrudnik1);
            IQueryable<Prodaj_Product> products = db.Prodaj_Products.Include(p => p.Gotov_product);
            if (product != null && product != 0)
            {
                products = products.Where(p => p.product == product);
                da = false;
            }
            if (sotrudnik != null && sotrudnik != 0)
            {
                proizvodstvos = proizvodstvos.Where(p => p.sotrudnik == sotrudnik);
                da = true;
            }

            List<Sotrudnik> sotrudniks = db.Sotrudniks.ToList();
            List<Gotov_product> gp_products = db.Gotov_Products.ToList();
            // устанавливаем начальный элемент, который позволит выбрать всех
            sotrudniks.Insert(0, new Sotrudnik { FIO = "Все", sotr_ID = 0 });
            gp_products.Insert(0, new Gotov_product { name = "Все", gp_ID = 0 });
            if (da == true)
            {
                ProdajProduct plvm = new ProdajProduct
                {
                    Prodaj_Products = proizvodstvos.ToList(),
                    Sotrudniksi = new SelectList(sotrudniks, "sotr_ID", "FIO"),
                    Productsi = new SelectList(gp_products, "gp_ID", "name"),
                };


                return View(plvm);
            }
            else
            {
                ProdajProduct plvm = new ProdajProduct
                {
                    Prodaj_Products = products.ToList(),
                    Sotrudniksi = new SelectList(sotrudniks, "sotr_ID", "FIO"),
                    Productsi = new SelectList(gp_products, "gp_ID", "name"),
                };


                return View(plvm);
            }
  
        }
        [HttpGet]
        public ActionResult Create()
        {
            // Формируем список команд для передачи в представление
            SelectList prodajs = new SelectList(db.Gotov_Products, "gp_ID", "name");
            ViewBag.Gotov_Products = prodajs;
            SelectList sotrudniks = new SelectList(db.Sotrudniks, "sotr_ID", "FIO");
            ViewBag.Sotrudniks = sotrudniks;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Prodaj_Product prodaja)
        {
            //Добавляем игрока в таблицу
            db.Prodaj_Products.Add(prodaja);
            db.SaveChanges();
            // перенаправляем на главную страницу
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Prodaj_Product b = db.Prodaj_Products.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Prodaj_Product b = db.Prodaj_Products.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Prodaj_Products.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
           Prodaj_Product Prodaj_Product = db.Prodaj_Products.Find(id);
            if (Prodaj_Product != null)
            {
                SelectList prodajs = new SelectList(db.Gotov_Products, "gp_ID", "name");
                ViewBag.Gotov_Products = prodajs;
                SelectList sotrudniks = new SelectList(db.Sotrudniks, "sotr_ID", "FIO");
                ViewBag.Sotrudniks = sotrudniks;
                return View(Prodaj_Product);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Prodaj_Product Prodaj_Product)
        {
            db.Entry(Prodaj_Product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}