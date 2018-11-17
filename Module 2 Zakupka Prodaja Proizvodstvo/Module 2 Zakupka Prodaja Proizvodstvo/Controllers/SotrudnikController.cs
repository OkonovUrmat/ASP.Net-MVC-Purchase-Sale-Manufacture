using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Module_2_Zakupka_Prodaja_Proizvodstvo.Models;
namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Controllers
{
    public class SotrudnikController : Controller
    {
        // GET: Sotrudnik
        ProdajProductContext db = new ProdajProductContext();
        public ActionResult Index()
        {
            var doljnost = db.Sotrudniks.Include(p => p.Doljnost1);
            return View(doljnost.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            // Формируем список команд для передачиg в представление
            SelectList doljnosta = new SelectList(db.Doljnosts, "dolj_ID", "doljnosts");
            ViewBag.Doljnosts = doljnosta;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Doljnost doljnosts)
        {
            //Добавляем игрока в таблицу
            db.Doljnosts.Add(doljnosts);
            db.SaveChanges();
            // перенаправляем на главную страницу
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Sotrudnik b = db.Sotrudniks.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Sotrudnik b = db.Sotrudniks.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Sotrudniks.Remove(b);
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
            Sotrudnik Sotrudnik = db.Sotrudniks.Find(id);
            if (Sotrudnik != null)
            {
                SelectList doljnosts = new SelectList(db.Doljnosts, "dolj_ID", "doljnosts");
                ViewBag.Doljnosts = doljnosts;
                return View(Sotrudnik);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Sotrudnik Proizvodstvo)
        {
            db.Entry(Proizvodstvo).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}