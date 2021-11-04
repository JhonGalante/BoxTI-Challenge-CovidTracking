﻿// <auto-generated />
using System;
using BoxTI.Challenge.CovidTracking.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BoxTI.Challenge.CovidTracking.Data.Migrations
{
    [DbContext(typeof(MySqlContext))]
    partial class MySqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("BoxTI.Challenge.CovidTracking.Models.Entities.CountryRegistry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ActiveCases")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime")
                        .HasColumnName("last_update");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("country_name");

                    b.Property<int>("NewCases")
                        .HasColumnType("int")
                        .HasColumnName("new_cases");

                    b.Property<int>("NewDeaths")
                        .HasColumnType("int")
                        .HasColumnName("new_deaths");

                    b.Property<int>("TotalCases")
                        .HasColumnType("int")
                        .HasColumnName("total_cases");

                    b.Property<int>("TotalDeaths")
                        .HasColumnType("int")
                        .HasColumnName("total_deaths");

                    b.Property<int>("TotalRecovered")
                        .HasColumnType("int")
                        .HasColumnName("total_recovered");

                    b.HasKey("Id");

                    b.ToTable("CountryCovidRegistry");
                });
#pragma warning restore 612, 618
        }
    }
}
