using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Module_2_Zakupka_Prodaja_Proizvodstvo.Models;
namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Controllers
{
    public class GotovProductController : Controller
    {
        // GET: GotovProduct
        ProdajProductContext db = new ProdajProductContext();
        public ActionResult Index()
        {
            var syries = db.Gotov_Products.Include(p => p.Edinic_izmer);
            return View(syries.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            // Формируем список команд для передачи в представление
            SelectList ed_izmers = new SelectList(db.Ed_Izmers, "ez_ID", "name");
            ViewBag.Edinic_izmer = ed_izmers;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Gotov_product gotov)
        {
            //Добавляем игрока в таблицу
            db.Gotov_Products.Add(gotov);
            db.SaveChanges();
            // перенаправляем на главную страницу
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            Gotov_product b = db.Gotov_Products.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
           Gotov_product b = db.Gotov_Products.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Gotov_Products.Remove(b);
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
            Gotov_product Prodaj_Product = db.Gotov_Products.Find(id);
            if (Prodaj_Product != null)
            {
                SelectList sotrudniks = new SelectList(db.Ed_Izmers, "ez_ID", "name");
                ViewBag.Ez = sotrudniks;
                return View(Prodaj_Product);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Gotov_product Prodaj_Product)
        {
            db.Entry(Prodaj_Product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}