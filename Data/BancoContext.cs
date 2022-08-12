using ContactManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<ContatoModel> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContatoModel>()
                .HasIndex(p => new { p.Email, p.Contato })
                .IsUnique(true);
        }
    }
}
