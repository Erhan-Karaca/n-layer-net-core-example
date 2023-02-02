using Firmabul.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firmabul.Repository.Seeds;

public class SectorSeed : IEntityTypeConfiguration<Sector>
{
    public void Configure(EntityTypeBuilder<Sector> builder)
    {
        builder.HasData(
            new Sector {Id = 1, Name = "Bilişim", CreatedDate = DateTime.Now}, 
            new Sector {Id = 2, Name = "Güvenlik", CreatedDate = DateTime.Now}
        );
    }
}