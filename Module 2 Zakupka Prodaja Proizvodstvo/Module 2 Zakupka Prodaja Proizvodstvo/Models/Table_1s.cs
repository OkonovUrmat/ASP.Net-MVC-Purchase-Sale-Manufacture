using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Models
{
    public class Table_1s
    {
        public IEnumerable<Table_1> Table_1si { get; set; }
        public int syrie_id { get; set; }
        public int name { get; set; }
        public int ed_izmer { get; set; }
        public int summa { get; set; }
        public int kol_vo { get; set; }

        public SelectList Tables { get; set; }
        public ICollection<Zakupka_syrya> Zakupka_syryas { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Table_1> Table_1sa { get; set; }
        public Table_1s()
        {
            Zakupka_syryas = new List<Zakupka_syrya>();
            Ingredients = new List<Ingredient>();
            Table_1sa = new List<Table_1>();
        }

    }
}