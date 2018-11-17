using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Module_2_Zakupka_Prodaja_Proizvodstvo.Models;
using System.Data.Entity;

namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Controllers
{
    public class PoluchenieController : Controller
    {
        ProdajProductContext db = new ProdajProductContext();
        // GET: Bank
        public ActionResult Index()
        {  // получаем из бд все объекты Poluchenie
            IEnumerable<Poluchenie> puluchenies = db.Poluchenies;
            // передаем все объекты в динамическое свойство puluchenies в ViewBag
            ViewBag.Poluchenies = puluchenies;
            // возвращаем представление
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Poluchenie poluchenie)
        {
            db.Poluchenies.Add(poluchenie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Poluchenie b = db.Poluchenies.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Poluchenie b = db.Poluchenies.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Poluchenies.Remove(b);
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
            Poluchenie Poluchenie = db.Poluchenies.Find(id);
            if (Poluchenie != null)
            {
                return View(Poluchenie);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Poluchenie poluchenie)
        {
            db.Entry(poluchenie).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}