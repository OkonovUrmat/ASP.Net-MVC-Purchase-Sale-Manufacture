using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Models
{
    public class ProizvodstvoVM
    {
        public int proizvodstvo_ID { get; set; }

        public int? product { get; set; }
        public GotovProduct GotovProducts { get; set; }

        public int kol_vo { get; set; }
        public DateTime data { get; set; }



        public int? sotrudnik { get; set; }
        public SotrudnikVM SotrudnikVM { get; set; }
    }
}