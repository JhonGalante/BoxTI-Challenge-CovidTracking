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
                .HasColumnType("varchar(50)");

            builder.Property(p => p.LastUpdate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(p => p.ActiveCases)
                .HasColumnType("int");

            builder.Property(p => p.NewCases)
                .HasColumnType("int");

            builder.Property(p => p.NewDeaths)
                .HasColumnType("int");

            builder.Property(p => p.TotalCases)
                .HasColumnType("int");

            builder.Property(p => p.TotalDeaths)
                .HasColumnType("int");

            builder.Property(p => p.TotalRecovered)
                .HasColumnType("int");
        }
    }
}
