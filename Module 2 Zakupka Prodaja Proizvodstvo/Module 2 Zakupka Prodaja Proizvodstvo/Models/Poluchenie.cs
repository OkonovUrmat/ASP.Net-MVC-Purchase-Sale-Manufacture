//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Poluchenie
    {
        public int poluchenie_id { get; set; }
        public Nullable<decimal> summa { get; set; }
        public Nullable<double> procent { get; set; }
        public Nullable<double> peni { get; set; }
        public Nullable<int> year { get; set; }
        public Nullable<System.DateTime> data { get; set; }
    }
}
