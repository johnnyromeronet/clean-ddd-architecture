using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.DDD.Architecture.Infrastructure.Context.Mappings
{
    [ExcludeFromCodeCoverage]
    public class UserRoleMapper : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");
            builder.HasKey(x => new { x.UserId, x.RoleId });
            builder.Ignore(x => x.Id);
            builder.Property(x => x.UserId).HasColumnName("UserId");
            builder.Property(x => x.RoleId).HasColumnName("RoleId");
            builder.HasOne(x => x.User).WithMany(x => x.UserRole).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Role).WithMany(x => x.UserRole).HasForeignKey(x => x.RoleId);
            builder.Configure();
        }
    }
}
