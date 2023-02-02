using Firmabul.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firmabul.Repository.Seeds;

public class CompanySeed : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasData(
            new Company {Id = 1, UserId = 1, Name = "Evishe", SectorId = 1, Description = "E-ticaret"},
            new Company {Id = 2, UserId = 1, Name = "Karaca Mobilya", SectorId = 2, Description = "Hizmet"}
        );
    }
}