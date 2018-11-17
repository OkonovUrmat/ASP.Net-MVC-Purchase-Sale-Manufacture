using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using Module_2_Zakupka_Prodaja_Proizvodstvo.Models;
namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Controllers
{
    public class SyrieController : Controller
    {
        // GET: Syrie
        ProdajProductContext db = new ProdajProductContext();
        public ActionResult Index(string syrye)
        {
            ViewBag.item = db.Syries;


            return View();
        }
        //[HttpGet]
        //public ActionResult Index(int date)
        //{
        //    ViewBag.Vyplatysi = db.Database.SqlQuery<SRSEntities4>("EXEC dbo.banki {0}", date);
        //    return View(ViewBag.Vyplatysi);
        //}
        [HttpGet]
        public ActionResult Create()
        {
            // Формируем список команд для передачи в представление
            SelectList ed_izmers = new SelectList(db.Ed_Izmers, "ez_ID", "name");
            ViewBag.Edinic_izmer = ed_izmers;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Syrie syrie)
        {
            //Добавляем в таблицу
            db.Syries.Add(syrie);
            db.SaveChanges();
            // перенаправляем на главную страницу
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
           Syrie b = db.Syries.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Syrie b = db.Syries.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Syries.Remove(b);
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
            Syrie Syrie = db.Syries.Find(id);
            if (Syrie != null)
            {
                SelectList sotrudniks = new SelectList(db.Ed_Izmers, "ez_ID", "name");
                ViewBag.Ez = sotrudniks;
                return View(Syrie);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Syrie Proizvodstvo)
        {
            db.Entry(Proizvodstvo).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}