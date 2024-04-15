using LearnQuestAPI.Data.Map;
using LearnQuestAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnQuestAPI.Data
{
    public class LearnQuestDBContext : DbContext
    {
        public LearnQuestDBContext(DbContextOptions<LearnQuestDBContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Mensagem> Mensagems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new MensagemMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
