﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Produlator
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    
    public partial class Produlator_dbEntities1 : DbContext
    {

        private static Produlator_dbEntities1 instance;


        public static Produlator_dbEntities1 GetInstance()
        {
            if (instance == null) instance = new Produlator_dbEntities1();
            return instance;
        }

        public Produlator_dbEntities1()
            : base("name=Produlator_dbEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<access_level> access_level { get; set; }
        public virtual DbSet<account> account { get; set; }
        public virtual DbSet<goods> goods { get; set; }
        public virtual DbSet<pallet> pallet { get; set; }
        public virtual DbSet<product> product { get; set; }
        public virtual DbSet<product_date> product_date { get; set; }
        public virtual DbSet<shelf> shelf { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
