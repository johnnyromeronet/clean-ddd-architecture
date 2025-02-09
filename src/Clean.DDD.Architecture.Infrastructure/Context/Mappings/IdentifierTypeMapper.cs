using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.DDD.Architecture.Infrastructure.Context.Mappings
{
    [ExcludeFromCodeCoverage]
    public class IdentifierTypeMapper : IEntityTypeConfiguration<IdentifierType>
    {
        public void Configure(EntityTypeBuilder<IdentifierType> builder)
        {
            builder.ToTable("IdentifierType");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Description).HasColumnName("Description");
            builder.Configure();
        }
    }
}
