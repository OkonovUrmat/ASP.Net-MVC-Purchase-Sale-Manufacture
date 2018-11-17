using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Module_2_Zakupka_Prodaja_Proizvodstvo.Models;
namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Controllers
{
    public class ProizvodstvoController : Controller
    {
        ProdajProductContext db = new ProdajProductContext();
        // GET: ProdajProduct

        public ActionResult Index(int? product,int? sotrudnik)
        {
            bool da = true;//Булевая переменная для фильтрации
            /*Создаем две переменные по которым будет фильтроватся записи*/
            IQueryable<Proizvodstvo> proizvodstvos = db.Proizvodstvos.Include(p => p.Sotrudnik1);
            IQueryable<Proizvodstvo> products = db.Proizvodstvos.Include(p => p.Gotov_product);
            /*Если выбран продукт,то берем данные для фильтра по продукту*/
            if (product != null && product != 0)
            {
                products = products.Where(p => p.product == product);
                da = false;
            }  
            /*Если выбран сотрудник,то берем данные для фильтра по сотруднику*/
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
           /* фильтруем данные по продукту*/
            if (da == true)
            {
                ProizvodstvoListModel plvm = new ProizvodstvoListModel
                {
                    Proizvodstvosi = proizvodstvos.ToList(),
                    Sotrudniksi = new SelectList(sotrudniks, "sotr_ID", "FIO"),
                    Productsi = new SelectList(gp_products, "gp_ID", "name"),
                };
                return View(plvm);
            }
           /* фильтруем данные по сотруднику*/
            else
            {
                ProizvodstvoListModel plvm = new ProizvodstvoListModel
                {
                    Proizvodstvosi = products.ToList(),
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
            SelectList proizvodstvos = new SelectList(db.Gotov_Products, "gp_ID", "name");
            ViewBag.Gotov_Products = proizvodstvos;
            SelectList sotrudniks = new SelectList(db.Sotrudniks, "sotr_ID", "FIO");
            ViewBag.Sotrudniks = sotrudniks;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Proizvodstvo proizvodstva)
        {
            //Добавляем игрока в таблицу
            db.Proizvodstvos.Add(proizvodstva);
            db.SaveChanges();
            // перенаправляем на главную страницу
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Proizvodstvo b = db.Proizvodstvos.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Proizvodstvo b = db.Proizvodstvos.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Proizvodstvos.Remove(b);
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
            Proizvodstvo Proizvodstvo= db.Proizvodstvos.Find(id);
            if (Proizvodstvo != null)
            {
                SelectList prodajs = new SelectList(db.Gotov_Products, "gp_ID", "name");
                ViewBag.Gotov_Products = prodajs;
                SelectList sotrudniks = new SelectList(db.Sotrudniks, "sotr_ID", "FIO");
                ViewBag.Sotrudniks = sotrudniks;
                return View(Proizvodstvo);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Proizvodstvo Proizvodstvo)
        {
            db.Entry(Proizvodstvo).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}