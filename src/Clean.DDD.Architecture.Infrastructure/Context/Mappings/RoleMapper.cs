using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.DDD.Architecture.Domain.Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.DDD.Architecture.Infrastructure.Context.Mappings
{
    [ExcludeFromCodeCoverage]
    public class RoleMapper : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Description).HasColumnName("Description");
            builder.HasMany(x => x.UserRole).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);
            builder.Configure();
        }
    }
}
