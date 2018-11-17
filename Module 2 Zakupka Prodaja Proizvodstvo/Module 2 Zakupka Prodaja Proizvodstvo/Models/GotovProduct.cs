using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Models
{
    public class GotovProduct
    {
        public int gp_ID { get; set; }
        public string name { get; set; }


        public int? ed_izmer { get; set; }
        public Ed_izmer Ed_imzer { get; set; }

        public int kol_vo { get; set; }
        public int summa { get; set; }

        public ICollection<Prodaj_Product> Prodajs_Products { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }

        public GotovProduct()
        {
            Prodajs_Products = new List<Prodaj_Product>();
            Ingredients = new List<Ingredient>();
        }
    }
}