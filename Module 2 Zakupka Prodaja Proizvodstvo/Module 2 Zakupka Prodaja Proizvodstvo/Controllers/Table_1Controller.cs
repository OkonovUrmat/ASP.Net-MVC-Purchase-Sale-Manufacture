using Module_2_Zakupka_Prodaja_Proizvodstvo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Routing;

namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Controllers
{
    public class Table_1Controller : Controller
    {
        ProdajProductContext db = new ProdajProductContext();
        // GET: Table_1
        public ActionResult Index(string syrye)
        {
            IQueryable<Table_1> syryes = db.Table_1s.Include(p => p.name);
            if (!String.IsNullOrEmpty(syrye) && !syrye.Equals("Все"))
            {
                syryes = syryes.Where(p => p.name == syrye);
            }

            List<Table_1> syries = db.Table_1s.ToList();
            // устанавливаем начальный элемент, который позволит выбрать всех
            syries.Insert(0, new Table_1 { name = "Все", syrie_id = 0 });
            Table_1s plvm = new Table_1s
            {
                Table_1si = syries.ToList(),
                Tables = new SelectList(syries, "syrie_id", "name"),
            };


            return View(plvm);
        }

        // GET: Table_1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Table_1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Table_1/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Table_1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Table_1/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Table_1/Delete/5
        public ActionResult Delete(int id)
        {
            Table_1 b = db.Table_1s.Find(id);
            if (b != null)
            {
                db.Table_1s.Remove(b);
                db.SaveChanges();
            }
            //  return RedirectToAction("/Syrie/Index");
            return View();
        }

        // POST: Table_1/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
