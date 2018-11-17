using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Module_2_Zakupka_Prodaja_Proizvodstvo.Models;
namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Controllers
{
    public class IngredientController : Controller
    {
        ProdajProductContext db = new ProdajProductContext();
        // GET: Ingredient
        public ActionResult Index(int? product,int? syrie)
        {
            bool da = true;
            IQueryable<Ingredient> proizvodstvos = db.Ingredients.Include(p => p.Syrie1);
            IQueryable<Ingredient> products = db.Ingredients.Include(p => p.Gotov_product);
            if (product != null && product != 0)
            {
                products = products.Where(p => p.produciya == product);
                da = false;
            }
            if (syrie != null && syrie != 0)
            {
                proizvodstvos = proizvodstvos.Where(p => p.syrie == syrie);
                da = true;
            }

            List<Syrie> syries = db.Syries.ToList();
            List<Gotov_product> gp_products = db.Gotov_Products.ToList();
            // устанавливаем начальный элемент, который позволит выбрать всех
            syries.Insert(0, new Syrie { name = "Все", syrie_id = 0 });
            gp_products.Insert(0, new Gotov_product { name = "Все", gp_ID = 0 });
            if (da == true)
            {
                IngredientVM plvm = new IngredientVM
                {
                   Ingredientsi = proizvodstvos.ToList(),
                    Syriesi = new SelectList(syries, "syrie_id", "name"),
                    Productsi = new SelectList(gp_products, "gp_ID", "name"),
                };


                return View(plvm);
            }
            else
            {
                IngredientVM plvm = new IngredientVM
                {
                   Ingredientsi = products.ToList(),
                    Syriesi = new SelectList(syries, "syrie_id", "name"),
                    Productsi = new SelectList(gp_products, "gp_ID", "name"),
                };


                return View(plvm);
            }

        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            ViewBag.Ingredients = db.Database.SqlQuery<Ingredient_Gotov_Result>("EXEC dbo.Ingredient_Gotov {0}", id);
            return View(ViewBag.Ingredients);
        }
        [HttpGet]
        public ActionResult Create()
        {
            // Формируем список команд для передачи в представление
            SelectList proizvodstvos = new SelectList(db.Gotov_Products, "gp_ID", "name");
            ViewBag.Gotov_Products = proizvodstvos;
            SelectList syries = new SelectList(db.Syries, "syrie_id", "name");
            ViewBag.Syries = syries;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Ingredient ingredients)
        {
            //Добавляем игрока в таблицу
            db.Ingredients.Add(ingredients);
            db.SaveChanges();
            // перенаправляем на главную страницу
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient != null)
            {
                return View(ingredient);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Ingredient ingredient)
        {
            db.Entry(ingredient).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}