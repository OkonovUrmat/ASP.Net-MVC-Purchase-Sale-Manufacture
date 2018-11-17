using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Models
{
    public class ZarplataVM
    {
        public IEnumerable<Zarplata> Zarplatasi { get; set; }
        public int id_zarplaty { get; set; }
        public int? id_sotrudnika { get; set; }
        public SotrudnikVM SotrudnikVM { get; set; }
        public int mesyac { get; set; }
        public int god { get; set; }
        public int oklad { get; set; }
        public int procent_oklada { get; set; }
        public int obwaya_summa { get; set; }
        public SelectList Sotrudniksi { get; set; }
    }
}