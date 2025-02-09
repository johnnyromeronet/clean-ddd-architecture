using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.DDD.Architecture.Infrastructure.Context.Mappings
{
    [ExcludeFromCodeCoverage]
    public class LanguageMapper : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Language");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Description).HasColumnName("Description");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Code).HasColumnName("Code");
            builder.Configure();
        }
    }
}
