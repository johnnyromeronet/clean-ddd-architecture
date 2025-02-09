using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.DDD.Architecture.Infrastructure.Context.Mappings
{
    [ExcludeFromCodeCoverage]
    public static class BaseEntityMapper
    {
        public static void Configure<T>(this EntityTypeBuilder<T> builder) where T : BaseEntity
        {
            builder.Property(x => x.Enabled).HasColumnName("Enabled");
            builder.Property(x => x.IUser).HasColumnName("IUser");
            builder.Property(x => x.IDate).HasColumnName("IDate");
            builder.Property(x => x.IComments).HasColumnName("IComments");
            builder.Property(x => x.UUser).HasColumnName("UUser");
            builder.Property(x => x.UDate).HasColumnName("UDate");
            builder.Property(x => x.UComments).HasColumnName("UComments");
        }
    }
}
