using Module_2_Zakupka_Prodaja_Proizvodstvo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Controllers
{
    public class BudgetController : Controller
    {
        ProdajProductContext db = new ProdajProductContext();
        // GET: Budget
        public ActionResult Index()
        {
            ViewBag.item = db.Budgets;
            return View();
        }

        // GET: Budget/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Budget/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Budget/Create
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

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
          Budget Proizvodstvo = db.Budgets.Find(id);
            if (Proizvodstvo != null)
            {
                return View(Proizvodstvo);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Budget Proizvodstvo)
        {
            db.Entry(Proizvodstvo).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Budget/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Budget/Delete/5
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
