using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.DDD.Architecture.Infrastructure.Context.Mappings
{
    [ExcludeFromCodeCoverage]
    public class UserKeyMapper : IEntityTypeConfiguration<UserKey>
    {
        public void Configure(EntityTypeBuilder<UserKey> builder)
        {
            builder.ToTable("UserKey");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserId).HasColumnName("UserId");
            builder.Property(x => x.PasswordHash).HasColumnName("PasswordHash");
            builder.HasOne(x => x.User).WithMany(x => x.UserKey).HasForeignKey(x => x.UserId);
            builder.Configure();
        }
    }
}
