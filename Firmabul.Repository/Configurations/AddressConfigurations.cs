using Firmabul.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firmabul.Repository.Configurations;

public class AddressConfigurations : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasOne(x => x.City).WithMany(x => x.Addresses).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.Country).WithMany(x => x.Addresses).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.Town).WithMany(x => x.Addresses).OnDelete(DeleteBehavior.NoAction);
    }
}