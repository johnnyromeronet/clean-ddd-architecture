using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Clean.DDD.Architecture.Domain.Entities.Context;
using Clean.DDD.Architecture.Infrastructure.Registration;
using Microsoft.EntityFrameworkCore;

namespace Clean.DDD.Architecture.Infrastructure.Context
{
    [ExcludeFromCodeCoverage]
    public class CurrentDBContext : DbContext
    {
        public CurrentDBContext() { }

        public CurrentDBContext(DbContextOptions<CurrentDBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigManager.CurrentDatabase);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema(ConfigManager.SchemaDatabase);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Token> Token { get; set; }

        public DbSet<IdentifierType> IdentifierType { get; set; }

        public DbSet<Language> Language { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<UserRole> UserRole { get; set; }

        public DbSet<UserKey> UserKey { get; set; }
    }
}
