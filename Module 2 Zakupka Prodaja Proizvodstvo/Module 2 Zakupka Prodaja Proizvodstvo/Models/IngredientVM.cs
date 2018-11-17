using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Models
{
    public class IngredientVM
    {
        public int ingr_ID { get; set; }
        public int? produciya { get; set; }
        public GotovProduct GotovProducts { get; set; }
        public int? syrie { get; set; }
        public SyrieVM SyrieVM { get; set; }
        public int kol_vo { get; set; }

       public  SelectList Productsi { get; set; }
        public SelectList Syriesi { get; set; }
        public IEnumerable<Ingredient> Ingredientsi { get; set; }
    }
}