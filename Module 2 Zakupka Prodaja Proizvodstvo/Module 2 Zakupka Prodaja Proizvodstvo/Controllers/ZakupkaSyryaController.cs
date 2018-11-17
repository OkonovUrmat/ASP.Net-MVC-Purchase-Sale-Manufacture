using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Sql;
using System.Data.Entity;
using Module_2_Zakupka_Prodaja_Proizvodstvo.Models;
using System.Configuration;

namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Controllers
{
    public class ZakupkaSyryaController : Controller
    {
        // GET: ZakupkaSyrya
        ProdajProductContext db = new ProdajProductContext();

        public ActionResult Index(int? syrie, int? sotrudnik)
        {
            bool da = true;
            IQueryable<Zakupka_syrya> sotrudniks = db.Zakupka_syryas.Include(p => p.Sotrudnik1);
            IQueryable<Zakupka_syrya> syries = db.Zakupka_syryas.Include(p => p.Syrie1);
            if (syrie != null && syrie != 0)
            {
                syries = syries.Where(p => p.syrie == syrie);
                da = false;
            }
            if (sotrudnik != null && sotrudnik != 0)
            {
                sotrudniks = sotrudniks.Where(p => p.sotrudnik == sotrudnik);
          
                da = true;
            }

            List<Sotrudnik> sotrudniksi = db.Sotrudniks.ToList();
            List<Syrie> gp_syries = db.Syries.ToList();
            // устанавливаем начальный элемент, который позволит выбрать всех
            sotrudniksi.Insert(0, new Sotrudnik { FIO = "Все", sotr_ID = 0 });
            gp_syries.Insert(0, new Syrie {  name= "Все", syrie_id = 0 });
            if (da == true)
            {
                ZakupkaSyrya plvm = new ZakupkaSyrya
                {
                    Zakup_syryas = sotrudniks.ToList(),
                    Sotrudniksi = new SelectList(sotrudniksi, "sotr_ID", "FIO"),
                    Syriesi = new SelectList(gp_syries, "syrie_id", "name"),
                }; return View(plvm);
            }
            else
            {
                ZakupkaSyrya plvm = new ZakupkaSyrya
                {
                    Zakup_syryas = syries.ToList(),
                    Sotrudniksi = new SelectList(sotrudniksi, "sotr_ID", "FIO"),
                    Syriesi = new SelectList(gp_syries, "syrie_id", "name"),
                };
                return View(plvm);
            }



        }
        [HttpGet]
        public ActionResult Create()
        {
            // Формируем список команд для передачи в представление
            SelectList syrie = new SelectList(db.Syries, "syrie_id", "name");
            ViewBag.Syries = syrie;
            SelectList sotrudniks = new SelectList(db.Sotrudniks, "sotr_ID", "FIO");
            ViewBag.Sotrudniks = sotrudniks;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Zakupka_syrya prodaja)
        { 
            //Добавляем игрока в таблицу
            db.Zakupka_syryas.Add(prodaja);
            db.SaveChanges();
            // перенаправляем на главную страницу
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Zakupka_syrya b = db.Zakupka_syryas.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Zakupka_syrya b = db.Zakupka_syryas.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Zakupka_syryas.Remove(b);
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
            Zakupka_syrya Zakupka_syrya= db.Zakupka_syryas.Find(id);
            if (Zakupka_syrya != null)
            {
                SelectList prodajs = new SelectList(db.Syries, "syrie_id", "name");
                ViewBag.Syries = prodajs;
                SelectList sotrudniks = new SelectList(db.Sotrudniks, "sotr_ID", "FIO");
                ViewBag.Sotrudniks = sotrudniks;
                return View(Zakupka_syrya);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Zakupka_syrya zakupka)
        {
            db.Entry(zakupka).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}