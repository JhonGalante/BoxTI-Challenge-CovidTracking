using BoxTI.Challenge.CovidTracking.Data.Mappings;
using BoxTI.Challenge.CovidTracking.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTI.Challenge.CovidTracking.Data.Context
{
    public class MySqlContext : DbContext
    {
        private readonly string stringConnection;
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
            stringConnection = "Server=localhost;Port=3306;Database=covidregistrydb;Uid=root;Pwd=root;charset=utf8;";
        }

        public DbSet<CountryRegistry> CountryRegistries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CountryRegistry>(new CountryRegistryMap().Configure);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseMySql(stringConnection, ServerVersion.AutoDetect(stringConnection));
        }
    }
}
