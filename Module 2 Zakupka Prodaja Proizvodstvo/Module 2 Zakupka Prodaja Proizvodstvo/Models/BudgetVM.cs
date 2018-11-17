using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Models
{
    public class BudgetVM
    {
        public IEnumerable<Budget> Budgetsi { get; set; }
        public int budg_id { get; set; }
        public int summa_budget { get; set; }

        public ICollection<Zakupka_syrya> Zakupka_syryas { get; set; }

        public BudgetVM()
        {
            Zakupka_syryas = new List<Zakupka_syrya>();
        }
    }
}