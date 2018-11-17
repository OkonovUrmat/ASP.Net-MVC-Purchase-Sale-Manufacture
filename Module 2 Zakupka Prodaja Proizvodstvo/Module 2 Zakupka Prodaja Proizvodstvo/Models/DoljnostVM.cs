using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Models
{
    public class DoljnostVM
    {
        public int dolj_ID { get; set; }
        public string doljnosts { get; set; }

        public ICollection<Sotrudnik> Sotrudniks{ get; set; }

        public DoljnostVM()
        {
           Sotrudniks = new List<Sotrudnik>();
        }
    }
}