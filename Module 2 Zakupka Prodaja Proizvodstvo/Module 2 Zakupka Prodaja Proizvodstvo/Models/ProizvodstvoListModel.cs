﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Models
{
    public class ProizvodstvoListModel
    {
        public IEnumerable<Proizvodstvo> Proizvodstvosi { get; set; }
        public int? product { get; set; }
        public GotovProduct GotovProducts { get; set; }

        public int kol_vo { get; set; }
        public DateTime data { get; set; }



        public int? sotrudnik { get; set; }
        public SotrudnikVM SotrudnikVM { get; set; }
        public SelectList Productsi { get; set; }
        public SelectList Sotrudniksi { get; set; }
    }
}