using Microsoft.EntityFrameworkCore;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Data
{
    public class ParkeerOpgaveContext : DbContext
    {
        public DbSet<DataPark> park { get; set; }
        public DbSet<DataHuis> huis { get; set; }
        public DbSet<DataHuurContract> huurContract { get; set; }
        public DbSet<DataHuurPeriode> huurPeriode { get; set; }
        public DbSet<DataHuurder> huurder { get; set; }
        public DbSet<DataContactGegevens> contactGegevens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-PJRLO8E\\SQLEXPRESS;Initial Catalog=ParkeerOpgave;Integrated Security=True; TrustServerCertificate=True");
        }
    }
}