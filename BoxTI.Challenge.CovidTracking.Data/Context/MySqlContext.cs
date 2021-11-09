using BoxTI.Challenge.CovidTracking.Data.Mappings;
using BoxTI.Challenge.CovidTracking.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTI.Challenge.CovidTracking.Data.Context
{
    public class MySqlContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MySqlContext(DbContextOptions<MySqlContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<CountryRegistry> CountryRegistries { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CountryRegistry>(new CountryRegistryMap().Configure);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseMySql(_configuration.GetConnectionString("MySQLConnection"), ServerVersion.AutoDetect(_configuration.GetConnectionString("MySQLConnection")));
        }
    }
}
