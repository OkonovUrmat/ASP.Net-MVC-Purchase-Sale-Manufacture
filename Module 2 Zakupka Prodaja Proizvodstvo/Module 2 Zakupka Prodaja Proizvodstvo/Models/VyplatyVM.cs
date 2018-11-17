using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Models
{
    public class VyplatyVM
    {
        public IEnumerable<Vyplaty> Vyplatysi { get; set; }
        public int vyplaty_id { get; set; }
        public int summa_kredita { get; set; }
        public int procent { get; set; }
        public int peni { get; set; }
        public DateTime data { get; set; }
        public int ostatok { get; set; }
    }
}