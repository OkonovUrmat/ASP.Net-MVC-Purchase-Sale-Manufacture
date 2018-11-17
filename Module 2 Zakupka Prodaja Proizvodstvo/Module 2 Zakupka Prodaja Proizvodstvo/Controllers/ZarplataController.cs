using Module_2_Zakupka_Prodaja_Proizvodstvo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Controllers
{
    public class ZarplataController : Controller
    {
        ProdajProductContext db = new ProdajProductContext();
        // GET: Zarplata
        public ActionResult Index(int? sotrudnik)
        {
            IQueryable<Zarplata> proizvodstvos = db.Zarplatas.Include(p => p.Sotrudnik);
            if (sotrudnik != null && sotrudnik != 0)
            {
                proizvodstvos = proizvodstvos.Where(p => p.id_sotrudnika == sotrudnik);
            }

            List<Sotrudnik> sotrudniks = db.Sotrudniks.ToList();
            sotrudniks.Insert(0, new Sotrudnik { FIO = "Все", sotr_ID = 0 });

                ZarplataVM plvm = new ZarplataVM
                {
                     Zarplatasi= proizvodstvos.ToList(),
                    Sotrudniksi = new SelectList(sotrudniks, "sotr_ID", "FIO"),
                };
                return View(plvm);
          

        }
        [HttpGet]
        public ActionResult Create()
        {
            SelectList sotrudniks = new SelectList(db.Sotrudniks, "sotr_ID", "FIO");
            ViewBag.Sotrudniks = sotrudniks;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Zarplata zarplatas)
        {
            //Добавляем игрока в таблицу
            db.Zarplatas.Add(zarplatas);
            db.SaveChanges();
            // перенаправляем на главную страницу
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
          Zarplata b = db.Zarplatas.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Zarplata b = db.Zarplatas.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Zarplatas.Remove(b);
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
            Zarplata Proizvodstvo = db.Zarplatas.Find(id);
            if (Proizvodstvo != null)
            {
                SelectList sotrudniks = new SelectList(db.Sotrudniks, "sotr_ID", "FIO");
                ViewBag.Sotrudniks = sotrudniks;
                return View(Proizvodstvo);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Zarplata Proizvodstvo)
        {
            db.Entry(Proizvodstvo).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}