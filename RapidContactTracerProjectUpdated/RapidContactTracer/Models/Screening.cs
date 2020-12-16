using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RapidContactTracer.Models
{
    public class Screening
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int idUser { get; set; }

        public int q1 { get; set; }
        public int q2 { get; set; }
        public int q3 { get; set; }
        public int q4 { get; set; }
        public int q5 { get; set; }
        public int q6 { get; set; }
        public int q7 { get; set; }
        public int q8 { get; set; }
        public int q9 { get; set; }
        public int q10 { get; set; }
        public int q11 { get; set; }
        public int q12 { get; set; }
        public int q13 { get; set; }
        public int q14 { get; set; }
        public int q15 { get; set; }
        public int q16 { get; set; }
        public int q17 { get; set; }
        public int q18 { get; set; }
    }

    public class ScreeningDBContext : DbContext
    {
        public ScreeningDBContext() : base("ScreeningDatabase") { }
        public DbSet<Screening> Screenings { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<demoEntities>(null);
            modelBuilder.Entity<Screening>().ToTable("Screenings");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}