using Module_2_Zakupka_Prodaja_Proizvodstvo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data;

namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Controllers
{
    public class VyplatyController : Controller
    {
        ProdajProductContext db = new ProdajProductContext();
        public ActionResult Index()
        {
            // получаем из бд все объекты Vyplaty
            IEnumerable<Vyplaty> vyplatys = db.Vyplatys;
            // передаем все объекты в динамическое свойство vyplatys в ViewBag
            ViewBag.Vyplatys = vyplatys;
            // возвращаем представление

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            SelectList poluchenie = new SelectList(db.Poluchenies, "poluchenie_id", "summa");
            ViewBag.Poluchenies = poluchenie;
         
            return View();
        }
        [HttpPost]
        public ActionResult Create(Vyplaty vyplaty)
        {
            db.Vyplatys.Add(vyplaty);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Vyplaty b = db.Vyplatys.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Vyplaty b = db.Vyplatys.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Vyplatys.Remove(b);
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
            Vyplaty Vyplaty = db.Vyplatys.Find(id);
            if (Vyplaty != null)
            {
                return View(Vyplaty);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Vyplaty vyplaty)
        {
            db.Entry(vyplaty).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}