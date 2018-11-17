﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Models
{
    public class SyrieVM
    {
        public IEnumerable<Syrie> Syriesi { get; set; }
        public int syrie_id { get; set; }
        public string name { get; set; }
        public int ed_izmer { get; set; }
        public int summa { get; set; }
        public int kol_vo { get; set; }

        public SelectList Syryes { get; set; }
        public ICollection<Zakupka_syrya> Zakupka_syryas { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Table_1> Table_1s { get; set; }
        public SyrieVM()
        {
            Zakupka_syryas = new List<Zakupka_syrya>();
            Ingredients = new List<Ingredient>();
            Table_1s = new List<Table_1>();
        }
       

   
    }
}