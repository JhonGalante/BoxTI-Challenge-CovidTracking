using BoxTI.Challenge.CovidTracking.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxTI.Challenge.CovidTracking.Data.Mappings
{
    public class CountryRegistryMap : IEntityTypeConfiguration<CountryRegistry>
    {
        public void Configure(EntityTypeBuilder<CountryRegistry> builder)
        {
            builder.ToTable("CountryCovidRegistry");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("country_name")
                .HasColumnType("varchar(50)");

            builder.Property(p => p.LastUpdate)
                .IsRequired()
                .HasColumnName("last_update")
                .HasColumnType("datetime");

            builder.Property(p => p.NewCases)
                .HasColumnName("new_cases")
                .HasColumnType("int");

            builder.Property(p => p.NewDeaths)
                .HasColumnName("new_deaths")
                .HasColumnType("int");

            builder.Property(p => p.TotalCases)
                .HasColumnName("total_cases")
                .HasColumnType("int");

            builder.Property(p => p.TotalDeaths)
                .HasColumnName("total_deaths")
                .HasColumnType("int");

            builder.Property(p => p.TotalRecovered)
                .HasColumnName("total_recovered")
                .HasColumnType("int");
        }
    }
}
