using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Models
{
    public class ZakupkaSyrya
    {
        public int zakup_ID { get; set; }

        public int? syrie { get; set; }
        public Syrie Syries { get; set; }

        public int kol_vo { get; set; }
        public int summa { get; set; }
        public DateTime data { get; set; }



        public int? sotrudnik { get; set; }
        public SotrudnikVM SotrudnikVM { get; set; }

        public int? budget { get; set; }
        public BudgetVM BudgetVM { get; set; }

        public IEnumerable<Zakupka_syrya> Zakup_syryas { get; set; }
        public SelectList Syriesi { get; set; }
        public SelectList Sotrudniksi { get; set; }
    }
}