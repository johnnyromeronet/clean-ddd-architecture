using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.DDD.Architecture.Infrastructure.Context.Mappings
{
    [ExcludeFromCodeCoverage]
    public class UserMapper : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Surname).HasColumnName("Surname");
            builder.Property(x => x.SecondSurname).HasColumnName("SecondSurname");
            builder.Property(x => x.IdentifierTypeId).HasColumnName("IdentifierTypeId");
            builder.Property(x => x.Identifier).HasColumnName("Identifier");
            builder.Property(x => x.LanguageId).HasColumnName("LanguageId");
            builder.Property(x => x.PhoneNumber).HasColumnName("PhoneNumber");
            builder.Property(x => x.Email).HasColumnName("Email");
            builder.Property(x => x.PasswordHash).HasColumnName("PasswordHash");
            builder.Property(x => x.IsActive).HasColumnName("IsActive");
            builder.Property(x => x.IsSystem).HasColumnName("IsSystem");
            builder.HasMany(x => x.UserRole).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            builder.HasMany(x => x.UserKey).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.IdentifierType).WithMany().HasForeignKey(x => x.IdentifierTypeId);
            builder.HasOne(x => x.Language).WithMany().HasForeignKey(x => x.LanguageId);
            builder.Configure();
        }
    }
}
