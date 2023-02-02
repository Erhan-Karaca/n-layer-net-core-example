using Firmabul.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firmabul.Repository.Seeds;

public class UserSeed : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User {Id = 1, Email = "erhankaraca@outlook.com.tr", FirstName = "Erhan", LastName = "Karaca"}    
        );
    }
}