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
    
    public partial class Syrie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Syrie()
        {
            this.Ingredient = new HashSet<Ingredient>();
            this.Zakupka_syrya = new HashSet<Zakupka_syrya>();
        }
    
        public short syrie_id { get; set; }
        public string name { get; set; }
        public Nullable<byte> ed_izmer { get; set; }
        public Nullable<double> summa { get; set; }
        public Nullable<double> kol_vo { get; set; }
    
        public virtual Edinic_izmer Edinic_izmer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ingredient> Ingredient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zakupka_syrya> Zakupka_syrya { get; set; }
    }
}
