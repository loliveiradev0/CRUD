using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using todo.Models;

namespace todo.Dao
{
    public class EFContext : DbContext
    {
        public EFContext() : base("EFConnectionString") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        //Entidades do banco
        public DbSet<Atividades> Atividades { get; set; }
    }
}