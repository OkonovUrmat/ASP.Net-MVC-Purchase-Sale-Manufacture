using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Models
{
    public class SotrudnikVM
    {
        public int sotr_ID { get; set; }
        public string FIO { get; set; }


        public int? doljnost { get; set; }
        public DoljnostVM DoljnostVM { get; set; }

        public int oklad { get; set; }
        public string adress { get; set; }
        public string telephone { get; set; }

        public ICollection<Sotrudnik> Sotrudniks { get; set; }

        public SotrudnikVM()
        {
           Sotrudniks = new List<Sotrudnik>();
        }
    }
}