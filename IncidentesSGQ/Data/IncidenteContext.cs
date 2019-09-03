using IncidentesSGQ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentesSGQ.Data
{
    public class IncidenteContext : DbContext
    {
        public IncidenteContext()
        {

        }
       
        public IncidenteContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Incidente> Incidentes { get; set; }
        public DbSet<NaoConformidade> NaoConformidades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=;Initial Catalog=incidentes;Persist Security Info=False;User ID=;Password=;MultipleActiveResultSets=False;Connection Timeout=30;");
            }
        }
    }
}
