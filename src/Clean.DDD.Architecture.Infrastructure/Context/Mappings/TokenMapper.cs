using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.DDD.Architecture.Infrastructure.Context.Mappings
{
    [ExcludeFromCodeCoverage]
    public class TokenMapper : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.ToTable("Token");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.AccessToken).HasColumnName("AccessToken");
            builder.Property(x => x.Email).HasColumnName("Email");
            builder.Property(x => x.ExpiredDate).HasColumnName("ExpiredDate");
            builder.Property(x => x.IsRefreshToken).HasColumnName("IsRefreshToken");
            builder.Configure();
        }
    }
}
