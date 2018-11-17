using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Module_2_Zakupka_Prodaja_Proizvodstvo.Models
{
    public class ProdajProductContext:DbContext
    {
        public DbSet<Prodaj_Product> Prodaj_Products { get; set; }
        public DbSet<Gotov_product> Gotov_Products { get; set;}
        public DbSet<Sotrudnik> Sotrudniks { get; set; }
        public DbSet<Zakupka_syrya> Zakupka_syryas { get; set; }
        public DbSet<Syrie> Syries { get; set; }
        public DbSet<Proizvodstvo> Proizvodstvos { get; set; }
        public DbSet<Edinic_izmer> Ed_Izmers { get; set; }
        public DbSet<Doljnost> Doljnosts { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Zarplata> Zarplatas { get; set; }
        public DbSet<Vyplaty>Vyplatys { get; set; }
        public DbSet<Poluchenie> Poluchenies { get; set; }
        public DbSet<Table_1> Table_1s { get; set; }

        public ProdajProductContext() :
        base("SRSEntities6")
    { }

        public DbSet<Usersa> Users { get; set; }
    }
}