using Microsoft.EntityFrameworkCore;
using TokenTestApi.Core.Domain.Models;

namespace TokenTestApi.Core.Infrastructure.Data
{
    public class TokenTestApiContext : DbContext
    {
        public TokenTestApiContext(DbContextOptions<TokenTestApiContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Token> Token { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(x => x.Id);
        }
    }
}