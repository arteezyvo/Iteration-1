using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RapidContactTracer.Models
{
    public class SeatingChart
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public int SeatingID { get; set; }
        public string Email { get; set; }
        //public Boolean IsAffected { get; set; }
    }
    public class SeatingChartDBContext : DbContext
    {
        public DbSet<SeatingChart> SeatingCharts { get; set; }
    }
}