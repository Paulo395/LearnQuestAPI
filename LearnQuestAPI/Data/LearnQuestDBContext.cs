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
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<Seminario> Seminarios { get; set; }
        public DbSet<Pergunta> Perguntas {  get; set; }
        public DbSet<Resposta> Respostas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new MensagemMap());
            modelBuilder.ApplyConfiguration(new SeminarioMap());

            //Relacionamento Migratios
            modelBuilder.Entity<Pergunta>()
                .HasMany(p => p.Respostas)
                .WithOne(r => r.Pergunta)
                .HasForeignKey(r => r.PerguntaId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
